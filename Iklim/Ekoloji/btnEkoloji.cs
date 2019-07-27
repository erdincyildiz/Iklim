using ESRI.ArcGIS.ArcMapUI;
using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.DataSourcesRaster;
using ESRI.ArcGIS.Geodatabase;
using ESRI.ArcGIS.Geometry;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Iklim
{
    public class btnEkoloji : ESRI.ArcGIS.Desktop.AddIns.Button
    {
        public BufferKatmanSec bufferKatmanSec;

        public EmptyControl emptyControl;

        public EnterpolasyonKatmanSec enterpolasyonKatmanSec;

        public LastControl lastControl;

        public PolygonSec poligonSec;

        public List<string> reclassList;

        public btnEkoloji()
        {
        }

        public double FindMaxValue(List<double> list)
        {
            try
            {
                if (list.Count == 0)
                {
                    throw new InvalidOperationException("Empty list");
                }
                double maxValue = double.MinValue;
                foreach (double type in list)
                {
                    if (type > maxValue)
                    {
                        maxValue = type;
                    }
                }
                return maxValue;
            }
            catch (Exception ex)
            {
                return -1;
            }
        }

        public double FindMinValue(List<double> list)
        {
            try
            {
                if (list.Count == 0)
                {
                    throw new InvalidOperationException("Empty list");
                }
                double minValue = double.MaxValue;
                foreach (double type in list)
                {
                    if (type < minValue)
                    {
                        minValue = type;
                    }
                }
                return minValue;
            }
            catch (Exception ex)
            {
                return -1;
            }
        }

        public FieldGrid GetBufferGrid(string layerName)
        {
            try
            {
                foreach (var item in AppSingleton.Instance().BufferDict)
                {
                    if (item.Key == layerName)
                    {
                        return item.Value;
                    }
                }
                return null;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public EnterpoleGrid GetEnterpoleGrid(string layerName)
        {
            try
            {
                foreach (var item in AppSingleton.Instance().EnterpoleGridDict)
                {
                    if (item.Key == layerName)
                    {
                        return item.Value;
                    }
                }
                return null;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public FieldLayerObject GetFieldLayerObject(string layerName)
        {
            try
            {
                foreach (var item in AppSingleton.Instance().ReclassList)
                {
                    if (item.LayerObject.Name == layerName)
                    {
                        return item;
                    }
                }
                return null;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public FieldGrid GetPolygonGrid(string layerName)
        {
            try
            {
                foreach (var item in AppSingleton.Instance().PolyGridDict)
                {
                    if (item.Key == layerName)
                    {
                        return item.Value;
                    }
                }
                return null;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public List<double> GetUniques(ITable table, string fldName)
        {
            int idx = table.Fields.FindField(fldName);
            if (idx == -1)
            {
                throw new Exception(string.Format(
                    "field {0} not found in {1}",
                    fldName, ((IDataset)table).Name));
            }
            IQueryFilter qf = new QueryFilterClass();
            qf.AddField(fldName);

            List<double> myList = new List<double>();
            ICursor cur = null;
            IRow row = null;
            try
            {
                cur = table.Search(qf, true);
                while ((row = cur.NextRow()) != null)
                {
                    try
                    {
                        double key = Convert.ToDouble(row.get_Value(idx) is DBNull ? "<Null>" :
                                               row.get_Value(idx).ToString());
                        if (!myList.Contains(key))
                        {
                            myList.Add(key);
                        }
                    }
                    catch (Exception ex)
                    {
                    }
                    finally
                    {
                        Marshal.ReleaseComObject(row);
                    }
                }
            }
            catch (Exception ex)
            {
                return null;
            }
            finally
            {
                if (cur != null)
                    System.Runtime.InteropServices.Marshal.FinalReleaseComObject(cur);
            }

            return myList;
        }

        protected override void OnClick()
        {
            AppSingleton.Instance().CreateWorkspacePath();
            RunProgram();
        }

        protected override void OnUpdate()
        {
            Enabled = ArcMap.Application != null;
        }

        private bool AddField(ILayer selectedLayer, string fieldName, string type)
        {
            try
            {
                ESRI.ArcGIS.Geoprocessor.Geoprocessor gp = new ESRI.ArcGIS.Geoprocessor.Geoprocessor();
                ESRI.ArcGIS.DataManagementTools.AddField addField = new ESRI.ArcGIS.DataManagementTools.AddField();
                addField.in_table = AppSingleton.Instance().WorkspacePath + "\\" + type + selectedLayer.Name;
                addField.field_name = fieldName;
                addField.field_type = "DOUBLE";
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

        private void bufferlayersUpdated()
        {
            if (AppSingleton.Instance().BufferLayerList.Count > 0 || AppSingleton.Instance().PolygonLayerList.Count > 0)
            {
                if (!(AppSingleton.Instance().wizardHost.WizardPages.ContainsKey(3)))
                {
                    bufferKatmanSec = new BufferKatmanSec();
                    //AppSingleton.Instance().wizardHost.WizardPages.Add(3, bufferKatmanSec);
                }
            }
            else
            {
                //AppSingleton.Instance().wizardHost.WizardPages.Remove(3);
            }
            //bufferKatmanSec.InitForm();
        }

        private bool CalculateField(ILayer selectedLayer)
        {
            try
            {
                ESRI.ArcGIS.Geoprocessor.Geoprocessor gp = new ESRI.ArcGIS.Geoprocessor.Geoprocessor();
                ESRI.ArcGIS.DataManagementTools.CalculateField calculateField = new ESRI.ArcGIS.DataManagementTools.CalculateField();
                calculateField.in_table = AppSingleton.Instance().WorkspacePath + "\\RingBuffered_" + selectedLayer.Name;
                calculateField.field = "priority";
                calculateField.expression = "1/Sqr ( [distance] )";
                calculateField.expression_type = "VB";

                gp.AddOutputsToMap = AppSingleton.Instance().AralariEkle;
                gp.OverwriteOutput = true;
                gp.Execute(calculateField, null);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        private bool ClipLayers(ILayer selectedLayer)
        {
            try
            {
                IFeatureWorkspace fWorkspace = AppSingleton.Instance().PersonalWorkspace as IFeatureWorkspace;
                ESRI.ArcGIS.Geoprocessor.Geoprocessor gp = new ESRI.ArcGIS.Geoprocessor.Geoprocessor();
                ESRI.ArcGIS.AnalysisTools.Clip clip = new ESRI.ArcGIS.AnalysisTools.Clip();
                clip.in_features = selectedLayer;
                clip.clip_features = AppSingleton.Instance().SinirLayer;
                clip.out_feature_class = AppSingleton.Instance().WorkspacePath + "\\Clip_" + selectedLayer.Name;
                gp.AddOutputsToMap = AppSingleton.Instance().AralariEkle;
                gp.OverwriteOutput = true;
                gp.Execute(clip, null);
                //return clip.out_feature_class.ToString();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        private bool Combine(string layerNames)
        {
            try
            {
                ESRI.ArcGIS.Geoprocessor.Geoprocessor gp = new ESRI.ArcGIS.Geoprocessor.Geoprocessor();
                ESRI.ArcGIS.SpatialAnalystTools.Combine combine = new ESRI.ArcGIS.SpatialAnalystTools.Combine();
                combine.in_rasters = layerNames;
                combine.out_raster = AppSingleton.Instance().WorkspacePath + "\\" + "Ekolojik_Sit_Alani";
                gp.AddOutputsToMap = true;
                gp.OverwriteOutput = true;
                gp.Execute(combine, null);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        private bool CreateTin(ILayer selectedLayer, EnterpoleGrid grid)
        {
            try
            {
                ESRI.ArcGIS.Geoprocessor.Geoprocessor gp = new ESRI.ArcGIS.Geoprocessor.Geoprocessor();
                ESRI.ArcGIS.Analyst3DTools.CreateTin createTin = new ESRI.ArcGIS.Analyst3DTools.CreateTin();
                createTin.out_tin = AppSingleton.Instance().Path + "\\TIN_" + selectedLayer.Name;//RingBuffered_
                //erdinç
                createTin.in_features = AppSingleton.Instance().WorkspacePath + "\\Clip_" + selectedLayer.Name + " " + grid.FieldName + " hardline <None>";// 10.1 Hard_Line ; 10.0 hardline
                createTin.constrained_delaunay = "DELAUNAY";

                gp.AddOutputsToMap = AppSingleton.Instance().AralariEkle;
                gp.OverwriteOutput = true;
                gp.Execute(createTin, null);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        private void host_WizardCompleted()
        {
            AppSingleton.Instance().CreateWorkspacePath();

            if (AppSingleton.Instance().SettingsControl == null)
            {
                SettingsControl control = new SettingsControl();
                control.Load();
                control.CheckForm();
            }

            lastControl.SetRichTextBoxLabel("Veriler çalışma alanı sınırlarına göre kesiliyor...");
            foreach (var item in AppSingleton.Instance().allLayers)
            {
                if (!ClipLayers(item.layer))
                {
                    MessageBox.Show("Hata Kodu :1103 . Lütfen yöneticiniz ile görüşünüz.");
                    return;
                }
            }
            lastControl.SetRichTextBoxLabel("İşlem tamamlandı...");

            foreach (var item in AppSingleton.Instance().PolygonLayerList)
            {
                FieldLayerObject fieldLayerObject = GetFieldLayerObject(item.layer.Name);
                if (fieldLayerObject == null)
                {
                    MessageBox.Show("Hata Kodu :1110 . Lütfen yöneticiniz ile görüşünüz.");
                    return;
                }

                lastControl.SetRichTextBoxLabel(item.layer.Name + " katmanı için raster dönüşüm yapılıyor...");
                if (!PolygonToRaster(item.layer, "Clip_", fieldLayerObject.FieldName, ""))
                {
                    MessageBox.Show("Hata Kodu :1111 . Lütfen yöneticiniz ile görüşünüz.");
                    return;
                }
                lastControl.SetRichTextBoxLabel("İşlem tamamlandı...");
                Dictionary<string, string> myDict = fieldLayerObject.FieldList;
                string reclassifyList = "";
                foreach (var pair in myDict)
                {
                    var key = pair.Key;
                    if (key.Contains(" "))
                    {
                        key = "'" + key + "'";
                    }
                    if (reclassifyList == "")
                    {
                        reclassifyList = key + " " + pair.Value + ";";
                    }
                    else
                    {
                        reclassifyList = reclassifyList + key + " " + pair.Value + ";";
                    }
                }
                reclassifyList = reclassifyList + "NODATA " + AppSingleton.Instance().NodataValue;

                lastControl.SetRichTextBoxLabel(item.layer.Name + " katmanı yeniden sınıflandırılıyor...");

                IFeatureClass fclass = (AppSingleton.Instance().PersonalWorkspace as IFeatureWorkspace).OpenFeatureClass("Poly_Raster_" + item.layer.Name);

                Type factoryType = Type.GetTypeFromProgID(
                "esriDataSourcesGDB.AccessWorkspaceFactory");

                IWorkspaceFactory workspaceFactory = (IWorkspaceFactory)Activator.CreateInstance
                    (factoryType);

                IRasterWorkspaceEx rasterWorkspaceEx = workspaceFactory.OpenFromFile(AppSingleton.Instance().WorkspacePath, 0) as IRasterWorkspaceEx;

                //IRasterWorkspace rasterWorkspace = AppSingleton.Instance().PersonalWorkspace as IRasterWorkspace;
                IRasterDataset rasterDataset = rasterWorkspaceEx.OpenRasterDataset("Poly_Raster_" + item.layer.Name);
                IRasterDatasetEdit2 raster = (IRasterDatasetEdit2)rasterDataset;

                ESRI.ArcGIS.Geodatabase.IGeoDataset geoDataset = (ESRI.ArcGIS.Geodatabase.IGeoDataset)rasterDataset;
                raster.BuildAttributeTable();
                ITable vat = (raster as IRasterBandCollection).Item(0).AttributeTable;

                //Check if field Exists
                var check = false;
                for (int j = 0; j < vat.Fields.FieldCount; j++)
                {
                    IField field = vat.Fields.get_Field(j);
                    if (field.Name == fieldLayerObject.FieldName)
                        check = true;
                }

                if (!check)
                {
                    lastControl.SetRichTextBoxLabel("Eksik kolonlar ekleniyor...");
                    if (!JoinField(vat, "Value", item.layer.Name, fieldLayerObject.FieldName, fieldLayerObject.FieldName))
                    {
                        MessageBox.Show("Hata Kodu :5614 . Lütfen yöneticiniz ile görüşünüz.");
                        return;
                    }
                }

                string returnStr = SetFieldToValue(vat, fieldLayerObject.FieldName);
                bool aragecis = true;
                if (!Reclassify(item.layer, "Value", returnStr, "Poly_Raster_", "TempReclass_"))
                {
                    aragecis = false;
                }

                if (aragecis == true)
                {
                    if (!Reclassify(item.layer, "Value", reclassifyList, "TempReclass_", "Reclassified_"))
                    {
                        MessageBox.Show("Hata Kodu :1112 . Lütfen yöneticiniz ile görüşünüz.");
                        return;
                    }
                }
                else
                {
                    if (!Reclassify(item.layer, fieldLayerObject.FieldName, reclassifyList, "Poly_Raster_", "Reclassified_"))
                    {
                        MessageBox.Show("Hata Kodu :1112 . Lütfen yöneticiniz ile görüşünüz.");
                        return;
                    }
                }

                IRasterDataset reclassedDataset = rasterWorkspaceEx.OpenRasterDataset("Reclassified_" + item.layer.Name);
                IRasterDatasetEdit2 reclassed = (IRasterDatasetEdit2)reclassedDataset;

                ESRI.ArcGIS.Geodatabase.IGeoDataset reclassedGeoDataset = (ESRI.ArcGIS.Geodatabase.IGeoDataset)reclassedDataset;
                reclassed.BuildAttributeTable();

                ITable vatReclass = (reclassed as IRasterBandCollection).Item(0).AttributeTable;

                //Check if field Exists
                var checkReclass = false;
                for (int j = 0; j < vatReclass.Fields.FieldCount; j++)
                {
                    IField field = vatReclass.Fields.get_Field(j);
                    if (field.Name == fieldLayerObject.FieldName)
                        checkReclass = true;
                }

                if (!checkReclass)
                {
                    if (!JoinField(vatReclass, "Value", item.layer.Name, fieldLayerObject.FieldName, fieldLayerObject.FieldName))
                    {
                        MessageBox.Show("Hata Kodu :5614 . Lütfen yöneticiniz ile görüşünüz.");
                        return;
                    }
                }

                lastControl.SetRichTextBoxLabel("İşlem tamamlandı...");
            }
            string rasterString = string.Empty;
            foreach (var item in reclassList)
            {
                if (rasterString == string.Empty)
                {
                    rasterString = item;
                }
                else
                {
                    rasterString = rasterString + ";" + item;
                }
            }
            foreach (var item in AppSingleton.Instance().RasterLayerList)
            {
                if (rasterString == string.Empty)
                {
                    rasterString = item.Name;
                }
                else
                {
                    rasterString = rasterString + ";" + item.Name;
                }
            }
            lastControl.SetRichTextBoxLabel("Tüm raster katmanlar birleştiriliyor...");
            if (!Combine(rasterString))
            {
                MessageBox.Show("Hata Kodu :2639. Lütfen yöneticiniz ile görüşünüz.");
                return;
            }

            //Combine işlemleri

            Type factoryType2 = Type.GetTypeFromProgID(
               "esriDataSourcesGDB.AccessWorkspaceFactory");

            IWorkspaceFactory workspaceFactory2 = (IWorkspaceFactory)Activator.CreateInstance
                (factoryType2);

            IRasterWorkspaceEx rasterWorkspaceEx2 = workspaceFactory2.OpenFromFile(AppSingleton.Instance().WorkspacePath, 0) as IRasterWorkspaceEx;

            //IRasterWorkspace rasterWorkspace = PersonalWorkspace as IRasterWorkspace;
            IRasterDataset rasterDataset2 = rasterWorkspaceEx2.OpenRasterDataset("Ekolojik_Sit_Alani");
            IRasterDatasetEdit2 raster2 = (IRasterDatasetEdit2)rasterDataset2;

            ESRI.ArcGIS.Geodatabase.IGeoDataset geoDataset2 = (ESRI.ArcGIS.Geodatabase.IGeoDataset)rasterDataset2;
            raster2.BuildAttributeTable();
            ITable vat2 = (raster2 as IRasterBandCollection).Item(0).AttributeTable;

            List<string> fieldList = new List<string>();

            for (int j = 0; j < vat2.Fields.FieldCount; j++)
            {
                IField field = vat2.Fields.get_Field(j);
                if (field.Name.ToUpper() != "OID" && field.Name.ToUpper() != "VALUE" && field.Name.ToUpper() != "COUNT")
                    fieldList.Add(field.Name);
            }

            lastControl.SetRichTextBoxLabel("Final katmanında eksik kolonlar tanımlanıyor...");

            for (int i = 0; i < AppSingleton.Instance().PolygonLayerList.Count; i++)
            {
                var item = AppSingleton.Instance().PolygonLayerList[i];
                FieldLayerObject fieldLayerObject = GetFieldLayerObject(item.layer.Name);
                var reclassifiedlayername = AppSingleton.Instance().WorkspacePath + "\\Reclassified_" + item.layer.Name;
                if (!JoinField(vat2, fieldList[i], reclassifiedlayername, "Value", fieldLayerObject.FieldName))
                {
                    MessageBox.Show("Hata Kodu :5614 . Lütfen yöneticiniz ile görüşünüz.");
                    return;
                }
            }

            //foreach (var item in reclassList)
            //{
            //    IFeatureClass fclass = (AppSingleton.Instance().PersonalWorkspace as IFeatureWorkspace).OpenFeatureClass(item);

            //    Type factoryType = Type.GetTypeFromProgID(
            //    "esriDataSourcesGDB.AccessWorkspaceFactory");
            //    string guid = Guid.NewGuid().ToString();
            //    IWorkspaceFactory workspaceFactory = (IWorkspaceFactory)Activator.CreateInstance
            //        (factoryType);

            //    IRasterWorkspaceEx rasterWorkspaceEx = workspaceFactory.OpenFromFile(AppSingleton.Instance().WorkspacePath, 0) as IRasterWorkspaceEx;

            //    //IRasterWorkspace rasterWorkspace = AppSingleton.Instance().PersonalWorkspace as IRasterWorkspace;
            //    IRasterDataset rasterDataset = rasterWorkspaceEx.OpenRasterDataset(item);
            //    IRasterDatasetEdit2 raster = (IRasterDatasetEdit2)rasterDataset;

            //    ESRI.ArcGIS.Geodatabase.IGeoDataset geoDataset = (ESRI.ArcGIS.Geodatabase.IGeoDataset)rasterDataset;
            //    raster.BuildAttributeTable();
            //    ITable vat = (raster as IRasterBandCollection).Item(0).AttributeTable;
            //    //IFeatureClass fclass= (AppSingleton.Instance().PersonalWorkspace as IFeatureWorkspace).OpenFeatureClass(item);
            //    List<double> valueList = GetUniques(vat as ITable, "Value");
            //    double max = FindMaxValue(valueList);
            //    double min = FindMinValue(valueList);
            //    IFeatureLayer fLayer = new FeatureLayerClass();
            //    fLayer.Name = item;
            //    fLayer.FeatureClass = fclass;
            //    lastControl.SetRichTextBoxLabel("Öznitelik ekleniyor...");
            //    AddField(fLayer, "Normal", "");
            //    lastControl.SetRichTextBoxLabel("İşlem tamamlandı...");
            //    lastControl.SetRichTextBoxLabel("Normalleştirme işlemi yapılıyor...");
            //    foreach (var myLayer in AppSingleton.Instance().AllLayersDict)
            //    {
            //        string layerName = myLayer.Key;
            //        if ("Reclassified_" + layerName == item)
            //        {
            //            LayerType lType = myLayer.Value;
            //            switch (lType.Metod)
            //            {
            //                case "x/Maks":
            //                    SetFirstNormal(vat, max);
            //                    break;
            //                case "1-(x/Maks)":
            //                    SetSecondNormal(vat, max);
            //                    break;
            //                case "(x-Min)/(Maks-Min)":
            //                    SetThirdNormal(vat, max, min);
            //                    break;
            //                case "(Maks-x)/(Maks-Min)":
            //                    SetFourthNormal(vat, max, min);
            //                    break;
            //                default:
            //                    Console.WriteLine("Invalid selection. Please select 1, 2, or 3.");
            //                    break;
            //            }

            //        }

            //    }
            //    lastControl.SetRichTextBoxLabel("İşlem tamamlandı...");
            //}

            lastControl.SetRichTextBoxLabel("İşlem tamamlandı...");
            //this.Dispose();
            //MessageBox.Show("Done!"); //obviously you'd do something else in a real app...
        }

        private bool IDW(ILayer selectedLayer, string FieldName)
        {
            try
            {
                ESRI.ArcGIS.SpatialAnalystTools.Idw idw = new ESRI.ArcGIS.SpatialAnalystTools.Idw();
                idw.cell_size = AppSingleton.Instance().CellSize;
                idw.out_raster = AppSingleton.Instance().WorkspacePath + "\\" + selectedLayer.Name + "_IDW";
                idw.in_point_features = selectedLayer;
                idw.z_field = FieldName;
                idw.power = 3;
                idw.search_radius = AppSingleton.Instance().IDWYaricap;
                ESRI.ArcGIS.Geoprocessor.Geoprocessor gp = new ESRI.ArcGIS.Geoprocessor.Geoprocessor();

                gp.AddOutputsToMap = AppSingleton.Instance().AralariEkle;
                gp.OverwriteOutput = true;
                gp.Execute(idw, null);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        private bool JoinField(object table, string inField, string joinTable, string joinField, string fieldName)
        {
            try
            {
                ESRI.ArcGIS.Geoprocessor.Geoprocessor gp = new ESRI.ArcGIS.Geoprocessor.Geoprocessor();
                ESRI.ArcGIS.DataManagementTools.JoinField join = new ESRI.ArcGIS.DataManagementTools.JoinField();
                join.in_data = table;
                join.in_field = inField;
                join.join_table = joinTable;
                join.join_field = joinField;
                join.fields = fieldName;
                gp.AddOutputsToMap = AppSingleton.Instance().AralariEkle;
                gp.OverwriteOutput = true;
                gp.Execute(join, null);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        private bool Kriging(ILayer selectedLayer, string FieldName)
        {
            try
            {
                ESRI.ArcGIS.SpatialAnalystTools.Kriging kriging = new ESRI.ArcGIS.SpatialAnalystTools.Kriging();
                kriging.cell_size = AppSingleton.Instance().CellSize;
                kriging.out_surface_raster = AppSingleton.Instance().WorkspacePath + "\\" + selectedLayer.Name + "_Kriging";
                kriging.in_point_features = selectedLayer;
                kriging.z_field = FieldName;
                kriging.semiVariogram_props = AppSingleton.Instance().KrigingSemiVariogram;
                kriging.search_radius = AppSingleton.Instance().KrigingYaricap;

                ESRI.ArcGIS.Geoprocessor.Geoprocessor gp = new ESRI.ArcGIS.Geoprocessor.Geoprocessor();

                gp.AddOutputsToMap = AppSingleton.Instance().AralariEkle;
                gp.OverwriteOutput = true;
                gp.Execute(kriging, null);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        private void layersUpdated()
        {
            if (AppSingleton.Instance().PolygonLayerList.Count > 0)
            {
                if (!(AppSingleton.Instance().wizardHost.WizardPages.ContainsKey(2)))
                {
                    poligonSec = new PolygonSec();
                    AppSingleton.Instance().wizardHost.WizardPages.Add(2, poligonSec);
                }
            }
            else
            {
                AppSingleton.Instance().wizardHost.WizardPages.Remove(2);
            }
            poligonSec.InitForm();
        }

        private bool PolygonToRaster(ILayer selectedLayer, string inputType, string valueField, string priorityField)
        {
            try
            {
                ESRI.ArcGIS.Geoprocessor.Geoprocessor gp = new ESRI.ArcGIS.Geoprocessor.Geoprocessor();
                ESRI.ArcGIS.ConversionTools.PolygonToRaster polygonToRaster = new ESRI.ArcGIS.ConversionTools.PolygonToRaster();
                polygonToRaster.in_features = selectedLayer;
                polygonToRaster.value_field = valueField;//"distance";
                polygonToRaster.out_rasterdataset = AppSingleton.Instance().WorkspacePath + "\\Poly_Raster_" + selectedLayer.Name;
                polygonToRaster.cell_assignment = "MAXIMUM_AREA";
                polygonToRaster.cellsize = AppSingleton.Instance().CellSize;
                if (priorityField != "")
                {
                    polygonToRaster.priority_field = priorityField; //"priority";
                }
                IFeatureLayer fLayer = AppSingleton.Instance().SinirLayer as IFeatureLayer;
                IEnvelope env = fLayer.AreaOfInterest.Envelope;
                gp.SetEnvironmentValue("Extent", env.XMin.ToString() + " " + env.YMin.ToString() + " " + env.XMax.ToString() + " " + env.YMax.ToString());
                gp.AddOutputsToMap = AppSingleton.Instance().AralariEkle;
                gp.OverwriteOutput = true;
                gp.Execute(polygonToRaster, null);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        private void polylayersUpdated()
        {
            if (AppSingleton.Instance().PolygonLayerList.Count > 0)
            {
                if (!(AppSingleton.Instance().wizardHost.WizardPages.ContainsKey(4)))
                {
                    poligonSec = new PolygonSec();
                    AppSingleton.Instance().wizardHost.WizardPages.Add(4, poligonSec);
                }
            }
            else
            {
                AppSingleton.Instance().wizardHost.WizardPages.Remove(4);
            }
            poligonSec.InitForm();
        }

        private bool RasterClipLayer(ILayer selectedLayer, string type)
        {
            try
            {
                IFeatureWorkspace fWorkspace = AppSingleton.Instance().PersonalWorkspace as IFeatureWorkspace;
                ESRI.ArcGIS.Geoprocessor.Geoprocessor gp = new ESRI.ArcGIS.Geoprocessor.Geoprocessor();
                ESRI.ArcGIS.SpatialAnalystTools.ExtractByRectangle rastClip = new ESRI.ArcGIS.SpatialAnalystTools.ExtractByRectangle();
                rastClip.in_raster = AppSingleton.Instance().WorkspacePath + "\\" + selectedLayer.Name + "_" + type;//Kriging
                rastClip.extraction_area = "INSIDE";
                rastClip.out_raster = AppSingleton.Instance().WorkspacePath + "\\" + type + "Clip_" + selectedLayer.Name;

                IFeatureLayer fLayer = AppSingleton.Instance().SinirLayer as IFeatureLayer;
                IEnvelope env = fLayer.AreaOfInterest.Envelope;
                //<<<<<<< .mine
                //string geo = env.XMin.ToString() + " " + env.YMin.ToString() + " " + env.XMax.ToString() + " " + env.YMax.ToString();
                // rastClip.clipping_geometry = geo;
                //=======
                string geo = env.XMin.ToString() + " " + env.YMin.ToString() + " " + env.XMax.ToString() + " " + env.YMax.ToString();
                rastClip.rectangle = geo;

                gp.AddOutputsToMap = AppSingleton.Instance().AralariEkle;
                gp.OverwriteOutput = true;
                gp.Execute(rastClip, null);
                return true;
                //return clip.out_feature_class.ToString();
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        private bool Reclassify(ILayer selectedLayer, string FieldName, string reclassMap, string inputType, string outputType)
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
                if (outputType == "Reclassified_")
                {
                    reclassList.Add(reclass.out_raster.ToString());
                }
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        private bool RingBuffer(ILayer selectedLayer, string distances)
        {
            try
            {
                ESRI.ArcGIS.Geoprocessor.Geoprocessor gp = new ESRI.ArcGIS.Geoprocessor.Geoprocessor();
                ESRI.ArcGIS.AnalysisTools.MultipleRingBuffer ringBuffer = new ESRI.ArcGIS.AnalysisTools.MultipleRingBuffer();
                ringBuffer.Input_Features = AppSingleton.Instance().WorkspacePath + "\\Clip_" + selectedLayer.Name;
                ringBuffer.Output_Feature_class = AppSingleton.Instance().WorkspacePath + "\\RingBuffered_" + selectedLayer.Name;
                ringBuffer.Distances = distances;//"50;100;150";
                ringBuffer.Buffer_Unit = "Meters";
                ringBuffer.Dissolve_Option = "NONE";

                gp.AddOutputsToMap = AppSingleton.Instance().AralariEkle;
                gp.OverwriteOutput = true;
                gp.Execute(ringBuffer, null);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        private void RunProgram()
        {
            ArcMap.Application.CurrentTool = null;
            IMxDocument mxDocument = ArcMap.Document;
            reclassList = new List<string>();
            WizardHost host = new WizardHost();
            AppSingleton.Instance().PolyItemCount = 1000;
            AppSingleton.Instance().EnterpoleItemCount = 500;
            AppSingleton.Instance().BufferItemCount = 300;
            host.ShowFirstButton = false;
            host.ShowLastButton = false;
            host.WizardCompleted += new WizardHost.WizardCompletedEventHandler(host_WizardCompleted);
            KatmanSec katmanSec = new KatmanSec();

            katmanSec.InitForm(mxDocument);
            host.WizardPages.Add(1, katmanSec);
            katmanSec.layersUpdated += new KatmanSec.LayersUpdated(layersUpdated);
            enterpolasyonKatmanSec = new EnterpolasyonKatmanSec();
            enterpolasyonKatmanSec.layersUpdated += new EnterpolasyonKatmanSec.BufferLayersUpdated(bufferlayersUpdated);

            poligonSec = new PolygonSec();
            //emptyControl = new EmptyControl();
            bufferKatmanSec = new BufferKatmanSec();
            bufferKatmanSec.layersUpdated += new BufferKatmanSec.LayersUpdated(polylayersUpdated);

            lastControl = new LastControl();
            //host.WizardPages.Add(2, enterpolasyonKatmanSec);
            //host.WizardPages.Add(3, bufferKatmanSec);
            host.WizardPages.Add(2, poligonSec);
            //host.WizardPages.Add(10000, emptyControl);
            host.WizardPages.Add(50001, lastControl);
            AppSingleton.Instance().wizardHost = host;
            host.LoadWizard();
            host.ShowDialog();
        }

        private string SetFieldToValue(ITable vat, string fieldName)
        {
            IQueryFilter queryFilter = new QueryFilterClass();
            ICursor updateCursor = vat.Search(queryFilter, false);
            IRow feature = null;
            string returnStr = "";
            try
            {
                while ((feature = updateCursor.NextRow()) != null)
                {
                    int valueIndex = feature.Fields.FindField("Value");
                    int fieldIndex = feature.Fields.FindField(fieldName);
                    string fieldValue = (feature.get_Value(fieldIndex).ToString());
                    string valueValue = (feature.get_Value(valueIndex).ToString());
                    if (fieldValue.Contains(" "))
                    {
                        fieldValue = "'" + fieldValue + "'";
                    }
                    if (returnStr == "")
                    {
                        returnStr = valueValue + " " + fieldValue;
                    }
                    else
                    {
                        returnStr = returnStr + ";" + valueValue + " " + fieldValue;
                    }

                    if (fieldValue.Contains(" "))
                    {
                        fieldValue = "'" + fieldValue + "'";
                    }
                }
                return returnStr;
            }
            catch (COMException comExc)
            {
                return "";
                // Handle any errors that might occur on NextFeature().
            }
        }
    }
}