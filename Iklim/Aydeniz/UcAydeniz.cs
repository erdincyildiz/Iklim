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
            var comboBox = cmbUygulamaKatmani;
            comboBox.BindingContext = new BindingContext();
            comboBox.DataSource = null;
            comboBox.DataSource = LayerObjectList;
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
                FillCmboboboxWithFieldList(cmbNp, fieldList);
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
            string nN = string.Empty;
            string nP= string.Empty;
            string Y= string.Empty;
            string S= string.Empty;
            string gS= string.Empty;
            if (AppSingleton.Instance().UygulamaYontemi == "IDW")
            {
                nN = AppSingleton.Instance().IDW((cmbUygulamaKatmani.SelectedItem as LayerObject).layer, cmbNn.SelectedItem.ToString());
                nP = AppSingleton.Instance().IDW((cmbUygulamaKatmani.SelectedItem as LayerObject).layer, cmbNp.SelectedItem.ToString());
                Y = AppSingleton.Instance().IDW((cmbUygulamaKatmani.SelectedItem as LayerObject).layer, cmbY.SelectedItem.ToString());
                S = AppSingleton.Instance().IDW((cmbUygulamaKatmani.SelectedItem as LayerObject).layer, cmbS.SelectedItem.ToString());
                gS = AppSingleton.Instance().IDW((cmbUygulamaKatmani.SelectedItem as LayerObject).layer, cmbGs.SelectedItem.ToString());
            }
            else if (AppSingleton.Instance().UygulamaYontemi == "KRIGING")
            {
                nN = AppSingleton.Instance().Kriging((cmbUygulamaKatmani.SelectedItem as LayerObject).layer, cmbNn.SelectedItem.ToString());
                nP = AppSingleton.Instance().Kriging((cmbUygulamaKatmani.SelectedItem as LayerObject).layer, cmbNp.SelectedItem.ToString());
                Y = AppSingleton.Instance().Kriging((cmbUygulamaKatmani.SelectedItem as LayerObject).layer, cmbY.SelectedItem.ToString());
                S = AppSingleton.Instance().Kriging((cmbUygulamaKatmani.SelectedItem as LayerObject).layer, cmbS.SelectedItem.ToString());
                gS = AppSingleton.Instance().Kriging((cmbUygulamaKatmani.SelectedItem as LayerObject).layer, cmbGs.SelectedItem.ToString());
            }
            string nKS = RasterCalculatorNKS(nN, nP, Y, S, gS);
            string kKS = RasterCalculatorKKS(nKS);
        }


        public string RasterCalculatorNKS(string nN,string nP,string Y, string S, string gS)
        {
            try
            {
                ESRI.ArcGIS.SpatialAnalystTools.RasterCalculator rasterCalculator= new ESRI.ArcGIS.SpatialAnalystTools.RasterCalculator();
                rasterCalculator.expression = "('" + Y + "' * '" + nN + "' * '" + nP + "') / ('" + S + "' * '" + gS +  "')" + " + " + 15;
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
