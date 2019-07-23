namespace Iklim
{
    partial class ucTools
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucTools));
            this.grpbxInfo = new System.Windows.Forms.GroupBox();
            this.lblInfo1 = new System.Windows.Forms.Label();
            this.grpbxInput = new System.Windows.Forms.GroupBox();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.btnTampon = new System.Windows.Forms.Button();
            this.btnXYTable = new System.Windows.Forms.Button();
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
            this.grpbxInfo.Size = new System.Drawing.Size(632, 100);
            this.grpbxInfo.TabIndex = 0;
            this.grpbxInfo.TabStop = false;
            this.grpbxInfo.Text = "Veri Düzenleme Fonksiyonları";
            // 
            // lblInfo1
            // 
            this.lblInfo1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInfo1.Location = new System.Drawing.Point(6, 16);
            this.lblInfo1.Name = "lblInfo1";
            this.lblInfo1.Size = new System.Drawing.Size(620, 51);
            this.lblInfo1.TabIndex = 0;
            this.lblInfo1.Text = resources.GetString("lblInfo1.Text");
            // 
            // grpbxInput
            // 
            this.grpbxInput.Controls.Add(this.button2);
            this.grpbxInput.Controls.Add(this.button1);
            this.grpbxInput.Controls.Add(this.btnTampon);
            this.grpbxInput.Controls.Add(this.btnXYTable);
            this.grpbxInput.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpbxInput.Location = new System.Drawing.Point(3, 109);
            this.grpbxInput.Name = "grpbxInput";
            this.grpbxInput.Size = new System.Drawing.Size(632, 161);
            this.grpbxInput.TabIndex = 1;
            this.grpbxInput.TabStop = false;
            this.grpbxInput.Text = "Veri Düzenleme Fonksiyonları Listesi";
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.Location = new System.Drawing.Point(477, 40);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 75);
            this.button2.TabIndex = 0;
            this.button2.Text = "Kadastro Veri Kontrolü";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(342, 40);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 75);
            this.button1.TabIndex = 0;
            this.button1.Text = "Yüzey Oluşturma";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // btnTampon
            // 
            this.btnTampon.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTampon.Location = new System.Drawing.Point(207, 40);
            this.btnTampon.Name = "btnTampon";
            this.btnTampon.Size = new System.Drawing.Size(75, 75);
            this.btnTampon.TabIndex = 0;
            this.btnTampon.Text = "Tampon Bölge Analizi";
            this.btnTampon.UseVisualStyleBackColor = true;
            // 
            // btnXYTable
            // 
            this.btnXYTable.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnXYTable.Location = new System.Drawing.Point(72, 40);
            this.btnXYTable.Name = "btnXYTable";
            this.btnXYTable.Size = new System.Drawing.Size(75, 75);
            this.btnXYTable.TabIndex = 0;
            this.btnXYTable.Text = "Excel - Nokta Dönüşümü";
            this.btnXYTable.UseVisualStyleBackColor = true;
            this.btnXYTable.Click += new System.EventHandler(this.btnXYTable_Click);
            // 
            // ucTools
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.grpbxInput);
            this.Controls.Add(this.grpbxInfo);
            this.Name = "ucTools";
            this.Size = new System.Drawing.Size(640, 366);
            this.grpbxInfo.ResumeLayout(false);
            this.grpbxInput.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grpbxInfo;
        private System.Windows.Forms.Label lblInfo1;
        private System.Windows.Forms.GroupBox grpbxInput;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnTampon;
        private System.Windows.Forms.Button btnXYTable;
        private System.Windows.Forms.Button button2;
    }
}
