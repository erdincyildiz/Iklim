namespace Iklim
{
    partial class PolygonSec
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PolygonSec));
            this.label2 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.LayerName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnName = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.label3 = new System.Windows.Forms.Label();
            this.grpbxInfoPolygonSec = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.grpbxInfoPolygonSec.SuspendLayout();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(72, 209);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(274, 20);
            this.label2.TabIndex = 21;
            this.label2.Text = "Poligon Olarak Kullanılacak Katmanlar";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.LayerName,
            this.ColumnName});
            this.dataGridView1.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.dataGridView1.Location = new System.Drawing.Point(33, 103);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(613, 317);
            this.dataGridView1.TabIndex = 22;
            // 
            // LayerName
            // 
            this.LayerName.HeaderText = "Katman Adı";
            this.LayerName.Name = "LayerName";
            this.LayerName.Width = 280;
            // 
            // ColumnName
            // 
            this.ColumnName.HeaderText = "Öznitelik Adı";
            this.ColumnName.Name = "ColumnName";
            this.ColumnName.Width = 280;
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(6, 16);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(664, 32);
            this.label3.TabIndex = 27;
            this.label3.Text = "Analizde kullanılmak üzere bir önceki ekranda seçilen vektör katmanların her biri" +
    " için bir öznitelik sütunu seçilmelidir. Oluşturulacak raster sonuç yüzeyde bu ö" +
    "znitelik değeri yer alacaktır. ";
            // 
            // grpbxInfoPolygonSec
            // 
            this.grpbxInfoPolygonSec.Controls.Add(this.label1);
            this.grpbxInfoPolygonSec.Controls.Add(this.label3);
            this.grpbxInfoPolygonSec.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpbxInfoPolygonSec.Location = new System.Drawing.Point(3, 3);
            this.grpbxInfoPolygonSec.Name = "grpbxInfoPolygonSec";
            this.grpbxInfoPolygonSec.Size = new System.Drawing.Size(676, 100);
            this.grpbxInfoPolygonSec.TabIndex = 28;
            this.grpbxInfoPolygonSec.TabStop = false;
            this.grpbxInfoPolygonSec.Text = "Girdi Katmanları İçin Özniteliklerin Belirlenmesi";
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(6, 48);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(664, 44);
            this.label1.TabIndex = 27;
            this.label1.Text = resources.GetString("label1.Text");
            // 
            // PolygonSec
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.grpbxInfoPolygonSec);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.label2);
            this.Name = "PolygonSec";
            this.Size = new System.Drawing.Size(682, 449);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.grpbxInfoPolygonSec.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn LayerName;
        private System.Windows.Forms.DataGridViewComboBoxColumn ColumnName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox grpbxInfoPolygonSec;
        private System.Windows.Forms.Label label1;
    }
}
