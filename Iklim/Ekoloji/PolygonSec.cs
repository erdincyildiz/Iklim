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
using System.Collections;
using System.Runtime.InteropServices;

namespace Iklim
{
    public partial class PolygonSec : UserControl, IWizardPage
    {
        public void InitForm()
        {
            FillDatagrid();

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
                        foreach (LayerObject item in AppSingleton.Instance().PolygonLayerList)
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
            foreach (LayerObject item in AppSingleton.Instance().PolygonLayerList)
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
            for (int j = 0; j < fLayer.FeatureClass.Fields.FieldCount; j++)
            {
                IField field = fLayer.FeatureClass.Fields.get_Field(j);
                fieldList.Add(field.Name);
            }
            DataGridViewTextBoxCell tbKatmanAdi = new DataGridViewTextBoxCell();
            tbKatmanAdi.Value = fLayer.Name;
            DataGridViewComboBoxCell fieldListCombo = new DataGridViewComboBoxCell();
            fieldListCombo.DataSource = fieldList;
            // metodTipiCombo.Value = metodTipi[0];

            DataGridViewRow dataGridRow = new DataGridViewRow();
            dataGridRow.Cells.Add(tbKatmanAdi);
            dataGridRow.Cells.Add(fieldListCombo);
            dataGridView1.Rows.Add(dataGridRow);
        }
        public PolygonSec()
        {
            InitializeComponent();
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
        //Dictionary<LayerObject, string> dict = new Dictionary<LayerObject, string>();

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
            List<LayerField> poligonListesi = new List<LayerField>();
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                LayerField field = new LayerField();
                if (row.Cells[0].Value != null)
                {
                    string layerName = row.Cells[0].Value.ToString();
                    foreach (LayerObject item in AppSingleton.Instance().PolygonLayerList)
                    {
                        if (item.layer.Name == layerName)
                        {
                            field.LayerObject = item;
                            field.FieldName = row.Cells[1].Value.ToString();
                            poligonListesi.Add(field);
                        }
                    }

                }
            }
            AppSingleton.Instance().PoligonFieldListesi = poligonListesi;
            CheckDict();
            return true;
        }
        public void UpdateFieldList(string FieldName,string layerName)
        {
            FieldGrid fieldGrid = AppSingleton.Instance().PolyGridDict[layerName];
            Dictionary<string, string> fieldList = new Dictionary<string, string>();

            IFeatureLayer fLayer = fieldGrid.FieldLayerObject.LayerObject.layer as IFeatureLayer;

            fieldGrid.FieldLayerObject.FieldList =UtilMethods.CountUniques((ITable)fLayer.FeatureClass, FieldName);
            AppSingleton.Instance().PolyGridDict[layerName] = fieldGrid;
           
        }
        public void CheckDict()
        {
            if (AppSingleton.Instance().PolyGridDict == null)
            {
                AppSingleton.Instance().PolyGridDict = new Dictionary<string, FieldGrid>();
            }

            for (int i = AppSingleton.Instance().PolyGridDict.Count - 1; i >= 0; i--)
            {
                bool kontrol = false;
                KeyValuePair<string, FieldGrid> peer = AppSingleton.Instance().PolyGridDict.ElementAt(i);

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
                            foreach (LayerField layerField in AppSingleton.Instance().PoligonFieldListesi)
                            {
                                if (layerField.LayerObject.layer.Name==layerName)
                                {
                                    fieldName = layerField.FieldName;
                                }
                            }
                            if (fieldGrid.FieldName!=fieldName)
                            {
                                AppSingleton.Instance().PolyGridDict[layerName].FieldName = fieldName;
                                UpdateFieldList(fieldName, layerName);
                            }
                            break;
                        }
                        
                    }
                }
                if (kontrol == false)
                {
                    AppSingleton.Instance().PolyGridDict.Remove(peer.Key);
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

                        for (int i = AppSingleton.Instance().PolyGridDict.Count - 1; i >= 0; i--)
                        {
                            KeyValuePair<string, FieldGrid> peer = AppSingleton.Instance().PolyGridDict.ElementAt(i);

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
            FieldGrid fieldGrid = new FieldGrid();
            FieldLayerObject fieldLayerObject = new FieldLayerObject();

            foreach (LayerField layerField in AppSingleton.Instance().PoligonFieldListesi)
            {
                if (layerField.LayerObject.layer.Name == item.Cells[0].Value.ToString())
                {
                    fieldLayerObject.LayerObject = layerField.LayerObject;
                    fieldGrid.FieldLayerObject = fieldLayerObject;
                    fieldGrid.FieldName = layerField.FieldName;
                    break;
                }
            }
            int itemCount = AppSingleton.Instance().PolyItemCount+1;
            fieldGrid.GridID = itemCount;
            AppSingleton.Instance().PolyItemCount = itemCount;

            IFeatureLayer fLayer = fieldGrid.FieldLayerObject.LayerObject.layer as IFeatureLayer;
            
            AppSingleton.Instance().PolyGridDict.Add(fLayer.Name,fieldGrid);
            fieldGrid.FieldLayerObject.FieldList =UtilMethods.CountUniques((ITable)fLayer.FeatureClass, fieldGrid.FieldName);
            fieldGrid.SetLabel(fLayer.Name);
            AppSingleton.Instance().wizardHost.WizardPages.Add(itemCount,fieldGrid);

        }
       
    }
}
