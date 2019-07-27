using ESRI.ArcGIS.ArcMapUI;
using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.DataSourcesRaster;
using ESRI.ArcGIS.esriSystem;
using ESRI.ArcGIS.Geodatabase;
using ESRI.ArcGIS.Geometry;
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

        public SettingsControl SettingsControl { get; set; }
        public string Path { get; set; }

        public string UygulamaYontemi { get; set; }
        public void CreateWorkspacePath()
        {
            string path =Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\Iklim\\" + DateTime.Today.ToShortDateString().Replace("/", ".") + "\\";
            Path = path;
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);                

            }
            clearFolder(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\Iklim");
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

        public string Kriging(ILayer selectedLayer, string FieldName)
        {
            try
            {
                ESRI.ArcGIS.SpatialAnalystTools.Kriging kriging = new ESRI.ArcGIS.SpatialAnalystTools.Kriging();
                kriging.cell_size = AppSingleton.Instance().CellSize;
                kriging.out_surface_raster = AppSingleton.Instance().WorkspacePath + "\\" + selectedLayer.Name + "_Kriging_" + FieldName;
                kriging.in_point_features = selectedLayer;
                kriging.z_field = FieldName;
                kriging.semiVariogram_props = AppSingleton.Instance().KrigingSemiVariogram + " " + AppSingleton.Instance().KrigingLagSayisi;
                kriging.search_radius = AppSingleton.Instance().KrigingYaricap;

                ESRI.ArcGIS.Geoprocessor.Geoprocessor gp = new ESRI.ArcGIS.Geoprocessor.Geoprocessor();

                gp.AddOutputsToMap = AppSingleton.Instance().AralariEkle;
                gp.OverwriteOutput = true;
                gp.Execute(kriging, null);
                return kriging.out_surface_raster.ToString();
            }
            catch (Exception ex)
            {
                return string.Empty;
            }
        }

        public bool AddField(object table, string fieldName, string type)
        {
            try
            {
                ESRI.ArcGIS.Geoprocessor.Geoprocessor gp = new ESRI.ArcGIS.Geoprocessor.Geoprocessor();
                ESRI.ArcGIS.DataManagementTools.AddField addField = new ESRI.ArcGIS.DataManagementTools.AddField();
                addField.in_table = table;
                addField.field_name = fieldName;
                addField.field_type = type;
                addField.field_is_nullable = "NULLABLE";
                addField.field_is_required = "NON_REQUIRED";

                gp.AddOutputsToMap = AppSingleton.Instance().AralariEkle;
                gp.OverwriteOutput = true;
                gp.Execute(addField, null);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public string IDW(object fclass, string FieldName, string outLayerName)
        {
            try
            {
                ESRI.ArcGIS.SpatialAnalystTools.Idw idw = new ESRI.ArcGIS.SpatialAnalystTools.Idw();
                idw.cell_size = AppSingleton.Instance().CellSize;
                idw.out_raster = AppSingleton.Instance().WorkspacePath + "\\" + outLayerName;
                idw.in_point_features = fclass;
                idw.z_field = FieldName;
                idw.power = 3;
                idw.search_radius = AppSingleton.Instance().IDWYaricap;
                ESRI.ArcGIS.Geoprocessor.Geoprocessor gp = new ESRI.ArcGIS.Geoprocessor.Geoprocessor();
                gp.AddOutputsToMap = AppSingleton.Instance().AralariEkle;
                gp.OverwriteOutput = true;
                gp.Execute(idw, null);
                return idw.out_raster.ToString();
            }
            catch (Exception ex)
            {
                return string.Empty;
            }
        }

        public string IDW(ILayer selectedLayer, string FieldName)
        {
            try
            {
                ESRI.ArcGIS.SpatialAnalystTools.Idw idw = new ESRI.ArcGIS.SpatialAnalystTools.Idw();
                idw.cell_size = AppSingleton.Instance().CellSize;
                idw.out_raster = AppSingleton.Instance().WorkspacePath + "\\" + selectedLayer.Name + "_IDW_" + FieldName;
                idw.in_point_features = selectedLayer;
                idw.z_field = FieldName;
                idw.power = 3;
                idw.search_radius = AppSingleton.Instance().IDWYaricap;
                ESRI.ArcGIS.Geoprocessor.Geoprocessor gp = new ESRI.ArcGIS.Geoprocessor.Geoprocessor();
                gp.AddOutputsToMap = AppSingleton.Instance().AralariEkle;
                gp.OverwriteOutput = true;
                gp.Execute(idw, null);
                return idw.out_raster.ToString();
            }
            catch (Exception ex)
            {
                return string.Empty;
            }
        }

        public string RasterClipLayer(object selectedLayer,IFeatureLayer sinirLayer,string outputName)
        {
            try
            {
                IFeatureWorkspace fWorkspace = AppSingleton.Instance().PersonalWorkspace as IFeatureWorkspace;
                ESRI.ArcGIS.Geoprocessor.Geoprocessor gp = new ESRI.ArcGIS.Geoprocessor.Geoprocessor();
                ESRI.ArcGIS.SpatialAnalystTools.ExtractByRectangle rastClip = new ESRI.ArcGIS.SpatialAnalystTools.ExtractByRectangle();
                rastClip.in_raster = selectedLayer;//Kriging
                rastClip.extraction_area = "INSIDE";
                rastClip.out_raster = AppSingleton.Instance().WorkspacePath + "\\"+outputName;

                IFeatureLayer fLayer = sinirLayer;
                IEnvelope env = fLayer.AreaOfInterest.Envelope;
               
                string geo = env.XMin.ToString() + " " + env.YMin.ToString() + " " + env.XMax.ToString() + " " + env.YMax.ToString();
                rastClip.rectangle = geo;

                gp.AddOutputsToMap = AppSingleton.Instance().AralariEkle;
                gp.OverwriteOutput = true;
                gp.Execute(rastClip, null);
                return rastClip.out_raster.ToString() ;
                //return clip.out_feature_class.ToString();
            }
            catch (Exception ex)
            {
                return string.Empty ;
            }
        }

        public string ClipLayers(ILayer sinirLayer, ILayer selectedLayer)
        {
            try
            {
                IFeatureWorkspace fWorkspace = PersonalWorkspace as IFeatureWorkspace;
                ESRI.ArcGIS.Geoprocessor.Geoprocessor gp = new ESRI.ArcGIS.Geoprocessor.Geoprocessor();
                ESRI.ArcGIS.AnalysisTools.Clip clip = new ESRI.ArcGIS.AnalysisTools.Clip();
                clip.in_features = selectedLayer;
                clip.clip_features = sinirLayer;
                var layerName = System.IO.Path.GetFileNameWithoutExtension(selectedLayer.Name); 
                clip.out_feature_class = WorkspacePath + "\\Clip_" + layerName;
                gp.AddOutputsToMap = AppSingleton.Instance().AralariEkle;
                gp.OverwriteOutput = true;
                gp.Execute(clip, null);
                //return clip.out_feature_class.ToString();
                return clip.out_feature_class.ToString();
            }
            catch (Exception ex)
            {
                return string.Empty;
            }
        }

        public string Int(string layerName, string outName)
        {
            try
            {
                ESRI.ArcGIS.SpatialAnalystTools.Int intRaster = new ESRI.ArcGIS.SpatialAnalystTools.Int();
                intRaster.in_raster_or_constant = layerName;
                intRaster.out_raster = AppSingleton.Instance().WorkspacePath + "\\" + outName;
                ESRI.ArcGIS.Geoprocessor.Geoprocessor gp = new ESRI.ArcGIS.Geoprocessor.Geoprocessor();
                gp.AddOutputsToMap = AppSingleton.Instance().AralariEkle;
                gp.OverwriteOutput = true;
                gp.Execute(intRaster, null);
                return intRaster.out_raster.ToString();
            }
            catch (Exception ex)
            {
                return string.Empty;
            }
        }

        public ITable BuildRasterAttributeTable(string rasterName)
        {
            try
            {

            
            Type factoryType = Type.GetTypeFromProgID(
                "esriDataSourcesGDB.AccessWorkspaceFactory");
            IWorkspaceFactory workspaceFactory = (IWorkspaceFactory)Activator.CreateInstance
               (factoryType);
            IRasterWorkspaceEx rasterWorkspaceEx = workspaceFactory.OpenFromFile(AppSingleton.Instance().WorkspacePath, 0) as IRasterWorkspaceEx;
            IRasterDataset rasterDataset = rasterWorkspaceEx.OpenRasterDataset(rasterName);
            IRasterDatasetEdit2 raster = (IRasterDatasetEdit2)rasterDataset;

            ESRI.ArcGIS.Geodatabase.IGeoDataset geoDataset = (ESRI.ArcGIS.Geodatabase.IGeoDataset)rasterDataset;
            raster.BuildAttributeTable();
            ITable vat = (raster as IRasterBandCollection).Item(0).AttributeTable;
                return vat;
            }
            catch (Exception)
            {

                return null;
            }
        }
        public string Combine(string layerNames, string outLayerName)
        {
            try
            {
                ESRI.ArcGIS.Geoprocessor.Geoprocessor gp = new ESRI.ArcGIS.Geoprocessor.Geoprocessor();
                ESRI.ArcGIS.SpatialAnalystTools.Combine combine = new ESRI.ArcGIS.SpatialAnalystTools.Combine();
                combine.in_rasters = layerNames;
                combine.out_raster = AppSingleton.Instance().WorkspacePath + "\\" + outLayerName;
                gp.AddOutputsToMap = true;
                gp.OverwriteOutput = true;
                gp.Execute(combine, null);
                return combine.out_raster.ToString();
            }
            catch (Exception ex)
            {
                return string.Empty;
            }
        }
        public string Reclassify(ILayer selectedLayer, string FieldName, string reclassMap, string inputType, string outputType)
        {
            try
            {

                ESRI.ArcGIS.Geoprocessor.Geoprocessor gp = new ESRI.ArcGIS.Geoprocessor.Geoprocessor();
                ESRI.ArcGIS.Analyst3DTools.Reclassify reclass = new ESRI.ArcGIS.Analyst3DTools.Reclassify();
                reclass.in_raster = AppSingleton.Instance().WorkspacePath + "\\" + inputType + selectedLayer.Name;//RingBuffered_
                reclass.reclass_field = FieldName;//"Value";
                reclass.out_raster = AppSingleton.Instance().WorkspacePath + "\\" + outputType + selectedLayer.Name;//Reclassified_
                reclass.remap = reclassMap;// "50 1;50 100 2;100 150 3;NODATA 0";


                gp.AddOutputsToMap = AppSingleton.Instance().AralariEkle;
                gp.OverwriteOutput = true;
                gp.Execute(reclass, null);
                return reclass.out_raster.ToString();
            }
            catch (Exception ex)
            {
                return string.Empty;
            }
        }
    }
}