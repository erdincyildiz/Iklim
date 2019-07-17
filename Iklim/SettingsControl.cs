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
    public partial class SettingsControl : UserControl
    {
        public SettingsControl()
        {
            InitializeComponent();
        }

        public UserControl Content
        {
            get { return this; }
        }

        public new void Load()
        {
            if( AppSingleton.Instance().CellSize == 0)
            {
                AppSingleton.Instance().CellSize = 10;
            }

            cmbTinToRasterMethod.SelectedIndex = 0;
            cmbSemiVariogramKriging.SelectedIndex = 0;
            cmbYarıcapIDW.SelectedIndex = 0;
            cmbYarıcapKriging.SelectedIndex = 0;
            cmbDataType.SelectedIndex = 0;
            txtPiksel.Text = AppSingleton.Instance().CellSize.ToString() ;
            cmbYontem.SelectedIndex = 0;
           
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
            if (txtPiksel.Text != "")
            {
                AppSingleton.Instance().CellSize = Convert.ToDouble(txtPiksel.Text);
            }
            AppSingleton.Instance().AralariEkle = chbAra.Checked;
            AppSingleton.Instance().TinRasterMethod = cmbTinToRasterMethod.SelectedItem.ToString();
            AppSingleton.Instance().TinRasterDataType = cmbDataType.SelectedItem.ToString();
            AppSingleton.Instance().NodataValue = Convert.ToInt32(txtNoData.Text);
            if (cmbYarıcapIDW.SelectedIndex == 0)
            {
                AppSingleton.Instance().IDWYaricap = cmbYarıcapIDW.SelectedItem.ToString() + " " + txtNoktaSayisiIDW.Text + " " + txtMaxUzaklikIDW.Text;
            }
            else
            {
                AppSingleton.Instance().IDWYaricap = cmbYarıcapIDW.SelectedItem.ToString() + " " + txtMesafeIDW.Text + " " + txtMinNoktaIDW.Text;
            }
            if (cmbYarıcapKriging.SelectedIndex == 0)
            {
                AppSingleton.Instance().KrigingYaricap = cmbYarıcapKriging.SelectedItem.ToString() + " " + txtNoktaSayisiKriging.Text + " " + txtMaxUzaklikKriging.Text;
            }
            else
            {
                AppSingleton.Instance().KrigingYaricap = cmbYarıcapKriging.SelectedItem.ToString() + " " + txtMesafeKriging.Text + " " + txtMinNoktaKriging.Text;
            }
            AppSingleton.Instance().KrigingSemiVariogram = cmbSemiVariogramKriging.SelectedItem.ToString();
            AppSingleton.Instance().KrigingLagSayisi = txtLagKriging.Text;
            AppSingleton.Instance().UygulamaYontemi = cmbYontem.SelectedItem.ToString();
            return true;
        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbYarıcapIDW.SelectedItem != null)
            {
                if (cmbYarıcapIDW.SelectedItem.ToString() == "Variable")
                {
                    txtNoktaSayisiIDW.Enabled = true;
                    txtMaxUzaklikIDW.Enabled = true;
                    txtMesafeIDW.Enabled = false;
                    txtMinNoktaIDW.Enabled = false;
                }
                if (cmbYarıcapIDW.SelectedItem.ToString() == "Fixed")
                {
                    txtNoktaSayisiIDW.Enabled = false;
                    txtMaxUzaklikIDW.Enabled = false;
                    txtMesafeIDW.Enabled = true;
                    txtMinNoktaIDW.Enabled = true;
                }
                else
                {
                    txtNoktaSayisiIDW.Enabled = false;
                    txtMaxUzaklikIDW.Enabled = false;
                    txtMesafeIDW.Enabled = false;
                    txtMinNoktaIDW.Enabled = false;
                }
            }

        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (cmbYarıcapKriging.SelectedItem != null)
            {
                if (cmbYarıcapKriging.SelectedItem.ToString() == "Variable")
                {
                    txtNoktaSayisiKriging.Enabled = true;
                    txtMaxUzaklikKriging.Enabled = true;
                    txtMesafeKriging.Enabled = false;
                    txtMinNoktaKriging.Enabled = false;
                }
                if (cmbYarıcapKriging.SelectedItem.ToString() == "Fixed")
                {
                    txtNoktaSayisiKriging.Enabled = false;
                    txtMaxUzaklikKriging.Enabled = false;
                    txtMesafeKriging.Enabled = true;
                    txtMinNoktaKriging.Enabled = true;
                }
                else
                {
                    txtNoktaSayisiKriging.Enabled = false;
                    txtMaxUzaklikKriging.Enabled = false;
                    txtMesafeKriging.Enabled = false;
                    txtMinNoktaKriging.Enabled = false;
                }
            }

        }


    }
}
