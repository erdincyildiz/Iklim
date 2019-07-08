namespace Iklim
{
    public partial class UcErinc
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbVeriSeti = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbCalismaAlani = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.cmbOrtSic = new System.Windows.Forms.ComboBox();
            this.cmbOrtYag = new System.Windows.Forms.ComboBox();
            this.btnOk = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial Black", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(185, 0);
            this.label1.MaximumSize = new System.Drawing.Size(430, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(408, 54);
            this.label1.TabIndex = 0;
            this.label1.Text = "Erinç Metodu ile İklim Sınırları Tesbiti için Meteoroloji Veri Seti Seçiniz";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(24, 79);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(141, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Meteoroloji Veri Seti Katmanı";
            // 
            // cmbVeriSeti
            // 
            this.cmbVeriSeti.FormattingEnabled = true;
            this.cmbVeriSeti.Location = new System.Drawing.Point(27, 106);
            this.cmbVeriSeti.Name = "cmbVeriSeti";
            this.cmbVeriSeti.Size = new System.Drawing.Size(121, 21);
            this.cmbVeriSeti.TabIndex = 2;
            this.cmbVeriSeti.SelectedIndexChanged += new System.EventHandler(this.cmbVeriSeti_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(27, 128);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(146, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Çalışma Alanı Sınırları Katmanı";
            // 
            // cmbCalismaAlani
            // 
            this.cmbCalismaAlani.FormattingEnabled = true;
            this.cmbCalismaAlani.Location = new System.Drawing.Point(27, 154);
            this.cmbCalismaAlani.Name = "cmbCalismaAlani";
            this.cmbCalismaAlani.Size = new System.Drawing.Size(121, 21);
            this.cmbCalismaAlani.TabIndex = 4;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(238, 106);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(89, 13);
            this.label6.TabIndex = 7;
            this.label6.Text = "Ortalama Sıcaklık";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(238, 154);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(78, 13);
            this.label7.TabIndex = 8;
            this.label7.Text = "Ortalama Yağış";
            // 
            // cmbOrtSic
            // 
            this.cmbOrtSic.FormattingEnabled = true;
            this.cmbOrtSic.Location = new System.Drawing.Point(360, 103);
            this.cmbOrtSic.Name = "cmbOrtSic";
            this.cmbOrtSic.Size = new System.Drawing.Size(121, 21);
            this.cmbOrtSic.TabIndex = 11;
            // 
            // cmbOrtYag
            // 
            this.cmbOrtYag.FormattingEnabled = true;
            this.cmbOrtYag.Location = new System.Drawing.Point(360, 151);
            this.cmbOrtYag.Name = "cmbOrtYag";
            this.cmbOrtYag.Size = new System.Drawing.Size(121, 21);
            this.cmbOrtYag.TabIndex = 12;
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(360, 207);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 23);
            this.btnOk.TabIndex = 13;
            this.btnOk.Text = "Çalıştır";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // UcErinc
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.cmbOrtYag);
            this.Controls.Add(this.cmbOrtSic);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.cmbCalismaAlani);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cmbVeriSeti);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "UcErinc";
            this.Size = new System.Drawing.Size(757, 402);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbVeriSeti;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmbCalismaAlani;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cmbOrtSic;
        private System.Windows.Forms.ComboBox cmbOrtYag;
        private System.Windows.Forms.Button btnOk;
    }
}
