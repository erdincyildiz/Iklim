namespace Iklim
{
    partial class EnterpolasyonKatmanSec
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
            this.label2 = new System.Windows.Forms.Label();
            this.BtnSolaHepsiniGecirEnterpole = new System.Windows.Forms.Button();
            this.BtnSagaHepsiniGecirEnterpole = new System.Windows.Forms.Button();
            this.BtnSolaGecirEnterpole = new System.Windows.Forms.Button();
            this.BtnSagaGecirEnterpole = new System.Windows.Forms.Button();
            this.listBoxKullanilacaklarEnterpole = new System.Windows.Forms.ListBox();
            this.listBoxTumKatmanlarEnterpole = new System.Windows.Forms.ListBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.LayerName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnName = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.Target = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.InterpolationType = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(3, 10);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(260, 20);
            this.label2.TabIndex = 20;
            this.label2.Text = "Enterpolasyon Yapılacak Katmanlar";
            // 
            // BtnSolaHepsiniGecirEnterpole
            // 
            this.BtnSolaHepsiniGecirEnterpole.Location = new System.Drawing.Point(293, 198);
            this.BtnSolaHepsiniGecirEnterpole.Name = "BtnSolaHepsiniGecirEnterpole";
            this.BtnSolaHepsiniGecirEnterpole.Size = new System.Drawing.Size(75, 23);
            this.BtnSolaHepsiniGecirEnterpole.TabIndex = 19;
            this.BtnSolaHepsiniGecirEnterpole.Text = "<<< Hepsi";
            this.BtnSolaHepsiniGecirEnterpole.UseVisualStyleBackColor = true;
            this.BtnSolaHepsiniGecirEnterpole.Click += new System.EventHandler(this.BtnSolaHepsiniGecirEnterpole_Click);
            // 
            // BtnSagaHepsiniGecirEnterpole
            // 
            this.BtnSagaHepsiniGecirEnterpole.Location = new System.Drawing.Point(293, 100);
            this.BtnSagaHepsiniGecirEnterpole.Name = "BtnSagaHepsiniGecirEnterpole";
            this.BtnSagaHepsiniGecirEnterpole.Size = new System.Drawing.Size(75, 23);
            this.BtnSagaHepsiniGecirEnterpole.TabIndex = 18;
            this.BtnSagaHepsiniGecirEnterpole.Text = "Hepsi >>>";
            this.BtnSagaHepsiniGecirEnterpole.UseVisualStyleBackColor = true;
            this.BtnSagaHepsiniGecirEnterpole.Click += new System.EventHandler(this.BtnSagaHepsiniGecirEnterpole_Click);
            // 
            // BtnSolaGecirEnterpole
            // 
            this.BtnSolaGecirEnterpole.Location = new System.Drawing.Point(293, 169);
            this.BtnSolaGecirEnterpole.Name = "BtnSolaGecirEnterpole";
            this.BtnSolaGecirEnterpole.Size = new System.Drawing.Size(75, 23);
            this.BtnSolaGecirEnterpole.TabIndex = 17;
            this.BtnSolaGecirEnterpole.Text = "<<<<";
            this.BtnSolaGecirEnterpole.UseVisualStyleBackColor = true;
            this.BtnSolaGecirEnterpole.Click += new System.EventHandler(this.BtnSolaGecirEnterpole_Click);
            // 
            // BtnSagaGecirEnterpole
            // 
            this.BtnSagaGecirEnterpole.Location = new System.Drawing.Point(293, 129);
            this.BtnSagaGecirEnterpole.Name = "BtnSagaGecirEnterpole";
            this.BtnSagaGecirEnterpole.Size = new System.Drawing.Size(75, 23);
            this.BtnSagaGecirEnterpole.TabIndex = 16;
            this.BtnSagaGecirEnterpole.Text = ">>>>";
            this.BtnSagaGecirEnterpole.UseVisualStyleBackColor = true;
            this.BtnSagaGecirEnterpole.Click += new System.EventHandler(this.BtnSagaGecirEnterpole_Click);
            // 
            // listBoxKullanilacaklarEnterpole
            // 
            this.listBoxKullanilacaklarEnterpole.DisplayMember = "Name";
            this.listBoxKullanilacaklarEnterpole.FormattingEnabled = true;
            this.listBoxKullanilacaklarEnterpole.Location = new System.Drawing.Point(389, 100);
            this.listBoxKullanilacaklarEnterpole.Name = "listBoxKullanilacaklarEnterpole";
            this.listBoxKullanilacaklarEnterpole.Size = new System.Drawing.Size(192, 121);
            this.listBoxKullanilacaklarEnterpole.TabIndex = 15;
            // 
            // listBoxTumKatmanlarEnterpole
            // 
            this.listBoxTumKatmanlarEnterpole.DisplayMember = "Name";
            this.listBoxTumKatmanlarEnterpole.FormattingEnabled = true;
            this.listBoxTumKatmanlarEnterpole.Location = new System.Drawing.Point(80, 100);
            this.listBoxTumKatmanlarEnterpole.Name = "listBoxTumKatmanlarEnterpole";
            this.listBoxTumKatmanlarEnterpole.Size = new System.Drawing.Size(192, 121);
            this.listBoxTumKatmanlarEnterpole.TabIndex = 14;
            this.listBoxTumKatmanlarEnterpole.ValueMember = "Name";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.LayerName,
            this.ColumnName,
            this.Target,
            this.InterpolationType});
            this.dataGridView1.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.dataGridView1.Location = new System.Drawing.Point(80, 280);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(501, 150);
            this.dataGridView1.TabIndex = 21;
            // 
            // LayerName
            // 
            this.LayerName.HeaderText = "Katman Adı";
            this.LayerName.Name = "LayerName";
            // 
            // ColumnName
            // 
            this.ColumnName.HeaderText = "Öznitelik Adı";
            this.ColumnName.Name = "ColumnName";
            // 
            // Target
            // 
            this.Target.HeaderText = "Hedef";
            this.Target.Name = "Target";
            // 
            // InterpolationType
            // 
            this.InterpolationType.HeaderText = "Enterpolasyon Metodu";
            this.InterpolationType.Name = "InterpolationType";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 30);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(538, 13);
            this.label3.TabIndex = 22;
            this.label3.Text = "Analizde kullanılacak olan katmanlardan enterpolasyon yapılacak olanları soldaki " +
    "listeden sağdaki listeye taşıyınız.";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 50);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(353, 13);
            this.label1.TabIndex = 22;
            this.label1.Text = "Enterpolasyon sadece Eğim, Yükseklik ve Nüfus verileri için hazırlanmıştır.";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 244);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(490, 13);
            this.label4.TabIndex = 22;
            this.label4.Text = "Enterpolasyon yapmak için seçilen katmanlar ile ilgili özelleştirmeleri aşağıdaki" +
    " pencerede tamamlayınız. ";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(76, 76);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(131, 20);
            this.label5.TabIndex = 23;
            this.label5.Text = "Analiz Katmanları";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(385, 76);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(190, 20);
            this.label6.TabIndex = 23;
            this.label6.Text = "Enterpolasyon Katmanları";
            // 
            // EnterpolasyonKatmanSec
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.BtnSolaHepsiniGecirEnterpole);
            this.Controls.Add(this.BtnSagaHepsiniGecirEnterpole);
            this.Controls.Add(this.BtnSolaGecirEnterpole);
            this.Controls.Add(this.BtnSagaGecirEnterpole);
            this.Controls.Add(this.listBoxKullanilacaklarEnterpole);
            this.Controls.Add(this.listBoxTumKatmanlarEnterpole);
            this.Name = "EnterpolasyonKatmanSec";
            this.Size = new System.Drawing.Size(682, 449);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button BtnSolaHepsiniGecirEnterpole;
        private System.Windows.Forms.Button BtnSagaHepsiniGecirEnterpole;
        private System.Windows.Forms.Button BtnSolaGecirEnterpole;
        private System.Windows.Forms.Button BtnSagaGecirEnterpole;
        private System.Windows.Forms.ListBox listBoxKullanilacaklarEnterpole;
        private System.Windows.Forms.ListBox listBoxTumKatmanlarEnterpole;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn LayerName;
        private System.Windows.Forms.DataGridViewComboBoxColumn ColumnName;
        private System.Windows.Forms.DataGridViewComboBoxColumn Target;
        private System.Windows.Forms.DataGridViewComboBoxColumn InterpolationType;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;

    }
}
