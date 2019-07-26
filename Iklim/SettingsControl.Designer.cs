namespace Iklim
{
    partial class SettingsControl
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
            this.txtPiksel = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cmbYontem = new System.Windows.Forms.ComboBox();
            this.chbAra = new System.Windows.Forms.CheckBox();
            this.label19 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtNoData = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.cmbDataType = new System.Windows.Forms.ComboBox();
            this.cmbTinToRasterMethod = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtMinNoktaIDW = new System.Windows.Forms.TextBox();
            this.txtMesafeIDW = new System.Windows.Forms.TextBox();
            this.txtNoktaSayisiIDW = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.txtMaxUzaklikIDW = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.cmbYarıcapIDW = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.txtLagKriging = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.txtMinNoktaKriging = new System.Windows.Forms.TextBox();
            this.txtMesafeKriging = new System.Windows.Forms.TextBox();
            this.txtNoktaSayisiKriging = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.txtMaxUzaklikKriging = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.cmbSemiVariogramKriging = new System.Windows.Forms.ComboBox();
            this.cmbYarıcapKriging = new System.Windows.Forms.ComboBox();
            this.label18 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtPiksel
            // 
            this.txtPiksel.Location = new System.Drawing.Point(6, 43);
            this.txtPiksel.Name = "txtPiksel";
            this.txtPiksel.Size = new System.Drawing.Size(71, 20);
            this.txtPiksel.TabIndex = 0;
            this.txtPiksel.Text = "0.1";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Piksel boyutu:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(3, 10);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 20);
            this.label2.TabIndex = 7;
            this.label2.Text = "Ayarlar";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cmbYontem);
            this.groupBox1.Controls.Add(this.chbAra);
            this.groupBox1.Controls.Add(this.label19);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.txtNoData);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txtPiksel);
            this.groupBox1.Location = new System.Drawing.Point(32, 66);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(150, 380);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Genel Ayarlar";
            // 
            // cmbYontem
            // 
            this.cmbYontem.FormattingEnabled = true;
            this.cmbYontem.Items.AddRange(new object[] {
            "IDW",
            "KRIGING"});
            this.cmbYontem.Location = new System.Drawing.Point(6, 220);
            this.cmbYontem.Name = "cmbYontem";
            this.cmbYontem.Size = new System.Drawing.Size(121, 21);
            this.cmbYontem.TabIndex = 5;
            this.cmbYontem.Visible = false;
            // 
            // chbAra
            // 
            this.chbAra.AutoSize = true;
            this.chbAra.Location = new System.Drawing.Point(6, 75);
            this.chbAra.Name = "chbAra";
            this.chbAra.Size = new System.Drawing.Size(127, 30);
            this.chbAra.TabIndex = 2;
            this.chbAra.Text = "Ara işlem katmanlarını\r\nlejanta ekle";
            this.chbAra.UseVisualStyleBackColor = true;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(6, 189);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(101, 13);
            this.label19.TabIndex = 4;
            this.label19.Text = "Uygulama Yöntemi :";
            this.label19.Visible = false;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 124);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(79, 13);
            this.label6.TabIndex = 1;
            this.label6.Text = "NoData değeri:";
            // 
            // txtNoData
            // 
            this.txtNoData.Location = new System.Drawing.Point(6, 142);
            this.txtNoData.Name = "txtNoData";
            this.txtNoData.Size = new System.Drawing.Size(71, 20);
            this.txtNoData.TabIndex = 0;
            this.txtNoData.Text = "0";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 30);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(469, 13);
            this.label3.TabIndex = 10;
            this.label3.Text = "Uygulama üzerindeki bazı standart özelliklerin değiştirilmesi için gerekli ayarla" +
    "rı bu kısımdan yapınız. ";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.cmbDataType);
            this.groupBox2.Controls.Add(this.cmbTinToRasterMethod);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Location = new System.Drawing.Point(188, 66);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(150, 380);
            this.groupBox2.TabIndex = 8;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Enterpolasyon Ayarları";
            // 
            // cmbDataType
            // 
            this.cmbDataType.FormattingEnabled = true;
            this.cmbDataType.Items.AddRange(new object[] {
            "FLOAT",
            "INT"});
            this.cmbDataType.Location = new System.Drawing.Point(6, 90);
            this.cmbDataType.Name = "cmbDataType";
            this.cmbDataType.Size = new System.Drawing.Size(121, 21);
            this.cmbDataType.TabIndex = 2;
            // 
            // cmbTinToRasterMethod
            // 
            this.cmbTinToRasterMethod.FormattingEnabled = true;
            this.cmbTinToRasterMethod.Items.AddRange(new object[] {
            "LINEAR",
            "NATURAL_NEIGHBOURS"});
            this.cmbTinToRasterMethod.Location = new System.Drawing.Point(6, 40);
            this.cmbTinToRasterMethod.Name = "cmbTinToRasterMethod";
            this.cmbTinToRasterMethod.Size = new System.Drawing.Size(121, 21);
            this.cmbTinToRasterMethod.TabIndex = 2;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 75);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(44, 13);
            this.label5.TabIndex = 1;
            this.label5.Text = "Veri tipi:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 25);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(103, 13);
            this.label4.TabIndex = 1;
            this.label4.Text = "Tin > Raster metodu";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label7);
            this.groupBox3.Controls.Add(this.txtMinNoktaIDW);
            this.groupBox3.Controls.Add(this.txtMesafeIDW);
            this.groupBox3.Controls.Add(this.txtNoktaSayisiIDW);
            this.groupBox3.Controls.Add(this.label11);
            this.groupBox3.Controls.Add(this.txtMaxUzaklikIDW);
            this.groupBox3.Controls.Add(this.label10);
            this.groupBox3.Controls.Add(this.cmbYarıcapIDW);
            this.groupBox3.Controls.Add(this.label8);
            this.groupBox3.Controls.Add(this.label9);
            this.groupBox3.Location = new System.Drawing.Point(344, 66);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(150, 380);
            this.groupBox3.TabIndex = 8;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "IDW Ayarları";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 124);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(96, 13);
            this.label7.TabIndex = 1;
            this.label7.Text = "Maksimum uzaklık:";
            // 
            // txtMinNoktaIDW
            // 
            this.txtMinNoktaIDW.Location = new System.Drawing.Point(6, 240);
            this.txtMinNoktaIDW.Name = "txtMinNoktaIDW";
            this.txtMinNoktaIDW.Size = new System.Drawing.Size(67, 20);
            this.txtMinNoktaIDW.TabIndex = 0;
            // 
            // txtMesafeIDW
            // 
            this.txtMesafeIDW.Location = new System.Drawing.Point(6, 190);
            this.txtMesafeIDW.Name = "txtMesafeIDW";
            this.txtMesafeIDW.Size = new System.Drawing.Size(67, 20);
            this.txtMesafeIDW.TabIndex = 0;
            this.txtMesafeIDW.Text = "1060";
            // 
            // txtNoktaSayisiIDW
            // 
            this.txtNoktaSayisiIDW.Location = new System.Drawing.Point(6, 90);
            this.txtNoktaSayisiIDW.Name = "txtNoktaSayisiIDW";
            this.txtNoktaSayisiIDW.Size = new System.Drawing.Size(67, 20);
            this.txtNoktaSayisiIDW.TabIndex = 0;
            this.txtNoktaSayisiIDW.Text = "12";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(3, 223);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(95, 13);
            this.label11.TabIndex = 1;
            this.label11.Text = "En az nokta sayısı:";
            // 
            // txtMaxUzaklikIDW
            // 
            this.txtMaxUzaklikIDW.Location = new System.Drawing.Point(6, 140);
            this.txtMaxUzaklikIDW.Name = "txtMaxUzaklikIDW";
            this.txtMaxUzaklikIDW.Size = new System.Drawing.Size(71, 20);
            this.txtMaxUzaklikIDW.TabIndex = 0;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(6, 173);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(45, 13);
            this.label10.TabIndex = 1;
            this.label10.Text = "Mesafe:";
            // 
            // cmbYarıcapIDW
            // 
            this.cmbYarıcapIDW.FormattingEnabled = true;
            this.cmbYarıcapIDW.Items.AddRange(new object[] {
            "Variable",
            "Fixed"});
            this.cmbYarıcapIDW.Location = new System.Drawing.Point(6, 40);
            this.cmbYarıcapIDW.Name = "cmbYarıcapIDW";
            this.cmbYarıcapIDW.Size = new System.Drawing.Size(121, 21);
            this.cmbYarıcapIDW.TabIndex = 2;
            this.cmbYarıcapIDW.SelectedIndexChanged += new System.EventHandler(this.comboBox4_SelectedIndexChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(6, 75);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(67, 13);
            this.label8.TabIndex = 1;
            this.label8.Text = "Nokta sayısı:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(6, 25);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(79, 13);
            this.label9.TabIndex = 1;
            this.label9.Text = "Arama yarıçapı:";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.txtLagKriging);
            this.groupBox4.Controls.Add(this.label12);
            this.groupBox4.Controls.Add(this.label17);
            this.groupBox4.Controls.Add(this.txtMinNoktaKriging);
            this.groupBox4.Controls.Add(this.txtMesafeKriging);
            this.groupBox4.Controls.Add(this.txtNoktaSayisiKriging);
            this.groupBox4.Controls.Add(this.label13);
            this.groupBox4.Controls.Add(this.txtMaxUzaklikKriging);
            this.groupBox4.Controls.Add(this.label14);
            this.groupBox4.Controls.Add(this.cmbSemiVariogramKriging);
            this.groupBox4.Controls.Add(this.cmbYarıcapKriging);
            this.groupBox4.Controls.Add(this.label18);
            this.groupBox4.Controls.Add(this.label15);
            this.groupBox4.Controls.Add(this.label16);
            this.groupBox4.Location = new System.Drawing.Point(500, 66);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(150, 380);
            this.groupBox4.TabIndex = 8;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Kriging Ayarları";
            // 
            // txtLagKriging
            // 
            this.txtLagKriging.Location = new System.Drawing.Point(7, 338);
            this.txtLagKriging.Name = "txtLagKriging";
            this.txtLagKriging.Size = new System.Drawing.Size(67, 20);
            this.txtLagKriging.TabIndex = 3;
            this.txtLagKriging.Text = "0.021";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(3, 173);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(96, 13);
            this.label12.TabIndex = 1;
            this.label12.Text = "Maksimum uzaklık:";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(4, 321);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(59, 13);
            this.label17.TabIndex = 4;
            this.label17.Text = "Lag sayısı :";
            // 
            // txtMinNoktaKriging
            // 
            this.txtMinNoktaKriging.Location = new System.Drawing.Point(6, 289);
            this.txtMinNoktaKriging.Name = "txtMinNoktaKriging";
            this.txtMinNoktaKriging.Size = new System.Drawing.Size(67, 20);
            this.txtMinNoktaKriging.TabIndex = 0;
            // 
            // txtMesafeKriging
            // 
            this.txtMesafeKriging.Location = new System.Drawing.Point(6, 239);
            this.txtMesafeKriging.Name = "txtMesafeKriging";
            this.txtMesafeKriging.Size = new System.Drawing.Size(67, 20);
            this.txtMesafeKriging.TabIndex = 0;
            this.txtMesafeKriging.Text = "1060";
            // 
            // txtNoktaSayisiKriging
            // 
            this.txtNoktaSayisiKriging.Location = new System.Drawing.Point(6, 139);
            this.txtNoktaSayisiKriging.Name = "txtNoktaSayisiKriging";
            this.txtNoktaSayisiKriging.Size = new System.Drawing.Size(67, 20);
            this.txtNoktaSayisiKriging.TabIndex = 0;
            this.txtNoktaSayisiKriging.Text = "12";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(3, 273);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(95, 13);
            this.label13.TabIndex = 1;
            this.label13.Text = "En az nokta sayısı:";
            // 
            // txtMaxUzaklikKriging
            // 
            this.txtMaxUzaklikKriging.Location = new System.Drawing.Point(6, 189);
            this.txtMaxUzaklikKriging.Name = "txtMaxUzaklikKriging";
            this.txtMaxUzaklikKriging.Size = new System.Drawing.Size(71, 20);
            this.txtMaxUzaklikKriging.TabIndex = 0;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(6, 223);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(45, 13);
            this.label14.TabIndex = 1;
            this.label14.Text = "Mesafe:";
            // 
            // cmbSemiVariogramKriging
            // 
            this.cmbSemiVariogramKriging.FormattingEnabled = true;
            this.cmbSemiVariogramKriging.Items.AddRange(new object[] {
            "Spherical",
            "Circular ",
            "Exponential",
            "Gaussian",
            "Linear"});
            this.cmbSemiVariogramKriging.Location = new System.Drawing.Point(6, 39);
            this.cmbSemiVariogramKriging.Name = "cmbSemiVariogramKriging";
            this.cmbSemiVariogramKriging.Size = new System.Drawing.Size(121, 21);
            this.cmbSemiVariogramKriging.TabIndex = 2;
            this.cmbSemiVariogramKriging.SelectedIndexChanged += new System.EventHandler(this.comboBox4_SelectedIndexChanged);
            // 
            // cmbYarıcapKriging
            // 
            this.cmbYarıcapKriging.FormattingEnabled = true;
            this.cmbYarıcapKriging.Items.AddRange(new object[] {
            "Variable",
            "Fixed"});
            this.cmbYarıcapKriging.Location = new System.Drawing.Point(6, 89);
            this.cmbYarıcapKriging.Name = "cmbYarıcapKriging";
            this.cmbYarıcapKriging.Size = new System.Drawing.Size(121, 21);
            this.cmbYarıcapKriging.TabIndex = 2;
            this.cmbYarıcapKriging.SelectedIndexChanged += new System.EventHandler(this.comboBox3_SelectedIndexChanged);
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(6, 24);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(112, 13);
            this.label18.TabIndex = 1;
            this.label18.Text = "Semivariogram modeli:";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(6, 124);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(67, 13);
            this.label15.TabIndex = 1;
            this.label15.Text = "Nokta sayısı:";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(6, 74);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(79, 13);
            this.label16.TabIndex = 1;
            this.label16.Text = "Arama yarıçapı:";
            // 
            // SettingsControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label3);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label2);
            this.Name = "SettingsControl";
            this.Size = new System.Drawing.Size(676, 458);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtPiksel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox chbAra;
        private System.Windows.Forms.ComboBox cmbDataType;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtNoData;
        private System.Windows.Forms.ComboBox cmbTinToRasterMethod;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtMinNoktaIDW;
        private System.Windows.Forms.TextBox txtMesafeIDW;
        private System.Windows.Forms.TextBox txtNoktaSayisiIDW;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtMaxUzaklikIDW;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox cmbYarıcapIDW;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtMinNoktaKriging;
        private System.Windows.Forms.TextBox txtMesafeKriging;
        private System.Windows.Forms.TextBox txtNoktaSayisiKriging;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox txtMaxUzaklikKriging;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.ComboBox cmbYarıcapKriging;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.ComboBox cmbSemiVariogramKriging;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.TextBox txtLagKriging;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.ComboBox cmbYontem;
        private System.Windows.Forms.Label label19;
    }
}
