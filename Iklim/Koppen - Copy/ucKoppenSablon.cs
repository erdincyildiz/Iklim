using ESRI.ArcGIS.ArcMapUI;
using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.DataSourcesRaster;
using ESRI.ArcGIS.Geodatabase;
using ESRI.ArcGIS.Geometry;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Iklim
{
    public partial class ucKoppenSablon : UserControl
    {
        public ucKoppenSablon()
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
            }
        }

        private void FillCmboboboxWithFieldList(ComboBox comboBox, List<string> fieldList)
        {
            comboBox.BindingContext = new BindingContext();
            comboBox.DataSource = null;
            comboBox.DataSource = fieldList;
            comboBox.SelectedIndex = -1;
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            
            if (cmbInputLayer.SelectedIndex < 0)
            {
                MessageBox.Show("Uygulama katmanı belirlenmeden işlem yapılamaz.");
                return;
            }
            if (cmbInputBorder.SelectedIndex < 0)
            {
                MessageBox.Show("Proje sınırı belirlenmeden işlem yapılamaz.");
                return;
            }
            if (cmbYillikOrtSic.SelectedIndex < 0)
            {
                MessageBox.Show("Yıllık Ortalama Sıcaklık değeri belirlenmeden işlem yapılamaz.");
                return;
            }
            if (cmbYillikTopYag.SelectedIndex < 0)
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

            
            var clipLayer = AppSingleton.Instance().ClipLayers((cmbInputBorder.SelectedItem as LayerObject).layer, (cmbInputLayer.SelectedItem as LayerObject).layer);
            var layerName = System.IO.Path.GetFileNameWithoutExtension(clipLayer);
            IFeatureClass clipClass = (AppSingleton.Instance().PersonalWorkspace as IFeatureWorkspace).OpenFeatureClass(layerName);

            var copiedfclass = CopyFeatureClass(clipClass);

            IFeatureClass fclass = (AppSingleton.Instance().PersonalWorkspace as IFeatureWorkspace).OpenFeatureClass("Copy");

            IQueryFilter queryFilter = new QueryFilterClass();
            IFeatureCursor updateCursor = fclass.Search(queryFilter, false);
            IFeature feature = null;

            while ((feature = updateCursor.NextFeature()) != null)
            {
                MultiplyFeatureValue(feature);
            }
            var layer = (cmbInputLayer.SelectedItem as LayerObject).layer;


            //var YilOrtSic = IDW(fclass, cmbYillikOrtSic.SelectedItem.ToString(), "YilOrtSic");
            //var AySicOcak = IDW(fclass, cmbAylikSicOcak.SelectedItem.ToString(), "AySicOca");
            //var AySicSubat = IDW(fclass, cmbAylikSicSubat.SelectedItem.ToString(), "AySicSub");
            //var AySicMart = IDW(fclass, cmbAylikSicMart.SelectedItem.ToString(), "AySicMar");
            //var AySicNisan = IDW(fclass, cmbAylikSicNisan.SelectedItem.ToString(), "AySicNis");
            //var AySicMayis = IDW(fclass, cmbAylikSicMayis.SelectedItem.ToString(), "AySicMay");
            //var AySicHaziran = IDW(fclass, cmbAylikSicHaziran.SelectedItem.ToString(), "AySicHaz");
            //var AySicTemmuz = IDW(fclass, cmbAylikSicTemmuz.SelectedItem.ToString(), "AySicTem");
            //var AySicAgustos = IDW(fclass, cmbAylikSicAgustos.SelectedItem.ToString(), "AySicAgu");
            //var AySicEylul = IDW(fclass, cmbAylikSicEylul.SelectedItem.ToString(), "AySicEyl");
            //var AySicEkim = IDW(fclass, cmbAylikSicEkim.SelectedItem.ToString(), "AySicEki");
            //var AySicKasim = IDW(fclass, cmbAylikSicKasim.SelectedItem.ToString(), "AySicKas");
            //var AySicAralik = IDW(fclass, cmbAylikSicAralik.SelectedItem.ToString(), "AySicAra");

            //string layerNames = YilOrtSic + ";" + AySicOcak + ";" + AySicSubat + ";" + AySicMart
            //    + ";" + AySicNisan + ";" + AySicMayis + ";" + AySicHaziran + ";" + AySicTemmuz
            //    + ";" + AySicAgustos + ";" + AySicEylul + ";" + AySicEkim + ";" + AySicKasim + ";" + AySicAralik;
            //var combine1 = Combine(layerNames, "CombineSic");
            //var YilTopYag = IDW(fclass, cmbYillikTopYag.SelectedItem.ToString(), "YilTopYag");
            //var AyYagOcak = IDW(fclass, cmbAylikYagOcak.SelectedItem.ToString(), "AyYagOca");
            //var AyYagSubat = IDW(fclass, cmbAylikYagSubat.SelectedItem.ToString(), "AyYagSub");
            //var AyYagMart = IDW(fclass, cmbAylikYagMart.SelectedItem.ToString(), "AyYagMar");
            //var AyYagNisan = IDW(fclass, cmbAylikYagNisan.SelectedItem.ToString(), "AyYagNis");
            //var AyYagMayis = IDW(fclass, cmbAylikYagMayis.SelectedItem.ToString(), "AyYagMay");
            //var AyYagHaziran = IDW(fclass, cmbAylikYagHaziran.SelectedItem.ToString(), "AyYagHaz");
            //var AyYagTemmuz = IDW(fclass, cmbAylikYagTemmuz.SelectedItem.ToString(), "AyYagTem");
            //var AyYagAgustos = IDW(fclass, cmbAylikYagAgustos.SelectedItem.ToString(), "AyYagAgu");
            //var AyYagEylul = IDW(fclass, cmbAylikYagEylul.SelectedItem.ToString(), "AyYagEyl");
            //var AyYagEkim = IDW(fclass, cmbAylikYagEkim.SelectedItem.ToString(), "AyYagEki");
            //var AyYagKasim = IDW(fclass, cmbAylikYagKasim.SelectedItem.ToString(), "AyYagKas");
            //var AyYagAralik = IDW(fclass, cmbAylikYagAralik.SelectedItem.ToString(), "AyYagAra");

            //string layerNames2 = YilTopYag + ";" + AyYagOcak + ";" + AyYagSubat + ";" + AyYagMart
            //    + ";" + AyYagNisan + ";" + AyYagMayis + ";" + AyYagHaziran + ";" + AyYagTemmuz
            //    + ";" + AyYagAgustos + ";" + AyYagEylul + ";" + AyYagEkim + ";" + AyYagKasim + ";" + AyYagAralik;
            //var combine2 = Combine(layerNames2, "CombineYag");
            //Combine(combine1 + ";" + combine2, "FinalCombined");
            //FindIklimForValues();
        }

        private void FindIklimForValues()
        {
            ITable vatRaster = BuildRasterAttributeTable("FinalCombined");
            ITable vatYag = BuildRasterAttributeTable("CombineYag");
            ITable vatSic = BuildRasterAttributeTable("CombineSic");
            AddField(vatRaster, "IKLIMTURU", "TEXT");

            IQueryFilter queryFilter = new QueryFilterClass();
            ICursor updateCursor = vatRaster.Search(queryFilter, false);
            IRow feature = null;

            int yagField = vatRaster.FindField("CombineYag");
            int sicField = vatRaster.FindField("CombineSic");
            while ((feature = updateCursor.NextRow()) != null)
            {

                IQueryFilter queryFilterSic = new QueryFilterClass();
                queryFilterSic.WhereClause = "Value  = " + feature.get_Value(sicField);
                ICursor updateCursorSic = vatSic.Search(queryFilterSic, false);
                IRow rowSic = updateCursorSic.NextRow();

                Sicaklik sicaklik = new Sicaklik();
                sicaklik.YilOrtSic = Convert.ToDouble(rowSic.get_Value(rowSic.Fields.FindField("YilOrtSic")));
                sicaklik.AySicOca = Convert.ToDouble(rowSic.get_Value(rowSic.Fields.FindField("AySicOca")));
                sicaklik.AySicSub = Convert.ToDouble(rowSic.get_Value(rowSic.Fields.FindField("AySicSub")));
                sicaklik.AySicMar = Convert.ToDouble(rowSic.get_Value(rowSic.Fields.FindField("AySicMar")));
                sicaklik.AySicNis = Convert.ToDouble(rowSic.get_Value(rowSic.Fields.FindField("AySicNis")));
                sicaklik.AySicMay = Convert.ToDouble(rowSic.get_Value(rowSic.Fields.FindField("AySicMay")));
                sicaklik.AySicHaz = Convert.ToDouble(rowSic.get_Value(rowSic.Fields.FindField("AySicHaz")));
                sicaklik.AySicTem = Convert.ToDouble(rowSic.get_Value(rowSic.Fields.FindField("AySicTem")));
                sicaklik.AySicAgu = Convert.ToDouble(rowSic.get_Value(rowSic.Fields.FindField("AySicAgu")));
                sicaklik.AySicEyl = Convert.ToDouble(rowSic.get_Value(rowSic.Fields.FindField("AySicEyl")));
                sicaklik.AySicEki = Convert.ToDouble(rowSic.get_Value(rowSic.Fields.FindField("AySicEki")));
                sicaklik.AySicKas = Convert.ToDouble(rowSic.get_Value(rowSic.Fields.FindField("AySicKas")));
                sicaklik.AySicAra = Convert.ToDouble(rowSic.get_Value(rowSic.Fields.FindField("AySicAra")));


                IQueryFilter queryFilterYag = new QueryFilterClass();
                queryFilterYag.WhereClause = "Value  = " + feature.get_Value(yagField);
                ICursor updateCursorYag = vatYag.Search(queryFilterYag, false);
                IRow rowYag = updateCursorYag.NextRow();

                Yagis yagis = new Yagis();
                yagis.YilTopYag = Convert.ToDouble(rowYag.get_Value(rowYag.Fields.FindField("YilTopYag")));
                yagis.AyYagOca = Convert.ToDouble(rowYag.get_Value(rowYag.Fields.FindField("AyYagOca")));
                yagis.AyYagSub = Convert.ToDouble(rowYag.get_Value(rowYag.Fields.FindField("AyYagSub")));
                yagis.AyYagMar = Convert.ToDouble(rowYag.get_Value(rowYag.Fields.FindField("AyYagMar")));
                yagis.AyYagNis = Convert.ToDouble(rowYag.get_Value(rowYag.Fields.FindField("AyYagNis")));
                yagis.AyYagMay = Convert.ToDouble(rowYag.get_Value(rowYag.Fields.FindField("AyYagMay")));
                yagis.AyYagHaz = Convert.ToDouble(rowYag.get_Value(rowYag.Fields.FindField("AyYagHaz")));
                yagis.AyYagTem = Convert.ToDouble(rowYag.get_Value(rowYag.Fields.FindField("AyYagTem")));
                yagis.AyYagAgu = Convert.ToDouble(rowYag.get_Value(rowYag.Fields.FindField("AyYagAgu")));
                yagis.AyYagEyl = Convert.ToDouble(rowYag.get_Value(rowYag.Fields.FindField("AyYagEyl")));
                yagis.AyYagEki = Convert.ToDouble(rowYag.get_Value(rowYag.Fields.FindField("AyYagEki")));
                yagis.AyYagKas = Convert.ToDouble(rowYag.get_Value(rowYag.Fields.FindField("AyYagKas")));
                yagis.AyYagAra = Convert.ToDouble(rowYag.get_Value(rowYag.Fields.FindField("AyYagAra")));

                var yazYagis = yagis.AyYagNis + yagis.AyYagMay + yagis.AyYagHaz + yagis.AyYagTem + yagis.AyYagAgu + yagis.AyYagEyl;
                var kisYagis = yagis.AyYagEki + yagis.AyYagKas + yagis.AyYagAra + yagis.AyYagOca + yagis.AyYagSub + yagis.AyYagMar;
                var topYagis = yazYagis + kisYagis;
                var T = sicaklik.YilOrtSic;
                List<double> sicaklikListesi = new List<double>();
                sicaklikListesi.Add(sicaklik.AySicOca);
                sicaklikListesi.Add(sicaklik.AySicSub);
                sicaklikListesi.Add(sicaklik.AySicMar);
                sicaklikListesi.Add(sicaklik.AySicNis);
                sicaklikListesi.Add(sicaklik.AySicMay);
                sicaklikListesi.Add(sicaklik.AySicHaz);
                sicaklikListesi.Add(sicaklik.AySicTem);
                sicaklikListesi.Add(sicaklik.AySicAgu);
                sicaklikListesi.Add(sicaklik.AySicEyl);
                sicaklikListesi.Add(sicaklik.AySicEki);
                sicaklikListesi.Add(sicaklik.AySicKas);
                sicaklikListesi.Add(sicaklik.AySicAra);
                sicaklikListesi.Sort();
                double TSoguk = sicaklikListesi[0];
                double TSicak = sicaklikListesi[sicaklikListesi.Count - 1];
                var P = yagis.YilTopYag;
                double r = 0.0;

                List<double> yazYagisList = new List<double>();
                List<double> kisYagisList = new List<double>();

                kisYagisList.Add(yagis.AyYagEki);
                kisYagisList.Add(yagis.AyYagKas);
                kisYagisList.Add(yagis.AyYagAra);
                kisYagisList.Add(yagis.AyYagOca);
                kisYagisList.Add(yagis.AyYagSub);
                kisYagisList.Add(yagis.AyYagMar);

                yazYagisList.Add(yagis.AyYagNis);
                yazYagisList.Add(yagis.AyYagMay);
                yazYagisList.Add(yagis.AyYagHaz);
                yazYagisList.Add(yagis.AyYagTem);
                yazYagisList.Add(yagis.AyYagAgu);
                yazYagisList.Add(yagis.AyYagEyl);

                kisYagisList.Sort();
                yazYagisList.Sort();


                List<double> Pm = new List<double>();
                Pm.AddRange(kisYagisList);
                Pm.AddRange(yazYagisList);
                Pm.Sort();
                var carpan = 10000;
                var PsMin = yazYagisList[0];
                var PsMax = yazYagisList[yazYagisList.Count - 1];

                var PwMin = kisYagisList[0];
                var PwMax = kisYagisList[kisYagisList.Count - 1];

                if (kisYagis > topYagis * 0.7)
                {
                    r = 20 * T;
                }
                else if (yazYagis > topYagis * 0.7)
                {
                    r = 20 * T + 280 * carpan;
                }
                else
                {
                    r = 20 * T + 140 * carpan;
                }
                string IklimTuru = string.Empty;
                if (TSicak >= 10 * carpan)
                {
                    if (TSoguk >= 18 * carpan)
                    {
                        if (Pm[0] > 60 * carpan)
                        {
                            IklimTuru = "Af";
                        }
                        else if (Pm[0] < 60 * carpan)
                        {
                            if (Pm[0] > (100 * carpan) - (P / 25))
                            {
                                IklimTuru = "Am";
                            }
                            else if (Pm[0] < (100 * carpan) - (P / 25))
                            {
                                IklimTuru = "Aw";
                            }
                        }
                    }
                    else if (TSoguk < 18 * carpan)
                    {
                        if (P < r)
                        {
                            if ((P >= r / 2) && (r > P))
                            {
                                if (T >= 18 * carpan)
                                {
                                    IklimTuru = "BSh";
                                }
                                else if (T < 18 * carpan)
                                {
                                    IklimTuru = "BSk";
                                }
                            }
                            else if (P < r / 2)
                            {
                                if (T >= 18 * carpan)
                                {
                                    IklimTuru = "BWh";
                                }
                                else if (T < 18 * carpan)
                                {
                                    IklimTuru = "BWk";
                                }
                            }
                        }
                        else if (P >= r)
                        {
                            if ((TSoguk > -3 * carpan) && (TSoguk < 18 * carpan))
                            {
                                if ((PsMin < PwMin) && (PwMax > 3 * PsMin) && (PsMin < 40 * carpan))
                                {
                                    if (TSicak >= 22 * carpan)
                                    {
                                        IklimTuru = "Csa";
                                    }
                                    else if (TSicak < 22 * carpan)
                                    {
                                        if ((sicaklikListesi[11] > 10 * carpan) && (sicaklikListesi[10] > 10 * carpan) && (sicaklikListesi[9] > 10 * carpan) && (sicaklikListesi[8] > 10 * carpan))
                                        {
                                            IklimTuru = "Csb";
                                        }
                                        else 
                                        {
                                            IklimTuru = "Csc";
                                        }
                                    }
                                }
                                else if ((PsMin > PwMin) && (PsMax > 10 * PwMin))
                                {
                                    if (TSicak >= 22 * carpan)
                                    {
                                        IklimTuru = "Cwa";
                                    }
                                    else if (TSicak < 22 * carpan)
                                    {
                                        if ((sicaklikListesi[11] > 10 * carpan) && (sicaklikListesi[10] > 10 * carpan) && (sicaklikListesi[9] > 10 * carpan) && (sicaklikListesi[8] > 10 * carpan))
                                        {
                                            IklimTuru = "Cwb";
                                        }
                                        else
                                        {
                                            IklimTuru = "Cwc";
                                        }
                                    }
                                }
                                else
                                {
                                    if (TSicak >= 22 * carpan)
                                    {
                                        IklimTuru = "Cfa";
                                    }
                                    else if (TSicak < 22 * carpan)
                                    {
                                         if ((sicaklikListesi[11] > 10 * carpan) && (sicaklikListesi[10] > 10 * carpan) && (sicaklikListesi[9] > 10 * carpan) && (sicaklikListesi[8] > 10 * carpan))
                                        {
                                            IklimTuru = "Cfb";
                                        }
                                        else
                                        {
                                            IklimTuru = "Cfc";
                                        }
                                    }
                                }
                            }
                            else if (TSoguk <= -3 * carpan)
                            {
                                if ((PsMin < PwMin) && (PwMax > 3 * PsMin) && (PsMin < 40 * carpan))
                                {
                                    if (TSicak >= 22 * carpan)
                                    {
                                        IklimTuru = "Dsa";
                                    }
                                    else if (TSicak < 22 * carpan)
                                    {
                                        if ((sicaklikListesi[11] > 10 * carpan) && (sicaklikListesi[10] > 10 * carpan) && (sicaklikListesi[9] > 10 * carpan) && (sicaklikListesi[8] > 10 * carpan))
                                        {
                                            IklimTuru = "Dsb";
                                        }
                                        else
                                        {
                                            if (TSoguk >= -38 * carpan)
                                            {
                                                IklimTuru = "Dsc";
                                            }
                                            else if (TSoguk < -38 * carpan)
                                            {
                                                IklimTuru = "Dsd";
                                            }
                                        }
                                    }
                                }
                                else if ((PsMin > PwMin) && (PsMax > 10 * PwMin))
                                {
                                    if (TSicak >= 22 * carpan)
                                    {
                                        IklimTuru = "Dwa";
                                    }
                                    else if (TSicak < 22 * carpan)
                                    {
                                         if ((sicaklikListesi[11] > 10 * carpan) && (sicaklikListesi[10] > 10 * carpan) && (sicaklikListesi[9] > 10 * carpan) && (sicaklikListesi[8] > 10 * carpan))
                                        {
                                            IklimTuru = "Dwb";
                                        }
                                        else 
                                        {
                                            if (TSoguk >= -38 * carpan)
                                            {
                                                IklimTuru = "Dwc";
                                            }
                                            else if (TSoguk < -38 * carpan)
                                            {
                                                IklimTuru = "Dwd";
                                            }
                                        }
                                    }
                                }
                                else
                                {
                                    if (TSicak >= 22 * carpan)
                                    {
                                        IklimTuru = "Dfa";
                                    }
                                    else if (TSicak < 22 * carpan)
                                    {
                                         if ((sicaklikListesi[11] > 10 * carpan) && (sicaklikListesi[10] > 10 * carpan) && (sicaklikListesi[9] > 10 * carpan) && (sicaklikListesi[8] > 10 * carpan)){
                                            IklimTuru = "Dfb";
                                        }
                                        else 
                                        {
                                            if (TSoguk >= -38 * carpan)
                                            {
                                                IklimTuru = "Dfc";
                                            }
                                            else if (TSoguk < -38 * carpan)
                                            {
                                                IklimTuru = "Dfd";
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
                else if (TSicak < 10 * carpan)
                {
                    if (TSicak > 0)
                    {
                        IklimTuru = "ET";
                    }
                    else if (TSicak <= 0)
                    {
                        IklimTuru = "EF";
                    }
                }

                feature.set_Value(feature.Fields.FindField("IKLIMTURU"), IklimTuru);
                feature.Store();
            }
        }

        private ITable BuildRasterAttributeTable(string rasterName)
        {
            Type factoryType = Type.GetTypeFromProgID(
                "esriDataSourcesGDB.AccessWorkspaceFactory");
            IWorkspaceFactory workspaceFactory = (IWorkspaceFactory)Activator.CreateInstance
               (factoryType);
            IRasterWorkspaceEx rasterWorkspaceEx = workspaceFactory.OpenFromFile(AppSingleton.Instance().WorkspacePath, 0) as IRasterWorkspaceEx;
            IRasterDataset rasterDataset = rasterWorkspaceEx.OpenRasterDataset(rasterName);
            IRasterDatasetEdit2 raster = (IRasterDatasetEdit2)rasterDataset;

            ESRI.ArcGIS.Geodatabase.IGeoDataset geoDataset = (ESRI.ArcGIS.Geodatabase.IGeoDataset)rasterDataset;
            raster.BuildAttributeTable();
            ITable vat = (raster as IRasterBandCollection).Item(0).AttributeTable;
            return vat;

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
        private void MultiplyFeatureValue(IFeature feature)
        {
            ////Sicaklik Fields
            //int yillikOrtSicField = feature.Fields.FindField(cmbYillikOrtSic.SelectedItem.ToString());
            //var yillikOrtSicValue = Convert.ToDouble(feature.get_Value(yillikOrtSicField)) * 10000;
            //int aylikSicOcakField = feature.Fields.FindField(cmbAylikSicOcak.SelectedItem.ToString());
            //var aylikSicOcakValue = Convert.ToDouble(feature.get_Value(aylikSicOcakField)) * 10000;
            //int aylikSicSubatField = feature.Fields.FindField(cmbAylikSicSubat.SelectedItem.ToString());
            //var aylikSicSubatValue = Convert.ToDouble(feature.get_Value(aylikSicSubatField)) * 10000;
            //int aylikSicMartField = feature.Fields.FindField(cmbAylikSicMart.SelectedItem.ToString());
            //var aylikSicMartValue = Convert.ToDouble(feature.get_Value(aylikSicMartField)) * 10000;
            //int aylikSicNisanField = feature.Fields.FindField(cmbAylikSicNisan.SelectedItem.ToString());
            //var aylikSicNisanValue = Convert.ToDouble(feature.get_Value(aylikSicNisanField)) * 10000;
            //int aylikSicMayisField = feature.Fields.FindField(cmbAylikSicMayis.SelectedItem.ToString());
            //var aylikSicMayisValue = Convert.ToDouble(feature.get_Value(aylikSicMayisField)) * 10000;
            //int aylikSicHaziranField = feature.Fields.FindField(cmbAylikSicHaziran.SelectedItem.ToString());
            //var aylikSicHaziranValue = Convert.ToDouble(feature.get_Value(aylikSicHaziranField)) * 10000;
            //int aylikSicTemmuzField = feature.Fields.FindField(cmbAylikSicTemmuz.SelectedItem.ToString());
            //var aylikSicTemmuzValue = Convert.ToDouble(feature.get_Value(aylikSicTemmuzField)) * 10000;
            //int aylikSicAgustosField = feature.Fields.FindField(cmbAylikSicAgustos.SelectedItem.ToString());
            //var aylikSicAgustosValue = Convert.ToDouble(feature.get_Value(aylikSicAgustosField)) * 10000;
            //int aylikSicEylulField = feature.Fields.FindField(cmbAylikSicEylul.SelectedItem.ToString());
            //var aylikSicEylulValue = Convert.ToDouble(feature.get_Value(aylikSicEylulField)) * 10000;
            //int aylikSicEkimField = feature.Fields.FindField(cmbAylikSicEkim.SelectedItem.ToString());
            //var aylikSicEkimValue = Convert.ToDouble(feature.get_Value(aylikSicEkimField)) * 10000;
            //int aylikSicKasimField = feature.Fields.FindField(cmbAylikSicKasim.SelectedItem.ToString());
            //var aylikSicKasimValue = Convert.ToDouble(feature.get_Value(aylikSicKasimField)) * 10000;
            //int aylikSicAralikField = feature.Fields.FindField(cmbAylikSicAralik.SelectedItem.ToString());
            //var aylikSicAralikValue = Convert.ToDouble(feature.get_Value(aylikSicAralikField)) * 10000;

            ////Yagis Fields
            //int yillikTopYagField = feature.Fields.FindField(cmbYillikTopYag.SelectedItem.ToString());
            //var yillikTopYagValue = Convert.ToDouble(feature.get_Value(yillikTopYagField)) * 10000;
            //int aylikYagOcakField = feature.Fields.FindField(cmbAylikYagOcak.SelectedItem.ToString());
            //var aylikYagOcakValue = Convert.ToDouble(feature.get_Value(aylikYagOcakField)) * 10000;
            //int aylikYagSubatField = feature.Fields.FindField(cmbAylikYagSubat.SelectedItem.ToString());
            //var aylikYagSubatValue = Convert.ToDouble(feature.get_Value(aylikYagSubatField)) * 10000;
            //int aylikYagMartField = feature.Fields.FindField(cmbAylikYagMart.SelectedItem.ToString());
            //var aylikYagMartValue = Convert.ToDouble(feature.get_Value(aylikYagMartField)) * 10000;
            //int aylikYagNisanField = feature.Fields.FindField(cmbAylikYagNisan.SelectedItem.ToString());
            //var aylikYagNisanValue = Convert.ToDouble(feature.get_Value(aylikYagNisanField)) * 10000;
            //int aylikYagMayisField = feature.Fields.FindField(cmbAylikYagMayis.SelectedItem.ToString());
            //var aylikYagMayisValue = Convert.ToDouble(feature.get_Value(aylikYagMayisField)) * 10000;
            //int aylikYagHaziranField = feature.Fields.FindField(cmbAylikYagHaziran.SelectedItem.ToString());
            //var aylikYagHaziranValue = Convert.ToDouble(feature.get_Value(aylikYagHaziranField)) * 10000;
            //int aylikYagTemmuzField = feature.Fields.FindField(cmbAylikYagTemmuz.SelectedItem.ToString());
            //var aylikYagTemmuzValue = Convert.ToDouble(feature.get_Value(aylikYagTemmuzField)) * 10000;
            //int aylikYagAgustosField = feature.Fields.FindField(cmbAylikYagAgustos.SelectedItem.ToString());
            //var aylikYagAgustosValue = Convert.ToDouble(feature.get_Value(aylikYagAgustosField)) * 10000;
            //int aylikYagEylulField = feature.Fields.FindField(cmbAylikYagEylul.SelectedItem.ToString());
            //var aylikYagEylulValue = Convert.ToDouble(feature.get_Value(aylikYagEylulField)) * 10000;
            //int aylikYagEkimField = feature.Fields.FindField(cmbAylikYagEkim.SelectedItem.ToString());
            //var aylikYagEkimValue = Convert.ToDouble(feature.get_Value(aylikYagEkimField)) * 10000;
            //int aylikYagKasimField = feature.Fields.FindField(cmbAylikYagKasim.SelectedItem.ToString());
            //var aylikYagKasimValue = Convert.ToDouble(feature.get_Value(aylikYagKasimField)) * 10000;
            //int aylikYagAralikField = feature.Fields.FindField(cmbAylikYagAralik.SelectedItem.ToString());
            //var aylikYagAralikValue = Convert.ToDouble(feature.get_Value(aylikYagAralikField)) * 10000;

            //feature.set_Value(yillikOrtSicField, yillikOrtSicValue);
            //feature.set_Value(aylikSicOcakField, aylikSicOcakValue);
            //feature.set_Value(aylikSicSubatField, aylikSicSubatValue);
            //feature.set_Value(aylikSicMartField, aylikSicMartValue);
            //feature.set_Value(aylikSicNisanField, aylikSicNisanValue);
            //feature.set_Value(aylikSicMayisField, aylikSicMayisValue);
            //feature.set_Value(aylikSicHaziranField, aylikSicHaziranValue);
            //feature.set_Value(aylikSicTemmuzField, aylikSicTemmuzValue);
            //feature.set_Value(aylikSicAgustosField, aylikSicAgustosValue);
            //feature.set_Value(aylikSicEylulField, aylikSicEylulValue);
            //feature.set_Value(aylikSicEkimField, aylikSicEkimValue);
            //feature.set_Value(aylikSicKasimField, aylikSicKasimValue);
            //feature.set_Value(aylikSicAralikField, aylikSicAralikValue);
            //feature.set_Value(yillikTopYagField, yillikTopYagValue);
            //feature.set_Value(aylikYagOcakField, aylikYagOcakValue);
            //feature.set_Value(aylikYagSubatField, aylikYagSubatValue);
            //feature.set_Value(aylikYagMartField, aylikYagMartValue);
            //feature.set_Value(aylikYagNisanField, aylikYagNisanValue);
            //feature.set_Value(aylikYagMayisField, aylikYagMayisValue);
            //feature.set_Value(aylikYagHaziranField, aylikYagHaziranValue);
            //feature.set_Value(aylikYagTemmuzField, aylikYagTemmuzValue);
            //feature.set_Value(aylikYagAgustosField, aylikYagAgustosValue);
            //feature.set_Value(aylikYagEylulField, aylikYagEylulValue);
            //feature.set_Value(aylikYagEkimField, aylikYagEkimValue);
            //feature.set_Value(aylikYagKasimField, aylikYagKasimValue);
            //feature.set_Value(aylikYagAralikField, aylikYagAralikValue);
            //feature.Store();
        }
        public string IDW(object fclass, string FieldName,string outLayerName)
        {
            try
            {
                ESRI.ArcGIS.SpatialAnalystTools.Idw idw = new ESRI.ArcGIS.SpatialAnalystTools.Idw();
                idw.cell_size = AppSingleton.Instance().CellSize;
                idw.out_raster = AppSingleton.Instance().WorkspacePath + "\\" + outLayerName;
                idw.in_point_features = fclass;
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

        private string Combine(string layerNames, string outLayerName)
        {
            try
            {
                ESRI.ArcGIS.Geoprocessor.Geoprocessor gp = new ESRI.ArcGIS.Geoprocessor.Geoprocessor();
                ESRI.ArcGIS.SpatialAnalystTools.Combine combine = new ESRI.ArcGIS.SpatialAnalystTools.Combine();
                combine.in_rasters = layerNames;
                combine.out_raster = AppSingleton.Instance().WorkspacePath + "\\" + outLayerName;
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
    }
}