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
    public partial class KoppenFormSablon : Form
    {
        public KoppenFormSablon()
        {
            InitializeComponent();
            ucKoppen.Init();
        }
    }
}
