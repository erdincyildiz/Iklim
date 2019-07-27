namespace Iklim
{
    partial class AydenizForm
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
            this.ucAydeniz = new Iklim.ucAydeniz();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // ucAydeniz
            // 
            this.ucAydeniz.Location = new System.Drawing.Point(4, 12);
            this.ucAydeniz.Name = "ucAydeniz";
            this.ucAydeniz.Size = new System.Drawing.Size(740, 399);
            this.ucAydeniz.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 402);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(144, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Tuğba MEMİŞOĞLU @2019";
            // 
            // AydenizForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(754, 424);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.ucAydeniz);
            this.Name = "AydenizForm";
            this.Text = "Aydeniz Yöntemi İle İklim Sınırlarının Belirlenmesi";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ucAydeniz ucAydeniz;
        private System.Windows.Forms.Label label2;
    }
}