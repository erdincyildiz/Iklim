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
            this.SuspendLayout();
            // 
            // ucKadastro
            // 
            this.ucKadastro.Location = new System.Drawing.Point(12, 12);
            this.ucKadastro.Name = "ucKadastro";
            this.ucKadastro.Size = new System.Drawing.Size(694, 412);
            this.ucKadastro.TabIndex = 0;
            // 
            // KadastroForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(723, 454);
            this.Controls.Add(this.ucKadastro);
            this.Name = "KadastroForm";
            this.Text = "KadastroForm";
            this.ResumeLayout(false);

        }

        #endregion

        private ucKadastro ucKadastro;
    }
}