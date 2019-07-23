using System;
using System.Collections.Generic;
using System.Text;
using System.IO;


namespace Iklim
{
    public class btnThird : ESRI.ArcGIS.Desktop.AddIns.Button
    {
        public btnThird()
        {
        }

        protected override void OnClick()
        {
            AppSingleton.Instance().CreateWorkspacePath();
            ThirdForm form = new ThirdForm();
            form.ShowDialog();
        }

        protected override void OnUpdate()
        {
        }
    }
}
