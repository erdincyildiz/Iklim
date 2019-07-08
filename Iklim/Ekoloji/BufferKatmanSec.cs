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
    public partial class BufferKatmanSec : UserControl, IWizardPage
    {
        #region Members of BufferKatmanSec
        public string validationMessage;
        #endregion Members of BufferKatmanSec

        #region Properties of BufferKatmanSec
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

        public string ValidationMessage
        {
            get { return validationMessage; }
        }
        #endregion Properties of BufferKatmanSec

        #region Methods of BufferKatmanSec
        private void AddToDatagrid(LayerObject item)
        {
            List<string> fieldList = new List<string>();
            IFeatureLayer fLayer = item.layer as IFeatureLayer;

            List<string> islemTipi = new List<string>();



            if (fLayer != null)
            {

                try
                {
                    DataGridViewComboBoxCell fieldListCombo = new DataGridViewComboBoxCell();
                    fieldListCombo.DataSource = fieldList;

                    DataGridViewTextBoxCell tbKatmanAdi = new DataGridViewTextBoxCell();
                    DataGridViewTextBoxCell tbTamponDegeri = new DataGridViewTextBoxCell();

                    tbKatmanAdi.Value = fLayer.Name;
                    DataGridViewRow dataGridRow = new DataGridViewRow();
                    dataGridRow.Cells.Add(tbKatmanAdi);
                    //dataGridRow.Cells.Add(fieldListCombo);
                    dataGridRow.Cells.Add(tbTamponDegeri);
                    dataGridView1.Rows.Add(dataGridRow);
                }
                catch (Exception ex)
                {

                }
            }
        }

        private void AddToDictionaryAndWizardPages(DataGridViewRow item)
        {
            FieldGrid fieldGrid = new FieldGrid();
            FieldLayerObject fieldLayerObject = new FieldLayerObject();

            foreach (LayerField layerField in AppSingleton.Instance().BufferFieldListesi)
            {
                if (layerField.LayerObject.layer.Name == item.Cells[0].Value.ToString())
                {
                    fieldLayerObject.LayerObject = layerField.LayerObject;
                    fieldGrid.FieldLayerObject = fieldLayerObject;
                    fieldGrid.FieldName = layerField.FieldName;
                    break;
                }
            }
            int itemCount = AppSingleton.Instance().BufferItemCount + 1;
            fieldGrid.GridID = itemCount;
            AppSingleton.Instance().BufferItemCount = itemCount;

            IFeatureLayer fLayer = fieldGrid.FieldLayerObject.LayerObject.layer as IFeatureLayer;

            AppSingleton.Instance().BufferDict.Add(fLayer.Name, fieldGrid);
            UpdateFieldList(fieldGrid.FieldName, fLayer.Name);// ((ITable)fLayer.FeatureClass, fieldGrid.FieldName);
            fieldGrid.SetLabel(fLayer.Name);
            AppSingleton.Instance().wizardHost.WizardPages.Add(itemCount, fieldGrid);

        }

        private void BtnSagaGecirBuffer_Click(object sender, EventArgs e)
        {
            try
            {
                listBoxKullanilacaklarBuffer.Items.Add(listBoxTumKatmanlarBuffer.SelectedItem);
                listBoxTumKatmanlarBuffer.Items.RemoveAt(listBoxTumKatmanlarBuffer.SelectedIndex);

                UpdateKullanilacakBufferLayers();
                NotifyLayersUpdated();
            }
            catch
            {
            }
        }

        private void BtnSagaHepsiniGecirBuffer_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (LayerObject st in listBoxTumKatmanlarBuffer.Items)
                {
                    listBoxKullanilacaklarBuffer.Items.Add(st);
                }
                // Remove the listbox2 added items from listbox1
                for (int i = listBoxTumKatmanlarBuffer.Items.Count; i > 0; i--)
                {
                    listBoxTumKatmanlarBuffer.Items.RemoveAt(i - 1);
                }
                UpdateKullanilacakBufferLayers();
                NotifyLayersUpdated();
            }
            catch
            { }
        }

        private void BtnSolaGecirBuffer_Click(object sender, EventArgs e)
        {
            try
            {
                listBoxTumKatmanlarBuffer.Items.Add(listBoxKullanilacaklarBuffer.SelectedItem);
                listBoxKullanilacaklarBuffer.Items.RemoveAt(listBoxKullanilacaklarBuffer.SelectedIndex);

                UpdateKullanilacakBufferLayers();
                NotifyLayersUpdated();
            }
            catch
            {
            }
        }

        private void BtnSolaHepsiniGecirBuffer_Click(object sender, EventArgs e)
        {

            try
            {
                foreach (LayerObject st in listBoxKullanilacaklarBuffer.Items)
                {
                    listBoxTumKatmanlarBuffer.Items.Add(st);
                }
                // Remove the listbox2 added items from listbox1
                for (int i = listBoxKullanilacaklarBuffer.Items.Count; i > 0; i--)
                {
                    listBoxKullanilacaklarBuffer.Items.RemoveAt(i - 1);
                }

                UpdateKullanilacakBufferLayers();
                NotifyLayersUpdated();
            }
            catch
            { }
        }

        public BufferKatmanSec()
        {
            InitializeComponent();
            //AppSingleton= AppSingleton.Instance();

        }

        public void Cancel()
        {
            throw new NotImplementedException();
        }

        public void CheckDict()
        {
            if (AppSingleton.Instance().BufferDict == null)
            {
                AppSingleton.Instance().BufferDict = new Dictionary<string, FieldGrid>();
            }

            for (int i = AppSingleton.Instance().BufferDict.Count - 1; i >= 0; i--)
            {
                bool kontrol = false;
                KeyValuePair<string, FieldGrid> peer = AppSingleton.Instance().BufferDict.ElementAt(i);

                for (int j = dataGridView1.Rows.Count - 1; j >= 0; j--)
                {
                    if (dataGridView1.Rows[j].Cells[0].Value != null)
                    {
                        string layerName = dataGridView1.Rows[j].Cells[0].Value.ToString();
                        if (peer.Key == layerName)
                        {
                            kontrol = true;
                            FieldGrid fieldGrid = peer.Value;
                            string fieldName = "";
                            foreach (LayerField layerField in AppSingleton.Instance().BufferFieldListesi)
                            {
                                if (layerField.LayerObject.layer.Name == layerName)
                                {
                                    fieldName = layerField.FieldName;
                                }
                            }
                            if (fieldGrid.FieldName != fieldName)
                            {
                                AppSingleton.Instance().BufferDict[layerName].FieldName = fieldName;
                                UpdateFieldList(fieldName, layerName);
                            }
                            break;
                        }

                    }
                }
                if (kontrol == false)
                {
                    AppSingleton.Instance().BufferDict.Remove(peer.Key);
                    AppSingleton.Instance().wizardHost.WizardPages.Remove(peer.Value.GridID);
                }
            }

            for (int j = dataGridView1.Rows.Count - 1; j >= 0; j--)
            {
                string layerName = "";
                if (dataGridView1.Rows.Count > 0)
                {
                    bool kontrol = false;
                    if (dataGridView1.Rows[j].Cells[0].Value != null)
                    {

                        for (int i = AppSingleton.Instance().BufferDict.Count - 1; i >= 0; i--)
                        {
                            KeyValuePair<string, FieldGrid> peer = AppSingleton.Instance().BufferDict.ElementAt(i);

                            layerName = dataGridView1.Rows[j].Cells[0].Value.ToString();

                            if (peer.Key == layerName)
                            {
                                kontrol = true;
                                break;
                            }
                        }

                        if (kontrol == false)
                        {
                            AddToDictionaryAndWizardPages(dataGridView1.Rows[j]);
                        }
                    }
                }
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
        public bool CheckForm()
        {
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (row.Cells[0].Value != null)
                {
                    if (row.Cells[1].Value == null)
                    {
                        validationMessage = row.Cells[0].Value.ToString() + " katmanının öznitelik tipi belli değildir. Lütfen belirtiniz.";
                        return false;
                    }
                }

            }

            List<LayerField> bufferListesi = new List<LayerField>();
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                LayerField field = new LayerField();
                if (row.Cells[0].Value != null)
                {
                    string layerName = row.Cells[0].Value.ToString();
                    foreach (LayerObject item in AppSingleton.Instance().FinalTamponKatmanListesi)
                    {
                        if (item.layer.Name == layerName)
                        {
                            field.LayerObject = item;
                            field.FieldName = row.Cells[1].Value.ToString();
                            bufferListesi.Add(field);
                        }
                    }
                }
            }
            AppSingleton.Instance().BufferFieldListesi = bufferListesi;
            CheckDict();

            return true;
        }

        public List<LayerObject> CheckListForSagList(List<LayerObject> enterpoleList)
        {
            List<LayerObject> sagList = GetList(listBoxKullanilacaklarBuffer);
            List<LayerObject> objectList = new List<LayerObject>();
            for (int i = enterpoleList.Count - 1; i >= 0; i--)
            {
                bool kontrol = false;
                foreach (LayerObject item in sagList)
                {
                    if (item == enterpoleList[i])
                    {
                        kontrol = true;
                        break;
                    }
                }
                if (kontrol == false)
                {
                    objectList.Add(enterpoleList[i]);
                }
            }
            return objectList;
        }

        public void CheckYonList(ListBox lb)
        {
            List<LayerObject> enterpoleList = AppSingleton.Instance().BufferLayerList;
            List<LayerObject> poligonList = AppSingleton.Instance().FinalTamponKatmanListesi;
            for (int i = lb.Items.Count - 1; i >= 0; i--)
            {
                bool kontrol = false;
                foreach (LayerObject item in enterpoleList)
                {
                    if (item == lb.Items[i])
                    {
                        kontrol = true;
                        break;
                    }
                }
                foreach (LayerObject item in poligonList)
                {
                    if (item == lb.Items[i])
                    {
                        kontrol = true;
                        break;
                    }
                }

                if (kontrol == false)
                {
                    lb.Items.RemoveAt(i);
                }

            }
        }

        public void FillDatagrid()
        {


            if (dataGridView1.Rows.Count > 0)
            {
                for (int i = dataGridView1.Rows.Count - 1; i >= 0; i--)
                {
                    bool kontrol = false;
                    if (dataGridView1.Rows[i].Cells[0].Value != null)
                    {
                        string layerName = dataGridView1.Rows[i].Cells[0].Value.ToString();
                        foreach (LayerObject item in listBoxKullanilacaklarBuffer.Items)
                        {
                            if (item.layer.Name == layerName)
                            {
                                kontrol = true;
                                break;
                            }
                        }
                        if (kontrol == false)
                        {
                            dataGridView1.Rows.RemoveAt(i);
                        }

                    }
                }
            }
            foreach (LayerObject item in listBoxKullanilacaklarBuffer.Items)
            {
                bool kontrol = false;
                if (dataGridView1.Rows.Count > 0)
                {
                    for (int j = dataGridView1.Rows.Count - 1; j >= 0; j--)
                    {

                        if (dataGridView1.Rows[j].Cells[0].Value != null)
                        {
                            string layerName = dataGridView1.Rows[j].Cells[0].Value.ToString();

                            if (item.layer.Name == layerName)
                            {
                                kontrol = true;
                                break;
                            }
                        }
                    }
                }
                if (kontrol == false)
                {
                    AddToDatagrid(item);
                }
            }

        }

        public void FillSolList()
        {
            List<LayerObject> solList = GetList(listBoxTumKatmanlarBuffer);
            List<LayerObject> sagList = GetList(listBoxKullanilacaklarBuffer);
            List<LayerObject> kontrollist = AppSingleton.Instance().BufferLayerList;
            List<LayerObject> enterpoleList = CheckListForSagList(kontrollist);
            for (int i = enterpoleList.Count - 1; i >= 0; i--)
            {
                bool kontrol = false;
                foreach (LayerObject item in solList)
                {
                    if (item == enterpoleList[i])
                    {
                        kontrol = true;
                        break;
                    }
                }
                if (kontrol == false)
                {
                    listBoxTumKatmanlarBuffer.Items.Add(enterpoleList[i]);
                }
            }


            List<LayerObject> polykontrollist = AppSingleton.Instance().PolygonLayerList;
            List<LayerObject> polyList = CheckListForSagList(polykontrollist);
            for (int i = polyList.Count - 1; i >= 0; i--)
            {
                bool kontrol = false;
                foreach (LayerObject item in solList)
                {
                    if (item == polyList[i])
                    {
                        kontrol = true;
                        break;
                    }
                }
                if (kontrol == false)
                {
                    listBoxTumKatmanlarBuffer.Items.Add(polyList[i]);
                }
            }

        }

        public List<LayerObject> GetList(ListBox lb)
        {
            List<LayerObject> solList = new List<LayerObject>();
            foreach (LayerObject item in lb.Items)
            {
                solList.Add(item);
            }
            return solList;
        }

        public void InitForm()
        {

            List<LayerObject> solList = GetList(listBoxTumKatmanlarBuffer);
            List<LayerObject> sagList = GetList(listBoxKullanilacaklarBuffer);

            CheckYonList(listBoxTumKatmanlarBuffer);
            CheckYonList(listBoxKullanilacaklarBuffer);
            FillSolList();
            UpdateKullanilacakBufferLayers();
            NotifyLayersUpdated();
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

        private void UpdateBufferLayers()
        {
            FillDatagrid();
        }

        public void UpdateFieldList(string FieldName, string layerName)
        {
            FieldGrid fieldGrid = AppSingleton.Instance().BufferDict[layerName];
            Dictionary<string, string> fieldList = new Dictionary<string, string>();

            string[] split = FieldName.Split(',');

            foreach (string item in split)
            {
                fieldList.Add(item, "");
            }
            fieldGrid.FieldLayerObject.FieldList = fieldList;
            AppSingleton.Instance().BufferDict[layerName] = fieldGrid;

        }

        public void UpdateKatmanList()
        {
            listBoxTumKatmanlarBuffer.DataSource = null;
            foreach (LayerObject LayerObject in AppSingleton.Instance().BufferLayerList)
            {
                listBoxTumKatmanlarBuffer.Items.Add(LayerObject);
            }
            foreach (LayerObject LayerObject in AppSingleton.Instance().PolygonLayerList)
            {
                listBoxTumKatmanlarBuffer.Items.Add(LayerObject);
            }
        }

        private void UpdateKullanilacakBufferLayers()
        {
            List<LayerObject> tamponLayerList = new List<LayerObject>();
            foreach (LayerObject LayerObject in listBoxKullanilacaklarBuffer.Items)
            {
                tamponLayerList.Add(LayerObject);
            }
            AppSingleton.Instance().FinalTamponKatmanListesi = tamponLayerList;
            

            List<LayerObject> polyList = new List<LayerObject>();
            foreach (LayerObject LayerObject in listBoxTumKatmanlarBuffer.Items)
            { 
                if ((LayerObject.layer as IFeatureLayer).FeatureClass.ShapeType == esriGeometryType.esriGeometryPolygon)
                {
                    polyList.Add(LayerObject);
                }
              
            }
            AppSingleton.Instance().PolygonLayerList = polyList;
            FillDatagrid();
        }
        #endregion Methods of BufferKatmanSec
    }
}
