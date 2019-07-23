using ESRI.ArcGIS.ArcMapUI;
using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.Geodatabase;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace Iklim
{
    public partial class ucDeMartonneGottman : UserControl
    {
        public ucDeMartonneGottman()
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
                    IFeatureClass fclass = fLayer.FeatureClass;

                    LayerObject lObject = new LayerObject();
                    lObject.layer = layer;
                    lObject.Name = layer.Name;
                    LayerObjectList.Add(lObject);
                }
            }
            UpdateComboboxWithLayers(cmbInputLayer, LayerObjectList);
            UpdateComboboxWithLayers(cmbInputBorder, LayerObjectList);
        }

        private void UpdateComboboxWithLayers(ComboBox comboBox, List<LayerObject> layerObjectList)
        {
            comboBox.BindingContext = new BindingContext();
            comboBox.DataSource = null;
            comboBox.DataSource = layerObjectList;
            comboBox.DisplayMember = "Name";
            comboBox.SelectedIndex = -1;
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            AppSingleton.Instance().CreateWorkspacePath();
            if (AppSingleton.Instance().SettingsControl == null)
            {
                SettingsControl control = new SettingsControl();
                control.Load();
                control.CheckForm();
            }

            if (cmbInputLayer.SelectedIndex < 0)
            {
                MessageBox.Show("Öncelikle uygulama katmanını belirleyiniz.");
                return;
            }

            var clipLayer = AppSingleton.Instance().ClipLayers((cmbInputBorder.SelectedItem as LayerObject).layer, (cmbInputLayer.SelectedItem as LayerObject).layer);
            var layerName = Path.GetFileNameWithoutExtension(clipLayer);
            IFeatureClass clipClass = (AppSingleton.Instance().PersonalWorkspace as IFeatureWorkspace).OpenFeatureClass(layerName);
            
            var copiedfclass = CopyFeatureClass(clipClass);

            IFeatureClass fclass = (AppSingleton.Instance().PersonalWorkspace as IFeatureWorkspace).OpenFeatureClass("Copy");

            IQueryFilter queryFilter = new QueryFilterClass();
          
            AppSingleton.Instance().AddField(fclass, "KURAKLIK", "DOUBLE");
            AppSingleton.Instance().AddField(fclass, "IDMG", "DOUBLE");
            List<string> sicaklikList = new List<string>();
            FillSicaklikList(sicaklikList);
            List<string> yagisList = new List<string>();
            FillYagisList(yagisList);
            IFeatureCursor updateCursor = fclass.Search(queryFilter, false);
            IFeature feature = null;
            while ((feature = updateCursor.NextFeature()) != null)
            {
                double kuraklik = 0.0;
                for (int i = 0; i < sicaklikList.Count; i++)
                {
                    var sic = sicaklikList[i];
                    var yag = yagisList[i];

                    var sicIndex = feature.Fields.FindField(sic);
                    var yagIndex = feature.Fields.FindField(yag);

                    var t = Convert.ToDouble(feature.get_Value(sicIndex));
                    var p = Convert.ToDouble(feature.get_Value(yagIndex));
                    var kurak = (12 * p) / t + 10;
                    if (kuraklik == 0.0)
                    {
                        kuraklik = kurak;
                    }
                    else if (kurak < kuraklik)
                    {
                        kuraklik = kurak;
                    }
                }
                var kuraklikIndex = feature.Fields.FindField("KURAKLIK");
                feature.set_Value(kuraklikIndex, kuraklik);

                var topYagField = feature.Fields.FindField(cmbYillikTopYag.SelectedItem.ToString());
                var P = Convert.ToDouble(feature.get_Value(topYagField));

                var ortSicField = feature.Fields.FindField(cmbYillikOrtSic.SelectedItem.ToString());
                double T = Convert.ToDouble(feature.get_Value(ortSicField));

                var idmg = 0.5 * ((P / (T + 10)) + kuraklik);
                var idmgIndex = feature.Fields.FindField("IDMG");
                feature.set_Value(idmgIndex, idmg);

                feature.Store();
            }

            var idwLayer = AppSingleton.Instance().IDW(fclass, "IDMG","IDW");
            var intLayer = Int(idwLayer, "GOTTMANN");
            var table = AppSingleton.Instance().BuildRasterAttributeTable("GOTTMANN");
            AppSingleton.Instance().AddField(table, "IKLIMTIPI", "TEXT");
            int idmField = table.FindField("VALUE");
            int ozellikField = table.FindField("IKLIMTIPI");
            IQueryFilter queryFilter2 = new QueryFilterClass();
            ICursor updateCursor2 = table.Search(queryFilter, false);
            IRow row = null;

            while ((row = updateCursor2.NextRow()) != null)
            {
                string ozellik = string.Empty;
                double idmVal = Convert.ToDouble(row.get_Value(idmField));
                if (idmVal < 0)
                {
                    ozellik = "Kutupsal";
                }
                else if (idmVal >= 0 && idmVal < 5)
                {
                    ozellik = "Çöl";
                }
                else if (idmVal >= 5 && idmVal < 10)
                {
                    ozellik = "Step - Yarı Kurak";
                }
                else if (idmVal >= 10 && idmVal < 20)
                {
                    ozellik = "Step - Nemli Arası";
                }
                else if (idmVal >= 20 && idmVal < 28)
                {
                    ozellik = "Yarı Nemli";
                }
                else if (idmVal >= 28 && idmVal < 35)
                {
                    ozellik = "Nemli";
                }
                else if (idmVal >= 35 && idmVal < 55)
                {
                    ozellik = "Çok Nemli";
                }
                else
                {
                    ozellik = "Islak";
                }
                row.set_Value(ozellikField, ozellik);
                row.Store();
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
        private void FillSicaklikList(List<string> sicaklikList)
        {
            try
            {
                sicaklikList.Add(cmbAylikSicOcak.SelectedItem.ToString());
                sicaklikList.Add(cmbAylikSicSubat.SelectedItem.ToString());
                sicaklikList.Add(cmbAylikSicMart.SelectedItem.ToString());
                sicaklikList.Add(cmbAylikSicNisan.SelectedItem.ToString());
                sicaklikList.Add(cmbAylikSicMayis.SelectedItem.ToString());
                sicaklikList.Add(cmbAylikSicHaziran.SelectedItem.ToString());
                sicaklikList.Add(cmbAylikSicTemmuz.SelectedItem.ToString());
                sicaklikList.Add(cmbAylikSicAgustos.SelectedItem.ToString());
                sicaklikList.Add(cmbAylikSicEylul.SelectedItem.ToString());
                sicaklikList.Add(cmbAylikSicEkim.SelectedItem.ToString());
                sicaklikList.Add(cmbAylikSicKasim.SelectedItem.ToString());
                sicaklikList.Add(cmbAylikSicAralik.SelectedItem.ToString());
            }
            catch (Exception)
            {
            }

        }

        private void FillYagisList(List<string> yagisList)
        {
            try
            {
                yagisList.Add(cmbAylikYagOcak.SelectedItem.ToString());
                yagisList.Add(cmbAylikYagSubat.SelectedItem.ToString());
                yagisList.Add(cmbAylikYagMart.SelectedItem.ToString());
                yagisList.Add(cmbAylikYagNisan.SelectedItem.ToString());
                yagisList.Add(cmbAylikYagMayis.SelectedItem.ToString());
                yagisList.Add(cmbAylikYagHaziran.SelectedItem.ToString());
                yagisList.Add(cmbAylikYagTemmuz.SelectedItem.ToString());
                yagisList.Add(cmbAylikYagAgustos.SelectedItem.ToString());
                yagisList.Add(cmbAylikYagEylul.SelectedItem.ToString());
                yagisList.Add(cmbAylikYagEkim.SelectedItem.ToString());
                yagisList.Add(cmbAylikYagKasim.SelectedItem.ToString());
                yagisList.Add(cmbAylikYagAralik.SelectedItem.ToString());
            }
            catch (Exception)
            {
            }
        }

    private string CopyFeatureClass(object featureClass)
        {
            try
            {
                ESRI.ArcGIS.Geoprocessor.Geoprocessor gp = new ESRI.ArcGIS.Geoprocessor.Geoprocessor();
                ESRI.ArcGIS.DataManagementTools.CopyFeatures copyFeatures = new ESRI.ArcGIS.DataManagementTools.CopyFeatures();
                copyFeatures.in_features = featureClass;
                copyFeatures.out_feature_class = AppSingleton.Instance().WorkspacePath + "\\" + "Copy";
                gp.AddOutputsToMap = true;
                gp.OverwriteOutput = true;
                gp.Execute(copyFeatures, null);
                return copyFeatures.out_feature_class.ToString();
            }
            catch (Exception ex)
            {
                return string.Empty;
            }
        }

        private void cmbInputLayer_SelectedIndexChanged(object sender, EventArgs e)
        {
            LayerObject layerObject = (LayerObject)cmbInputLayer.SelectedItem;
            if (layerObject != null)
            {
                List<string> fieldList = new List<string>();
                IFeatureLayer fLayer = layerObject.layer as IFeatureLayer;
                for (int j = 0; j < fLayer.FeatureClass.Fields.FieldCount; j++)
                {
                    IField field = fLayer.FeatureClass.Fields.get_Field(j);
                    fieldList.Add(field.Name);
                }
                //Sıcaklık Comboları
                FillCmboboboxWithFieldList(cmbYillikOrtSic, fieldList);
                FillCmboboboxWithFieldList(cmbAylikSicOcak, fieldList);
                FillCmboboboxWithFieldList(cmbAylikSicSubat, fieldList);
                FillCmboboboxWithFieldList(cmbAylikSicMart, fieldList);
                FillCmboboboxWithFieldList(cmbAylikSicNisan, fieldList);
                FillCmboboboxWithFieldList(cmbAylikSicMayis, fieldList);
                FillCmboboboxWithFieldList(cmbAylikSicHaziran, fieldList);
                FillCmboboboxWithFieldList(cmbAylikSicTemmuz, fieldList);
                FillCmboboboxWithFieldList(cmbAylikSicAgustos, fieldList);
                FillCmboboboxWithFieldList(cmbAylikSicEylul, fieldList);
                FillCmboboboxWithFieldList(cmbAylikSicEkim, fieldList);
                FillCmboboboxWithFieldList(cmbAylikSicKasim, fieldList);
                FillCmboboboxWithFieldList(cmbAylikSicAralik, fieldList);
                //Yağış Comboları
                FillCmboboboxWithFieldList(cmbYillikTopYag, fieldList);
                FillCmboboboxWithFieldList(cmbAylikYagOcak, fieldList);
                FillCmboboboxWithFieldList(cmbAylikYagSubat, fieldList);
                FillCmboboboxWithFieldList(cmbAylikYagMart, fieldList);
                FillCmboboboxWithFieldList(cmbAylikYagNisan, fieldList);
                FillCmboboboxWithFieldList(cmbAylikYagMayis, fieldList);
                FillCmboboboxWithFieldList(cmbAylikYagHaziran, fieldList);
                FillCmboboboxWithFieldList(cmbAylikYagTemmuz, fieldList);
                FillCmboboboxWithFieldList(cmbAylikYagAgustos, fieldList);
                FillCmboboboxWithFieldList(cmbAylikYagEylul, fieldList);
                FillCmboboboxWithFieldList(cmbAylikYagEkim, fieldList);
                FillCmboboboxWithFieldList(cmbAylikYagKasim, fieldList);
                FillCmboboboxWithFieldList(cmbAylikYagAralik, fieldList);
            }
        }

        private void FillCmboboboxWithFieldList(ComboBox comboBox, List<string> fieldList)
        {
            comboBox.BindingContext = new BindingContext();
            comboBox.DataSource = null;
            comboBox.DataSource = fieldList;
            comboBox.SelectedIndex = -1;
        }
    }
}