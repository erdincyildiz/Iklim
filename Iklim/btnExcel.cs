namespace Iklim
{
    public class btnExcel : ESRI.ArcGIS.Desktop.AddIns.Button
    {
        public btnExcel()
        {
        }

        protected override void OnClick()
        {
            AppSingleton.Instance().CreateWorkspacePath();
            XYEventTableForm form = new XYEventTableForm();
            form.Show();
        }

        protected override void OnUpdate()
        {
        }
    }
}