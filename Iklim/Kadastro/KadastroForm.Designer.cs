namespace Iklim
{
    partial class KadastroForm
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
            this.ucKadastro = new Iklim.ucKadastro();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // ucKadastro
            // 
            this.ucKadastro.Location = new System.Drawing.Point(12, 12);
            this.ucKadastro.Name = "ucKadastro";
            this.ucKadastro.Size = new System.Drawing.Size(694, 412);
            this.ucKadastro.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 432);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(144, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Tuğba MEMİŞOĞLU @2019";
            // 
            // KadastroForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(723, 454);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.ucKadastro);
            this.Name = "KadastroForm";
            this.Text = "Kadastro Verileri İle İklim Sınırları Ve Ekolojik Sit Alanları Bilgilerinin Eşleş" +
    "tirilmesi";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ucKadastro ucKadastro;
        private System.Windows.Forms.Label label2;
    }
}