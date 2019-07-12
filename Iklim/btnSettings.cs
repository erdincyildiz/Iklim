using System;
using System.Collections.Generic;
using System.Text;
using System.IO;


namespace Iklim
{
    public class btnSettings : ESRI.ArcGIS.Desktop.AddIns.Button
    {
        public btnSettings()
        {
        }

        protected override void OnClick()
        {
            SettingsForm settingsForm = new SettingsForm();
            settingsForm.ShowDialog();
        }

        protected override void OnUpdate()
        {
        }
    }
}
