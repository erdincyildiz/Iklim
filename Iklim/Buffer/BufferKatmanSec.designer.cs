namespace Iklim
{
    partial class BufferKatmanSec
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
            this.listBoxTumKatmanlarBuffer = new System.Windows.Forms.ListBox();
            this.listBoxKullanilacaklarBuffer = new System.Windows.Forms.ListBox();
            this.BtnSagaGecirBuffer = new System.Windows.Forms.Button();
            this.BtnSolaGecirBuffer = new System.Windows.Forms.Button();
            this.BtnSagaHepsiniGecirBuffer = new System.Windows.Forms.Button();
            this.BtnSolaHepsiniGecirBuffer = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.LayerName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Tampon = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btnOk = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // listBoxTumKatmanlarBuffer
            // 
            this.listBoxTumKatmanlarBuffer.DisplayMember = "Name";
            this.listBoxTumKatmanlarBuffer.FormattingEnabled = true;
            this.listBoxTumKatmanlarBuffer.Location = new System.Drawing.Point(80, 100);
            this.listBoxTumKatmanlarBuffer.Name = "listBoxTumKatmanlarBuffer";
            this.listBoxTumKatmanlarBuffer.Size = new System.Drawing.Size(192, 121);
            this.listBoxTumKatmanlarBuffer.TabIndex = 0;
            this.listBoxTumKatmanlarBuffer.ValueMember = "Name";
            // 
            // listBoxKullanilacaklarBuffer
            // 
            this.listBoxKullanilacaklarBuffer.DisplayMember = "Name";
            this.listBoxKullanilacaklarBuffer.FormattingEnabled = true;
            this.listBoxKullanilacaklarBuffer.Location = new System.Drawing.Point(389, 100);
            this.listBoxKullanilacaklarBuffer.Name = "listBoxKullanilacaklarBuffer";
            this.listBoxKullanilacaklarBuffer.Size = new System.Drawing.Size(192, 121);
            this.listBoxKullanilacaklarBuffer.TabIndex = 1;
            // 
            // BtnSagaGecirBuffer
            // 
            this.BtnSagaGecirBuffer.Location = new System.Drawing.Point(293, 129);
            this.BtnSagaGecirBuffer.Name = "BtnSagaGecirBuffer";
            this.BtnSagaGecirBuffer.Size = new System.Drawing.Size(75, 23);
            this.BtnSagaGecirBuffer.TabIndex = 2;
            this.BtnSagaGecirBuffer.Text = ">>>>";
            this.BtnSagaGecirBuffer.UseVisualStyleBackColor = true;
            this.BtnSagaGecirBuffer.Click += new System.EventHandler(this.BtnSagaGecirBuffer_Click);
            // 
            // BtnSolaGecirBuffer
            // 
            this.BtnSolaGecirBuffer.Location = new System.Drawing.Point(293, 169);
            this.BtnSolaGecirBuffer.Name = "BtnSolaGecirBuffer";
            this.BtnSolaGecirBuffer.Size = new System.Drawing.Size(75, 23);
            this.BtnSolaGecirBuffer.TabIndex = 3;
            this.BtnSolaGecirBuffer.Text = "<<<<";
            this.BtnSolaGecirBuffer.UseVisualStyleBackColor = true;
            this.BtnSolaGecirBuffer.Click += new System.EventHandler(this.BtnSolaGecirBuffer_Click);
            // 
            // BtnSagaHepsiniGecirBuffer
            // 
            this.BtnSagaHepsiniGecirBuffer.Location = new System.Drawing.Point(293, 100);
            this.BtnSagaHepsiniGecirBuffer.Name = "BtnSagaHepsiniGecirBuffer";
            this.BtnSagaHepsiniGecirBuffer.Size = new System.Drawing.Size(75, 23);
            this.BtnSagaHepsiniGecirBuffer.TabIndex = 4;
            this.BtnSagaHepsiniGecirBuffer.Text = "Hepsi >>>";
            this.BtnSagaHepsiniGecirBuffer.UseVisualStyleBackColor = true;
            this.BtnSagaHepsiniGecirBuffer.Click += new System.EventHandler(this.BtnSagaHepsiniGecirBuffer_Click);
            // 
            // BtnSolaHepsiniGecirBuffer
            // 
            this.BtnSolaHepsiniGecirBuffer.Location = new System.Drawing.Point(293, 198);
            this.BtnSolaHepsiniGecirBuffer.Name = "BtnSolaHepsiniGecirBuffer";
            this.BtnSolaHepsiniGecirBuffer.Size = new System.Drawing.Size(75, 23);
            this.BtnSolaHepsiniGecirBuffer.TabIndex = 5;
            this.BtnSolaHepsiniGecirBuffer.Text = "<<< Hepsi";
            this.BtnSolaHepsiniGecirBuffer.UseVisualStyleBackColor = true;
            this.BtnSolaHepsiniGecirBuffer.Click += new System.EventHandler(this.BtnSolaHepsiniGecirBuffer_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(3, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(311, 20);
            this.label1.TabIndex = 6;
            this.label1.Text = "Tampon Bölge Analizi Yapılacak Katmanlar";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.LayerName,
            this.Tampon});
            this.dataGridView1.Location = new System.Drawing.Point(80, 280);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(501, 150);
            this.dataGridView1.TabIndex = 22;
            // 
            // LayerName
            // 
            this.LayerName.HeaderText = "Katman Adı";
            this.LayerName.Name = "LayerName";
            this.LayerName.Width = 200;
            // 
            // Tampon
            // 
            this.Tampon.FillWeight = 200F;
            this.Tampon.HeaderText = "Tampon";
            this.Tampon.Name = "Tampon";
            this.Tampon.Width = 200;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(76, 77);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(131, 20);
            this.label5.TabIndex = 24;
            this.label5.Text = "Analiz Katmanları";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(385, 77);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(190, 20);
            this.label6.TabIndex = 25;
            this.label6.Text = "Enterpolasyon Katmanları";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 50);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(322, 13);
            this.label2.TabIndex = 27;
            this.label2.Text = "Tampon bölge analizi sadece nokta, çizgi verileri için hazırlanmıştır. ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 30);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(568, 13);
            this.label3.TabIndex = 26;
            this.label3.Text = "Analizde kullanılacak olan katmanlardan tampon bölge analizi yapılacak olanları s" +
    "oldaki listeden sağdaki listeye taşıyınız.";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 244);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(490, 13);
            this.label4.TabIndex = 28;
            this.label4.Text = "Enterpolasyon yapmak için seçilen katmanlar ile ilgili özelleştirmeleri aşağıdaki" +
    " pencerede tamamlayınız. ";
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(506, 445);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 23);
            this.btnOk.TabIndex = 29;
            this.btnOk.Text = "Çalıştır";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // BufferKatmanSec
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.BtnSolaHepsiniGecirBuffer);
            this.Controls.Add(this.BtnSagaHepsiniGecirBuffer);
            this.Controls.Add(this.BtnSolaGecirBuffer);
            this.Controls.Add(this.BtnSagaGecirBuffer);
            this.Controls.Add(this.listBoxKullanilacaklarBuffer);
            this.Controls.Add(this.listBoxTumKatmanlarBuffer);
            this.Name = "BufferKatmanSec";
            this.Size = new System.Drawing.Size(682, 494);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox listBoxTumKatmanlarBuffer;
        private System.Windows.Forms.ListBox listBoxKullanilacaklarBuffer;
        private System.Windows.Forms.Button BtnSagaGecirBuffer;
        private System.Windows.Forms.Button BtnSolaGecirBuffer;
        private System.Windows.Forms.Button BtnSagaHepsiniGecirBuffer;
        private System.Windows.Forms.Button BtnSolaHepsiniGecirBuffer;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn LayerName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Tampon;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnOk;
    }
}
