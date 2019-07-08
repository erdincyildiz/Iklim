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
            erincForm.Show();
        }
    }
}
