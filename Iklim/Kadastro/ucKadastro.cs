﻿using System;
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
    public partial class ucKadastro : UserControl
    {
        public ucKadastro()
        {
            InitializeComponent();
        }

        private void btnCalistir_Click(object sender, EventArgs e)
        {
           

            if (cmbIklimEkoloji.SelectedIndex < 0)
            {
                MessageBox.Show("İklim-Ekoloji katmanı belirlenmeden işlem yapılamaz.");
                return;
            }
            if (cmbProjectArea.SelectedIndex < 0)
            {
                MessageBox.Show("Proje sınırı belirlenmeden işlem yapılamaz.");
                return;
            }
            if (cmbKadastro.SelectedIndex < 0)
            {
                MessageBox.Show("Kadastro katmanı belirlenmeden işlem yapılamaz.");
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
            tpSonuc.CustomText = "İklim Katmanı kesiliyor...";
            tpSonuc.Maximum = 5;
            
            tpSonuc.VisualMode = ProgressBarDisplayMode.TextAndPercentage;
            tpSonuc.Step = 1;
            tpSonuc.PerformStep();
            var iklimClipLayer = AppSingleton.Instance().RasterClipLayer((cmbIklimEkoloji.SelectedItem as LayerObject).layer, ((cmbProjectArea.SelectedItem as LayerObject).layer as IFeatureLayer),"RC_IKLIM");
            tpSonuc.CustomText = "Poligona dönüştürülüyor...";
            tpSonuc.Step = 1;
            tpSonuc.PerformStep();

            var fClass = RasterToPolygon(iklimClipLayer);
             JoinField(fClass, "gridcode", iklimClipLayer, "Value");
            tpSonuc.CustomText = "Kadastro Katmanı kesiliyor...";
            tpSonuc.Step = 1;
            tpSonuc.PerformStep();

            var clipLayer = AppSingleton.Instance().ClipLayers((cmbProjectArea.SelectedItem as LayerObject).layer, (cmbKadastro.SelectedItem as LayerObject).layer);

            tpSonuc.CustomText = "Katmanlar kesiştiriliyor...";
            tpSonuc.Step = 1;
            tpSonuc.PerformStep();

            InterSect(fClass, clipLayer);
            tpSonuc.CustomText = "İşlem tamamlandı...";
            tpSonuc.Step = 1;
            tpSonuc.PerformStep();
            (this.Parent as Form).Close();

        }

        private string RasterToPolygon(object rasterlayer)
        {
            ESRI.ArcGIS.Geoprocessor.Geoprocessor gp = new ESRI.ArcGIS.Geoprocessor.Geoprocessor();
            ESRI.ArcGIS.ConversionTools.RasterToPolygon rasterToPolygon = new ESRI.ArcGIS.ConversionTools.RasterToPolygon();
            rasterToPolygon.in_raster = rasterlayer;
            rasterToPolygon.out_polygon_features = AppSingleton.Instance().WorkspacePath + "\\RasterToPolygon";
            rasterToPolygon.simplify = "SIMPLIFY";
            rasterToPolygon.raster_field = "Value";
            gp.AddOutputsToMap = AppSingleton.Instance().AralariEkle;
            gp.AddOutputsToMap = AppSingleton.Instance().AralariEkle;
            gp.OverwriteOutput = true;
            gp.Execute(rasterToPolygon, null);
            return rasterToPolygon.out_polygon_features.ToString();
        }

        private string InterSect(string flayer,string kadastroLayer)
        {
            ESRI.ArcGIS.Geoprocessor.Geoprocessor gp = new ESRI.ArcGIS.Geoprocessor.Geoprocessor();
            ESRI.ArcGIS.AnalysisTools.Intersect intersect = new ESRI.ArcGIS.AnalysisTools.Intersect();
            intersect.in_features = flayer + ";" + kadastroLayer;
            intersect.out_feature_class = AppSingleton.Instance().WorkspacePath + "\\Final";
            intersect.join_attributes = "All";
            intersect.output_type = "INPUT";
            gp.AddOutputsToMap = true;
            gp.AddOutputsToMap = true;
            gp.OverwriteOutput = true;
            gp.Execute(intersect, null);
            return intersect.out_feature_class.ToString();
        }

        private bool JoinField(object table, string inField, string joinTable, string joinField)
        {
            try
            {
                ESRI.ArcGIS.Geoprocessor.Geoprocessor gp = new ESRI.ArcGIS.Geoprocessor.Geoprocessor();
                ESRI.ArcGIS.DataManagementTools.JoinField join = new ESRI.ArcGIS.DataManagementTools.JoinField();
                join.in_data = table;
                join.in_field = inField;
                join.join_table = joinTable;
                join.join_field = joinField;
                gp.AddOutputsToMap = AppSingleton.Instance().AralariEkle;
                gp.OverwriteOutput = true;
                gp.Execute(join, null);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public void Init()
        {
            ArcMap.Application.CurrentTool = null;
            IMxDocument mxDocument = ArcMap.Document;
            IMap map = mxDocument.FocusMap;
            int layerCount = map.LayerCount;
            List<LayerObject> LayerObjectList = new List<LayerObject>();
            List<LayerObject> LayerObjectList2 = new List<LayerObject>();
            for (int i = 0; i < layerCount; i++)
            {
                ILayer layer = map.get_Layer(i);
                IRasterLayer rLayer = layer as IRasterLayer;
                if (rLayer != null)
                {
                    LayerObject lObject = new LayerObject();
                    lObject.layer = layer;
                    lObject.Name = layer.Name;
                    LayerObjectList.Add(lObject);
                }

                IFeatureLayer fLayer = layer as IFeatureLayer;
                if (fLayer != null)
                {
                    LayerObject lObject = new LayerObject();
                    lObject.layer = layer;
                    lObject.Name = layer.Name;
                    LayerObjectList2.Add(lObject);
                }
            }
            UpdateComboboxWithLayers(cmbIklimEkoloji, LayerObjectList);
            UpdateComboboxWithLayers(cmbKadastro, LayerObjectList2);
            UpdateComboboxWithLayers(cmbProjectArea, LayerObjectList2);
        }

        private void UpdateComboboxWithLayers(ComboBox comboBox, List<LayerObject> layerObjectList)
        {
            comboBox.BindingContext = new BindingContext();
            comboBox.DataSource = null;
            comboBox.DataSource = layerObjectList;
            comboBox.DisplayMember = "Name";
            comboBox.SelectedIndex = -1;
        }
    }
}
