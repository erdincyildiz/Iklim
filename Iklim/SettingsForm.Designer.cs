namespace Iklim
{
    partial class SettingsForm
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
            this.btnSaveSettings = new System.Windows.Forms.Button();
            this.settingsControl1 = new Iklim.SettingsControl();
            this.SuspendLayout();
            // 
            // btnSaveSettings
            // 
            this.btnSaveSettings.Location = new System.Drawing.Point(592, 467);
            this.btnSaveSettings.Name = "btnSaveSettings";
            this.btnSaveSettings.Size = new System.Drawing.Size(75, 23);
            this.btnSaveSettings.TabIndex = 1;
            this.btnSaveSettings.Text = "Kaydet";
            this.btnSaveSettings.UseVisualStyleBackColor = true;
            this.btnSaveSettings.Click += new System.EventHandler(this.btnSaveSettings_Click);
            // 
            // settingsControl1
            // 
            this.settingsControl1.Location = new System.Drawing.Point(5, 3);
            this.settingsControl1.Name = "settingsControl1";
            this.settingsControl1.Size = new System.Drawing.Size(676, 458);
            this.settingsControl1.TabIndex = 2;
            // 
            // SettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(693, 502);
            this.Controls.Add(this.settingsControl1);
            this.Controls.Add(this.btnSaveSettings);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "SettingsForm";
            this.Text = "Ayarlar";
            this.Load += new System.EventHandler(this.SettingsForm_Load);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btnSaveSettings;
        private SettingsControl settingsControl1;
    }
}