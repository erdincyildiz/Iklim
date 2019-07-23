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
            IMxDocument mxDocument = ArcMap.Document;
            AppSingleton.Instance().MxDocument = mxDocument;
            MainForm mainForm = new MainForm();
            mainForm.ShowDialog();
           
        }

        protected override void OnUpdate()
        {
           
        }
    }
}