using ESRI.ArcGIS.ArcMapUI;
using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.esriSystem;
using ESRI.ArcGIS.Geodatabase;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Iklim
{
    public partial class UcErinc : UserControl
    {
        public UcErinc()
        {
            InitializeComponent();
        }

        public void Init()
        {
            IMxDocument mxDocument = AppSingleton.Instance().MxDocument;
            IMap map = mxDocument.FocusMap;
            int layerCount = map.LayerCount;
            List<LayerObject> LayerObjectList = new List<LayerObject>();
            for (int i = 0; i < layerCount; i++)
            {
                ILayer layer = map.get_Layer(i);
                IFeatureLayer fLayer = layer as IFeatureLayer;
                if (fLayer != null)
                {
                    IFeatureClass fClass = fLayer.FeatureClass;

                    LayerObject lObject = new LayerObject();
                    lObject.layer = layer;
                    lObject.Name = layer.Name;
                    LayerObjectList.Add(lObject);
                }
            }
            UpdateComboboxWithLayers(cmbCalismaAlani, LayerObjectList);
            UpdateComboboxWithLayers(cmbVeriSeti, LayerObjectList);
        }

        private void UpdateComboboxWithLayers(ComboBox comboBox, List<LayerObject> layerObjectList)
        {
            comboBox.BindingContext = new BindingContext();
            comboBox.DataSource = null;
            comboBox.DataSource = layerObjectList;
            comboBox.DisplayMember = "Name";
            comboBox.SelectedIndex = -1;
        }

        private void cmbVeriSeti_SelectedIndexChanged(object sender, EventArgs e)
        {
            LayerObject layerObject = (LayerObject)cmbVeriSeti.SelectedItem;
            if (layerObject != null)
            {
                List<string> fieldList = new List<string>();
                IFeatureLayer fLayer = layerObject.layer as IFeatureLayer;
                for (int j = 0; j < fLayer.FeatureClass.Fields.FieldCount; j++)
                {
                    IField field = fLayer.FeatureClass.Fields.get_Field(j);
                    fieldList.Add(field.Name);
                }

                FillCmboboboxWithFieldList(cmbOrtSic, fieldList);
                FillCmboboboxWithFieldList(cmbOrtYag, fieldList);
            }
            else
            {
                cmbOrtSic.DataSource = null;
                cmbOrtYag.DataSource = null;
            }
        }

        private void FillCmboboboxWithFieldList(ComboBox comboBox, List<string> fieldList)
        {
            comboBox.BindingContext = new BindingContext();
            comboBox.DataSource = null;
            comboBox.DataSource = fieldList;
            comboBox.SelectedIndex = -1;
        }    

        private string Kriging(ILayer selectedLayer, string FieldName)
        {
            try
            {
                ESRI.ArcGIS.SpatialAnalystTools.Kriging kriging = new ESRI.ArcGIS.SpatialAnalystTools.Kriging();
                kriging.cell_size = AppSingleton.Instance().CellSize;
                kriging.out_surface_raster = AppSingleton.Instance().WorkspacePath + "\\" + selectedLayer.Name + "_Kriging_" + FieldName;
                kriging.in_point_features = selectedLayer;
                kriging.z_field = FieldName;
                kriging.semiVariogram_props = AppSingleton.Instance().KrigingSemiVariogram + " " + AppSingleton.Instance().KrigingLagSayisi;
                kriging.search_radius = AppSingleton.Instance().KrigingYaricap;

                ESRI.ArcGIS.Geoprocessor.Geoprocessor gp = new ESRI.ArcGIS.Geoprocessor.Geoprocessor();

                gp.AddOutputsToMap = AppSingleton.Instance().AralariEkle;
                gp.OverwriteOutput = true;
                gp.Execute(kriging, null);
                return kriging.out_surface_raster.ToString();
            }
            catch (Exception ex)
            {
                return string.Empty;
            }
        }

        private string IDW(ILayer selectedLayer, string FieldName)
        {
            try
            {
                ESRI.ArcGIS.SpatialAnalystTools.Idw idw = new ESRI.ArcGIS.SpatialAnalystTools.Idw();
                idw.cell_size = AppSingleton.Instance().CellSize;
                idw.out_raster = AppSingleton.Instance().WorkspacePath + "\\" + selectedLayer.Name + "_IDW_" + FieldName;
                idw.in_point_features = selectedLayer;
                idw.z_field = FieldName;
                idw.power = 3;
                idw.search_radius = AppSingleton.Instance().IDWYaricap;
                ESRI.ArcGIS.Geoprocessor.Geoprocessor gp = new ESRI.ArcGIS.Geoprocessor.Geoprocessor();
                gp.AddOutputsToMap = AppSingleton.Instance().AralariEkle;
                gp.OverwriteOutput = true;
                gp.Execute(idw, null);
                return idw.out_raster.ToString();
            }
            catch (Exception ex)
            {
                return string.Empty;
            }
        }

        private string Divide(string yagisLayer, string sicaklikLayer)
        {
            try
            {
                ESRI.ArcGIS.SpatialAnalystTools.Divide divide = new ESRI.ArcGIS.SpatialAnalystTools.Divide();
                divide.in_raster_or_constant1 = yagisLayer;
                divide.in_raster_or_constant2 = sicaklikLayer;
                divide.out_raster = AppSingleton.Instance().WorkspacePath + "\\" + "sonucLayer";
                ESRI.ArcGIS.Geoprocessor.Geoprocessor gp = new ESRI.ArcGIS.Geoprocessor.Geoprocessor();
                gp.AddOutputsToMap = true;
                gp.OverwriteOutput = true;
                gp.Execute(divide, null);
                return divide.out_raster.ToString();
            }
            catch (Exception ex)
            {
                return string.Empty;
            }
        }

        private bool Reclassify(string selectedLayer)
        {
            try
            {
                ESRI.ArcGIS.Geoprocessor.Geoprocessor gp = new ESRI.ArcGIS.Geoprocessor.Geoprocessor();
                ESRI.ArcGIS.SpatialAnalystTools.Reclassify reclass = new ESRI.ArcGIS.SpatialAnalystTools.Reclassify();
                reclass.in_raster = selectedLayer;//RingBuffered_
                reclass.reclass_field = "Value";
                reclass.out_raster = AppSingleton.Instance().WorkspacePath + "\\Reclassifiedlayer";
                reclass.remap = "0 8 1;8 15 2;15 23 3;23 40 4;40 55 5;55 10000 6;NODATA 0";
                gp.AddOutputsToMap = true;
                gp.OverwriteOutput = true;
                gp.Execute(reclass, null);

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public string Int(string layerName, string outName)
        {
            try
            {
                ESRI.ArcGIS.SpatialAnalystTools.Int intRaster = new ESRI.ArcGIS.SpatialAnalystTools.Int();
                intRaster.in_raster_or_constant = layerName;
                intRaster.out_raster = AppSingleton.Instance().WorkspacePath + "\\" + outName;
                ESRI.ArcGIS.Geoprocessor.Geoprocessor gp = new ESRI.ArcGIS.Geoprocessor.Geoprocessor();
                gp.AddOutputsToMap = true;
                gp.OverwriteOutput = true;
                gp.Execute(intRaster, null);
                return intRaster.out_raster.ToString();
            }
            catch (Exception ex)
            {
                return string.Empty;
            }
        }

        private void btnOk_Click(object sender, EventArgs e)
        {

            if (cmbVeriSeti.SelectedIndex < 0)
            {
                MessageBox.Show("Uygulama katmanı belirlenmeden işlem yapılamaz.");
                return;
            }
            if (cmbCalismaAlani.SelectedIndex < 0)
            {
                MessageBox.Show("Proje sınırı belirlenmeden işlem yapılamaz.");
                return;
            }
            if (cmbOrtSic.SelectedIndex < 0)
            {
                MessageBox.Show("Yıllık Ortalama Sıcaklık değeri belirlenmeden işlem yapılamaz.");
                return;
            }
            if (cmbOrtYag.SelectedIndex < 0)
            {
                MessageBox.Show("Yıllık Toplam Yağış değeri belirlenmeden işlem yapılamaz.");
                return;
            }
            AppSingleton.Instance().CreateWorkspacePath();
            if (AppSingleton.Instance().SettingsControl == null)
            {
                SettingsControl control = new SettingsControl();
                control.Load();
                control.CheckForm();
            }
            tpSonuc.Visible = true;
            tpSonuc.VisualMode = ProgressBarDisplayMode.TextAndPercentage;
            tpSonuc.CustomText = "Uygulama Katmanı kesiliyor...";
            tpSonuc.Maximum = 19;
            tpSonuc.Step = 1;
            tpSonuc.PerformStep();
            var clipLayer = AppSingleton.Instance().ClipLayers((cmbCalismaAlani.SelectedItem as LayerObject).layer, (cmbVeriSeti.SelectedItem as LayerObject).layer);
            tpSonuc.CustomText = "Yağış katmanı oluşturuluyor...";
            tpSonuc.PerformStep();
            var yagisLayer = AppSingleton.Instance().IDW(clipLayer, cmbOrtYag.SelectedItem.ToString(),"yagisLayer");
            tpSonuc.CustomText = "Sıcaklık katmanı oluşturuluyor...";
            tpSonuc.PerformStep();
            var sicaklikLayer = AppSingleton.Instance().IDW(clipLayer, cmbOrtSic.SelectedItem.ToString(),"sicaklikLayer");
            tpSonuc.CustomText = "Siniflandirma_Erinc katmanı oluşturuluyor...";
            tpSonuc.PerformStep();
            var sonucRaster = Divide(yagisLayer, sicaklikLayer);
            Int(sonucRaster, "Siniflandirma_Erinc");
            var vat = AppSingleton.Instance().BuildRasterAttributeTable("Siniflandirma_Erinc");

            tpSonuc.CustomText = "Veriler ekleniyor...";
            tpSonuc.PerformStep();
            AppSingleton.Instance().AddField(vat, "IKLIMTIPI", "TEXT");
            IQueryFilter queryFilter = new QueryFilterClass();
            ICursor updateCursor = vat.Search(queryFilter, false);
            IRow feature = null;
            int idmField = vat.FindField("VALUE");
            int ozellikField = vat.FindField("IKLIMTIPI");
            while ((feature = updateCursor.NextRow()) != null)
            {
                var ozellik = string.Empty;
                var Ieye = Convert.ToInt32(feature.get_Value(idmField));
                if (Ieye < 8)
                {
                    ozellik = "Tam Kurak";
                }
                else if (8 <= Ieye & Ieye < 15)
                {
                    ozellik = "Kurak";
                }
                else if (15 <= Ieye & Ieye < 23)
                {
                    ozellik = "Yarı Kurak";
                }
                else if (23 <= Ieye & Ieye < 40)
                {
                    ozellik = "Yarı Nemli";
                }
                else if (40 <= Ieye & Ieye < 55)
                {
                    ozellik = "Nemli";
                }
                else
                {
                    ozellik = "Çok Nemli";
                }
                feature.set_Value(ozellikField, ozellik);
                feature.Store();
            }
            tpSonuc.CustomText = "İşlem tamamlandı...";
            tpSonuc.PerformStep();
            (this.Parent as Form).Close();
        }
    }
}