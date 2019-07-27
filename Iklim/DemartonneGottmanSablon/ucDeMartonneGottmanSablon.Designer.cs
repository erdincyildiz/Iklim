﻿namespace Iklim
{
    partial class ucDeMartonneGottmanSablon
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
            this.tpSonuc = new Iklim.TextProgressBar();
            this.label12 = new System.Windows.Forms.Label();
            this.cmbInputBorder = new System.Windows.Forms.ComboBox();
            this.label14 = new System.Windows.Forms.Label();
            this.cmbInputLayer = new System.Windows.Forms.ComboBox();
            this.btnOk = new System.Windows.Forms.Button();
            this.grpbxInfo.SuspendLayout();
            this.grpbxInput.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpbxInfo
            // 
            this.grpbxInfo.Controls.Add(this.lblInfo1);
            this.grpbxInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpbxInfo.Location = new System.Drawing.Point(3, 3);
            this.grpbxInfo.Name = "grpbxInfo";
            this.grpbxInfo.Size = new System.Drawing.Size(688, 56);
            this.grpbxInfo.TabIndex = 1;
            this.grpbxInfo.TabStop = false;
            this.grpbxInfo.Text = "İklim Sınırlarının Belirlenmesi - DeMartonne-Gottman Yöntemi";
            // 
            // lblInfo1
            // 
            this.lblInfo1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInfo1.Location = new System.Drawing.Point(6, 16);
            this.lblInfo1.Name = "lblInfo1";
            this.lblInfo1.Size = new System.Drawing.Size(676, 31);
            this.lblInfo1.TabIndex = 0;
            this.lblInfo1.Text = "DeMartonne - Gottman yönteminde sıcaklık ve yağış verilerine bakılarak kuraklık e" +
    "ndeksi hesaplanır. Bu uygulamada kullanıcı yıllık ya da aylık olmak üzere iki fa" +
    "rklı analiz gerçekleştirebilir. ";
            // 
            // grpbxInput
            // 
            this.grpbxInput.Controls.Add(this.tpSonuc);
            this.grpbxInput.Controls.Add(this.label12);
            this.grpbxInput.Controls.Add(this.cmbInputBorder);
            this.grpbxInput.Controls.Add(this.label14);
            this.grpbxInput.Controls.Add(this.cmbInputLayer);
            this.grpbxInput.Controls.Add(this.btnOk);
            this.grpbxInput.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpbxInput.Location = new System.Drawing.Point(3, 65);
            this.grpbxInput.Name = "grpbxInput";
            this.grpbxInput.Size = new System.Drawing.Size(688, 129);
            this.grpbxInput.TabIndex = 2;
            this.grpbxInput.TabStop = false;
            this.grpbxInput.Text = "Girdi Veri Seti Seçilmesi";
            // 
            // tpSonuc
            // 
            this.tpSonuc.CustomText = "";
            this.tpSonuc.Location = new System.Drawing.Point(115, 75);
            this.tpSonuc.Name = "tpSonuc";
            this.tpSonuc.ProgressColor = System.Drawing.Color.LightGreen;
            this.tpSonuc.Size = new System.Drawing.Size(408, 23);
            this.tpSonuc.TabIndex = 110;
            this.tpSonuc.TextColor = System.Drawing.Color.Black;
            this.tpSonuc.TextFont = new System.Drawing.Font("Times New Roman", 11F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.tpSonuc.Visible = false;
            this.tpSonuc.VisualMode = Iklim.ProgressBarDisplayMode.CurrProgress;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(378, 32);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(85, 13);
            this.label12.TabIndex = 108;
            this.label12.Text = "Proje Alanı Sınırı:";
            // 
            // cmbInputBorder
            // 
            this.cmbInputBorder.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbInputBorder.FormattingEnabled = true;
            this.cmbInputBorder.Location = new System.Drawing.Point(482, 29);
            this.cmbInputBorder.Name = "cmbInputBorder";
            this.cmbInputBorder.Size = new System.Drawing.Size(173, 21);
            this.cmbInputBorder.TabIndex = 106;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(3, 32);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(126, 13);
            this.label14.TabIndex = 103;
            this.label14.Text = "Meteoroloji Veri Katmanı :";
            // 
            // cmbInputLayer
            // 
            this.cmbInputLayer.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbInputLayer.FormattingEnabled = true;
            this.cmbInputLayer.Location = new System.Drawing.Point(135, 29);
            this.cmbInputLayer.Name = "cmbInputLayer";
            this.cmbInputLayer.Size = new System.Drawing.Size(173, 21);
            this.cmbInputLayer.TabIndex = 102;
            // 
            // btnOk
            // 
            this.btnOk.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOk.Location = new System.Drawing.Point(584, 75);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 23);
            this.btnOk.TabIndex = 53;
            this.btnOk.Text = "Çalıştır";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // ucDeMartonneGottmanSablon
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.grpbxInput);
            this.Controls.Add(this.grpbxInfo);
            this.Name = "ucDeMartonneGottmanSablon";
            this.Size = new System.Drawing.Size(694, 216);
            this.grpbxInfo.ResumeLayout(false);
            this.grpbxInput.ResumeLayout(false);
            this.grpbxInput.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grpbxInfo;
        private System.Windows.Forms.Label lblInfo1;
        private System.Windows.Forms.GroupBox grpbxInput;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.ComboBox cmbInputBorder;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.ComboBox cmbInputLayer;
        private TextProgressBar tpSonuc;
    }
}
