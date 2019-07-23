namespace Iklim
{
    partial class ToolForm
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
            this.ucTools1 = new Iklim.ucTools();
            this.SuspendLayout();
            // 
            // ucTools1
            // 
            this.ucTools1.Location = new System.Drawing.Point(19, 3);
            this.ucTools1.Name = "ucTools1";
            this.ucTools1.Size = new System.Drawing.Size(638, 366);
            this.ucTools1.TabIndex = 0;
            // 
            // ToolForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(678, 373);
            this.Controls.Add(this.ucTools1);
            this.Name = "ToolForm";
            this.Text = "ToolForm";
            this.ResumeLayout(false);

        }

        #endregion

        private ucTools ucTools1;
    }
}