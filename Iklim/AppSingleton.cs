using ESRI.ArcGIS.ArcMapUI;
using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.esriSystem;
using ESRI.ArcGIS.Geodatabase;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;

namespace Iklim
{
    public class AppSingleton
    {
        public double CellSize { get; set; }
        public bool AralariEkle { get; set; }
        public IMxDocument MxDocument { get; set; }

        public int NodataValue { get; set; }
        public string KrigingYaricap { get; set; }
        public string IDWYaricap { get; set; }
        public string KrigingSemiVariogram { get; set; }
        public List<LayerObject> allLayers { get; set; }
        public ILayer SinirLayer { get; set; }
        public string TinRasterMethod { get; set; }
        public string TinRasterDataType { get; set; }
        public string KrigingLagSayisi { get; set; }

        public string WorkspacePath { get; set; }

        public int PolyItemCount { get; set; }
        public int EnterpoleItemCount { get; set; }
        public int BufferItemCount { get; set; }

        public List<LayerField> PoligonFieldListesi { get; set; }
        public List<LayerField> BufferFieldListesi { get; set; }
        public List<LayerType> TumKatmanlarListesi { get; set; }
        public List<AgirlikType> AgirlikListesi { get; set; }
        public List<EnterpoleField> EnterpoleFieldListesi { get; set; }

        public List<LayerObject> FinalEnterpolasyonKatmanListesi { get; set; }
        public List<LayerObject> FinalPoligonKatmanListesi { get; set; }
        public List<LayerObject> FinalTamponKatmanListesi { get; set; }

        public List<LayerObject> EnterpoleLayerList { get; set; }
        public List<LayerObject> BufferLayerList { get; set; }
        public List<LayerObject> PolygonLayerList { get; set; }

        public List<LayerObject> RasterLayerList { get; set; }
        public List<LayerObject> AllLayers { get; set; }

        public Dictionary<string, FieldGrid> PolyGridDict { get; set; }
        public Dictionary<string, EnterpoleGrid> EnterpoleGridDict { get; set; }
        public Dictionary<string, FieldGrid> BufferDict { get; set; }
        public Dictionary<string, LayerType> AllLayersDict { get; set; }

        public Dictionary<string, AgirlikType> AgirlikDict { get; set; }
        public List<FieldLayerObject> ReclassList { get; set; }

        public WizardHost wizardHost { get; set; }

        public IWorkspace PersonalWorkspace { get; set; }

        public string Path { get; set; }

        public void CreateWorkspacePath()
        {
            if (WorkspacePath != null)
            {
                MessageBox.Show(WorkspacePath);
                return;
            }
            string path ="C:"+ "\\Iklim\\" + DateTime.Today.ToShortDateString().Replace("/", ".") + "\\";
            Path = path;
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);                

            }
            clearFolder("C:"+ "\\Iklim");
            CreateAccessWorkspace(path);
        }

        public void CreateAccessWorkspace(string path)
        {
            try
            {
                // Instantiate an Access workspace factory and create a personal geodatabase.
                // The Create method returns a workspace name object.
                Type factoryType = Type.GetTypeFromProgID(
                    "esriDataSourcesGDB.AccessWorkspaceFactory");
                string guid = Guid.NewGuid().ToString();
                IWorkspaceFactory workspaceFactory = (IWorkspaceFactory)Activator.CreateInstance
                    (factoryType);
                IWorkspaceName workspaceName = workspaceFactory.Create(path, guid + ".mdb", null,
                    0);

                // Cast the workspace name object to the IName interface and open the workspace.
                IName name = (IName)workspaceName;
                IWorkspace workspace = (IWorkspace)name.Open();
                WorkspacePath = path + guid + ".mdb";
                PersonalWorkspace = workspace;
            }
            catch (Exception ex)
            {
            }
        }

        private void clearFolder(string FolderName)
        {

            foreach (string subDirectory in System.IO.Directory.GetDirectories(FolderName))
            {
                string name = subDirectory.Remove(0, subDirectory.LastIndexOf('\\') + 1);
                DateTime myDate = Convert.ToDateTime(name);
                DateTime fiveDays = DateTime.Today.AddDays(-5);
                if (fiveDays > myDate)
                {
                    clearAllFolder(subDirectory);
                }

            }
        }
        private void clearAllFolder(string path)
        {
            ProcessStartInfo Info = new ProcessStartInfo();
            Info.Arguments = "/C rd /s /q \"" + path;
            Info.WindowStyle = ProcessWindowStyle.Hidden;
            Info.CreateNoWindow = true;
            Info.FileName = "cmd.exe";
            Process.Start(Info);
        }
        private static AppSingleton instance;

        public static AppSingleton Instance()
        {
            if (instance == null)
                instance = new AppSingleton();

            return instance;
        }
    }
}