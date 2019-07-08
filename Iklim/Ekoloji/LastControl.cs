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
    public partial class LastControl : UserControl,IWizardPage
    {
        public LastControl()
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

        public void SetRichTextBoxLabel(string text)
        {
            if (rtbFinal.Text == "")
            {
                rtbFinal.Text = text;
            }
            else
            {
                rtbFinal.Text =rtbFinal.Text +"\n"+ text;
            }
            rtbFinal.SelectionLength = 0;
            rtbFinal.SelectionStart = rtbFinal.Text.Length;
            rtbFinal.ScrollToCaret();
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
            return true;
        }
    }
}
