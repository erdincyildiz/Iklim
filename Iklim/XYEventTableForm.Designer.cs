namespace Iklim
{
    partial class XYEventTableForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(XYEventTableForm));
            this.txtExcel = new System.Windows.Forms.TextBox();
            this.btnExcelOpen = new System.Windows.Forms.Button();
            this.cmbXColumn = new System.Windows.Forms.ComboBox();
            this.cmbYColumn = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnUygula = new System.Windows.Forms.Button();
            this.btnIptal = new System.Windows.Forms.Button();
            this.lblInfo1 = new System.Windows.Forms.Label();
            this.lblInfo2 = new System.Windows.Forms.Label();
            this.grpbxInfo = new System.Windows.Forms.GroupBox();
            this.grpbxInput = new System.Windows.Forms.GroupBox();
            this.grpbxParameters = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.grpbxInfo.SuspendLayout();
            this.grpbxInput.SuspendLayout();
            this.grpbxParameters.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtExcel
            // 
            this.txtExcel.Enabled = false;
            this.txtExcel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtExcel.Location = new System.Drawing.Point(9, 34);
            this.txtExcel.Name = "txtExcel";
            this.txtExcel.Size = new System.Drawing.Size(314, 20);
            this.txtExcel.TabIndex = 0;
            this.txtExcel.TextChanged += new System.EventHandler(this.txtExcel_TextChanged);
            // 
            // btnExcelOpen
            // 
            this.btnExcelOpen.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExcelOpen.Location = new System.Drawing.Point(329, 32);
            this.btnExcelOpen.Name = "btnExcelOpen";
            this.btnExcelOpen.Size = new System.Drawing.Size(75, 23);
            this.btnExcelOpen.TabIndex = 1;
            this.btnExcelOpen.Text = "Aç";
            this.btnExcelOpen.UseVisualStyleBackColor = true;
            this.btnExcelOpen.Click += new System.EventHandler(this.btnExcelOpen_Click);
            // 
            // cmbXColumn
            // 
            this.cmbXColumn.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbXColumn.FormattingEnabled = true;
            this.cmbXColumn.Location = new System.Drawing.Point(169, 22);
            this.cmbXColumn.Name = "cmbXColumn";
            this.cmbXColumn.Size = new System.Drawing.Size(235, 21);
            this.cmbXColumn.TabIndex = 2;
            // 
            // cmbYColumn
            // 
            this.cmbYColumn.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbYColumn.FormattingEnabled = true;
            this.cmbYColumn.Location = new System.Drawing.Point(169, 53);
            this.cmbYColumn.Name = "cmbYColumn";
            this.cmbYColumn.Size = new System.Drawing.Size(235, 21);
            this.cmbYColumn.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(6, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(131, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "X değeri sütununu seçiniz:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(6, 56);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(131, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Y değeri sütununu seçiniz:";
            // 
            // btnUygula
            // 
            this.btnUygula.Location = new System.Drawing.Point(347, 276);
            this.btnUygula.Name = "btnUygula";
            this.btnUygula.Size = new System.Drawing.Size(75, 23);
            this.btnUygula.TabIndex = 6;
            this.btnUygula.Text = "Uygula";
            this.btnUygula.UseVisualStyleBackColor = true;
            this.btnUygula.Click += new System.EventHandler(this.btnUygula_Click);
            // 
            // btnIptal
            // 
            this.btnIptal.Location = new System.Drawing.Point(258, 276);
            this.btnIptal.Name = "btnIptal";
            this.btnIptal.Size = new System.Drawing.Size(75, 23);
            this.btnIptal.TabIndex = 6;
            this.btnIptal.Text = "İptal";
            this.btnIptal.UseVisualStyleBackColor = true;
            this.btnIptal.Click += new System.EventHandler(this.btnUygula_Click);
            // 
            // lblInfo1
            // 
            this.lblInfo1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInfo1.Location = new System.Drawing.Point(6, 16);
            this.lblInfo1.Name = "lblInfo1";
            this.lblInfo1.Size = new System.Drawing.Size(398, 58);
            this.lblInfo1.TabIndex = 7;
            this.lblInfo1.Text = resources.GetString("lblInfo1.Text");
            // 
            // lblInfo2
            // 
            this.lblInfo2.AutoSize = true;
            this.lblInfo2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInfo2.Location = new System.Drawing.Point(6, 16);
            this.lblInfo2.Name = "lblInfo2";
            this.lblInfo2.Size = new System.Drawing.Size(122, 13);
            this.lblInfo2.TabIndex = 8;
            this.lblInfo2.Text = "Bir *.xlsx dosyası seçiniz:";
            // 
            // grpbxInfo
            // 
            this.grpbxInfo.Controls.Add(this.lblInfo1);
            this.grpbxInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpbxInfo.Location = new System.Drawing.Point(12, 12);
            this.grpbxInfo.Name = "grpbxInfo";
            this.grpbxInfo.Size = new System.Drawing.Size(410, 80);
            this.grpbxInfo.TabIndex = 9;
            this.grpbxInfo.TabStop = false;
            this.grpbxInfo.Text = "Sözel Veriden Nokta Üretilmesi";
            // 
            // grpbxInput
            // 
            this.grpbxInput.Controls.Add(this.lblInfo2);
            this.grpbxInput.Controls.Add(this.txtExcel);
            this.grpbxInput.Controls.Add(this.btnExcelOpen);
            this.grpbxInput.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpbxInput.Location = new System.Drawing.Point(12, 98);
            this.grpbxInput.Name = "grpbxInput";
            this.grpbxInput.Size = new System.Drawing.Size(410, 66);
            this.grpbxInput.TabIndex = 10;
            this.grpbxInput.TabStop = false;
            this.grpbxInput.Text = "Girdi Veri Dosyası Seçimi";
            // 
            // grpbxParameters
            // 
            this.grpbxParameters.Controls.Add(this.label1);
            this.grpbxParameters.Controls.Add(this.cmbXColumn);
            this.grpbxParameters.Controls.Add(this.cmbYColumn);
            this.grpbxParameters.Controls.Add(this.label2);
            this.grpbxParameters.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpbxParameters.Location = new System.Drawing.Point(12, 170);
            this.grpbxParameters.Name = "grpbxParameters";
            this.grpbxParameters.Size = new System.Drawing.Size(410, 89);
            this.grpbxParameters.TabIndex = 11;
            this.grpbxParameters.TabStop = false;
            this.grpbxParameters.Text = "Parametrelerin Belirlenmesi";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(12, 289);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(144, 13);
            this.label3.TabIndex = 12;
            this.label3.Text = "Tuğba MEMİŞOĞLU @2019";
            // 
            // XYEventTableForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(434, 311);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.grpbxParameters);
            this.Controls.Add(this.grpbxInput);
            this.Controls.Add(this.grpbxInfo);
            this.Controls.Add(this.btnIptal);
            this.Controls.Add(this.btnUygula);
            this.Name = "XYEventTableForm";
            this.Text = "Sözel Veriden Nokta Üret";
            this.grpbxInfo.ResumeLayout(false);
            this.grpbxInput.ResumeLayout(false);
            this.grpbxInput.PerformLayout();
            this.grpbxParameters.ResumeLayout(false);
            this.grpbxParameters.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtExcel;
        private System.Windows.Forms.Button btnExcelOpen;
        private System.Windows.Forms.ComboBox cmbXColumn;
        private System.Windows.Forms.ComboBox cmbYColumn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnUygula;
        private System.Windows.Forms.Button btnIptal;
        private System.Windows.Forms.Label lblInfo1;
        private System.Windows.Forms.Label lblInfo2;
        private System.Windows.Forms.GroupBox grpbxInfo;
        private System.Windows.Forms.GroupBox grpbxInput;
        private System.Windows.Forms.GroupBox grpbxParameters;
        private System.Windows.Forms.Label label3;
    }
}