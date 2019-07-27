namespace Iklim
{
    partial class BufferForm
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
            this.bufferKatmanSec1 = new Iklim.BufferKatmanSec();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // bufferKatmanSec1
            // 
            this.bufferKatmanSec1.Location = new System.Drawing.Point(12, 12);
            this.bufferKatmanSec1.Name = "bufferKatmanSec1";
            this.bufferKatmanSec1.Size = new System.Drawing.Size(682, 491);
            this.bufferKatmanSec1.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 490);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(144, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Tuğba MEMİŞOĞLU @2019";
            // 
            // BufferForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(730, 515);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.bufferKatmanSec1);
            this.Name = "BufferForm";
            this.Text = "Tampon Bölge Analizi";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private BufferKatmanSec bufferKatmanSec1;
        private System.Windows.Forms.Label label2;
    }
}