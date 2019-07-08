namespace Iklim
{
    partial class MainForm
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
            this.btnKoppen = new System.Windows.Forms.Button();
            this.btnKoppenGreiger = new System.Windows.Forms.Button();
            this.btnTrewertha = new System.Windows.Forms.Button();
            this.btnThornwaithe = new System.Windows.Forms.Button();
            this.btnAydeniz = new System.Windows.Forms.Button();
            this.btnErinc = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnKoppen
            // 
            this.btnKoppen.Location = new System.Drawing.Point(52, 42);
            this.btnKoppen.Name = "btnKoppen";
            this.btnKoppen.Size = new System.Drawing.Size(75, 23);
            this.btnKoppen.TabIndex = 0;
            this.btnKoppen.Text = "Köppen";
            this.btnKoppen.UseVisualStyleBackColor = true;
            // 
            // btnKoppenGreiger
            // 
            this.btnKoppenGreiger.Location = new System.Drawing.Point(134, 42);
            this.btnKoppenGreiger.Name = "btnKoppenGreiger";
            this.btnKoppenGreiger.Size = new System.Drawing.Size(129, 23);
            this.btnKoppenGreiger.TabIndex = 1;
            this.btnKoppenGreiger.Text = "Köppen Greiger";
            this.btnKoppenGreiger.UseVisualStyleBackColor = true;
            // 
            // btnTrewertha
            // 
            this.btnTrewertha.Location = new System.Drawing.Point(285, 42);
            this.btnTrewertha.Name = "btnTrewertha";
            this.btnTrewertha.Size = new System.Drawing.Size(75, 23);
            this.btnTrewertha.TabIndex = 2;
            this.btnTrewertha.Text = "Trewertha";
            this.btnTrewertha.UseVisualStyleBackColor = true;
            // 
            // btnThornwaithe
            // 
            this.btnThornwaithe.Location = new System.Drawing.Point(52, 92);
            this.btnThornwaithe.Name = "btnThornwaithe";
            this.btnThornwaithe.Size = new System.Drawing.Size(75, 23);
            this.btnThornwaithe.TabIndex = 3;
            this.btnThornwaithe.Text = "Thornwaithe";
            this.btnThornwaithe.UseVisualStyleBackColor = true;
            // 
            // btnAydeniz
            // 
            this.btnAydeniz.Location = new System.Drawing.Point(134, 92);
            this.btnAydeniz.Name = "btnAydeniz";
            this.btnAydeniz.Size = new System.Drawing.Size(75, 23);
            this.btnAydeniz.TabIndex = 4;
            this.btnAydeniz.Text = "Aydeniz";
            this.btnAydeniz.UseVisualStyleBackColor = true;
            // 
            // btnErinc
            // 
            this.btnErinc.Location = new System.Drawing.Point(228, 92);
            this.btnErinc.Name = "btnErinc";
            this.btnErinc.Size = new System.Drawing.Size(75, 23);
            this.btnErinc.TabIndex = 5;
            this.btnErinc.Text = "Erinç";
            this.btnErinc.UseVisualStyleBackColor = true;
            this.btnErinc.Click += new System.EventHandler(this.btnErinc_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(402, 168);
            this.Controls.Add(this.btnErinc);
            this.Controls.Add(this.btnAydeniz);
            this.Controls.Add(this.btnThornwaithe);
            this.Controls.Add(this.btnTrewertha);
            this.Controls.Add(this.btnKoppenGreiger);
            this.Controls.Add(this.btnKoppen);
            this.Name = "MainForm";
            this.Text = "MainForm";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnKoppen;
        private System.Windows.Forms.Button btnKoppenGreiger;
        private System.Windows.Forms.Button btnTrewertha;
        private System.Windows.Forms.Button btnThornwaithe;
        private System.Windows.Forms.Button btnAydeniz;
        private System.Windows.Forms.Button btnErinc;
    }
}