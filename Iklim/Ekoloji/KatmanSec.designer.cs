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
            this.listBoxTumKatmanlar = new System.Windows.Forms.ListBox();
            this.listBoxKullanilacaklar = new System.Windows.Forms.ListBox();
            this.BtnSagaGecir = new System.Windows.Forms.Button();
            this.BtnSolaGecir = new System.Windows.Forms.Button();
            this.BtnSagaHepsiniGecir = new System.Windows.Forms.Button();
            this.BtnSolaHepsiniGecir = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.CmbSinirKatmani = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // listBoxTumKatmanlar
            // 
            this.listBoxTumKatmanlar.DisplayMember = "Name";
            this.listBoxTumKatmanlar.FormattingEnabled = true;
            this.listBoxTumKatmanlar.Location = new System.Drawing.Point(80, 100);
            this.listBoxTumKatmanlar.Name = "listBoxTumKatmanlar";
            this.listBoxTumKatmanlar.Size = new System.Drawing.Size(192, 225);
            this.listBoxTumKatmanlar.TabIndex = 0;
            this.listBoxTumKatmanlar.ValueMember = "Name";
            // 
            // listBoxKullanilacaklar
            // 
            this.listBoxKullanilacaklar.DisplayMember = "Name";
            this.listBoxKullanilacaklar.FormattingEnabled = true;
            this.listBoxKullanilacaklar.Location = new System.Drawing.Point(389, 100);
            this.listBoxKullanilacaklar.Name = "listBoxKullanilacaklar";
            this.listBoxKullanilacaklar.Size = new System.Drawing.Size(192, 225);
            this.listBoxKullanilacaklar.TabIndex = 1;
            // 
            // BtnSagaGecir
            // 
            this.BtnSagaGecir.Location = new System.Drawing.Point(293, 179);
            this.BtnSagaGecir.Name = "BtnSagaGecir";
            this.BtnSagaGecir.Size = new System.Drawing.Size(75, 23);
            this.BtnSagaGecir.TabIndex = 2;
            this.BtnSagaGecir.Text = ">>>>";
            this.BtnSagaGecir.UseVisualStyleBackColor = true;
            this.BtnSagaGecir.Click += new System.EventHandler(this.button1_Click);
            // 
            // BtnSolaGecir
            // 
            this.BtnSolaGecir.Location = new System.Drawing.Point(293, 223);
            this.BtnSolaGecir.Name = "BtnSolaGecir";
            this.BtnSolaGecir.Size = new System.Drawing.Size(75, 23);
            this.BtnSolaGecir.TabIndex = 3;
            this.BtnSolaGecir.Text = "<<<<";
            this.BtnSolaGecir.UseVisualStyleBackColor = true;
            this.BtnSolaGecir.Click += new System.EventHandler(this.button2_Click);
            // 
            // BtnSagaHepsiniGecir
            // 
            this.BtnSagaHepsiniGecir.Location = new System.Drawing.Point(293, 150);
            this.BtnSagaHepsiniGecir.Name = "BtnSagaHepsiniGecir";
            this.BtnSagaHepsiniGecir.Size = new System.Drawing.Size(75, 23);
            this.BtnSagaHepsiniGecir.TabIndex = 4;
            this.BtnSagaHepsiniGecir.Text = "Hepsi >>>";
            this.BtnSagaHepsiniGecir.UseVisualStyleBackColor = true;
            this.BtnSagaHepsiniGecir.Click += new System.EventHandler(this.button3_Click);
            // 
            // BtnSolaHepsiniGecir
            // 
            this.BtnSolaHepsiniGecir.Location = new System.Drawing.Point(293, 252);
            this.BtnSolaHepsiniGecir.Name = "BtnSolaHepsiniGecir";
            this.BtnSolaHepsiniGecir.Size = new System.Drawing.Size(75, 23);
            this.BtnSolaHepsiniGecir.TabIndex = 5;
            this.BtnSolaHepsiniGecir.Text = "<<< Hepsi";
            this.BtnSolaHepsiniGecir.UseVisualStyleBackColor = true;
            this.BtnSolaHepsiniGecir.Click += new System.EventHandler(this.button4_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(3, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(131, 20);
            this.label1.TabIndex = 6;
            this.label1.Text = "Analiz Katmanları";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(3, 338);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(102, 20);
            this.label2.TabIndex = 7;
            this.label2.Text = "Sınır Katmanı";
            // 
            // CmbSinirKatmani
            // 
            this.CmbSinirKatmani.FormattingEnabled = true;
            this.CmbSinirKatmani.Location = new System.Drawing.Point(238, 392);
            this.CmbSinirKatmani.Name = "CmbSinirKatmani";
            this.CmbSinirKatmani.Size = new System.Drawing.Size(187, 21);
            this.CmbSinirKatmani.TabIndex = 8;
            this.CmbSinirKatmani.SelectedIndexChanged += new System.EventHandler(this.CmbSinirKatmani_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 30);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(531, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "Analizde kullanılacak olan katmanları soldaki listeden seçip sağdaki listeye arad" +
    "aki butonlar yardımıyla ekleyiniz. ";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(76, 68);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(154, 20);
            this.label4.TabIndex = 6;
            this.label4.Text = "Lejanttaki Katmanlar";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(385, 68);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(168, 20);
            this.label5.TabIndex = 6;
            this.label5.Text = "Kullanılacak Katmanlar";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(3, 367);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(596, 13);
            this.label6.TabIndex = 9;
            this.label6.Text = "Aşağıdaki kutudan çalışma alanı sınırlarını belirten bir katman seçiniz. Sınır ka" +
    "tmanı analizde kullanılmayan bir katman olmalıdır. ";
            // 
            // KatmanSec
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.CmbSinirKatmani);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.BtnSolaHepsiniGecir);
            this.Controls.Add(this.BtnSagaHepsiniGecir);
            this.Controls.Add(this.BtnSolaGecir);
            this.Controls.Add(this.BtnSagaGecir);
            this.Controls.Add(this.listBoxKullanilacaklar);
            this.Controls.Add(this.listBoxTumKatmanlar);
            this.Name = "KatmanSec";
            this.Size = new System.Drawing.Size(682, 449);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox listBoxTumKatmanlar;
        private System.Windows.Forms.ListBox listBoxKullanilacaklar;
        private System.Windows.Forms.Button BtnSagaGecir;
        private System.Windows.Forms.Button BtnSolaGecir;
        private System.Windows.Forms.Button BtnSagaHepsiniGecir;
        private System.Windows.Forms.Button BtnSolaHepsiniGecir;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox CmbSinirKatmani;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;

    }
}
