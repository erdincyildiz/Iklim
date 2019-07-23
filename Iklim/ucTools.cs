﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Iklim
{
    public partial class ucTools : UserControl
    {
        public ucTools()
        {
            InitializeComponent();
        }

        private void btnXYTable_Click(object sender, EventArgs e)
        {
            XYEventTableForm XYEventTableForm = new XYEventTableForm();
            XYEventTableForm.ShowDialog();
        }

        private void btnTampon_Click(object sender, EventArgs e)
        {
            BufferForm form = new BufferForm();
            form.ShowDialog();
        }
    }
}
