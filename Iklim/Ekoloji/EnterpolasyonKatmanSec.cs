using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.Geodatabase;

namespace Iklim
{
    public partial class EnterpolasyonKatmanSec : UserControl, IWizardPage
    {

        public void InitForm()
        {
            List<LayerObject> solList = GetList(listBoxTumKatmanlarEnterpole);
            List<LayerObject> sagList = GetList(listBoxKullanilacaklarEnterpole);

            CheckYonList(listBoxTumKatmanlarEnterpole);
            CheckYonList(listBoxKullanilacaklarEnterpole);
            FillSolList();
            UpdateKullanilacakBufferLayers();
            NotifyLayersUpdated();
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
                        foreach (LayerObject item in listBoxKullanilacaklarEnterpole.Items)
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
            foreach (LayerObject item in listBoxKullanilacaklarEnterpole.Items)
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
            List<LayerObject> solList = GetList(listBoxTumKatmanlarEnterpole);
            List<LayerObject> sagList = GetList(listBoxKullanilacaklarEnterpole);
            List<LayerObject> kontrollist = AppSingleton.Instance().EnterpoleLayerList;
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
                    listBoxTumKatmanlarEnterpole.Items.Add(enterpoleList[i]);
                }
            }
        }

        public List<LayerObject> CheckListForSagList(List<LayerObject> enterpoleList)
        {
            List<LayerObject> sagList = GetList(listBoxKullanilacaklarEnterpole);
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
            List<LayerObject> enterpoleList = AppSingleton.Instance().EnterpoleLayerList;
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
                if (kontrol == false)
                {
                    lb.Items.RemoveAt(i);
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

        public EnterpolasyonKatmanSec()
        {
            InitializeComponent();
        }

        private void BtnSagaHepsiniGecirEnterpole_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (LayerObject st in listBoxTumKatmanlarEnterpole.Items)
                {
                    listBoxKullanilacaklarEnterpole.Items.Add(st);
                }
                // Remove the listbox2 added items from listbox1
                for (int i = listBoxTumKatmanlarEnterpole.Items.Count; i > 0; i--)
                {
                    listBoxTumKatmanlarEnterpole.Items.RemoveAt(i - 1);
                }
                UpdateKullanilacakBufferLayers();
                NotifyLayersUpdated();
            }
            catch
            { }
        }

        private void BtnSagaGecirEnterpole_Click(object sender, EventArgs e)
        {
            try
            {
                listBoxKullanilacaklarEnterpole.Items.Add(listBoxTumKatmanlarEnterpole.SelectedItem);
                listBoxTumKatmanlarEnterpole.Items.RemoveAt(listBoxTumKatmanlarEnterpole.SelectedIndex);

                UpdateKullanilacakBufferLayers();
                NotifyLayersUpdated();
            }
            catch
            {
            }
        }

        private void BtnSolaGecirEnterpole_Click(object sender, EventArgs e)
        {
            try
            {
                listBoxTumKatmanlarEnterpole.Items.Add(listBoxKullanilacaklarEnterpole.SelectedItem);
                listBoxKullanilacaklarEnterpole.Items.RemoveAt(listBoxKullanilacaklarEnterpole.SelectedIndex);

                UpdateKullanilacakBufferLayers();
                NotifyLayersUpdated();
            }
            catch
            {
            }
        }
        public void TestForm()
        {
            MessageBox.Show("alarm");
        }

        private void UpdateKullanilacakBufferLayers()
        {
            List<LayerObject> BufferLayerList = new List<LayerObject>();
            List<LayerObject> enterpoleLayerList = new List<LayerObject>();
            foreach (LayerObject LayerObject in listBoxTumKatmanlarEnterpole.Items)
            {
                BufferLayerList.Add(LayerObject);
            }

            foreach (LayerObject LayerObject in listBoxKullanilacaklarEnterpole.Items)
            {
                enterpoleLayerList.Add(LayerObject);
            }
            AppSingleton.Instance().FinalEnterpolasyonKatmanListesi = enterpoleLayerList;

            AppSingleton.Instance().BufferLayerList = BufferLayerList;

            FillDatagrid();
        }
        public delegate void BufferLayersUpdated();
        public event BufferLayersUpdated layersUpdated;
        private void NotifyLayersUpdated()
        {
            if (layersUpdated != null)
            {
                layersUpdated();
            }
        }

        private void AddToDatagrid(LayerObject item)
        {
            List<string> hedefTipi = new List<string>();
            hedefTipi.Add("Eğim");
            hedefTipi.Add("Nüfus");
            List<string> metodTipi = new List<string>();
            metodTipi.Add("-");
            metodTipi.Add("IDW");
            metodTipi.Add("Kriging");
            List<string> fieldList = new List<string>();
            IFeatureLayer fLayer = item.layer as IFeatureLayer;
            for (int j = 0; j < fLayer.FeatureClass.Fields.FieldCount; j++)
            {
                IField field = fLayer.FeatureClass.Fields.get_Field(j);
                fieldList.Add(field.Name);
            }
            DataGridViewTextBoxCell tbKatmanAdi = new DataGridViewTextBoxCell();
            tbKatmanAdi.Value = fLayer.Name;
            DataGridViewComboBoxCell fieldListCombo = new DataGridViewComboBoxCell();
            fieldListCombo.DataSource = fieldList;
            DataGridViewComboBoxCell hedefTipiCombo = new DataGridViewComboBoxCell();
            hedefTipiCombo.DataSource = hedefTipi;
            hedefTipiCombo.Value = hedefTipi[0];
            DataGridViewComboBoxCell metodTipiCombo = new DataGridViewComboBoxCell();
            metodTipiCombo.DataSource = metodTipi;
            // metodTipiCombo.Value = metodTipi[0];

            DataGridViewRow dataGridRow = new DataGridViewRow();
            dataGridRow.Cells.Add(tbKatmanAdi);
            dataGridRow.Cells.Add(fieldListCombo);
            dataGridRow.Cells.Add(hedefTipiCombo);

            dataGridRow.Cells.Add(metodTipiCombo);
            dataGridView1.Rows.Add(dataGridRow);
        }
        private void BtnSolaHepsiniGecirEnterpole_Click(object sender, EventArgs e)
        {

            try
            {
                foreach (LayerObject st in listBoxKullanilacaklarEnterpole.Items)
                {
                    listBoxTumKatmanlarEnterpole.Items.Add(st);
                }
                // Remove the listbox2 added items from listbox1
                for (int i = listBoxKullanilacaklarEnterpole.Items.Count; i > 0; i--)
                {
                    listBoxKullanilacaklarEnterpole.Items.RemoveAt(i - 1);
                }

                UpdateKullanilacakBufferLayers();
                NotifyLayersUpdated();
            }
            catch
            { }
        }

        public UserControl Content
        {
            get { return this; }
        }

        public new void Load()
        {

        }

        public void Save()
        {

        }

        public void Cancel()
        {
            throw new NotImplementedException();
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
                    if (row.Cells[3].Value == null)
                    {
                        validationMessage = row.Cells[0].Value.ToString() + " katmanının enterpolasyon metodu belli değildir. Lütfen belirtiniz.";
                        return false;
                    }
                }

            }
            List<EnterpoleField> enterpoleListesi = new List<EnterpoleField>();
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                EnterpoleField field = new EnterpoleField();
                if (row.Cells[0].Value != null)
                {
                    string layerName = row.Cells[0].Value.ToString();
                    string attributeName = row.Cells[1].Value.ToString();
                    string hedef = row.Cells[2].Value.ToString();
                    string metod = row.Cells[3].Value.ToString();
                    foreach (LayerObject item in AppSingleton.Instance().FinalEnterpolasyonKatmanListesi)
                    {
                        if (item.layer.Name == layerName)
                        {
                            field.LayerObject = item;
                            field.Hedef = hedef;
                            field.EnterpoleMetodu = metod;
                            field.FieldName = attributeName;
                            enterpoleListesi.Add(field);
                        }
                    }

                }
            }
            AppSingleton.Instance().EnterpoleFieldListesi = enterpoleListesi;
            CheckDict();
            return true;
        }
        public void UpdateFieldList(string metodName, string layerName)
        {
            Dictionary<string, string> fieldList = new Dictionary<string, string>();
            switch (metodName)
            {
                case "Eğim":
                    fieldList.Add("0-5", "");
                    fieldList.Add("5-10", "");
                    fieldList.Add("10-20", "");
                    fieldList.Add("20-30", "");
                    fieldList.Add("30-40", "");
                    fieldList.Add("40-90", "");
                    break;
                case "Nüfus":
                    fieldList.Add("0-500", "");
                    fieldList.Add("500-2000", "");
                    fieldList.Add("2000-5000", "");
                    fieldList.Add("5000-10000", "");
                    fieldList.Add("10000-20000", "");
                    break;
                case "Yükseklik":
                    fieldList.Add("Yükseklik 1", "");
                    fieldList.Add("Yükseklik 2", "");
                    break;
                default:

                    break;
            }
            EnterpoleGrid fieldGrid = AppSingleton.Instance().EnterpoleGridDict[layerName];
            

            IFeatureLayer fLayer = fieldGrid.FieldLayerObject.LayerObject.layer as IFeatureLayer;

            fieldGrid.FieldLayerObject.FieldList = fieldList;
            AppSingleton.Instance().EnterpoleGridDict[layerName] = fieldGrid;

        }
        public void CheckDict()
        {
            if (AppSingleton.Instance().EnterpoleGridDict == null)
            {
                AppSingleton.Instance().EnterpoleGridDict = new Dictionary<string, EnterpoleGrid>();
            }

            for (int i = AppSingleton.Instance().EnterpoleGridDict.Count - 1; i >= 0; i--)
            {
                bool kontrol = false;
                KeyValuePair<string, EnterpoleGrid> peer = AppSingleton.Instance().EnterpoleGridDict.ElementAt(i);

                for (int j = dataGridView1.Rows.Count - 1; j >= 0; j--)
                {
                    if (dataGridView1.Rows[j].Cells[0].Value != null)
                    {
                        string layerName = dataGridView1.Rows[j].Cells[0].Value.ToString();
                        string attributeName = dataGridView1.Rows[j].Cells[1].Value.ToString();
                        string hedef = dataGridView1.Rows[j].Cells[2].Value.ToString();
                        string metod = dataGridView1.Rows[j].Cells[3].Value.ToString();
                        if (peer.Key == layerName)
                        {
                            kontrol = true;
                            EnterpoleGrid fieldGrid = peer.Value;
                            string fieldName = "";
                            foreach (EnterpoleField layerField in AppSingleton.Instance().EnterpoleFieldListesi)
                            {
                                if (layerField.LayerObject.layer.Name == layerName)
                                {
                                    fieldName = layerField.FieldName;
                                }
                            }
                            if (fieldGrid.Hedef != hedef)
                            {
                                AppSingleton.Instance().EnterpoleGridDict[layerName].Hedef = hedef;
                                UpdateFieldList(hedef, layerName);

                            }
                            if (fieldGrid.FieldName != fieldName)
                            {
                                AppSingleton.Instance().EnterpoleGridDict[layerName].FieldName = fieldName;

                            }
                            if (fieldGrid.EnterpoleMethod != metod)
                            {
                                AppSingleton.Instance().EnterpoleGridDict[layerName].EnterpoleMethod = metod;
                                //UpdateFieldList(fieldName, layerName);
                                
                            }
                            break;
                        }

                    }
                }
                if (kontrol == false)
                {
                    AppSingleton.Instance().EnterpoleGridDict.Remove(peer.Key);
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

                        for (int i = AppSingleton.Instance().EnterpoleGridDict.Count - 1; i >= 0; i--)
                        {
                            KeyValuePair<string, EnterpoleGrid> peer = AppSingleton.Instance().EnterpoleGridDict.ElementAt(i);

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
        private void AddToDictionaryAndWizardPages(DataGridViewRow item)
        {
            EnterpoleGrid fieldGrid = new EnterpoleGrid();
            FieldLayerObject fieldLayerObject = new FieldLayerObject();

            foreach (EnterpoleField layerField in AppSingleton.Instance().EnterpoleFieldListesi)
            {
                if (layerField.LayerObject.layer.Name == item.Cells[0].Value.ToString())
                {
                    fieldLayerObject.LayerObject = layerField.LayerObject;
                    fieldGrid.FieldLayerObject = fieldLayerObject;
                    fieldGrid.FieldName = layerField.FieldName;
                    fieldGrid.EnterpoleMethod = layerField.EnterpoleMetodu;
                    fieldGrid.Hedef = layerField.Hedef;
                    break;
                }
            }
            int itemCount = AppSingleton.Instance().EnterpoleItemCount + 1;
            fieldGrid.GridID = itemCount;
            AppSingleton.Instance().EnterpoleItemCount = itemCount;

            IFeatureLayer fLayer = fieldGrid.FieldLayerObject.LayerObject.layer as IFeatureLayer;

            AppSingleton.Instance().EnterpoleGridDict.Add(fLayer.Name, fieldGrid);
            UpdateFieldList(fieldGrid.Hedef,fLayer.Name);//UtilMethods.CountUniques((ITable)fLayer.FeatureClass, fieldGrid.FieldName);
            fieldGrid.SetLabel(fLayer.Name);
            AppSingleton.Instance().wizardHost.WizardPages.Add(itemCount, fieldGrid);

        }

    }
}
