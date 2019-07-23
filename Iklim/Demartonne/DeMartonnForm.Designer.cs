namespace Iklim
{
    partial class DeMartonneForm
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
            this.ucDeMartonne = new Iklim.ucDeMartonne();
            this.SuspendLayout();
            // 
            // ucDeMartonne
            // 
            this.ucDeMartonne.Location = new System.Drawing.Point(25, 31);
            this.ucDeMartonne.Name = "ucDeMartonne";
            this.ucDeMartonne.Size = new System.Drawing.Size(694, 412);
            this.ucDeMartonne.TabIndex = 0;
            // 
            // deMartonneForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(748, 455);
            this.Controls.Add(this.ucDeMartonne);
            this.Name = "deMartonneForm";
            this.Text = "deMartonneForm";
            this.ResumeLayout(false);

        }

        #endregion

        private Iklim.ucDeMartonne ucDeMartonne;
    }
}