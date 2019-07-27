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
    public partial class ucThird : UserControl
    {
        public ucThird()
        {
            InitializeComponent();
        }

        private void btnCalistir_Click(object sender, EventArgs e)
        {
            if (cmbEkolojikSitAlani.SelectedIndex < 0)
            {
                MessageBox.Show("Ekolojik Sit Alanı katmanı belirlenmeden işlem yapılamaz.");
                return;
            }
            if (cmbProjectArea.SelectedIndex < 0)
            {
                MessageBox.Show("Proje sınırı belirlenmeden işlem yapılamaz.");
                return;
            }
            if (cmbIklimSiniri.SelectedIndex < 0)
            {
                MessageBox.Show("İklim Sınırı katmanı belirlenmeden işlem yapılamaz.");
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
            tpSonuc.CustomText = "İklim Katmanı kesiliyor...";
            tpSonuc.Maximum = 5;
            tpSonuc.Step = 1;
            tpSonuc.PerformStep();
            var iklimClipLayer = AppSingleton.Instance().RasterClipLayer((cmbIklimSiniri.SelectedItem as LayerObject).layer, ((cmbProjectArea.SelectedItem as LayerObject).layer as IFeatureLayer),"RC_IKL" );
             tpSonuc.CustomText = "Ekoloji Katmanı kesiliyor...";
            tpSonuc.PerformStep();
            var ekolojiClipLayer= AppSingleton.Instance().RasterClipLayer((cmbEkolojikSitAlani.SelectedItem as LayerObject).layer, ((cmbProjectArea.SelectedItem as LayerObject).layer as IFeatureLayer),"RC_EKO");
            var vatIklim = AppSingleton.Instance().BuildRasterAttributeTable("RC_IKL");
            var vatEko = AppSingleton.Instance().BuildRasterAttributeTable("RC_EKO");
           
            var layerNames = iklimClipLayer+ ";" + ekolojiClipLayer;
            tpSonuc.CustomText = "Katmanlar birleştiriliyor...";
            tpSonuc.PerformStep();
            AppSingleton.Instance().Combine(layerNames, "IKL_EKO" );
            var vatIklEko = AppSingleton.Instance().BuildRasterAttributeTable("IKL_EKO");
            tpSonuc.CustomText = "Eksik kolonlar ekleniyor...";
            tpSonuc.PerformStep();
            JoinField(vatIklEko, "RC_IKL", vatIklim, "Value");
            JoinField(vatIklEko, "RC_EKO", vatEko, "Value");
            tpSonuc.CustomText = "İşlem tamamlandı...";
            tpSonuc.PerformStep();
            (this.Parent as Form).Close();
        }

        private bool JoinField(object table, string inField, object joinTable, string joinField)
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
            UpdateComboboxWithLayers(cmbEkolojikSitAlani, LayerObjectList);
            UpdateComboboxWithLayers(cmbIklimSiniri, LayerObjectList);
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
