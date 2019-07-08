using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Iklim
{
    public partial class FieldGrid : UserControl, IWizardPage
    {
        public FieldGrid()
        {
            InitializeComponent();
        }
        public int GridID { get; set; }
        public FieldLayerObject FieldLayerObject { get; set; }
        public string FieldName { get; set; }
        public UserControl Content
        {
            get { return this; }
        }

        public new void Load()
        {
            FillAttributeDatagrid(FieldLayerObject.FieldList);
        }

        private void FillAttributeDatagrid(Dictionary<string, string> stringList)
        {
            for (int i = 0; i < dataGridView2.Rows.Count ; i++)
            {
                dataGridView2.Rows.RemoveAt(i);
                i--;               
            }
            foreach (KeyValuePair<string, string> pair in stringList)
            {

                DataGridViewTextBoxCell oznitelikTipi = new DataGridViewTextBoxCell();
                oznitelikTipi.Value = pair.Key;
                DataGridViewRow dataGridRow = new DataGridViewRow();
                DataGridViewTextBoxCell oznitelikDegeri = new DataGridViewTextBoxCell();
                oznitelikDegeri.Value = pair.Value;
                dataGridRow.Cells.Add(oznitelikTipi);
                dataGridRow.Cells.Add(oznitelikDegeri);
                dataGridView2.Rows.Add(dataGridRow);
            }
        }
        public void SetLabel(string labelText)
        {
            label2.Text = "\" "+labelText+" \" Katmanı İçin Ağırlıkları Belirleyiniz";
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
            try
            {
                foreach (DataGridViewRow row in dataGridView2.Rows)
                {
                    if (row.Cells[0].Value != null)
                    {
                        FieldLayerObject.FieldList[row.Cells[0].Value.ToString()] = row.Cells[1].Value.ToString();
                    }
                }
                foreach (DataGridViewRow row in dataGridView2.Rows)
                {
                    if (row.Cells[0].Value != null)
                    {
                        if (row.Cells[1].Value == "")
                        {
                            validationMessage = row.Cells[0].Value.ToString() + " tipinin değeri belli değildir. Lütfen belirleyiniz.";
                            return false;
                        }
                        if (row.Cells[1].Value == null)
                        {
                            validationMessage = row.Cells[0].Value.ToString() + " tipinin değeri belli değildir. Lütfen belirleyiniz.";
                            return false;
                        }
                    }

                }
            }
            catch (Exception ex)
            {
            }
            return true;
        }
    }
}
