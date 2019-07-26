namespace Iklim
{
    partial class KoppenFormSablon
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
            this.ucKoppen = new Iklim.ucKoppen();
            this.SuspendLayout();
            // 
            // ucKoppen
            // 
            this.ucKoppen.Location = new System.Drawing.Point(-3, 1);
            this.ucKoppen.Name = "ucKoppen";
            this.ucKoppen.Size = new System.Drawing.Size(698, 450);
            this.ucKoppen.TabIndex = 0;
            // 
            // KoppenForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(694, 452);
            this.Controls.Add(this.ucKoppen);
            this.Name = "KoppenForm";
            this.Text = "KoppenForm";
            this.ResumeLayout(false);

        }

        #endregion

        private ucKoppen ucKoppen;
    }
}