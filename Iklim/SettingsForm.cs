﻿using System;
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
    public partial class SettingsForm : Form
    {
        public SettingsForm()
        {
            InitializeComponent();
        }

        private void btnSaveSettings_Click(object sender, EventArgs e)
        {
            settingsControl1.CheckForm();
             AppSingleton.Instance().SettingsControl = this.settingsControl1;
            this.Close();
        }

        private void SettingsForm_Load(object sender, EventArgs e)
        {
            settingsControl1.Load();           
        }
    }
}
