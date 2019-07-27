namespace Iklim
{
    partial class ThirdForm
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
            this.ucThird = new Iklim.ucThird();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // ucThird
            // 
            this.ucThird.Location = new System.Drawing.Point(2, -3);
            this.ucThird.Name = "ucThird";
            this.ucThird.Size = new System.Drawing.Size(689, 279);
            this.ucThird.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 279);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(144, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Tuğba MEMİŞOĞLU @2019";
            // 
            // ThirdForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(716, 301);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.ucThird);
            this.Name = "ThirdForm";
            this.Text = "İklim Sınırları ve Ekolojik Sit Alanlarının Birleştirilmesi Analizi";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ucThird ucThird;
        private System.Windows.Forms.Label label2;
    }
}