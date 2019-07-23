namespace Iklim
{
    partial class ucDeMartonne
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
            this.grpbxInfo = new System.Windows.Forms.GroupBox();
            this.lblInfo1 = new System.Windows.Forms.Label();
            this.grpbxInput = new System.Windows.Forms.GroupBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rbYillik = new System.Windows.Forms.RadioButton();
            this.rbAylik = new System.Windows.Forms.RadioButton();
            this.lblInputProjectArea = new System.Windows.Forms.Label();
            this.cmbProjectArea = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.lblOrtalamaSicaklik = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblToplamYagis = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblInputVeri = new System.Windows.Forms.Label();
            this.cmbOrtalamaSicaklikAylik = new System.Windows.Forms.ComboBox();
            this.cmbToplamYagisAylik = new System.Windows.Forms.ComboBox();
            this.cmbOrtalamaSicaklikYillik = new System.Windows.Forms.ComboBox();
            this.cmbVeriAylik = new System.Windows.Forms.ComboBox();
            this.cmbToplamYagisYillik = new System.Windows.Forms.ComboBox();
            this.cmbVeriYillik = new System.Windows.Forms.ComboBox();
            this.btnOk = new System.Windows.Forms.Button();
            this.grpbxInfo.SuspendLayout();
            this.grpbxInput.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpbxInfo
            // 
            this.grpbxInfo.Controls.Add(this.lblInfo1);
            this.grpbxInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpbxInfo.Location = new System.Drawing.Point(3, 3);
            this.grpbxInfo.Name = "grpbxInfo";
            this.grpbxInfo.Size = new System.Drawing.Size(688, 56);
            this.grpbxInfo.TabIndex = 0;
            this.grpbxInfo.TabStop = false;
            this.grpbxInfo.Text = "İklim Sınırlarının Belirlenmesi - DeMartonne Yöntemi";
            // 
            // lblInfo1
            // 
            this.lblInfo1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInfo1.Location = new System.Drawing.Point(6, 16);
            this.lblInfo1.Name = "lblInfo1";
            this.lblInfo1.Size = new System.Drawing.Size(676, 31);
            this.lblInfo1.TabIndex = 0;
            this.lblInfo1.Text = "Demartonne yönteminde sıcaklık ve yağış verilerine bakılarak kuraklık endeksi hes" +
    "aplanır. Bu uygulamada kullanıcı yıllık ya da aylık olmak üzere iki farklı anali" +
    "z gerçekleştirebilir. ";
            // 
            // grpbxInput
            // 
            this.grpbxInput.Controls.Add(this.groupBox1);
            this.grpbxInput.Controls.Add(this.lblInputProjectArea);
            this.grpbxInput.Controls.Add(this.cmbProjectArea);
            this.grpbxInput.Controls.Add(this.label3);
            this.grpbxInput.Controls.Add(this.lblOrtalamaSicaklik);
            this.grpbxInput.Controls.Add(this.label2);
            this.grpbxInput.Controls.Add(this.lblToplamYagis);
            this.grpbxInput.Controls.Add(this.label1);
            this.grpbxInput.Controls.Add(this.lblInputVeri);
            this.grpbxInput.Controls.Add(this.cmbOrtalamaSicaklikAylik);
            this.grpbxInput.Controls.Add(this.cmbToplamYagisAylik);
            this.grpbxInput.Controls.Add(this.cmbOrtalamaSicaklikYillik);
            this.grpbxInput.Controls.Add(this.cmbVeriAylik);
            this.grpbxInput.Controls.Add(this.cmbToplamYagisYillik);
            this.grpbxInput.Controls.Add(this.cmbVeriYillik);
            this.grpbxInput.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpbxInput.Location = new System.Drawing.Point(3, 65);
            this.grpbxInput.Name = "grpbxInput";
            this.grpbxInput.Size = new System.Drawing.Size(688, 203);
            this.grpbxInput.TabIndex = 1;
            this.grpbxInput.TabStop = false;
            this.grpbxInput.Text = "Girdi Veri Seti Seçilmesi";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rbYillik);
            this.groupBox1.Controls.Add(this.rbAylik);
            this.groupBox1.Location = new System.Drawing.Point(6, 43);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(634, 45);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "gbAnaliz";
            // 
            // rbYillik
            // 
            this.rbYillik.AutoSize = true;
            this.rbYillik.Checked = true;
            this.rbYillik.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbYillik.Location = new System.Drawing.Point(6, 19);
            this.rbYillik.Name = "rbYillik";
            this.rbYillik.Size = new System.Drawing.Size(120, 17);
            this.rbYillik.TabIndex = 0;
            this.rbYillik.TabStop = true;
            this.rbYillik.Text = "Yıllık Kuraklık Analizi";
            this.rbYillik.UseVisualStyleBackColor = true;
            this.rbYillik.CheckedChanged += new System.EventHandler(this.rbYillik_CheckedChanged);
            // 
            // rbAylik
            // 
            this.rbAylik.AutoSize = true;
            this.rbAylik.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbAylik.Location = new System.Drawing.Point(343, 19);
            this.rbAylik.Name = "rbAylik";
            this.rbAylik.Size = new System.Drawing.Size(121, 17);
            this.rbAylik.TabIndex = 0;
            this.rbAylik.Text = "Aylık Kuraklık Analizi";
            this.rbAylik.UseVisualStyleBackColor = true;
            this.rbAylik.CheckedChanged += new System.EventHandler(this.rbAylik_CheckedChanged);
            // 
            // lblInputProjectArea
            // 
            this.lblInputProjectArea.AutoSize = true;
            this.lblInputProjectArea.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInputProjectArea.Location = new System.Drawing.Point(6, 22);
            this.lblInputProjectArea.Name = "lblInputProjectArea";
            this.lblInputProjectArea.Size = new System.Drawing.Size(134, 13);
            this.lblInputProjectArea.TabIndex = 4;
            this.lblInputProjectArea.Text = "Proje Analiz Sınırı Katmanı :";
            // 
            // cmbProjectArea
            // 
            this.cmbProjectArea.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbProjectArea.FormattingEnabled = true;
            this.cmbProjectArea.Location = new System.Drawing.Point(146, 19);
            this.cmbProjectArea.Name = "cmbProjectArea";
            this.cmbProjectArea.Size = new System.Drawing.Size(250, 21);
            this.cmbProjectArea.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(346, 154);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(120, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Aylık Ortalama Sıcaklık :";
            // 
            // lblOrtalamaSicaklik
            // 
            this.lblOrtalamaSicaklik.AutoSize = true;
            this.lblOrtalamaSicaklik.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOrtalamaSicaklik.Location = new System.Drawing.Point(6, 151);
            this.lblOrtalamaSicaklik.Name = "lblOrtalamaSicaklik";
            this.lblOrtalamaSicaklik.Size = new System.Drawing.Size(119, 13);
            this.lblOrtalamaSicaklik.TabIndex = 2;
            this.lblOrtalamaSicaklik.Text = "Yıllık Ortalama Sıcaklık :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(346, 127);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(102, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Aylık Toplam Yağış :";
            // 
            // lblToplamYagis
            // 
            this.lblToplamYagis.AutoSize = true;
            this.lblToplamYagis.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblToplamYagis.Location = new System.Drawing.Point(6, 124);
            this.lblToplamYagis.Name = "lblToplamYagis";
            this.lblToplamYagis.Size = new System.Drawing.Size(101, 13);
            this.lblToplamYagis.TabIndex = 2;
            this.lblToplamYagis.Text = "Yıllık Toplam Yağış :";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(346, 100);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(112, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Meteorolojik Veri Seti :";
            // 
            // lblInputVeri
            // 
            this.lblInputVeri.AutoSize = true;
            this.lblInputVeri.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInputVeri.Location = new System.Drawing.Point(6, 97);
            this.lblInputVeri.Name = "lblInputVeri";
            this.lblInputVeri.Size = new System.Drawing.Size(112, 13);
            this.lblInputVeri.TabIndex = 2;
            this.lblInputVeri.Text = "Meteorolojik Veri Seti :";
            // 
            // cmbOrtalamaSicaklikAylik
            // 
            this.cmbOrtalamaSicaklikAylik.Enabled = false;
            this.cmbOrtalamaSicaklikAylik.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbOrtalamaSicaklikAylik.FormattingEnabled = true;
            this.cmbOrtalamaSicaklikAylik.Location = new System.Drawing.Point(472, 151);
            this.cmbOrtalamaSicaklikAylik.Name = "cmbOrtalamaSicaklikAylik";
            this.cmbOrtalamaSicaklikAylik.Size = new System.Drawing.Size(168, 21);
            this.cmbOrtalamaSicaklikAylik.TabIndex = 1;
            // 
            // cmbToplamYagisAylik
            // 
            this.cmbToplamYagisAylik.Enabled = false;
            this.cmbToplamYagisAylik.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbToplamYagisAylik.FormattingEnabled = true;
            this.cmbToplamYagisAylik.Location = new System.Drawing.Point(472, 124);
            this.cmbToplamYagisAylik.Name = "cmbToplamYagisAylik";
            this.cmbToplamYagisAylik.Size = new System.Drawing.Size(168, 21);
            this.cmbToplamYagisAylik.TabIndex = 1;
            // 
            // cmbOrtalamaSicaklikYillik
            // 
            this.cmbOrtalamaSicaklikYillik.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbOrtalamaSicaklikYillik.FormattingEnabled = true;
            this.cmbOrtalamaSicaklikYillik.Location = new System.Drawing.Point(131, 148);
            this.cmbOrtalamaSicaklikYillik.Name = "cmbOrtalamaSicaklikYillik";
            this.cmbOrtalamaSicaklikYillik.Size = new System.Drawing.Size(168, 21);
            this.cmbOrtalamaSicaklikYillik.TabIndex = 1;
            // 
            // cmbVeriAylik
            // 
            this.cmbVeriAylik.Enabled = false;
            this.cmbVeriAylik.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbVeriAylik.FormattingEnabled = true;
            this.cmbVeriAylik.Location = new System.Drawing.Point(472, 97);
            this.cmbVeriAylik.Name = "cmbVeriAylik";
            this.cmbVeriAylik.Size = new System.Drawing.Size(168, 21);
            this.cmbVeriAylik.TabIndex = 1;
            this.cmbVeriAylik.SelectedIndexChanged += new System.EventHandler(this.cmbVeriAylik_SelectedIndexChanged);
            // 
            // cmbToplamYagisYillik
            // 
            this.cmbToplamYagisYillik.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbToplamYagisYillik.FormattingEnabled = true;
            this.cmbToplamYagisYillik.Location = new System.Drawing.Point(131, 121);
            this.cmbToplamYagisYillik.Name = "cmbToplamYagisYillik";
            this.cmbToplamYagisYillik.Size = new System.Drawing.Size(168, 21);
            this.cmbToplamYagisYillik.TabIndex = 1;
            // 
            // cmbVeriYillik
            // 
            this.cmbVeriYillik.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbVeriYillik.FormattingEnabled = true;
            this.cmbVeriYillik.Location = new System.Drawing.Point(131, 94);
            this.cmbVeriYillik.Name = "cmbVeriYillik";
            this.cmbVeriYillik.Size = new System.Drawing.Size(168, 21);
            this.cmbVeriYillik.TabIndex = 1;
            this.cmbVeriYillik.SelectedIndexChanged += new System.EventHandler(this.cmbVeriYillik_SelectedIndexChanged);
            // 
            // btnOk
            // 
            this.btnOk.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOk.Location = new System.Drawing.Point(568, 366);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 23);
            this.btnOk.TabIndex = 40;
            this.btnOk.Text = "Çalıştır";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // ucDeMartonne
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.grpbxInput);
            this.Controls.Add(this.grpbxInfo);
            this.Name = "ucDeMartonne";
            this.Size = new System.Drawing.Size(694, 412);
            this.grpbxInfo.ResumeLayout(false);
            this.grpbxInput.ResumeLayout(false);
            this.grpbxInput.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grpbxInfo;
        private System.Windows.Forms.Label lblInfo1;
        private System.Windows.Forms.GroupBox grpbxInput;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblOrtalamaSicaklik;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblToplamYagis;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblInputVeri;
        private System.Windows.Forms.ComboBox cmbOrtalamaSicaklikAylik;
        private System.Windows.Forms.ComboBox cmbToplamYagisAylik;
        private System.Windows.Forms.ComboBox cmbOrtalamaSicaklikYillik;
        private System.Windows.Forms.ComboBox cmbVeriAylik;
        private System.Windows.Forms.ComboBox cmbToplamYagisYillik;
        private System.Windows.Forms.ComboBox cmbVeriYillik;
        private System.Windows.Forms.RadioButton rbAylik;
        private System.Windows.Forms.RadioButton rbYillik;
        private System.Windows.Forms.Label lblInputProjectArea;
        private System.Windows.Forms.ComboBox cmbProjectArea;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnOk;
    }
}
