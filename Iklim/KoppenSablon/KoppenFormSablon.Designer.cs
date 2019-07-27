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
            this.ucKoppenSablon = new Iklim.ucKoppenSablon();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // ucKoppenSablon
            // 
            this.ucKoppenSablon.Location = new System.Drawing.Point(-1, 9);
            this.ucKoppenSablon.Name = "ucKoppenSablon";
            this.ucKoppenSablon.Size = new System.Drawing.Size(698, 215);
            this.ucKoppenSablon.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 207);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(144, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Tuğba MEMİŞOĞLU @2019";
            // 
            // KoppenFormSablon
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(701, 229);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.ucKoppenSablon);
            this.Name = "KoppenFormSablon";
            this.Text = "Köppen Yöntemi İle İklim Sınırlarının Belirlenmesi";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ucKoppenSablon ucKoppenSablon;
        private System.Windows.Forms.Label label2;
    }
}