using System;
using System.Collections.Generic;
using System.Text;
using System.IO;


namespace Iklim
{
    public class btnKadastro : ESRI.ArcGIS.Desktop.AddIns.Button
    {
        public btnKadastro()
        {
        }

        protected override void OnClick()
        {
            AppSingleton.Instance().CreateWorkspacePath();
            KadastroForm form = new KadastroForm();
            form.ShowDialog();
        }

        protected override void OnUpdate()
        {
        }
    }
}
