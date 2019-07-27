namespace Iklim
{
    partial class DeMArtonnGotmannFormSablon
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
            this.ucDeMartonneGottmanSablon = new Iklim.ucDeMartonneGottmanSablon();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // ucDeMartonneGottmanSablon
            // 
            this.ucDeMartonneGottmanSablon.Location = new System.Drawing.Point(12, 20);
            this.ucDeMartonneGottmanSablon.Name = "ucDeMartonneGottmanSablon";
            this.ucDeMartonneGottmanSablon.Size = new System.Drawing.Size(694, 412);
            this.ucDeMartonneGottmanSablon.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 419);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(144, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Tuğba MEMİŞOĞLU @2019";
            // 
            // DeMArtonnGotmannFormSablon
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(725, 444);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.ucDeMartonneGottmanSablon);
            this.Name = "DeMArtonnGotmannFormSablon";
            this.Text = "De Martonne - Gottman Yöntemi İle İklim Sınırlarının Belirlenmesi";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ucDeMartonneGottmanSablon ucDeMartonneGottmanSablon;
        private System.Windows.Forms.Label label2;
    }
}