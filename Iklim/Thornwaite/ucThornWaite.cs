using ESRI.ArcGIS.ArcMapUI;
using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.Geodatabase;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Iklim
{
    public partial class ucThornWaite : UserControl
    {
        public ucThornWaite()
        {
            InitializeComponent();
        }

        private void btnCalistir_Click(object sender, EventArgs e)
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
            if (cmbYillikSuEksigi.SelectedIndex < 0)
            {
                MessageBox.Show("Yıllık Su eksiği değeri belirlenmeden işlem yapılamaz.");
                return;
            }
            if (cmbYillikSuFazlasi.SelectedIndex < 0)
            {
                MessageBox.Show("Yıllık Su fazlası değeri belirlenmeden işlem yapılamaz.");
                return;
            }
            if (cmbETP.SelectedIndex < 0)
            {
                MessageBox.Show("Yıllık Gerçek Evapotranspirasyon değeri belirlenmeden işlem yapılamaz.");
                return;
            }
            if (cmbPETP.SelectedIndex < 0)
            {
                MessageBox.Show("Yıllık Potansiyel Evapotranspirasyon değeri belirlenmeden işlem yapılamaz.");
                return;
            }
            if (cmbPETPHaziran.SelectedIndex < 0)
            {
                MessageBox.Show("Haziran ayı Potansiyel Evapotranspirasyon değeri belirlenmeden işlem yapılamaz.");
                return;
            }
            if (cmbPETPTemmuz.SelectedIndex < 0)
            {
                MessageBox.Show("Temmuz ayı Potansiyel Evapotranspirasyon değeri belirlenmeden işlem yapılamaz.");
                return;
            }
            if (cmbPETPAgustos.SelectedIndex < 0)
            {
                MessageBox.Show("Ağustos ayı Potansiyel Evapotranspirasyon değeri belirlenmeden işlem yapılamaz.");
                return;
            }
            if (cmbSuFazlasiYaz.SelectedIndex < 0)
            {
                MessageBox.Show("Yaz ayları su fazlası değeri belirlenmeden işlem yapılamaz.");
                return;
            }
            if (cmbSuFazlasiKis.SelectedIndex < 0)
            {
                MessageBox.Show("Kış ayları su fazlası değeri belirlenmeden işlem yapılamaz.");
                return;
            }
            if (cmbSuEksigiYaz.SelectedIndex < 0)
            {
                MessageBox.Show("Yaz ayları su eksiği değeri belirlenmeden işlem yapılamaz.");
                return;
            }
            if (cmbSuEksigiKis.SelectedIndex < 0)
            {
                MessageBox.Show("Kış ayları su eksiği değeri belirlenmeden işlem yapılamaz.");
                return;
            }

            AppSingleton.Instance().CreateWorkspacePath();
            if (AppSingleton.Instance().SettingsControl == null)
            {
                SettingsControl control = new SettingsControl();
                control.Load();
                control.CheckForm();
            }

            if (cmbUygulamaKatmani.SelectedIndex < 0)
            {
                MessageBox.Show("Öncelikli katmanı belirleyiniz.");
                return;
            }

            var clipLayer = AppSingleton.Instance().ClipLayers((cmbProjectArea.SelectedItem as LayerObject).layer, (cmbUygulamaKatmani.SelectedItem as LayerObject).layer);

            var s = AppSingleton.Instance().IDW(clipLayer, cmbYillikSuFazlasi.SelectedItem.ToString(), "s");
            var d = AppSingleton.Instance().IDW(clipLayer, cmbYillikSuEksigi.SelectedItem.ToString(), "d");
            var etp = AppSingleton.Instance().IDW(clipLayer, cmbETP.SelectedItem.ToString(), "etp");
            var petp = AppSingleton.Instance().IDW(clipLayer, cmbPETP.SelectedItem.ToString(), "sei");
            var aPetAgu = AppSingleton.Instance().IDW(clipLayer, cmbPETPAgustos.SelectedItem.ToString(), "aPetAgu");
            var aPetTem = AppSingleton.Instance().IDW(clipLayer, cmbPETPTemmuz.SelectedItem.ToString(), "aPetTem");
            var aPetHaz = AppSingleton.Instance().IDW(clipLayer, cmbPETPHaziran.SelectedItem.ToString(), "aPetHaz");
            var suEksYaz = AppSingleton.Instance().IDW(clipLayer, cmbSuEksigiYaz.SelectedItem.ToString(), "suEksYaz");
            var suFazYaz = AppSingleton.Instance().IDW(clipLayer, cmbSuFazlasiYaz.SelectedItem.ToString(), "suFazYaz");
            var suEksKis = AppSingleton.Instance().IDW(clipLayer, cmbSuEksigiKis.SelectedItem.ToString(), "suEksKis");
            var suFazKis = AppSingleton.Instance().IDW(clipLayer, cmbSuFazlasiKis.SelectedItem.ToString(), "suFazKis");

            var yei = RasterCalculatorYei(s, d, etp, "yei");
            var sei = petp;
            var ki = RasterCalculatorKi(d, etp, "ki");
            var ni = RasterCalculatorKi(s, etp, "ni");
            var etp3YazOrani = RasterCalculatorEtp3(aPetHaz, aPetTem, aPetAgu, petp, "etp3");

            string combine = Combine(yei + ";" + sei + ";" + ki + ";" + ni + ";" + etp3YazOrani + ";" + suEksYaz+ ";" + suEksKis + ";" + suFazYaz + ";" + suFazKis);

            var vat = AppSingleton.Instance().BuildRasterAttributeTable("Combined");
            var yeiField = vat.Fields.FindField("yei");
            var seiField = vat.Fields.FindField("sei");
            var kiField = vat.Fields.FindField("ki");
            var niField = vat.Fields.FindField("ni");
            var etpField = vat.Fields.FindField("etp3");
            var suFazlasiYazField =  vat.Fields.FindField("suFazYaz");
            var suFazlasiKisField = vat.Fields.FindField("suFazKis");
            var suEksigiYazField =  vat.Fields.FindField("suEksYaz");
            var suEksigiKisField =  vat.Fields.FindField("suEksKis");


            AppSingleton.Instance().AddField(vat, "yeiHarf", "TEXT");
            AppSingleton.Instance().AddField(vat, "seiHarf", "TEXT");
            AppSingleton.Instance().AddField(vat, "kiHarf", "TEXT");
            AppSingleton.Instance().AddField(vat, "niHarf", "TEXT");
            AppSingleton.Instance().AddField(vat, "etp3Harf", "TEXT");

            var yeiHarfField = vat.Fields.FindField("yeiHarf");
            var seiHarfField = vat.Fields.FindField("seiHarf");
            var kiHarfField = vat.Fields.FindField("kiHarf");
            var niHarfField = vat.Fields.FindField("niHarf");
            var etpHarfField = vat.Fields.FindField("etp3Harf");

            IQueryFilter queryFilter = new QueryFilterClass();
            ICursor updateCursor = vat.Search(queryFilter, false);
            IRow feature = null;
            while ((feature = updateCursor.NextRow()) != null)
            {

                var suFazlasiKisVal = Convert.ToDouble(feature.get_Value(suFazlasiKisField));
                var suFazlasiYazVal = Convert.ToDouble(feature.get_Value(suFazlasiYazField));

                var suEksigiKisVal = Convert.ToDouble(feature.get_Value(suEksigiKisField));
                var suEksigiYazVal = Convert.ToDouble(feature.get_Value(suEksigiYazField));

                var yeiVal = Convert.ToInt32(feature.get_Value(yeiField));
                var yeiHarf = CalculateYeiHarf(yeiVal);
                feature.set_Value(yeiHarfField, yeiHarf);
                var seiVal = Convert.ToInt32(feature.get_Value(seiField));
                var seiHarf = CalculateSeiHarf(seiVal);
                feature.set_Value(seiHarfField, seiHarf);
                var etpVal = Convert.ToInt32(feature.get_Value(etpField));
                var etpHarf = CalculateEtpHarf(etpVal);
                feature.set_Value(etpHarfField, etpHarf);
                
                var kiVal = Convert.ToInt32(feature.get_Value(kiField));
                var kiHarf = CalculateKiHarf(kiVal,suEksigiYazVal,suEksigiKisVal);
                feature.set_Value(kiHarfField, kiHarf);                

                var niVal = Convert.ToInt32(feature.get_Value(niField));
                var niHarf = CalculateNiHarf(niVal,suFazlasiYazVal,suFazlasiKisVal);
                feature.set_Value(niHarfField, niHarf);
                feature.Store();
            }
        }

        private string CalculateKiHarf(int ki,double suEksigiYaz,double suEksigiKis)
        {
            string harf = string.Empty;

            if (0 <= ki && ki < 168)
            {
                return "r";
            }
            else if (168 <= ki&& ki < 334)
            {
                if (suEksigiKis > suEksigiYaz)
                {
                    return "w";
                }
                return "s";
            }
            else if (334 <= ki)
            {
                if (suEksigiKis > suEksigiYaz)
                {
                    return "w2";
                }
                return "s2";
            }

            return string.Empty;
        }
        private string CalculateNiHarf(int ni, double suFazlasiYaz, double suFazlasiKis)
        {
            string harf = string.Empty;

            if (0 <= ni && ni < 10)
            {
                return "r";
            }
            else if (10 <= ni && ni < 20)
            {
                if (suFazlasiKis > suFazlasiYaz)
                {
                    return "w";
                }
                return "s";
            }
            else if (20 <= ni)
            {
                if (suFazlasiKis > suFazlasiYaz)
                {
                    return "w2";
                }
                return "s2";
            }

            return string.Empty;
        }
        private string CalculateEtpHarf(int ETP3YazOrani)
        {
            string harf = string.Empty;

            if ( ETP3YazOrani < 481)
            {
                return "a'";
            }
            else if (481 <= ETP3YazOrani && ETP3YazOrani < 520)
            {
                return "b'4";
            }
            else if (520 <= ETP3YazOrani && ETP3YazOrani< 564)
            {
                return "b'3";
            }
            else if (564 <= ETP3YazOrani && ETP3YazOrani< 617)
            {
                return "b'2";
            }
            else if (617 <= ETP3YazOrani && ETP3YazOrani< 681)
            {
                return "b'1";
            }
            else if (681 <= ETP3YazOrani  && ETP3YazOrani< 764)
            {
                return "c'2";
            }

            else if (764 <= ETP3YazOrani && ETP3YazOrani< 881)
            {
                return "c'1";
            }
            else if (881 <= ETP3YazOrani)
            {
                return "d";
            }

            return string.Empty;
        }
        private string CalculateSeiHarf(int Sei)
        {
            string harf = string.Empty;
            if (Sei >= 1141)
            {
                return "A'";
            }
            else if (1141 > Sei && Sei >= 998)
            {
                return "B'4";
            }
            else if (998 > Sei && Sei>= 856)
            {
                return "B'3";
            }
            else if (856 > Sei && Sei>= 713 )
            {
                return "B'2";
            }
            else if (713 > Sei && Sei>= 571)
            {
                return "B'1";
            }
            else if (571 > Sei && Sei>= 428)
            {
                return "C'2";
            }

            else if (428 > Sei && Sei>= 286)
            {
                return "C'1";
            }
            else if (286 > Sei && Sei>= 143)
            {
                return "D";
            }
            else if (143 > Sei)
            {
                return "E";
            }

            return string.Empty;
        }

        private string CalculateYeiHarf(int Yei)
        {
            string harf = string.Empty;
            if(Yei > 100)
            {
                return "A";
            }
          else if (Yei < 100 && Yei >=80)
            {
                return "B4";
            }else if (Yei < 80 && Yei >= 60)
            {
                return "B3";
            }
            else if (Yei < 60 && Yei >= 40)
            {
                return "B2";
            }
            else if (Yei < 40 && Yei >= 20)
            {
                return "B1";
            }
            else if (Yei < 20 && Yei >= 0)
            {
                return "C2";
            }

            else if (Yei < 0 && Yei >= -20)
            {
                return "C1";
            }
            else if (Yei < -20 && Yei >= -40)
            {
                return "D";
            }
            else if (Yei < -40 && Yei >= -60)
            {
                return "E";
            }

            return string.Empty;
        }

        public string IDW(ILayer selectedLayer, string FieldName,string layerName)
        {
            try
            {
                ESRI.ArcGIS.SpatialAnalystTools.Idw idw = new ESRI.ArcGIS.SpatialAnalystTools.Idw();
                idw.cell_size = AppSingleton.Instance().CellSize;
                idw.out_raster = AppSingleton.Instance().WorkspacePath + "\\" + layerName;
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
        private string Combine(string layerNames)
        {
            try
            {
                ESRI.ArcGIS.Geoprocessor.Geoprocessor gp = new ESRI.ArcGIS.Geoprocessor.Geoprocessor();
                ESRI.ArcGIS.SpatialAnalystTools.Combine combine = new ESRI.ArcGIS.SpatialAnalystTools.Combine();
                combine.in_rasters = layerNames;
                combine.out_raster = AppSingleton.Instance().WorkspacePath + "\\" + "Combined";
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
        public string RasterCalculatorEtp3(string aPetHaz, string aPetTem,string aPetAgu,string petp , string layerName)
        {
            try
            {
                ESRI.ArcGIS.SpatialAnalystTools.RasterCalculator rasterCalculator = new ESRI.ArcGIS.SpatialAnalystTools.RasterCalculator();
                rasterCalculator.expression = "('" + aPetHaz + "' + '" + aPetTem + "' + '" + aPetAgu + "')* 1000/'" + petp+ "'";
                ESRI.ArcGIS.Geoprocessor.Geoprocessor gp = new ESRI.ArcGIS.Geoprocessor.Geoprocessor();
                rasterCalculator.output_raster = AppSingleton.Instance().WorkspacePath + "\\" + layerName;
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
        public string RasterCalculatorYei(string s, string d, string etp, string layerName)
        {
            try
            {
                ESRI.ArcGIS.SpatialAnalystTools.RasterCalculator rasterCalculator = new ESRI.ArcGIS.SpatialAnalystTools.RasterCalculator();
                rasterCalculator.expression = "(100 * '" + s + "' - 60 * '" + d + "') / '" + etp + "'";
                ESRI.ArcGIS.Geoprocessor.Geoprocessor gp = new ESRI.ArcGIS.Geoprocessor.Geoprocessor();
                rasterCalculator.output_raster = AppSingleton.Instance().WorkspacePath + "\\" + layerName;
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

        public string RasterCalculatorKi(string d, string etp, string layerName)
        {
            try
            {
                ESRI.ArcGIS.SpatialAnalystTools.RasterCalculator rasterCalculator = new ESRI.ArcGIS.SpatialAnalystTools.RasterCalculator();
                rasterCalculator.expression = "((100 * '" + d + "') / '" + etp + "')*10";
                ESRI.ArcGIS.Geoprocessor.Geoprocessor gp = new ESRI.ArcGIS.Geoprocessor.Geoprocessor();
                rasterCalculator.output_raster = AppSingleton.Instance().WorkspacePath + "\\" + layerName;
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
            UpdateComboboxWithLayers(cmbProjectArea, LayerObjectList);
            UpdateComboboxWithLayers(cmbUygulamaKatmani, LayerObjectList);
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

                FillCmboboboxWithFieldList(cmbYillikSuEksigi, fieldList);
                FillCmboboboxWithFieldList(cmbYillikSuFazlasi, fieldList);
                FillCmboboboxWithFieldList(cmbETP, fieldList);
                FillCmboboboxWithFieldList(cmbPETP, fieldList);
                FillCmboboboxWithFieldList(cmbPETPAgustos, fieldList);
                FillCmboboboxWithFieldList(cmbPETPHaziran, fieldList);
                FillCmboboboxWithFieldList(cmbPETPTemmuz, fieldList);
                FillCmboboboxWithFieldList(cmbSuEksigiKis, fieldList);
                FillCmboboboxWithFieldList(cmbSuEksigiYaz, fieldList);
                FillCmboboboxWithFieldList(cmbSuFazlasiKis, fieldList);
                FillCmboboboxWithFieldList(cmbSuFazlasiYaz, fieldList);
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