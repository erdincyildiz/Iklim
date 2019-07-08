namespace Iklim
{
    partial class LastControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.rtbFinal = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // rtbFinal
            // 
            this.rtbFinal.Location = new System.Drawing.Point(50, 38);
            this.rtbFinal.Name = "rtbFinal";
            this.rtbFinal.Size = new System.Drawing.Size(587, 348);
            this.rtbFinal.TabIndex = 0;
            this.rtbFinal.Text = "";
            // 
            // LastControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.rtbFinal);
            this.Name = "LastControl";
            this.Size = new System.Drawing.Size(682, 449);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox rtbFinal;
    }
}
