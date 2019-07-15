namespace Iklim
{
    partial class KatmanSec
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(KatmanSec));
            this.listBoxTumKatmanlar = new System.Windows.Forms.ListBox();
            this.listBoxKullanilacaklar = new System.Windows.Forms.ListBox();
            this.BtnSagaGecir = new System.Windows.Forms.Button();
            this.BtnSolaGecir = new System.Windows.Forms.Button();
            this.BtnSagaHepsiniGecir = new System.Windows.Forms.Button();
            this.BtnSolaHepsiniGecir = new System.Windows.Forms.Button();
            this.CmbSinirKatmani = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lblProjeSinir = new System.Windows.Forms.Label();
            this.grpbxInfo = new System.Windows.Forms.GroupBox();
            this.lblInfo1 = new System.Windows.Forms.Label();
            this.lblInfo2 = new System.Windows.Forms.Label();
            this.grpbxInput = new System.Windows.Forms.GroupBox();
            this.grpbxParameters = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.grpbxInfo.SuspendLayout();
            this.grpbxInput.SuspendLayout();
            this.grpbxParameters.SuspendLayout();
            this.SuspendLayout();
            // 
            // listBoxTumKatmanlar
            // 
            this.listBoxTumKatmanlar.DisplayMember = "Name";
            this.listBoxTumKatmanlar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listBoxTumKatmanlar.FormattingEnabled = true;
            this.listBoxTumKatmanlar.Location = new System.Drawing.Point(13, 36);
            this.listBoxTumKatmanlar.Name = "listBoxTumKatmanlar";
            this.listBoxTumKatmanlar.Size = new System.Drawing.Size(250, 160);
            this.listBoxTumKatmanlar.TabIndex = 0;
            this.listBoxTumKatmanlar.ValueMember = "Name";
            // 
            // listBoxKullanilacaklar
            // 
            this.listBoxKullanilacaklar.DisplayMember = "Name";
            this.listBoxKullanilacaklar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listBoxKullanilacaklar.FormattingEnabled = true;
            this.listBoxKullanilacaklar.Location = new System.Drawing.Point(428, 36);
            this.listBoxKullanilacaklar.Name = "listBoxKullanilacaklar";
            this.listBoxKullanilacaklar.Size = new System.Drawing.Size(250, 160);
            this.listBoxKullanilacaklar.TabIndex = 1;
            // 
            // BtnSagaGecir
            // 
            this.BtnSagaGecir.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnSagaGecir.Location = new System.Drawing.Point(310, 86);
            this.BtnSagaGecir.Name = "BtnSagaGecir";
            this.BtnSagaGecir.Size = new System.Drawing.Size(75, 23);
            this.BtnSagaGecir.TabIndex = 2;
            this.BtnSagaGecir.Text = ">>>>";
            this.BtnSagaGecir.UseVisualStyleBackColor = true;
            this.BtnSagaGecir.Click += new System.EventHandler(this.button1_Click);
            // 
            // BtnSolaGecir
            // 
            this.BtnSolaGecir.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnSolaGecir.Location = new System.Drawing.Point(310, 124);
            this.BtnSolaGecir.Name = "BtnSolaGecir";
            this.BtnSolaGecir.Size = new System.Drawing.Size(75, 23);
            this.BtnSolaGecir.TabIndex = 3;
            this.BtnSolaGecir.Text = "<<<<";
            this.BtnSolaGecir.UseVisualStyleBackColor = true;
            this.BtnSolaGecir.Click += new System.EventHandler(this.button2_Click);
            // 
            // BtnSagaHepsiniGecir
            // 
            this.BtnSagaHepsiniGecir.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnSagaHepsiniGecir.Location = new System.Drawing.Point(310, 48);
            this.BtnSagaHepsiniGecir.Name = "BtnSagaHepsiniGecir";
            this.BtnSagaHepsiniGecir.Size = new System.Drawing.Size(75, 23);
            this.BtnSagaHepsiniGecir.TabIndex = 4;
            this.BtnSagaHepsiniGecir.Text = "Hepsi >>>";
            this.BtnSagaHepsiniGecir.UseVisualStyleBackColor = true;
            this.BtnSagaHepsiniGecir.Click += new System.EventHandler(this.button3_Click);
            // 
            // BtnSolaHepsiniGecir
            // 
            this.BtnSolaHepsiniGecir.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnSolaHepsiniGecir.Location = new System.Drawing.Point(310, 162);
            this.BtnSolaHepsiniGecir.Name = "BtnSolaHepsiniGecir";
            this.BtnSolaHepsiniGecir.Size = new System.Drawing.Size(75, 23);
            this.BtnSolaHepsiniGecir.TabIndex = 5;
            this.BtnSolaHepsiniGecir.Text = "<<< Hepsi";
            this.BtnSolaHepsiniGecir.UseVisualStyleBackColor = true;
            this.BtnSolaHepsiniGecir.Click += new System.EventHandler(this.button4_Click);
            // 
            // CmbSinirKatmani
            // 
            this.CmbSinirKatmani.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmbSinirKatmani.FormattingEnabled = true;
            this.CmbSinirKatmani.Location = new System.Drawing.Point(151, 56);
            this.CmbSinirKatmani.Name = "CmbSinirKatmani";
            this.CmbSinirKatmani.Size = new System.Drawing.Size(222, 21);
            this.CmbSinirKatmani.TabIndex = 8;
            this.CmbSinirKatmani.SelectedIndexChanged += new System.EventHandler(this.CmbSinirKatmani_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(10, 20);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(106, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Lejanttaki Katmanlar:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(425, 20);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(117, 13);
            this.label5.TabIndex = 6;
            this.label5.Text = "Kullanılacak Katmanlar:";
            // 
            // lblProjeSinir
            // 
            this.lblProjeSinir.AutoSize = true;
            this.lblProjeSinir.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProjeSinir.Location = new System.Drawing.Point(10, 59);
            this.lblProjeSinir.Name = "lblProjeSinir";
            this.lblProjeSinir.Size = new System.Drawing.Size(135, 13);
            this.lblProjeSinir.TabIndex = 9;
            this.lblProjeSinir.Text = "Proje Analiz Sınırını Seçiniz:";
            // 
            // grpbxInfo
            // 
            this.grpbxInfo.Controls.Add(this.lblInfo2);
            this.grpbxInfo.Controls.Add(this.lblInfo1);
            this.grpbxInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpbxInfo.Location = new System.Drawing.Point(7, 3);
            this.grpbxInfo.Name = "grpbxInfo";
            this.grpbxInfo.Size = new System.Drawing.Size(684, 80);
            this.grpbxInfo.TabIndex = 10;
            this.grpbxInfo.TabStop = false;
            this.grpbxInfo.Text = "Ekolojik Sit Alanlarının Belirlenmesi";
            // 
            // lblInfo1
            // 
            this.lblInfo1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInfo1.Location = new System.Drawing.Point(10, 16);
            this.lblInfo1.Name = "lblInfo1";
            this.lblInfo1.Size = new System.Drawing.Size(668, 30);
            this.lblInfo1.TabIndex = 0;
            this.lblInfo1.Text = resources.GetString("lblInfo1.Text");
            // 
            // lblInfo2
            // 
            this.lblInfo2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInfo2.Location = new System.Drawing.Point(10, 46);
            this.lblInfo2.Name = "lblInfo2";
            this.lblInfo2.Size = new System.Drawing.Size(668, 30);
            this.lblInfo2.TabIndex = 0;
            this.lblInfo2.Text = resources.GetString("lblInfo2.Text");
            // 
            // grpbxInput
            // 
            this.grpbxInput.Controls.Add(this.label4);
            this.grpbxInput.Controls.Add(this.label5);
            this.grpbxInput.Controls.Add(this.listBoxTumKatmanlar);
            this.grpbxInput.Controls.Add(this.BtnSagaHepsiniGecir);
            this.grpbxInput.Controls.Add(this.BtnSagaGecir);
            this.grpbxInput.Controls.Add(this.listBoxKullanilacaklar);
            this.grpbxInput.Controls.Add(this.BtnSolaHepsiniGecir);
            this.grpbxInput.Controls.Add(this.BtnSolaGecir);
            this.grpbxInput.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpbxInput.Location = new System.Drawing.Point(7, 90);
            this.grpbxInput.Name = "grpbxInput";
            this.grpbxInput.Size = new System.Drawing.Size(684, 211);
            this.grpbxInput.TabIndex = 11;
            this.grpbxInput.TabStop = false;
            this.grpbxInput.Text = "Girdi Verilerin Seçilmesi";
            // 
            // grpbxParameters
            // 
            this.grpbxParameters.Controls.Add(this.label1);
            this.grpbxParameters.Controls.Add(this.lblProjeSinir);
            this.grpbxParameters.Controls.Add(this.CmbSinirKatmani);
            this.grpbxParameters.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpbxParameters.Location = new System.Drawing.Point(7, 307);
            this.grpbxParameters.Name = "grpbxParameters";
            this.grpbxParameters.Size = new System.Drawing.Size(684, 102);
            this.grpbxParameters.TabIndex = 12;
            this.grpbxParameters.TabStop = false;
            this.grpbxParameters.Text = "Proje Analiz Sınırı Belirlenmesi";
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(10, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(668, 33);
            this.label1.TabIndex = 10;
            this.label1.Text = resources.GetString("label1.Text");
            // 
            // KatmanSec
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.grpbxParameters);
            this.Controls.Add(this.grpbxInput);
            this.Controls.Add(this.grpbxInfo);
            this.Name = "KatmanSec";
            this.Size = new System.Drawing.Size(694, 412);
            this.grpbxInfo.ResumeLayout(false);
            this.grpbxInput.ResumeLayout(false);
            this.grpbxInput.PerformLayout();
            this.grpbxParameters.ResumeLayout(false);
            this.grpbxParameters.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox listBoxTumKatmanlar;
        private System.Windows.Forms.ListBox listBoxKullanilacaklar;
        private System.Windows.Forms.Button BtnSagaGecir;
        private System.Windows.Forms.Button BtnSolaGecir;
        private System.Windows.Forms.Button BtnSagaHepsiniGecir;
        private System.Windows.Forms.Button BtnSolaHepsiniGecir;
        private System.Windows.Forms.ComboBox CmbSinirKatmani;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblProjeSinir;
        private System.Windows.Forms.GroupBox grpbxInfo;
        private System.Windows.Forms.Label lblInfo2;
        private System.Windows.Forms.Label lblInfo1;
        private System.Windows.Forms.GroupBox grpbxInput;
        private System.Windows.Forms.GroupBox grpbxParameters;
        private System.Windows.Forms.Label label1;
    }
}
