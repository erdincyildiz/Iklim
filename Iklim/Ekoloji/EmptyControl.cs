using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ESRI.ArcGIS.Carto;

namespace Iklim
{
    public partial class EmptyControl : UserControl,IWizardPage
    {
        public EmptyControl()
        {
            InitializeComponent();
        }

        public UserControl Content
        {
            get { return this; }
        }

        public new void Load()
        {
             FillDatagrid();

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
                        foreach (LayerObject item in AppSingleton.Instance().allLayers)
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
            foreach (LayerObject item in AppSingleton.Instance().allLayers)
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
        private void AddToDatagrid(LayerObject item)
        {

            List<string> fieldList = new List<string>();
            IFeatureLayer fLayer = item.layer as IFeatureLayer;
            List<string> normalizasyonTipi = new List<string>();

            normalizasyonTipi.Add("x/Maks");
            normalizasyonTipi.Add("1-(x/Maks)");
            normalizasyonTipi.Add("(x-Min)/(Maks-Min)");
            normalizasyonTipi.Add("(Maks-x)/(Maks-Min)");
            DataGridViewTextBoxCell tbKatmanAdi = new DataGridViewTextBoxCell();
            tbKatmanAdi.Value = fLayer.Name;
           
            DataGridViewComboBoxCell mormalCombo = new DataGridViewComboBoxCell();
            mormalCombo.DataSource = normalizasyonTipi;
            // metodTipiCombo.Value = metodTipi[0];

            DataGridViewRow dataGridRow = new DataGridViewRow();
            dataGridRow.Cells.Add(tbKatmanAdi);
            dataGridRow.Cells.Add(mormalCombo);
            dataGridView1.Rows.Add(dataGridRow);
        }
       


        public bool CheckForm()
        {
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (row.Cells[0].Value != null)
                {
                    if (row.Cells[1].Value == null || row.Cells[1].Value == "")
                    {
                        validationMessage = row.Cells[0].Value.ToString() + " katmanının değeri belli değildir. Lütfen belirtiniz.";
                        return false;
                    }
                    
                }

            }
            List<LayerType> tipListesi = new List<LayerType>();
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                LayerType field = new LayerType();
                if (row.Cells[0].Value != null)
                {
                    string layerName = row.Cells[0].Value.ToString();
                    foreach (LayerObject item in AppSingleton.Instance().allLayers)
                    {
                        if (item.layer.Name == layerName)
                        {
                            field.LayerObject = item;
                            field.Metod = row.Cells[1].Value.ToString();
                            tipListesi.Add(field);
                        }
                    }

                }
            }
            AppSingleton.Instance().TumKatmanlarListesi = tipListesi;
            CheckDict();
            return true;
        }
        
        public void CheckDict()
        {
            if (AppSingleton.Instance().AllLayersDict == null)
            {
                AppSingleton.Instance().AllLayersDict = new Dictionary<string, LayerType>();
            }

            for (int i = AppSingleton.Instance().AllLayersDict.Count - 1; i >= 0; i--)
            {
                bool kontrol = false;
                KeyValuePair<string, LayerType> peer = AppSingleton.Instance().AllLayersDict.ElementAt(i);

                for (int j = dataGridView1.Rows.Count - 1; j >= 0; j--)
                {
                    if (dataGridView1.Rows[j].Cells[0].Value != null)
                    {
                        string layerName = dataGridView1.Rows[j].Cells[0].Value.ToString();
                        if (peer.Key == layerName)
                        {
                            kontrol = true;
                            LayerType fieldGrid = peer.Value;
                            string agirlik = "";
                            string metod = "";
                            foreach (LayerType layerType in AppSingleton.Instance().TumKatmanlarListesi)
                            {
                                if (layerType.LayerObject.layer.Name == layerName)
                                {
                                   
                                    metod = layerType.Metod;
                                }
                            }
                            if (fieldGrid.Metod!=metod)
                            {
                                AppSingleton.Instance().AllLayersDict[layerName].Metod = metod;
                            }
                            break;
                        }

                    }
                }
                if (kontrol == false)
                {
                    AppSingleton.Instance().AllLayersDict.Remove(peer.Key);
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

                        for (int i = AppSingleton.Instance().AllLayersDict.Count - 1; i >= 0; i--)
                        {
                            KeyValuePair<string, LayerType> peer = AppSingleton.Instance().AllLayersDict.ElementAt(i);

                            layerName = dataGridView1.Rows[j].Cells[0].Value.ToString();

                            if (peer.Key == layerName)
                            {
                                kontrol = true;
                                break;
                            }
                        }

                        if (kontrol == false)
                        {
                            AddToDictionary(dataGridView1.Rows[j]);
                        }
                    }
                }
            }
        }
        private void AddToDictionary(DataGridViewRow item)
        {
            LayerType fieldGrid = new LayerType();
            FieldLayerObject fieldLayerObject = new FieldLayerObject();

            foreach (LayerType layerType in AppSingleton.Instance().TumKatmanlarListesi)
            {
                if (layerType.LayerObject.layer.Name == item.Cells[0].Value.ToString())
                {
                    fieldLayerObject.LayerObject = layerType.LayerObject;
                   
                    fieldGrid.Metod = item.Cells[1].Value.ToString();
                    fieldGrid.LayerObject = layerType.LayerObject;
                    break;
                }
            }
            int itemCount = AppSingleton.Instance().PolyItemCount + 1;
           
            IFeatureLayer fLayer = fieldGrid.LayerObject.layer as IFeatureLayer;

            AppSingleton.Instance().AllLayersDict.Add(fLayer.Name, fieldGrid);
          

        }

        private void button1_Click(object sender, EventArgs e)
        {
        }
    }
}
