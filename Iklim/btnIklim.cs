using ESRI.ArcGIS.ArcMapUI;

namespace Iklim
{
    public class btnIklim : ESRI.ArcGIS.Desktop.AddIns.Button
    {
        public btnIklim()
        {
        }

        protected override void OnClick()
        {
            //
            //  TODO: Sample code showing how to access button host
            //
            ArcMap.Application.CurrentTool = null;
            MainForm mainForm = new MainForm();
            mainForm.Show();
            IMxDocument mxDocument = ArcMap.Document;
            AppSingleton.Instance().MxDocument = mxDocument;
        }

        protected override void OnUpdate()
        {
            Enabled = ArcMap.Application != null;
        }
    }
}