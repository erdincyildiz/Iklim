using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Iklim
{
    public partial class WizardHost : Form
    {
        private const string VALIDATION_MESSAGE = "Current page is not valid. Please fill in required information";

        #region Properties

        public WizardPageCollection WizardPages { get; set; }
        public bool ShowFirstButton
        {
            get { return btnFirst.Visible; }
            set { btnFirst.Visible = value; }
        }
        public bool ShowLastButton
        {
            get { return btnLast.Visible; }
            set { btnLast.Visible = value; }
        }

        private bool navigationEnabled = true;
        public bool NavigationEnabled
        {
            get { return navigationEnabled; }
            set
            {
                btnFirst.Enabled = value;
                btnPrevious.Enabled = value;
                btnNext.Enabled = value;
                btnLast.Enabled = value;
                navigationEnabled = value;
            }
        }

        #endregion

        #region Delegates & Events

        public delegate void WizardCompletedEventHandler();
        public event WizardCompletedEventHandler WizardCompleted;

        #endregion

        #region Constructor & Window Event Handlers

        public WizardHost()
        {
            InitializeComponent();
            WizardPages = new WizardPageCollection();
            WizardPages.WizardPageLocationChanged += new WizardPageCollection.WizardPageLocationChangedEventHanlder(WizardPages_WizardPageLocationChanged);
        }

        void WizardPages_WizardPageLocationChanged(WizardPageLocationChangedEventArgs e)
        {
            LoadNextPage(e.PageIndex, e.PreviousPageIndex, true);
        }

        #endregion

        #region Private Methods

        private void NotifyWizardCompleted()
        {
            if (WizardCompleted != null)
            {
                OnWizardCompleted();
                WizardCompleted();
            }
        }
        private void OnWizardCompleted()
        {
            WizardPages.LastPage.Save();
            WizardPages.Reset();
            this.DialogResult = DialogResult.OK;
        }

        public void UpdateNavigation()
        {
            #region Reset

            btnNext.Enabled = true;
            btnNext.Visible = true;

            btnLast.Text = "Sonuncu >>";
            if (ShowLastButton)
            {
                btnLast.Enabled = true;
            }
            else
            {
                btnLast.Enabled = false;
            }

            #endregion

            bool canMoveNext = WizardPages.CanMoveNext;
            bool canMovePrevious = WizardPages.CanMovePrevious;

            btnPrevious.Enabled = canMovePrevious;
            btnFirst.Enabled = canMovePrevious;

            if (canMoveNext)
            {
                btnNext.Text = "Sonraki >";
                btnNext.Enabled = true;

                if (ShowLastButton)
                {
                    btnLast.Enabled = true;
                }
            }
            else
            {
                if (ShowLastButton)
                {
                    btnLast.Text = "İşleme Başla";
                    btnNext.Visible = false;
                }
                else
                {
                    btnNext.Text = "İşleme Başla";
                    btnNext.Visible = true;
                }
            }
        }

        private bool CheckPageIsValid()
        {
            if (!WizardPages.CurrentPage.PageValid)
            {
                MessageBox.Show(
                    string.Concat(VALIDATION_MESSAGE, Environment.NewLine, Environment.NewLine, WizardPages.CurrentPage.ValidationMessage),
                    "Details Required",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation);
                return false;
            }
            return true;
        }

        #endregion

        #region Public Methods

        public void LoadWizard()
        {
            WizardPages.MovePageFirst();
        }
        public void LoadNextPage(int pageIndex, int previousPageIndex, bool savePreviousPage)
        {
            if (pageIndex != -1)
            {
                contentPanel.Controls.Clear();
                contentPanel.Controls.Add(WizardPages[pageIndex].Content);
                if (savePreviousPage && previousPageIndex != -1)
                {
                    WizardPages[previousPageIndex].Save();
                }
                WizardPages[pageIndex].Load();
                UpdateNavigation();
            }
        }

        #endregion

        #region Event Handlers

        private void btnFirst_Click(object sender, EventArgs e)
        {
            //if (!CheckPageIsValid()) //Maybe doesn't matter if move back; only matters if move forward
            //{ return; }

            WizardPages.MovePageFirst();
        }
        private void btnPrevious_Click(object sender, EventArgs e)
        {
            //if (!CheckPageIsValid()) //Maybe doesn't matter if move back; only matters if move forward
            //{ return; }

            WizardPages.MovePagePrevious();
        }
        private void btnNext_Click(object sender, EventArgs e)
        {
            if (!CheckPageIsValid())
            { return; }
            if (AppSingleton.Instance().allLayers != null)
            {
                if (AppSingleton.Instance().allLayers.Count == 0)
                {
                    MessageBox.Show("Lütfen işlem için en az bir katman seçiniz");
                    return;
                }

            }
            else
            {
                MessageBox.Show("Lütfen işlem için en az bir katman seçiniz");
                return;
            }
            if (AppSingleton.Instance().SinirLayer == null)
            {
                MessageBox.Show("Lütfen öncelikle sınır katmanını seçiniz");
                return;
            }

            if (WizardPages.CanMoveNext)
            {
                WizardPages.MovePageNext();
            }
            else
            {

                bool check = WizardPages.CurrentPage.CheckForm();
                if (!check)
                {
                    MessageBox.Show(WizardPages.CurrentPage.ValidationMessage);
                    return ;
                }
                
                //This is the finish button and it has been clicked
                NotifyWizardCompleted();
            }
        }
        private void btnLast_Click(object sender, EventArgs e)
        {
            if (!CheckPageIsValid())
            { return; }

            if (WizardPages.CanMoveNext)
            {
                WizardPages.MovePageLast();
            }
            else
            {
                //This is the finish button and it has been clicked
                NotifyWizardCompleted();
            }
        }

        #endregion
    }
}