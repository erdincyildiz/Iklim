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
using ESRI.ArcGIS.DataSourcesRaster;

namespace Iklim
{
    public partial class ucDeMartonne : UserControl
    {
        public ucDeMartonne()
        {
            InitializeComponent();
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
        private void btnOk_Click(object sender, EventArgs e)
        {
            AppSingleton.Instance().CreateWorkspacePath();
            if (AppSingleton.Instance().SettingsControl == null)
            {
                SettingsControl control = new SettingsControl();
                control.Load();
                control.CheckForm();
            }

            if (rbYillik.Checked)
            {
                var clipLayer = AppSingleton.Instance().ClipLayers((cmbProjectArea.SelectedItem as LayerObject).layer, (cmbVeriYillik.SelectedItem as LayerObject).layer);

                var IDWT = IDW(clipLayer, cmbOrtalamaSicaklikYillik.SelectedItem.ToString(), "IDWT");
                var T = Int(IDWT, "T");
                var IDWP = IDW(clipLayer, cmbToplamYagisYillik.SelectedItem.ToString(), "IDWP");
                var P = Int(IDWP, "P");
                var idm = RasterCalculatorYillik(P, T, "IDM");

                ITable vatYillik = BuildRasterAttributeTable("IDM");
                AddField(vatYillik, "OZELLIK", "TEXT");
                IQueryFilter queryFilter = new QueryFilterClass();
                ICursor updateCursor = vatYillik.Search(queryFilter, false);
                IRow feature = null;
                int idmField = vatYillik.FindField("VALUE");
                int ozellikField = vatYillik.FindField("OZELLIK");
                while ((feature = updateCursor.NextRow()) != null)
                {
                    string ozellik = string.Empty;
                    double idmVal = Convert.ToDouble(feature.get_Value(idmField));
                    if (idmVal < 5)
                    {
                        ozellik = "Kurak";
                    }
                    else if (idmVal >= 5 && idmVal < 10)
                    {
                        ozellik = "Yarı Kurak";
                    }
                    else if (idmVal >= 10 && idmVal < 20)
                    {
                        ozellik = "Yarı Kurak - Nemli Arası";
                    }
                    else if (idmVal >= 20 && idmVal < 30)
                    {
                        ozellik = "Yarı Nemli";
                    }
                    else if (idmVal >= 30 && idmVal < 60)
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
            }
            else
            {
                var IDWT = IDW((cmbVeriAylik.SelectedItem as LayerObject).layer, cmbOrtalamaSicaklikAylik.SelectedItem.ToString(), "IDWT");
                var T = Int(IDWT, "T");
                var IDWP = IDW((cmbVeriAylik.SelectedItem as LayerObject).layer, cmbToplamYagisAylik.SelectedItem.ToString(), "IDWP");
                var P = Int(IDWP, "P");
                var idm = RasterCalculatorAylik(P, T, "IDM");

                ITable vatAylik = BuildRasterAttributeTable("IDM");
                AddField(vatAylik, "OZELLIK", "TEXT");
                IQueryFilter queryFilter = new QueryFilterClass();
                ICursor updateCursor = vatAylik.Search(queryFilter, false);
                IRow feature = null;
                int idmField = vatAylik.FindField("VALUE");
                int ozellikField = vatAylik.FindField("OZELLIK");
                while ((feature = updateCursor.NextRow()) != null)
                {
                    string ozellik = string.Empty;
                    double idmVal = Convert.ToDouble(feature.get_Value(idmField));
                    if (idmVal < 5)
                    {
                        ozellik = "Kurak";
                    }
                    else if (idmVal >= 5 && idmVal < 10)
                    {
                        ozellik = "Yarı Kurak";
                    }
                    else if (idmVal >= 10 && idmVal < 20)
                    {
                        ozellik = "Yarı Kurak - Nemli Arası";
                    }
                    else if (idmVal >= 20 && idmVal < 30)
                    {
                        ozellik = "Yarı Nemli";
                    }
                    else if (idmVal >= 30 && idmVal < 60)
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

        public string RasterCalculatorAylik(string P, string T, string layerName)
        {
            try
            {
                ESRI.ArcGIS.SpatialAnalystTools.RasterCalculator rasterCalculator = new ESRI.ArcGIS.SpatialAnalystTools.RasterCalculator();
                rasterCalculator.expression = "('" + P + "' + 12)/('" + T + "' + 10)";
                ESRI.ArcGIS.Geoprocessor.Geoprocessor gp = new ESRI.ArcGIS.Geoprocessor.Geoprocessor();
                rasterCalculator.output_raster = AppSingleton.Instance().WorkspacePath + "\\" + layerName;
                gp.AddOutputsToMap = true;//AppSingleton.Instance().AralariEkle;
                gp.OverwriteOutput = true;
                gp.Execute(rasterCalculator, null);
                return rasterCalculator.output_raster.ToString();
            }
            catch (Exception ex)
            {
                return string.Empty;
            }
        }

        public string RasterCalculatorYillik(string P, string T, string layerName)
        {
            try
            {
                ESRI.ArcGIS.SpatialAnalystTools.RasterCalculator rasterCalculator = new ESRI.ArcGIS.SpatialAnalystTools.RasterCalculator();
                rasterCalculator.expression = "'" + P + "'/('" + T+ "' + 10)";
                ESRI.ArcGIS.Geoprocessor.Geoprocessor gp = new ESRI.ArcGIS.Geoprocessor.Geoprocessor();
                rasterCalculator.output_raster = AppSingleton.Instance().WorkspacePath + "\\" + layerName;
                gp.AddOutputsToMap = true;//AppSingleton.Instance().AralariEkle;
                gp.OverwriteOutput = true;
                gp.Execute(rasterCalculator, null);
                return rasterCalculator.output_raster.ToString();
            }
            catch (Exception ex)
            {
                return string.Empty;
            }
        }

        public string IDW(object selectedLayer, string FieldName, string layerName)
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

        public string Int(string layerName,string outName)
        {
            try
            {
                ESRI.ArcGIS.SpatialAnalystTools.Int intRaster = new ESRI.ArcGIS.SpatialAnalystTools.Int();
                intRaster.in_raster_or_constant = layerName;
                intRaster.out_raster = AppSingleton.Instance().WorkspacePath + "\\" + outName;
               
                ESRI.ArcGIS.Geoprocessor.Geoprocessor gp = new ESRI.ArcGIS.Geoprocessor.Geoprocessor();
                gp.AddOutputsToMap = AppSingleton.Instance().AralariEkle;
                gp.OverwriteOutput = true;
                gp.Execute(intRaster, null);
                return intRaster.out_raster.ToString();
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
                    IFeatureClass fclass = fLayer.FeatureClass;

                    LayerObject lObject = new LayerObject();
                    lObject.layer = layer;
                    lObject.Name = layer.Name;
                    LayerObjectList.Add(lObject);
                }
            }
            UpdateComboboxWithLayers(cmbProjectArea, LayerObjectList);
            UpdateComboboxWithLayers(cmbVeriAylik, LayerObjectList);
            UpdateComboboxWithLayers(cmbVeriYillik, LayerObjectList);
        }

        private void UpdateComboboxWithLayers(ComboBox comboBox, List<LayerObject> layerObjectList)
        {
            comboBox.BindingContext = new BindingContext();
            comboBox.DataSource = null;
            comboBox.DataSource = layerObjectList;
            comboBox.DisplayMember = "Name";
            comboBox.SelectedIndex = -1;
        }

        private void cmbVeriYillik_SelectedIndexChanged(object sender, EventArgs e)
        {
            LayerObject layerObject = (LayerObject)cmbVeriYillik.SelectedItem;
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
                FillCmboboboxWithFieldList(cmbOrtalamaSicaklikYillik, fieldList);
                FillCmboboboxWithFieldList(cmbToplamYagisYillik, fieldList);               
            }
        }
        private void FillCmboboboxWithFieldList(ComboBox comboBox, List<string> fieldList)
        {
            comboBox.BindingContext = new BindingContext();
            comboBox.DataSource = null;
            comboBox.DataSource = fieldList;
            comboBox.SelectedIndex = -1;
        }

        private void cmbVeriAylik_SelectedIndexChanged(object sender, EventArgs e)
        {
            LayerObject layerObject = (LayerObject)cmbVeriAylik.SelectedItem;
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
                FillCmboboboxWithFieldList(cmbOrtalamaSicaklikAylik, fieldList);
                FillCmboboboxWithFieldList(cmbToplamYagisAylik, fieldList);
            }
        }

        private void rbAylik_CheckedChanged(object sender, EventArgs e)
        {
            if (rbAylik.Checked)
            {
                cmbToplamYagisAylik.Enabled = true;
                cmbOrtalamaSicaklikAylik.Enabled = true;
                cmbVeriAylik.Enabled = true;

                cmbToplamYagisYillik.Enabled = false;
                cmbOrtalamaSicaklikYillik.Enabled = false;
                cmbVeriYillik.Enabled = false;
            }
        }

        private void rbYillik_CheckedChanged(object sender, EventArgs e)
        {
            if (rbYillik.Checked)
            {
                cmbToplamYagisAylik.Enabled = false;
                cmbOrtalamaSicaklikAylik.Enabled = false;
                cmbVeriAylik.Enabled = false;

                cmbToplamYagisYillik.Enabled = true;
                cmbOrtalamaSicaklikYillik.Enabled = true;
                cmbVeriYillik.Enabled = true;
            }
        }
    }
}
