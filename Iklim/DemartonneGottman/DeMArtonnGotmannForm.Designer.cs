namespace Iklim
{
    partial class DeMArtonnGotmannForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.ucDeMartonneGottman = new Iklim.ucDeMartonneGottman();
            this.SuspendLayout();
            // 
            // ucDeMartonneGottman
            // 
            this.ucDeMartonneGottman.Location = new System.Drawing.Point(12, 20);
            this.ucDeMartonneGottman.Name = "ucDeMartonneGottman";
            this.ucDeMartonneGottman.Size = new System.Drawing.Size(694, 412);
            this.ucDeMartonneGottman.TabIndex = 0;
            // 
            // DeMArtonnGotmannForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(725, 444);
            this.Controls.Add(this.ucDeMartonneGottman);
            this.Name = "DeMArtonnGotmannForm";
            this.Text = "DeMArtonnGotmannForm";
            this.ResumeLayout(false);

        }

        #endregion

        private ucDeMartonneGottman ucDeMartonneGottman;
    }
}