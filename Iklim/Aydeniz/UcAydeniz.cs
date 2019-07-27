using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ESRI.ArcGIS.ArcMapUI;
using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.Geodatabase;
using System.IO;
using ESRI.ArcGIS.DataSourcesRaster;

namespace Iklim
{
    public partial class ucAydeniz : UserControl
    {
        public ucAydeniz()
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
            UpdateComboboxWithLayers(cmbUygulamaKatmani, LayerObjectList);
            UpdateComboboxWithLayers(cmbProjectArea, LayerObjectList);
        }

        private void UpdateComboboxWithLayers(ComboBox comboBox, List<LayerObject> layerObjectList)
        {
            comboBox.BindingContext = new BindingContext();
            comboBox.DataSource = null;
            comboBox.DataSource = layerObjectList;
            comboBox.DisplayMember = "Name";
            comboBox.SelectedIndex = -1;
        }
        private void cmbUygulamaKatmani_SelectedIndexChanged(object sender, EventArgs e)
        {
            LayerObject layerObject = (LayerObject)cmbUygulamaKatmani.SelectedItem;
            if (layerObject != null)
            {
                List<string> fieldList = new List<string>();
                IFeatureLayer fLayer = layerObject.layer as IFeatureLayer;
                for (int j = 0; j < fLayer.FeatureClass.Fields.FieldCount; j++)
                {
                    IField field = fLayer.FeatureClass.Fields.get_Field(j);
                    fieldList.Add(field.Name);
                }

                FillCmboboboxWithFieldList(cmbNn, fieldList);
                FillCmboboboxWithFieldList(cmbS, fieldList);
                FillCmboboboxWithFieldList(cmbY, fieldList);
                FillCmboboboxWithFieldList(cmbGs, fieldList);
            }
        }

        private void FillCmboboboxWithFieldList(ComboBox comboBox, List<string> fieldList)
        {
            comboBox.BindingContext = new BindingContext();
            comboBox.DataSource = null;
            comboBox.DataSource = fieldList;
            comboBox.SelectedIndex = -1;
        }

