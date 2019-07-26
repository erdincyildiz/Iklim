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

            var iklimClipLayer = AppSingleton.Instance().RasterClipLayer((cmbIklimSiniri.SelectedItem as LayerObject).layer, ((cmbProjectArea.SelectedItem as LayerObject).layer as IFeatureLayer));
            var ekolojiClipLayer= AppSingleton.Instance().RasterClipLayer((cmbEkolojikSitAlani.SelectedItem as LayerObject).layer, ((cmbProjectArea.SelectedItem as LayerObject).layer as IFeatureLayer));

            var layerNames = iklimClipLayer+ ";" + ekolojiClipLayer;
            AppSingleton.Instance().Combine(layerNames, "Combined");
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
