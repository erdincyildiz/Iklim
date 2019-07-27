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
            this.label2 = new System.Windows.Forms.Label();
            this.cmbVeriSeti = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbCalismaAlani = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.cmbOrtSic = new System.Windows.Forms.ComboBox();
            this.cmbOrtYag = new System.Windows.Forms.ComboBox();
            this.btnOk = new System.Windows.Forms.Button();
            this.grpbxInfoErinc = new System.Windows.Forms.GroupBox();
            this.lblInfo4 = new System.Windows.Forms.Label();
            this.lblInfo6 = new System.Windows.Forms.Label();
            this.lblInfo5 = new System.Windows.Forms.Label();
            this.lblInfo3 = new System.Windows.Forms.Label();
            this.lblInfo2 = new System.Windows.Forms.Label();
            this.lblInfo1 = new System.Windows.Forms.Label();
            this.grpbxInputErinc = new System.Windows.Forms.GroupBox();
            this.tpSonuc = new Iklim.TextProgressBar();
            this.grpbxInfoErinc.SuspendLayout();
            this.grpbxInputErinc.SuspendLayout();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(6, 25);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(147, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Meteoroloji Veri Seti Katmanı: ";
            // 
            // cmbVeriSeti
            // 
            this.cmbVeriSeti.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbVeriSeti.FormattingEnabled = true;
            this.cmbVeriSeti.Location = new System.Drawing.Point(261, 22);
            this.cmbVeriSeti.Name = "cmbVeriSeti";
            this.cmbVeriSeti.Size = new System.Drawing.Size(270, 21);
            this.cmbVeriSeti.TabIndex = 2;
            this.cmbVeriSeti.SelectedIndexChanged += new System.EventHandler(this.cmbVeriSeti_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(6, 106);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(131, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Proje Analiz Sınırı Katmanı:";
            // 
            // cmbCalismaAlani
            // 
            this.cmbCalismaAlani.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbCalismaAlani.FormattingEnabled = true;
            this.cmbCalismaAlani.Location = new System.Drawing.Point(261, 103);
            this.cmbCalismaAlani.Name = "cmbCalismaAlani";
            this.cmbCalismaAlani.Size = new System.Drawing.Size(270, 21);
            this.cmbCalismaAlani.TabIndex = 4;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(6, 52);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(249, 13);
            this.label6.TabIndex = 7;
            this.label6.Text = "Yıllık Ortalama Maksimum Sıcaklık Öznitelik Sütunu:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(6, 79);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(212, 13);
            this.label7.TabIndex = 8;
            this.label7.Text = "Yıllık Toplam Yağış Miktarı Öznitelik Sütunu:";
            // 
            // cmbOrtSic
            // 
            this.cmbOrtSic.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbOrtSic.FormattingEnabled = true;
            this.cmbOrtSic.Location = new System.Drawing.Point(261, 49);
            this.cmbOrtSic.Name = "cmbOrtSic";
            this.cmbOrtSic.Size = new System.Drawing.Size(270, 21);
            this.cmbOrtSic.TabIndex = 11;
            // 
            // cmbOrtYag
            // 
            this.cmbOrtYag.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbOrtYag.FormattingEnabled = true;
            this.cmbOrtYag.Location = new System.Drawing.Point(261, 76);
            this.cmbOrtYag.Name = "cmbOrtYag";
            this.cmbOrtYag.Size = new System.Drawing.Size(270, 21);
            this.cmbOrtYag.TabIndex = 12;
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(600, 365);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 23);
            this.btnOk.TabIndex = 13;
            this.btnOk.Text = "Çalıştır";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // grpbxInfoErinc
            // 
            this.grpbxInfoErinc.Controls.Add(this.lblInfo4);
            this.grpbxInfoErinc.Controls.Add(this.lblInfo6);
            this.grpbxInfoErinc.Controls.Add(this.lblInfo5);
            this.grpbxInfoErinc.Controls.Add(this.lblInfo3);
            this.grpbxInfoErinc.Controls.Add(this.lblInfo2);
            this.grpbxInfoErinc.Controls.Add(this.lblInfo1);
            this.grpbxInfoErinc.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpbxInfoErinc.Location = new System.Drawing.Point(3, 3);
            this.grpbxInfoErinc.Name = "grpbxInfoErinc";
            this.grpbxInfoErinc.Size = new System.Drawing.Size(688, 100);
            this.grpbxInfoErinc.TabIndex = 14;
            this.grpbxInfoErinc.TabStop = false;
            this.grpbxInfoErinc.Text = "İklim Sınırlarının Belirlenmesi - Erinç Yöntemi";
            // 
            // lblInfo4
            // 
            this.lblInfo4.AutoSize = true;
            this.lblInfo4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInfo4.Location = new System.Drawing.Point(6, 56);
            this.lblInfo4.Name = "lblInfo4";
            this.lblInfo4.Size = new System.Drawing.Size(290, 13);
            this.lblInfo4.TabIndex = 0;
            this.lblInfo4.Text = "- Meteoroloji veri setinde yer alan yıllık toplam yağış özniteliği,";
            // 
            // lblInfo6
            // 
            this.lblInfo6.AutoSize = true;
            this.lblInfo6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInfo6.Location = new System.Drawing.Point(6, 82);
            this.lblInfo6.Name = "lblInfo6";
            this.lblInfo6.Size = new System.Drawing.Size(424, 13);
            this.lblInfo6.TabIndex = 0;
            this.lblInfo6.Text = "seçilmelidir. Ardından analiz çalıştırılır ve Erinç yöntemine göre iklim sınırlar" +
    "ı katmanı oluşur.";
            // 
            // lblInfo5
            // 
            this.lblInfo5.AutoSize = true;
            this.lblInfo5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInfo5.Location = new System.Drawing.Point(6, 69);
            this.lblInfo5.Name = "lblInfo5";
            this.lblInfo5.Size = new System.Drawing.Size(90, 13);
            this.lblInfo5.TabIndex = 0;
            this.lblInfo5.Text = "- Proje analiz sınırı";
            // 
            // lblInfo3
            // 
            this.lblInfo3.AutoSize = true;
            this.lblInfo3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInfo3.Location = new System.Drawing.Point(6, 43);
            this.lblInfo3.Name = "lblInfo3";
            this.lblInfo3.Size = new System.Drawing.Size(362, 13);
            this.lblInfo3.TabIndex = 0;
            this.lblInfo3.Text = "- Meteoroloji veri setinde yer alan yıllık ortalama maksimum sıcaklık özniteliği," +
    "";
            // 
            // lblInfo2
            // 
            this.lblInfo2.AutoSize = true;
            this.lblInfo2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInfo2.Location = new System.Drawing.Point(6, 30);
            this.lblInfo2.Name = "lblInfo2";
            this.lblInfo2.Size = new System.Drawing.Size(146, 13);
            this.lblInfo2.TabIndex = 0;
            this.lblInfo2.Text = "- Meteoroloji veri seti katmanı,";
            // 
            // lblInfo1
            // 
            this.lblInfo1.AutoSize = true;
            this.lblInfo1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInfo1.Location = new System.Drawing.Point(6, 16);
            this.lblInfo1.Name = "lblInfo1";
            this.lblInfo1.Size = new System.Drawing.Size(197, 13);
            this.lblInfo1.TabIndex = 0;
            this.lblInfo1.Text = "İklim sınırlarının belirlenmesi için sırasıyla: ";
            // 
            // grpbxInputErinc
            // 
            this.grpbxInputErinc.Controls.Add(this.label2);
            this.grpbxInputErinc.Controls.Add(this.cmbVeriSeti);
            this.grpbxInputErinc.Controls.Add(this.cmbOrtSic);
            this.grpbxInputErinc.Controls.Add(this.label3);
            this.grpbxInputErinc.Controls.Add(this.cmbCalismaAlani);
            this.grpbxInputErinc.Controls.Add(this.cmbOrtYag);
            this.grpbxInputErinc.Controls.Add(this.label6);
            this.grpbxInputErinc.Controls.Add(this.label7);
            this.grpbxInputErinc.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpbxInputErinc.Location = new System.Drawing.Point(3, 109);
            this.grpbxInputErinc.Name = "grpbxInputErinc";
            this.grpbxInputErinc.Size = new System.Drawing.Size(688, 138);
            this.grpbxInputErinc.TabIndex = 15;
            this.grpbxInputErinc.TabStop = false;
            this.grpbxInputErinc.Text = "Girdi Veri Seti Seçilmesi";
            // 
            // tpSonuc
            // 
            this.tpSonuc.CustomText = "";
            this.tpSonuc.Location = new System.Drawing.Point(136, 365);
            this.tpSonuc.Name = "tpSonuc";
            this.tpSonuc.ProgressColor = System.Drawing.Color.LightGreen;
            this.tpSonuc.Size = new System.Drawing.Size(408, 23);
            this.tpSonuc.TabIndex = 43;
            this.tpSonuc.TextColor = System.Drawing.Color.Black;
            this.tpSonuc.TextFont = new System.Drawing.Font("Times New Roman", 11F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.tpSonuc.Visible = false;
            this.tpSonuc.VisualMode = Iklim.ProgressBarDisplayMode.CurrProgress;
            // 
            // UcErinc
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tpSonuc);
            this.Controls.Add(this.grpbxInputErinc);
            this.Controls.Add(this.grpbxInfoErinc);
            this.Controls.Add(this.btnOk);
            this.Name = "UcErinc";
            this.Size = new System.Drawing.Size(694, 412);
            this.grpbxInfoErinc.ResumeLayout(false);
            this.grpbxInfoErinc.PerformLayout();
            this.grpbxInputErinc.ResumeLayout(false);
            this.grpbxInputErinc.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbVeriSeti;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmbCalismaAlani;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cmbOrtSic;
        private System.Windows.Forms.ComboBox cmbOrtYag;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.GroupBox grpbxInfoErinc;
        private System.Windows.Forms.Label lblInfo4;
        private System.Windows.Forms.Label lblInfo6;
        private System.Windows.Forms.Label lblInfo5;
        private System.Windows.Forms.Label lblInfo3;
        private System.Windows.Forms.Label lblInfo2;
        private System.Windows.Forms.Label lblInfo1;
        private System.Windows.Forms.GroupBox grpbxInputErinc;
        private TextProgressBar tpSonuc;
    }
}