        private void CalculateNpYillik(string layerName) {
            IFeatureClass fclass = (AppSingleton.Instance().PersonalWorkspace as IFeatureWorkspace).OpenFeatureClass(layerName);

            //var copiedfclass = CopyFeatureClass(clipClass);

            //IFeatureClass fclass = (AppSingleton.Instance().PersonalWorkspace as IFeatureWorkspace).OpenFeatureClass("Copy");

            IQueryFilter queryFilter = new QueryFilterClass();

            AppSingleton.Instance().AddField(fclass, "npYillik", "DOUBLE");

            IFeatureCursor updateCursor = fclass.Search(queryFilter, false);
            IFeature feature = null;
            var npField = fclass.Fields.FindField("npYillik");
            while ((feature = updateCursor.NextFeature()) != null)
            {
                var counter = 0;
                var ocaTmp = Convert.ToDouble(feature.get_Value(feature.Fields.FindField("ocaTmp")));
                var subTmp = Convert.ToDouble(feature.get_Value(feature.Fields.FindField("subTmp")));
                var marTmp = Convert.ToDouble(feature.get_Value(feature.Fields.FindField("marTmp")));
                var nisTmp = Convert.ToDouble(feature.get_Value(feature.Fields.FindField("nisTmp")));
                var mayTmp = Convert.ToDouble(feature.get_Value(feature.Fields.FindField("mayTmp")));
                var hazTmp = Convert.ToDouble(feature.get_Value(feature.Fields.FindField("hazTmp")));
                var temTmp = Convert.ToDouble(feature.get_Value(feature.Fields.FindField("temTmp")));
                var aguTmp = Convert.ToDouble(feature.get_Value(feature.Fields.FindField("aguTmp")));
                var eylTmp = Convert.ToDouble(feature.get_Value(feature.Fields.FindField("eylTmp")));
                var ekiTmp = Convert.ToDouble(feature.get_Value(feature.Fields.FindField("ekiTmp")));
                var kasTmp = Convert.ToDouble(feature.get_Value(feature.Fields.FindField("kasTmp")));
                var araTmp = Convert.ToDouble(feature.get_Value(feature.Fields.FindField("araTmp")));
               

                var ocaRain = Convert.ToDouble(feature.get_Value(feature.Fields.FindField("ocaRain")));
                var subRain = Convert.ToDouble(feature.get_Value(feature.Fields.FindField("subRain")));
                var marRain = Convert.ToDouble(feature.get_Value(feature.Fields.FindField("marRain")));
                var nisRain = Convert.ToDouble(feature.get_Value(feature.Fields.FindField("nisRain")));
                var mayRain = Convert.ToDouble(feature.get_Value(feature.Fields.FindField("mayRain")));
                var hazRain = Convert.ToDouble(feature.get_Value(feature.Fields.FindField("hazRain")));
                var temRain = Convert.ToDouble(feature.get_Value(feature.Fields.FindField("temRain")));
                var aguRain = Convert.ToDouble(feature.get_Value(feature.Fields.FindField("aguRain")));
                var eylRain = Convert.ToDouble(feature.get_Value(feature.Fields.FindField("eylRain")));
                var ekiRain = Convert.ToDouble(feature.get_Value(feature.Fields.FindField("ekiRain")));
                var kasRain = Convert.ToDouble(feature.get_Value(feature.Fields.FindField("kasRain")));
                var araRain = Convert.ToDouble(feature.get_Value(feature.Fields.FindField("araRain")));

                var ocaNispNem = Convert.ToDouble(feature.get_Value(feature.Fields.FindField("ocaNispNem")));
                var subNispNem = Convert.ToDouble(feature.get_Value(feature.Fields.FindField("subNispNem")));
                var marNispNem = Convert.ToDouble(feature.get_Value(feature.Fields.FindField("marNispNem")));
                var nisNispNem = Convert.ToDouble(feature.get_Value(feature.Fields.FindField("nisNispNem")));
                var mayNispNem = Convert.ToDouble(feature.get_Value(feature.Fields.FindField("mayNispNem")));
                var hazNispNem = Convert.ToDouble(feature.get_Value(feature.Fields.FindField("hazNispNem")));
                var temNispNem = Convert.ToDouble(feature.get_Value(feature.Fields.FindField("temNispNem")));
                var aguNispNem = Convert.ToDouble(feature.get_Value(feature.Fields.FindField("aguNispNem")));
                var eylNispNem = Convert.ToDouble(feature.get_Value(feature.Fields.FindField("eylNispNem")));
                var ekiNispNem = Convert.ToDouble(feature.get_Value(feature.Fields.FindField("ekiNispNem")));
                var kasNispNem = Convert.ToDouble(feature.get_Value(feature.Fields.FindField("kasNispNem")));
                var araNispNem = Convert.ToDouble(feature.get_Value(feature.Fields.FindField("araNispNem")));

                var ocaguneSur = Convert.ToDouble(feature.get_Value(feature.Fields.FindField("ocaguneSur")));
                var subguneSur = Convert.ToDouble(feature.get_Value(feature.Fields.FindField("subguneSur")));
                var marguneSur = Convert.ToDouble(feature.get_Value(feature.Fields.FindField("marguneSur")));
                var nisguneSur = Convert.ToDouble(feature.get_Value(feature.Fields.FindField("nisguneSur")));
                var mayguneSur = Convert.ToDouble(feature.get_Value(feature.Fields.FindField("mayguneSur")));
                var hazguneSur = Convert.ToDouble(feature.get_Value(feature.Fields.FindField("hazguneSur")));
                var temguneSur = Convert.ToDouble(feature.get_Value(feature.Fields.FindField("temguneSur")));
                var aguguneSur = Convert.ToDouble(feature.get_Value(feature.Fields.FindField("aguguneSur")));
                var eylguneSur = Convert.ToDouble(feature.get_Value(feature.Fields.FindField("eylguneSur")));
                var ekiguneSur = Convert.ToDouble(feature.get_Value(feature.Fields.FindField("ekiguneSur")));
                var kasguneSur = Convert.ToDouble(feature.get_Value(feature.Fields.FindField("kasguneSur")));
                var araguneSur = Convert.ToDouble(feature.get_Value(feature.Fields.FindField("araguneSur")));

                var ocaNp = (ocaRain * ocaNispNem * 12) / ((ocaTmp*ocaguneSur) + 15);
                if(ocaNp>0.4)
                {
                    counter++;
                }
                var subNp = (subRain * subNispNem * 12) / ((subTmp * subguneSur) + 15);
                if (subNp > 0.4)
                {
                    counter++;
                }
                var marNp = (marRain * marNispNem * 12) / ((marTmp * marguneSur) + 15);
                if (marNp > 0.4)
                {
                    counter++;
                }
                var nisNp = (nisRain * nisNispNem * 12) / ((nisTmp * nisguneSur) + 15);
                if (nisNp > 0.4)
                {
                    counter++;
                }
                var mayNp = (mayRain * mayNispNem * 12) / ((mayTmp * mayguneSur) + 15);
                if (mayNp > 0.4)
                {
                    counter++;
                }
                var hazNp = (hazRain * hazNispNem * 12) / ((hazTmp * hazguneSur) + 15);
                if (hazNp > 0.4)
                {
                    counter++;
                }
                var temNp = (temRain * temNispNem * 12) / ((temTmp * temguneSur) + 15);
                if (temNp > 0.4)
                {
                    counter++;
                }
                var aguNp = (aguRain * aguNispNem * 12) / ((aguTmp * aguguneSur) + 15);
                if (aguNp > 0.4)
                {
                    counter++;
                }
                var eylNp = (eylRain * eylNispNem * 12) / ((eylTmp * eylguneSur) + 15);
                if (eylNp > 0.4)
                {
                    counter++;
                }
                var ekiNp = (ekiRain * ekiNispNem * 12) / ((ekiTmp * ekiguneSur) + 15);
                if (ekiNp > 0.4)
                {
                    counter++;
                }
                var kasNp = (kasRain * kasNispNem * 12) / ((kasTmp * kasguneSur) + 15);
                if (kasNp > 0.4)
                {
                    counter++;
                }
                var araNp = (araRain * araNispNem * 12) / ((araTmp * araguneSur) + 15);
                if (araNp > 0.4)
                {
                    counter++;
                }
                double val = Convert.ToDouble(counter) / Convert.ToDouble(12);
                feature.set_Value(npField, val);
                feature.Store();
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

        private void btnOk_Click(object sender, EventArgs e)
        {

            if (cmbUygulamaKatmani.SelectedIndex < 0)
            {
                MessageBox.Show("Uygulama katmanı belirlenmeden işlem yapılamaz.");
                return;
            }
            if (cmbProjectArea.SelectedIndex < 0)
            {
                MessageBox.Show("Proje sınırı belirlenmeden işlem yapılamaz.");
                return;
            }
            if (cmbNn.SelectedIndex < 0)
            {
                MessageBox.Show("Nn değeri belirlenmeden işlem yapılamaz.");
                return;
            }
            if (cmbGs.SelectedIndex < 0)
            {
                MessageBox.Show("Gs değeri belirlenmeden işlem yapılamaz.");
                return;
            }

            if (cmbY.SelectedIndex < 0)
            {
                MessageBox.Show("Y değeri belirlenmeden işlem yapılamaz.");
                return;
            }

            if (cmbS.SelectedIndex < 0)
            {
                MessageBox.Show("S değeri belirlenmeden işlem yapılamaz.");
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
            tpSonuc.Maximum = 13;
            tpSonuc.Step = 1;
             tpSonuc.PerformStep();
            var clipLayer = AppSingleton.Instance().ClipLayers((cmbProjectArea.SelectedItem as LayerObject).layer, (cmbUygulamaKatmani.SelectedItem as LayerObject).layer);

            if (rbYillik.Checked)
            {
                var clipLayerName = Path.GetFileNameWithoutExtension(clipLayer);
                CalculateNpYillik(clipLayerName);
            }

            string nN = string.Empty;
            string nP = string.Empty;
            string Y = string.Empty;
            string S = string.Empty;
            string gS = string.Empty;
            //if (AppSingleton.Instance().UygulamaYontemi == "IDW")
            //{
             tpSonuc.CustomText = "nN Katmanı oluşturuluyor...";
              tpSonuc.PerformStep();
            nN = AppSingleton.Instance().IDW(clipLayer, cmbNn.SelectedItem.ToString(), "nN");
            tpSonuc.CustomText = "nP Katmanı oluşturuluyor...";
              tpSonuc.PerformStep();
            if (rbYillik.Checked)
            {
                nP = AppSingleton.Instance().IDW(clipLayer, "npYillik", "npYillik");
            }
            tpSonuc.CustomText = "Y Katmanı oluşturuluyor...";
              tpSonuc.PerformStep();
            Y = AppSingleton.Instance().IDW(clipLayer, cmbY.SelectedItem.ToString(), "Y");
            tpSonuc.CustomText = "S Katmanı oluşturuluyor...";
              tpSonuc.PerformStep();
            S = AppSingleton.Instance().IDW(clipLayer, cmbS.SelectedItem.ToString(), "S");
            tpSonuc.CustomText = "gS Katmanı oluşturuluyor...";
              tpSonuc.PerformStep();
            gS = AppSingleton.Instance().IDW(clipLayer, cmbGs.SelectedItem.ToString(), "gS");
            //}
            //else if (AppSingleton.Instance().UygulamaYontemi == "KRIGING")
            //{
            //    nN = AppSingleton.Instance().Kriging((cmbUygulamaKatmani.SelectedItem as LayerObject).layer, cmbNn.SelectedItem.ToString());
            //    nP = AppSingleton.Instance().Kriging((cmbUygulamaKatmani.SelectedItem as LayerObject).layer, cmbNp.SelectedItem.ToString());
            //    Y = AppSingleton.Instance().Kriging((cmbUygulamaKatmani.SelectedItem as LayerObject).layer, cmbY.SelectedItem.ToString());
            //    S = AppSingleton.Instance().Kriging((cmbUygulamaKatmani.SelectedItem as LayerObject).layer, cmbS.SelectedItem.ToString());
            //    gS = AppSingleton.Instance().Kriging((cmbUygulamaKatmani.SelectedItem as LayerObject).layer, cmbGs.SelectedItem.ToString());
            //}

            tpSonuc.CustomText = "nKS Katmanı oluşturuluyor...";
             tpSonuc.PerformStep();
            if(rbAylik.Checked)
            {
                nP = "12";
            }
            string nKS = RasterCalculatorNKS(nN, nP, Y, S, gS);
            tpSonuc.CustomText = "kKS Katmanı oluşturuluyor...";
             tpSonuc.PerformStep();
            string kKS = RasterCalculatorKKS(nKS);

            var nksStr = "0 0.400000 1;0.400000 0.670000 2;0.670000 1 3;1 1.330000 4;1.330000 2 5;2 4 6;4 100000 7;NODATA 0";
            var kksStr = "0 0.250000 7;0.250000 0.500000 6;0.500000 0.750000 5;0.750000 1 4;1 1.500000 3;1.500000 2.500000 2;2.500000 100000 1;NODATA 0";
            tpSonuc.CustomText = "nKS Katmanı sınıflandırılıyor...";
             tpSonuc.PerformStep();
            var rNKS = Reclassify(Path.GetFileNameWithoutExtension(nKS), "Value", nksStr, "R_");
            tpSonuc.CustomText = "kKS Katmanı sınıflandırılıyor...";
             tpSonuc.PerformStep();
            var rKKS = Reclassify(Path.GetFileNameWithoutExtension(kKS), "Value", kksStr, "R_");
            tpSonuc.CustomText = "Katmanlar birleştiriliyor...";
             tpSonuc.PerformStep();
            string combine = Combine(rNKS + ";" + rKKS);
            tpSonuc.CustomText = "Veriler ekleniyor...";
             tpSonuc.PerformStep();
            Type factoryType = Type.GetTypeFromProgID(
            "esriDataSourcesGDB.AccessWorkspaceFactory");

            IWorkspaceFactory workspaceFactory = (IWorkspaceFactory)Activator.CreateInstance
                (factoryType);
            IRasterWorkspaceEx rasterWorkspaceEx = workspaceFactory.OpenFromFile(AppSingleton.Instance().WorkspacePath, 0) as IRasterWorkspaceEx;
            IRasterDataset rasterDataset = rasterWorkspaceEx.OpenRasterDataset("Siniflandirma_Aydeniz");
            IRasterDatasetEdit2 raster = (IRasterDatasetEdit2)rasterDataset;

            ESRI.ArcGIS.Geodatabase.IGeoDataset geoDataset = (ESRI.ArcGIS.Geodatabase.IGeoDataset)rasterDataset;
            raster.BuildAttributeTable();
            ITable vat = (raster as IRasterBandCollection).Item(0).AttributeTable;
            AddField(vat, "SONUC", "TEXT");

            IQueryFilter queryFilter = new QueryFilterClass();
            ICursor updateCursor = vat.Search(queryFilter, false);
            IRow feature = null;

            while ((feature = updateCursor.NextRow()) != null)
            {
                int kksField = feature.Fields.FindField("R_kks");
                int nksField = feature.Fields.FindField("R_nks");
                int sonucField = feature.Fields.FindField("SONUC");
                string sonucValue = string.Empty;
                int nksValue = Convert.ToInt32(feature.get_Value(nksField));
                int kksValue = Convert.ToInt32(feature.get_Value(nksField));

                if (nksValue != kksValue)
                {
                    sonucValue = "Diğer";
                }
                else if (nksValue == 1)
                {
                    sonucValue = "Çöl";
                }
                else if (nksValue == 2)
                {
                    sonucValue = "Çok Kurak";
                }
                else if (nksValue == 3)
                {
                    sonucValue = "Kurak";
                }

                else if (nksValue == 4)
                {
                    sonucValue = "Yarı Kurak";
                }
                else if (nksValue == 5)
                {
                    sonucValue = "Yarı Nemli";
                }
                else if (nksValue == 6)
                {
                    sonucValue = "Nemli";
                }
                else if (nksValue == 7)
                {
                    sonucValue = "Çok Nemli (Islak)";
                }
                else if (nksValue == 0)
                {
                    sonucValue = "Diğer";
                }

                feature.set_Value(sonucField, sonucValue);
                feature.Store();
            }
            tpSonuc.CustomText = "İşlem tamamlandı...";
            tpSonuc.PerformStep();
            (this.Parent as Form).Close();
        }

        private string Combine(string layerNames)
        {
            try
            {
                ESRI.ArcGIS.Geoprocessor.Geoprocessor gp = new ESRI.ArcGIS.Geoprocessor.Geoprocessor();
                ESRI.ArcGIS.SpatialAnalystTools.Combine combine = new ESRI.ArcGIS.SpatialAnalystTools.Combine();
                combine.in_rasters = layerNames;
                combine.out_raster = AppSingleton.Instance().WorkspacePath + "\\" + "Siniflandirma_Aydeniz";
                gp.AddOutputsToMap = true;
                gp.OverwriteOutput = true;
                gp.Execute(combine, null);
                return combine.out_raster.ToString();
            }
            catch (Exception ex)
            {
                return string.Empty;
            }
        }
        private bool AddField(object table, string fieldName, string type)
        {
            try
            {
                ESRI.ArcGIS.Geoprocessor.Geoprocessor gp = new ESRI.ArcGIS.Geoprocessor.Geoprocessor();
                ESRI.ArcGIS.DataManagementTools.AddField addField = new ESRI.ArcGIS.DataManagementTools.AddField();
                addField.in_table = table;
                addField.field_name = fieldName;
                addField.field_type = type;
                addField.field_is_nullable = "NULLABLE";
                addField.field_is_required = "NON_REQUIRED";

                gp.AddOutputsToMap = AppSingleton.Instance().AralariEkle;
                gp.OverwriteOutput = true;
                gp.Execute(addField, null);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public string Reclassify(string layerName, string FieldName, string reclassMap, string outputType)
        {
            try
            {

                ESRI.ArcGIS.Geoprocessor.Geoprocessor gp = new ESRI.ArcGIS.Geoprocessor.Geoprocessor();
                ESRI.ArcGIS.Analyst3DTools.Reclassify reclass = new ESRI.ArcGIS.Analyst3DTools.Reclassify();
                reclass.in_raster = AppSingleton.Instance().WorkspacePath + "\\" + layerName;//RingBuffered_
                reclass.reclass_field = FieldName;//"Value";
                reclass.out_raster = AppSingleton.Instance().WorkspacePath + "\\" + outputType + layerName;//Reclassified_
                reclass.remap = reclassMap;// "50 1;50 100 2;100 150 3;NODATA 0";


                gp.AddOutputsToMap = AppSingleton.Instance().AralariEkle;
                gp.OverwriteOutput = true;
                gp.Execute(reclass, null);
                return reclass.out_raster.ToString();
            }
            catch (Exception ex)
            {
                return string.Empty;
            }
        }
    

    public string RasterCalculatorNKS(string nN,string nP,string Y, string S, string gS)
        {
            try
            {
                ESRI.ArcGIS.SpatialAnalystTools.RasterCalculator rasterCalculator= new ESRI.ArcGIS.SpatialAnalystTools.RasterCalculator();
                if (nP == "12")
                {
                     rasterCalculator.expression = "('" + Y + "' * '" + nN + "' * 12) / ('" + S + "' * '" + gS + "' + 15 )" ;
                }
                else
                {
                    rasterCalculator.expression = "('" + Y + "' * '" + nN + "' * '" + nP + "') / ('" + S + "' * '" + gS + "' + 15)";
                }
                ESRI.ArcGIS.Geoprocessor.Geoprocessor gp = new ESRI.ArcGIS.Geoprocessor.Geoprocessor();
                rasterCalculator.output_raster = AppSingleton.Instance().WorkspacePath + "\\nks";
                gp.AddOutputsToMap = AppSingleton.Instance().AralariEkle;
                gp.OverwriteOutput = true;
                gp.Execute(rasterCalculator, null);
                return rasterCalculator.output_raster.ToString();
            }
            catch (Exception ex)
            {
                return string.Empty;
            }
        }
        public string RasterCalculatorKKS(string nKS)
        {
            try
            {
                ESRI.ArcGIS.SpatialAnalystTools.RasterCalculator rasterCalculator = new ESRI.ArcGIS.SpatialAnalystTools.RasterCalculator();
                rasterCalculator.expression = "1 / '" +nKS + "'";
                ESRI.ArcGIS.Geoprocessor.Geoprocessor gp = new ESRI.ArcGIS.Geoprocessor.Geoprocessor();
                rasterCalculator.output_raster = AppSingleton.Instance().WorkspacePath + "\\kks";
                gp.AddOutputsToMap = AppSingleton.Instance().AralariEkle;
                gp.OverwriteOutput = true;
                gp.Execute(rasterCalculator, null);
                return rasterCalculator.output_raster.ToString();
            }
            catch (Exception ex)
            {
                return string.Empty;
            }
        }

       
    }
}
