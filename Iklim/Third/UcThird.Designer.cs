namespace Iklim.Third
{
    partial class UcThird
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
            this.cmbCalismaAlani = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbVeriSeti = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.grpbxInfo = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lblInfo1 = new System.Windows.Forms.Label();
            this.grpbxInput = new System.Windows.Forms.GroupBox();
            this.grpbxInfo.SuspendLayout();
            this.grpbxInput.SuspendLayout();
            this.SuspendLayout();
            // 
            // cmbCalismaAlani
            // 
            this.cmbCalismaAlani.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbCalismaAlani.FormattingEnabled = true;
            this.cmbCalismaAlani.Location = new System.Drawing.Point(231, 54);
            this.cmbCalismaAlani.Name = "cmbCalismaAlani";
            this.cmbCalismaAlani.Size = new System.Drawing.Size(235, 21);
            this.cmbCalismaAlani.TabIndex = 8;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(6, 57);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(143, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Ekolojik Sit Alanları Katmanı :";
            // 
            // cmbVeriSeti
            // 
            this.cmbVeriSeti.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbVeriSeti.FormattingEnabled = true;
            this.cmbVeriSeti.Location = new System.Drawing.Point(231, 23);
            this.cmbVeriSeti.Name = "cmbVeriSeti";
            this.cmbVeriSeti.Size = new System.Drawing.Size(235, 21);
            this.cmbVeriSeti.TabIndex = 6;
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
            this.grpbxInput.Controls.Add(this.label2);
            this.grpbxInput.Controls.Add(this.cmbVeriSeti);
            this.grpbxInput.Controls.Add(this.cmbCalismaAlani);
            this.grpbxInput.Controls.Add(this.label3);
            this.grpbxInput.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpbxInput.Location = new System.Drawing.Point(3, 92);
            this.grpbxInput.Name = "grpbxInput";
            this.grpbxInput.Size = new System.Drawing.Size(688, 100);
            this.grpbxInput.TabIndex = 10;
            this.grpbxInput.TabStop = false;
            this.grpbxInput.Text = "Girdi Veri Setleri";
            // 
            // UcThird
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.grpbxInput);
            this.Controls.Add(this.grpbxInfo);
            this.Name = "UcThird";
            this.Size = new System.Drawing.Size(694, 412);
            this.grpbxInfo.ResumeLayout(false);
            this.grpbxInput.ResumeLayout(false);
            this.grpbxInput.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbCalismaAlani;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmbVeriSeti;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox grpbxInfo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblInfo1;
        private System.Windows.Forms.GroupBox grpbxInput;
    }
}
