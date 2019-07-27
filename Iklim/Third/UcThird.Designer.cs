namespace Iklim
{
    partial class ucThird
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
            this.cmbEkolojikSitAlani = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbIklimSiniri = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.grpbxInfo = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lblInfo1 = new System.Windows.Forms.Label();
            this.grpbxInput = new System.Windows.Forms.GroupBox();
            this.cmbProjectArea = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btnCalistir = new System.Windows.Forms.Button();
            this.tpSonuc = new Iklim.TextProgressBar();
            this.grpbxInfo.SuspendLayout();
            this.grpbxInput.SuspendLayout();
            this.SuspendLayout();
            // 
            // cmbEkolojikSitAlani
            // 
            this.cmbEkolojikSitAlani.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbEkolojikSitAlani.FormattingEnabled = true;
            this.cmbEkolojikSitAlani.Location = new System.Drawing.Point(231, 50);
            this.cmbEkolojikSitAlani.Name = "cmbEkolojikSitAlani";
            this.cmbEkolojikSitAlani.Size = new System.Drawing.Size(235, 21);
            this.cmbEkolojikSitAlani.TabIndex = 8;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(6, 53);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(143, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Ekolojik Sit Alanları Katmanı :";
            // 
            // cmbIklimSiniri
            // 
            this.cmbIklimSiniri.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbIklimSiniri.FormattingEnabled = true;
            this.cmbIklimSiniri.Location = new System.Drawing.Point(231, 23);
            this.cmbIklimSiniri.Name = "cmbIklimSiniri";
            this.cmbIklimSiniri.Size = new System.Drawing.Size(235, 21);
            this.cmbIklimSiniri.TabIndex = 6;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(6, 26);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(111, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "İklim Sınırları Katmanı :";
            // 
            // grpbxInfo
            // 
            this.grpbxInfo.Controls.Add(this.label1);
            this.grpbxInfo.Controls.Add(this.lblInfo1);
            this.grpbxInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpbxInfo.Location = new System.Drawing.Point(3, 3);
            this.grpbxInfo.Name = "grpbxInfo";
            this.grpbxInfo.Size = new System.Drawing.Size(688, 83);
            this.grpbxInfo.TabIndex = 9;
            this.grpbxInfo.TabStop = false;
            this.grpbxInfo.Text = "İklim Sınırları ve Ekolojik Sit Alanları Verilerinin Birleştirilmesi";
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(6, 47);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(676, 31);
            this.label1.TabIndex = 0;
            this.label1.Text = "Aşağıdaki veri seçim araçları ile kullanıcı, harita ekranında yer alan İklim Sını" +
    "rı veri setini ve Ekolojik Sit Alanları veri setini seçer; ardından analiz gerçe" +
    "kleştirilir.";
            // 
            // lblInfo1
            // 
            this.lblInfo1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInfo1.Location = new System.Drawing.Point(6, 16);
            this.lblInfo1.Name = "lblInfo1";
            this.lblInfo1.Size = new System.Drawing.Size(676, 31);
            this.lblInfo1.TabIndex = 0;
            this.lblInfo1.Text = "Kullanıcının girdi veri seti olarak göstereceği İklim Sınırları ve Ekolojik Sit A" +
    "lanları verileri bu fonksiyon ile bir araya getirilir ve tek bir veri seti halin" +
    "de kullanılması sağlanır.";
            // 
            // grpbxInput
            // 
            this.grpbxInput.Controls.Add(this.cmbProjectArea);
            this.grpbxInput.Controls.Add(this.label4);
            this.grpbxInput.Controls.Add(this.label2);
            this.grpbxInput.Controls.Add(this.cmbIklimSiniri);
            this.grpbxInput.Controls.Add(this.cmbEkolojikSitAlani);
            this.grpbxInput.Controls.Add(this.label3);
            this.grpbxInput.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpbxInput.Location = new System.Drawing.Point(3, 92);
            this.grpbxInput.Name = "grpbxInput";
            this.grpbxInput.Size = new System.Drawing.Size(688, 155);
            this.grpbxInput.TabIndex = 10;
            this.grpbxInput.TabStop = false;
            this.grpbxInput.Text = "Girdi Veri Setleri";
            // 
            // cmbProjectArea
            // 
            this.cmbProjectArea.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbProjectArea.FormattingEnabled = true;
            this.cmbProjectArea.Location = new System.Drawing.Point(231, 77);
            this.cmbProjectArea.Name = "cmbProjectArea";
            this.cmbProjectArea.Size = new System.Drawing.Size(235, 21);
            this.cmbProjectArea.TabIndex = 10;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(6, 80);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(94, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "Proje Analiz Alanı :";
            // 
            // btnCalistir
            // 
            this.btnCalistir.Location = new System.Drawing.Point(610, 253);
            this.btnCalistir.Name = "btnCalistir";
            this.btnCalistir.Size = new System.Drawing.Size(75, 23);
            this.btnCalistir.TabIndex = 11;
            this.btnCalistir.Text = "Çalıştır";
            this.btnCalistir.UseVisualStyleBackColor = true;
            this.btnCalistir.Click += new System.EventHandler(this.btnCalistir_Click);
            // 
            // tpSonuc
            // 
            this.tpSonuc.CustomText = "";
            this.tpSonuc.Location = new System.Drawing.Point(61, 253);
            this.tpSonuc.Name = "tpSonuc";
            this.tpSonuc.ProgressColor = System.Drawing.Color.LightGreen;
            this.tpSonuc.Size = new System.Drawing.Size(408, 23);
            this.tpSonuc.TabIndex = 42;
            this.tpSonuc.TextColor = System.Drawing.Color.Black;
            this.tpSonuc.TextFont = new System.Drawing.Font("Times New Roman", 11F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.tpSonuc.Visible = false;
            this.tpSonuc.VisualMode = Iklim.ProgressBarDisplayMode.CurrProgress;
            // 
            // ucThird
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tpSonuc);
            this.Controls.Add(this.btnCalistir);
            this.Controls.Add(this.grpbxInput);
            this.Controls.Add(this.grpbxInfo);
            this.Name = "ucThird";
            this.Size = new System.Drawing.Size(694, 412);
            this.grpbxInfo.ResumeLayout(false);
            this.grpbxInput.ResumeLayout(false);
            this.grpbxInput.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbEkolojikSitAlani;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmbIklimSiniri;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox grpbxInfo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblInfo1;
        private System.Windows.Forms.GroupBox grpbxInput;
        private System.Windows.Forms.ComboBox cmbProjectArea;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnCalistir;
        private TextProgressBar tpSonuc;
    }
}
