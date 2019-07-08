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
            this.txtExcel = new System.Windows.Forms.TextBox();
            this.btnExcelOpen = new System.Windows.Forms.Button();
            this.cmbXColumn = new System.Windows.Forms.ComboBox();
            this.cmbYColumn = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnUygula = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtExcel
            // 
            this.txtExcel.Enabled = false;
            this.txtExcel.Location = new System.Drawing.Point(21, 12);
            this.txtExcel.Name = "txtExcel";
            this.txtExcel.Size = new System.Drawing.Size(251, 20);
            this.txtExcel.TabIndex = 0;
            this.txtExcel.TextChanged += new System.EventHandler(this.txtExcel_TextChanged);
            // 
            // btnExcelOpen
            // 
            this.btnExcelOpen.Location = new System.Drawing.Point(278, 12);
            this.btnExcelOpen.Name = "btnExcelOpen";
            this.btnExcelOpen.Size = new System.Drawing.Size(55, 23);
            this.btnExcelOpen.TabIndex = 1;
            this.btnExcelOpen.Text = "Aç";
            this.btnExcelOpen.UseVisualStyleBackColor = true;
            this.btnExcelOpen.Click += new System.EventHandler(this.btnExcelOpen_Click);
            // 
            // cmbXColumn
            // 
            this.cmbXColumn.FormattingEnabled = true;
            this.cmbXColumn.Location = new System.Drawing.Point(212, 59);
            this.cmbXColumn.Name = "cmbXColumn";
            this.cmbXColumn.Size = new System.Drawing.Size(121, 21);
            this.cmbXColumn.TabIndex = 2;
            // 
            // cmbYColumn
            // 
            this.cmbYColumn.FormattingEnabled = true;
            this.cmbYColumn.Location = new System.Drawing.Point(212, 98);
            this.cmbYColumn.Name = "cmbYColumn";
            this.cmbYColumn.Size = new System.Drawing.Size(121, 21);
            this.cmbYColumn.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 62);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "X Kolonu : ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(18, 101);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Y Kolonu : ";
            // 
            // btnUygula
            // 
            this.btnUygula.Location = new System.Drawing.Point(258, 135);
            this.btnUygula.Name = "btnUygula";
            this.btnUygula.Size = new System.Drawing.Size(75, 23);
            this.btnUygula.TabIndex = 6;
            this.btnUygula.Text = "Uygula";
            this.btnUygula.UseVisualStyleBackColor = true;
            this.btnUygula.Click += new System.EventHandler(this.btnUygula_Click);
            // 
            // XYEventTableForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(348, 170);
            this.Controls.Add(this.btnUygula);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmbYColumn);
            this.Controls.Add(this.cmbXColumn);
            this.Controls.Add(this.btnExcelOpen);
            this.Controls.Add(this.txtExcel);
            this.Name = "XYEventTableForm";
            this.Text = "XYEventTable";
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
    }
}