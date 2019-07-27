using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Iklim
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void btnErinc_Click(object sender, EventArgs e)
        {
            ErincForm erincForm = new ErincForm();
            erincForm.ShowDialog();
        }

        private void btnAydeniz_Click(object sender, EventArgs e)
        {
            AydenizForm aydenizForm = new AydenizForm();
            aydenizForm.ShowDialog();
        }

        private void btnKoppen_Click(object sender, EventArgs e)
        {
            KoppenForm koppenForm = new KoppenForm();
            koppenForm.ShowDialog();
        }

        private void btnThornwaithe_Click(object sender, EventArgs e)
        {
            ThornwaiteForm thornForm = new ThornwaiteForm();
            thornForm.ShowDialog();
        }

        private void btnKoppenGreiger_Click(object sender, EventArgs e)
        {
            DeMartonneForm deMartonneForm = new DeMartonneForm();
            deMartonneForm.ShowDialog();
        }

        private void btnTrewertha_Click(object sender, EventArgs e)
        {
            DeMArtonnGotmannForm demartonForm = new DeMArtonnGotmannForm();
            demartonForm.ShowDialog();
        }

        private void btnKoppenSablon_Click(object sender, EventArgs e)
        {
            KoppenFormSablon sablonKoppen = new KoppenFormSablon();
            sablonKoppen.ShowDialog();
        }

        private void btnDMGSablon_Click(object sender, EventArgs e)
        {
            DeMArtonnGotmannFormSablon demartonForm = new DeMArtonnGotmannFormSablon();
            demartonForm.ShowDialog();
        }
    }
}
