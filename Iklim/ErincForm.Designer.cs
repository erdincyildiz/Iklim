namespace Iklim
{
    partial class ErincForm
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
            this.ucErinc = new UcErinc();
            this.SuspendLayout();
            // 
            // ucErinc
            // 
            this.ucErinc.Location = new System.Drawing.Point(6, 6);
            this.ucErinc.Name = "ucErinc";
            this.ucErinc.Size = new System.Drawing.Size(760, 402);
            this.ucErinc.TabIndex = 0;
            // 
            // ErincForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(771, 423);
            this.Controls.Add(this.ucErinc);
            this.Name = "ErincForm";
            this.Text = "Erinc";
            this.ResumeLayout(false);

        }

        #endregion

        private UcErinc ucErinc;
    }
}