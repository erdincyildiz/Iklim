using ESRI.ArcGIS.ArcMapUI;
using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.Geodatabase;
using ESRI.ArcGIS.Geometry;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;


namespace Iklim
{
    public partial class KatmanSec : UserControl, IWizardPage
    {
        #region Properties of KatmanSec
        public UserControl Content
        {
            get { return this; }
        }

        public bool IsBusy
        {
            get { throw new NotImplementedException(); }
        }

        public bool PageValid
        {
            get { return true; }
        }

        public string validationMessage;
        public string ValidationMessage
        {
            get { return validationMessage; }
        }
        #endregion Properties of KatmanSec

        #region Methods of KatmanSec
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                listBoxKullanilacaklar.Items.Add(listBoxTumKatmanlar.SelectedItem);
                listBoxTumKatmanlar.Items.RemoveAt(listBoxTumKatmanlar.SelectedIndex);
                updateComboBox();
                UpdateKullanilacakLayers();
                UpdateEnterpoleLayers();               
            }
            catch
            {
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                listBoxTumKatmanlar.Items.Add(listBoxKullanilacaklar.SelectedItem);
                listBoxKullanilacaklar.Items.RemoveAt(listBoxKullanilacaklar.SelectedIndex);
                updateComboBox();
                UpdateKullanilacakLayers();
                UpdateEnterpoleLayers();
               
            }
            catch
            {
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (LayerObject st in listBoxTumKatmanlar.Items)
                {
                    listBoxKullanilacaklar.Items.Add(st);
                }
                // Remove the listbox2 added items from listbox1
                for (int i = listBoxTumKatmanlar.Items.Count; i > 0; i--)
                {
                    listBoxTumKatmanlar.Items.RemoveAt(i - 1);
                }
                updateComboBox();
                UpdateKullanilacakLayers();
                UpdateEnterpoleLayers();
                
            }
            catch
            { }
        }

        private void button4_Click(object sender, EventArgs e)
        {

            try
            {
                foreach (LayerObject st in listBoxKullanilacaklar.Items)
                {
                    listBoxTumKatmanlar.Items.Add(st);
                }
                // Remove the listbox2 added items from listbox1
                for (int i = listBoxKullanilacaklar.Items.Count; i > 0; i--)
                {
                    listBoxKullanilacaklar.Items.RemoveAt(i - 1);
                }
                updateComboBox();
                UpdateKullanilacakLayers();
                UpdateEnterpoleLayers();
               
            }
            catch
            { }
        }

        public void Cancel()
        {
            throw new NotImplementedException();
        }

        private void CmbSinirKatmani_SelectedIndexChanged(object sender, EventArgs e)
        {
            LayerObject LayerObject = CmbSinirKatmani.SelectedItem as LayerObject;
            if (LayerObject != null)
            {
                AppSingleton.Instance().SinirLayer = LayerObject.layer;
            }
            else
            {
                AppSingleton.Instance().SinirLayer = null;
            }
        }
        public delegate void LayersUpdated();
        public event LayersUpdated layersUpdated;
        private void NotifyLayersUpdated()
        {
            if (layersUpdated != null)
            {
                layersUpdated();
            }
        }
        public void InitForm(IMxDocument mxDocument)
        {
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
                    listBoxTumKatmanlar.Items.Add(lObject);
                }
                else if(layer is IRasterLayer)
                {
                    LayerObject lObject = new LayerObject();
                    lObject.layer = layer;
                    lObject.Name = layer.Name;
                    listBoxTumKatmanlar.Items.Add(lObject);
                }
            }
            updateComboBox();
        }

        public KatmanSec()
        {
            InitializeComponent();
            //AppSingleton= AppSingleton.Instance();

        }

        private void label1_Click(object sender, EventArgs e)
        {
        }

        public new void Load()
        {
        }

        public void Save()
        {
        }

        private void UpdateEnterpoleLayers()
        {
            List<LayerObject> EnterpoleLayer = new List<LayerObject>();
            List<LayerObject> PolygonLayer = new List<LayerObject>();
            List<LayerObject> RasterLayer = new List<LayerObject>();
            foreach (LayerObject layerObject in AppSingleton.Instance().allLayers)
            {
                var layer = (layerObject.layer as IFeatureLayer);
                if (layer != null)
                {
                    if (layer.FeatureClass.ShapeType != esriGeometryType.esriGeometryPolygon)
                    {
                        EnterpoleLayer.Add(layerObject);
                    }
                    else if (layer.FeatureClass.ShapeType == esriGeometryType.esriGeometryPolygon)
                    {
                        PolygonLayer.Add(layerObject);
                    }
                }
                else if (layerObject.layer is IRasterLayer)
                {
                    RasterLayer.Add(layerObject);
                }
            }
            AppSingleton.Instance().EnterpoleLayerList = EnterpoleLayer;
            AppSingleton.Instance().PolygonLayerList = PolygonLayer;
            AppSingleton.Instance().RasterLayerList = RasterLayer;
        }

        private void updateComboBox()
        {
            CmbSinirKatmani.DataSource = null;
            CmbSinirKatmani.DataSource = listBoxTumKatmanlar.Items;
            CmbSinirKatmani.DisplayMember = "Name";
            CmbSinirKatmani.SelectedIndex = -1;
        }

        private void UpdateKullanilacakLayers()
        {
            List<LayerObject> allLayer = new List<LayerObject>();

            foreach (LayerObject LayerObject in listBoxKullanilacaklar.Items)
            {
                allLayer.Add(LayerObject);
            }
            AppSingleton.Instance().allLayers = allLayer;
        }
        #endregion Methods of KatmanSec


        public bool CheckForm()
        {

            //IGraphicsContainer destLayer = GraphicSingleton.Instance().destinationlayer as IGraphicsContainer;
            //IGraphicsContainer originLayer = GraphicSingleton.Instance().originlayer as IGraphicsContainer;
            //destLayer.Reset();
            //originLayer.Reset();

            //IElement destElement = destLayer.Next();
            //IElement originElement = originLayer.Next();

            //ILayer SinirLayer = AppSingleton.Instance().SinirLayer;
            //IFeatureLayer fLayer = SinirLayer as IFeatureLayer;
            //IQueryFilter queryFilter = new QueryFilterClass();
            //IFeatureCursor searchCursor = fLayer.Search(queryFilter, false);
            //IFeature feature = searchCursor.NextFeature();
            //System.Runtime.InteropServices.Marshal.ReleaseComObject(searchCursor);
            //IRelationalOperator pRelOperator = (IRelationalOperator)feature.Shape;
            //ITopologicalOperator topop = feature.Shape as ITopologicalOperator;
            //bool kontrolOrigin = false;
            //try
            //{
            //    IGeometry geom = topop.Intersect(originElement.Geometry, esriGeometryDimension.esriGeometry0Dimension);
            //    kontrolOrigin = geom.IsEmpty;
            //}
            //catch (Exception ex)
            //{
                
            //}
           
          
            //IGeometry geom2 = topop.Intersect(destElement.Geometry, esriGeometryDimension.esriGeometry0Dimension);
            //bool kontrolDestination = geom2.IsEmpty;
            //try
            //{
            //    if (kontrolOrigin == true)
            //    {
            //        validationMessage = "Başlangıç noktası sınır katmanı içinde kalmıyor. Lütfen düzeltiniz.";
            //        return false;
            //    }

            //}
            //catch (Exception ex)
            //{


            //}
            //try
            //{
            //    if (kontrolDestination == true)
            //    {
            //        validationMessage = "Bitiş noktası sınır katmanı içinde kalmıyor. Lütfen düzeltiniz.";
            //        return false;
            //    }
            //}
            //catch (Exception ex)
            //{
            //}
            NotifyLayersUpdated();

            return true;
        }
    }
}
