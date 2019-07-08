using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Windows.Forms;
using ESRI.ArcGIS.ArcMapUI;

namespace Iklim
{
    public class btnEkoloji : ESRI.ArcGIS.Desktop.AddIns.Button
    {
        public btnEkoloji()
        {
            AppSingleton.Instance().CreateWorkspacePath();
            RunProgram();
        }
        public BufferKatmanSec bufferKatmanSec;
        public EnterpolasyonKatmanSec enterpolasyonKatmanSec;
        public PolygonSec poligonSec;
        public EmptyControl emptyControl;
        public List<string> reclassList;
         public LastControl lastControl;
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
            host.Text = "Doğalgaz İletim Hattı Optimum Güzergah Analizi Aracı  (111Y041)";
            host.WizardCompleted += new WizardHost.WizardCompletedEventHandler(host_WizardCompleted);
            KatmanSec katmanSec = new KatmanSec();

            katmanSec.InitForm(mxDocument);
            host.WizardPages.Add(1, katmanSec);
            katmanSec.layersUpdated += new KatmanSec.LayersUpdated(layersUpdated);
            enterpolasyonKatmanSec = new EnterpolasyonKatmanSec();
            enterpolasyonKatmanSec.layersUpdated += new EnterpolasyonKatmanSec.BufferLayersUpdated(bufferlayersUpdated);

            poligonSec = new PolygonSec();
            emptyControl = new EmptyControl();
            bufferKatmanSec = new BufferKatmanSec();
            bufferKatmanSec.layersUpdated += new BufferKatmanSec.LayersUpdated(polylayersUpdated);
         
            
            lastControl = new LastControl();
            host.WizardPages.Add(2, enterpolasyonKatmanSec);
            host.WizardPages.Add(3, bufferKatmanSec);
            host.WizardPages.Add(4, poligonSec);
            host.WizardPages.Add(10000, emptyControl);
            host.WizardPages.Add(50001, lastControl);
            AppSingleton.Instance().wizardHost = host;
            host.LoadWizard();
            host.ShowDialog();
        }

        protected override void OnClick()
        {
        }

        protected override void OnUpdate()
        {
            Enabled = ArcMap.Application != null;
        }

        void layersUpdated()
        {


            if (AppSingleton.Instance().EnterpoleLayerList.Count > 0)
            {


                if (!(AppSingleton.Instance().wizardHost.WizardPages.ContainsKey(2)))
                {
                    enterpolasyonKatmanSec = new EnterpolasyonKatmanSec();
                    enterpolasyonKatmanSec.layersUpdated += new EnterpolasyonKatmanSec.BufferLayersUpdated(bufferlayersUpdated);
                    AppSingleton.Instance().wizardHost.WizardPages.Add(2, enterpolasyonKatmanSec);
                }

            }
            else
            {
                AppSingleton.Instance().wizardHost.WizardPages.Remove(2);

            }

            if (AppSingleton.Instance().EnterpoleLayerList.Count > 0 || AppSingleton.Instance().PolygonLayerList.Count > 0)
            {


                if (!(AppSingleton.Instance().wizardHost.WizardPages.ContainsKey(3)))
                {
                    bufferKatmanSec = new BufferKatmanSec();
                    //enterpolasyonKatmanSec.layersUpdated += new EnterpolasyonKatmanSec.BufferLayersUpdated(bufferlayersUpdated);
                    AppSingleton.Instance().wizardHost.WizardPages.Add(3, bufferKatmanSec);
                }

            }
            else
            {
                AppSingleton.Instance().wizardHost.WizardPages.Remove(3);
            }


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
            enterpolasyonKatmanSec.InitForm();
            bufferKatmanSec.InitForm();
            poligonSec.InitForm();

        }
        void bufferlayersUpdated()
        {


            if (AppSingleton.Instance().BufferLayerList.Count > 0 || AppSingleton.Instance().PolygonLayerList.Count > 0)
            {


                if (!(AppSingleton.Instance().wizardHost.WizardPages.ContainsKey(3)))
                {
                    bufferKatmanSec = new BufferKatmanSec();
                    AppSingleton.Instance().wizardHost.WizardPages.Add(3, bufferKatmanSec);
                }
            }
            else
            {
                AppSingleton.Instance().wizardHost.WizardPages.Remove(3);
            }
            bufferKatmanSec.InitForm();
        }

        void polylayersUpdated()
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

        void host_WizardCompleted()
        {
        //    lastControl.SetRichTextBoxLabel("Veriler çalışma alanı sınırlarına göre kesiliyor...");
        //    foreach (var item in AppSingleton.Instance().allLayers)
        //    {
        //        if (!ClipLayers(item.layer))
        //        {
        //            MessageBox.Show("Hata Kodu :1103 . Lütfen yöneticiniz ile görüşünüz.");
        //            return;
        //        }
        //    }
        //    lastControl.SetRichTextBoxLabel("İşlem tamamlandı...");
        //    foreach (var item in AppSingleton.Instance().FinalTamponKatmanListesi)
        //    {
        //        FieldGrid bufferGrid = GetBufferGrid(item.layer.Name);
        //        if (bufferGrid == null)
        //        {
        //            MessageBox.Show("Hata Kodu :1104 . Lütfen yöneticiniz ile görüşünüz.");
        //            return;
        //        }
        //        Dictionary<string, string> myDict = bufferGrid.FieldListObject.FieldList;
        //        string pairList = "";
        //        string reclassifyList = "";
        //        foreach (var pair in myDict)
        //        {
        //            if (pairList == "")
        //            {
        //                pairList = pair.Key;
        //            }
        //            else
        //            {
        //                pairList = pairList + ";" + pair.Key;
        //            }

        //        }
        //        for (int i = 0; i < myDict.Count; i++)
        //        {
        //            KeyValuePair<string, string> pair = myDict.ElementAt(i);
        //            if (reclassifyList == "")
        //            {
        //                reclassifyList = "0 " + pair.Key + " " + pair.Value + ";";
        //            }
        //            else
        //            {
        //                KeyValuePair<string, string> previouspair = myDict.ElementAt(i - 1);
        //                reclassifyList = reclassifyList + previouspair.Key + " " + pair.Key + " " + pair.Value + ";";
        //            }
        //        }
        //        reclassifyList = reclassifyList + "NODATA " + AppSingleton.Instance().NodataValue;
        //        lastControl.SetRichTextBoxLabel(item.layer.Name + " katmanı için tampon bölge oluşturuluyor...");
        //        if (!RingBuffer(item.layer, pairList))
        //        {
        //            MessageBox.Show("Hata Kodu :1105 . Lütfen yöneticiniz ile görüşünüz.");
        //            return;
        //        }
        //        lastControl.SetRichTextBoxLabel("İşlem tamamlandı...");
        //        lastControl.SetRichTextBoxLabel("Yeni öznitelik sütunu oluşturuluyor...");
        //        if (!AddField(item.layer, "priority", "RingBuffered_"))
        //        {
        //            MessageBox.Show("Hata Kodu :1106 . Lütfen yöneticiniz ile görüşünüz.");
        //            return;
        //        }

        //        lastControl.SetRichTextBoxLabel("Öznitelik değerleri yeniden hesaplanıyor...");
        //        if (!CalculateField(item.layer))
        //        {
        //            MessageBox.Show("Hata Kodu :1107 . Lütfen yöneticiniz ile görüşünüz.");
        //            return;
        //        }
        //        lastControl.SetRichTextBoxLabel(item.layer.Name + " katmanı için raster dönüşüm yapılıyor...");
        //        if (!PolygonToRaster(item.layer, "RingBuffered_", "distance", "priority"))
        //        {
        //            MessageBox.Show("Hata Kodu :1108 . Lütfen yöneticiniz ile görüşünüz.");
        //            return;
        //        }
        //        lastControl.SetRichTextBoxLabel("İşlem tamamlandı...");
        //        lastControl.SetRichTextBoxLabel(item.layer.Name + " katmanı yeniden sınıflandırılıyor...");
        //        if (!Reclassify(item.layer, "Value", reclassifyList, "Poly_Raster_", "Reclassified_"))
        //        {
        //            MessageBox.Show("Hata Kodu :1109 . Lütfen yöneticiniz ile görüşünüz.");
        //            return;
        //        }
        //        lastControl.SetRichTextBoxLabel("İşlem tamamlandı...");
        //    }
        //    foreach (var item in AppSingleton.Instance().polygonLayerList)
        //    {
        //        FieldGrid polyGrid = GetPolygonGrid(item.layer.Name);
        //        if (polyGrid == null)
        //        {
        //            MessageBox.Show("Hata Kodu :1110 . Lütfen yöneticiniz ile görüşünüz.");
        //            return;
        //        }

        //        lastControl.SetRichTextBoxLabel(item.layer.Name + " katmanı için raster dönüşüm yapılıyor...");
        //        if (!PolygonToRaster(item.layer, "Clip_", polyGrid.FieldName, ""))
        //        {
        //            MessageBox.Show("Hata Kodu :1111 . Lütfen yöneticiniz ile görüşünüz.");
        //            return;
        //        }
        //        lastControl.SetRichTextBoxLabel("İşlem tamamlandı...");
        //        Dictionary<string, string> myDict = polyGrid.FieldListObject.FieldList;
        //        string reclassifyList = "";
        //        foreach (var pair in myDict)
        //        {
        //            if (reclassifyList == "")
        //            {
        //                reclassifyList = pair.Key + " " + pair.Value + ";";
        //            }
        //            else
        //            {
        //                reclassifyList = reclassifyList + pair.Key + " " + pair.Value + ";";
        //            }

        //        }
        //        reclassifyList = reclassifyList + "NODATA " + AppSingleton.Instance().NodataValue;
                
        //        lastControl.SetRichTextBoxLabel(item.layer.Name + " katmanı yeniden sınıflandırılıyor...");

        //        IFeatureClass fclass = (PersonalWorkspace as IFeatureWorkspace).OpenFeatureClass("Poly_Raster_" + item.layer.Name);

        //        Type factoryType = Type.GetTypeFromProgID(
        //        "esriDataSourcesGDB.AccessWorkspaceFactory");

        //        IWorkspaceFactory workspaceFactory = (IWorkspaceFactory)Activator.CreateInstance
        //            (factoryType);


        //        IRasterWorkspaceEx rasterWorkspaceEx = workspaceFactory.OpenFromFile(WorkspacePath, 0) as IRasterWorkspaceEx;


        //        //IRasterWorkspace rasterWorkspace = PersonalWorkspace as IRasterWorkspace;
        //        IRasterDataset rasterDataset = rasterWorkspaceEx.OpenRasterDataset("Poly_Raster_" + item.layer.Name);
        //        IRasterDatasetEdit2 raster = (IRasterDatasetEdit2)rasterDataset;

        //        ESRI.ArcGIS.Geodatabase.IGeoDataset geoDataset = (ESRI.ArcGIS.Geodatabase.IGeoDataset)rasterDataset;
        //        raster.BuildAttributeTable();
        //        ITable vat = (raster as IRasterBandCollection).Item(0).AttributeTable;
        //        string returnStr= SetFieldToValue(vat, polyGrid.FieldName);
        //        bool aragecis = true;
        //        if (!Reclassify(item.layer, "Value", returnStr, "Poly_Raster_", "TempReclass_"))
        //        {
        //            aragecis = false;
        //        }

        //        if (aragecis == true)
        //        {
        //            if (!Reclassify(item.layer, "Value", reclassifyList, "TempReclass_", "Reclassified_"))
        //            {
        //                MessageBox.Show("Hata Kodu :1112 . Lütfen yöneticiniz ile görüşünüz.");
        //                return;
        //            }
        //        }
        //        else
        //        {
        //            if (!Reclassify(item.layer, polyGrid.FieldName, reclassifyList, "Poly_Raster_", "Reclassified_"))
        //            {
        //                MessageBox.Show("Hata Kodu :1112 . Lütfen yöneticiniz ile görüşünüz.");
        //                return;
        //            }
        //        }
        //        lastControl.SetRichTextBoxLabel("İşlem tamamlandı...");
        //    }
        //    foreach (var item in AppSingleton.Instance().FinalEnterpolasyonKatmanListesi)
        //    {
        //        EnterpoleGrid enterpoleGrid = GetEnterpoleGrid(item.layer.Name);

        //        if (enterpoleGrid == null)
        //        {
        //            MessageBox.Show("Hata Kodu :1113 . Lütfen yöneticiniz ile görüşünüz.");
        //            return;
        //        }

        //        Dictionary<string, string> myDict = enterpoleGrid.FieldListObject.FieldList;
        //        string reclassifyList = "";
        //        foreach (var pair in myDict)
        //        {
        //            string replacedKey = pair.Key.Replace("-", " ");
        //            if (reclassifyList == "")
        //            {

        //                reclassifyList = replacedKey + " " + pair.Value + ";";
        //            }
        //            else
        //            {
        //                reclassifyList = reclassifyList + replacedKey + " " + pair.Value + ";";
        //            }

        //        }

        //        if (enterpoleGrid.Hedef == "Eğim")
        //        {
        //            lastControl.SetRichTextBoxLabel(item.layer.Name + " katmanı için üçgen yüzey modeli oluşturuluyor...");
        //            if (!CreateTin(item.layer, enterpoleGrid))
        //            {
        //                MessageBox.Show("Hata Kodu :1114 . Lütfen yöneticiniz ile görüşünüz.");
        //                return;
        //            }
        //            lastControl.SetRichTextBoxLabel("İşlem tamamlandı...");
        //            lastControl.SetRichTextBoxLabel(item.layer.Name + " katmanı için oluşturulan yüzey raster veri tipine dönüştürülüyor...");
        //            if (!TinToRaster(item.layer))
        //            {
        //                MessageBox.Show("Hata Kodu :1115 . Lütfen yöneticiniz ile görüşünüz.");
        //                return;
        //            }
        //            lastControl.SetRichTextBoxLabel("İşlem tamamlandı...");
        //            lastControl.SetRichTextBoxLabel(item.layer.Name + " katmanı için eğim haritası oluşturuluyor...");
        //            if (!Slope(item.layer))
        //            {
        //                MessageBox.Show("Hata Kodu :1116 . Lütfen yöneticiniz ile görüşünüz.");
        //                return;
        //            }
        //            lastControl.SetRichTextBoxLabel("İşlem tamamlandı...");
        //            lastControl.SetRichTextBoxLabel(item.layer.Name + " katmanı sınıflandırma işlemi yapılıyor...");
        //            if (!Reclassify(item.layer, "Value", reclassifyList, "Slope_", "Reclassified_"))
        //            {
        //                MessageBox.Show("Hata Kodu :1117 . Lütfen yöneticiniz ile görüşünüz.");
        //                return;
        //            }
        //            lastControl.SetRichTextBoxLabel("İşlem tamamlandı...");
        //        }
        //        if (enterpoleGrid.Hedef == "Nüfus")
        //        {
        //            if (enterpoleGrid.EnterpoleMethod == "Kriging")
        //            {
        //                lastControl.SetRichTextBoxLabel(item.layer.Name + " katmanı için Kriging metodu ile yüzey oluşturuluyor...");
        //                if (!Kriging(item.layer, enterpoleGrid.FieldName))
        //                {
        //                    MessageBox.Show("Hata Kodu :1118 . Lütfen yöneticiniz ile görüşünüz.");
        //                    return;
        //                }
        //                lastControl.SetRichTextBoxLabel("İşlem tamamlandı...");
        //                lastControl.SetRichTextBoxLabel("Kriging metodu ile oluşturulan yüzey çalışma alanına sınırlandırılıyor...");
        //                if (!RasterClipLayer(item.layer, "Kriging"))
        //                {
        //                    MessageBox.Show("Hata Kodu :1119 . Lütfen yöneticiniz ile görüşünüz.");
        //                    return;
        //                }
        //                lastControl.SetRichTextBoxLabel("İşlem tamamlandı...");
        //                lastControl.SetRichTextBoxLabel(item.layer.Name + " katmanı yeniden sınıflandırılıyor...");
        //                if (!Reclassify(item.layer, "Value", reclassifyList, "KrigingClip_", "Reclassified_"))
        //                {
        //                    MessageBox.Show("Hata Kodu :1120 . Lütfen yöneticiniz ile görüşünüz.");
        //                    return;
        //                }
        //                lastControl.SetRichTextBoxLabel("İşlem tamamlandı...");
        //            }
        //            else if (enterpoleGrid.EnterpoleMethod == "IDW")
        //            {
        //                lastControl.SetRichTextBoxLabel(item.layer.Name + " katmanı için IDW metodu ile yüzey oluşturuluyor...");
        //                if (!IDW(item.layer, enterpoleGrid.FieldName))
        //                {
        //                    MessageBox.Show("Hata Kodu :1121 . Lütfen yöneticiniz ile görüşünüz.");
        //                    return;
        //                }
        //                lastControl.SetRichTextBoxLabel("İşlem tamamlandı...");
        //                lastControl.SetRichTextBoxLabel("IDW metodu ile oluşturulan yüzey çalışma alanına sınırlandırılıyor...");
        //                if (!RasterClipLayer(item.layer, "IDW"))
        //                {
        //                    MessageBox.Show("Hata Kodu :1119 . Lütfen yöneticiniz ile görüşünüz.");
        //                    return;
        //                }
        //                lastControl.SetRichTextBoxLabel("İşlem tamamlandı...");
        //                lastControl.SetRichTextBoxLabel(item.layer.Name + " katmanı yeniden sınıflandırılıyor...");
        //                if (!Reclassify(item.layer, "Value", reclassifyList, "IDWClip_", "Reclassified_"))
        //                {
        //                    MessageBox.Show("Hata Kodu :1120 . Lütfen yöneticiniz ile görüşünüz.");
        //                    return;
        //                }
        //                lastControl.SetRichTextBoxLabel("İşlem tamamlandı...");
        //            }


        //            //CreateTin(item.layer);
        //            //TinToRaster(item.layer);
        //            //Slope(item.layer);
        //            //Reclassify(item.layer, "Value", reclassifyList, "Slope_", "Reclassified_");
        //        }
        //    }

        //    foreach (var item in reclassList)
        //    {
        //        IFeatureClass fclass = (PersonalWorkspace as IFeatureWorkspace).OpenFeatureClass(item);

        //        Type factoryType = Type.GetTypeFromProgID(
        //        "esriDataSourcesGDB.AccessWorkspaceFactory");
        //        string guid = Guid.NewGuid().ToString();
        //        IWorkspaceFactory workspaceFactory = (IWorkspaceFactory)Activator.CreateInstance
        //            (factoryType);


        //        IRasterWorkspaceEx rasterWorkspaceEx = workspaceFactory.OpenFromFile(WorkspacePath, 0) as IRasterWorkspaceEx;


        //        //IRasterWorkspace rasterWorkspace = PersonalWorkspace as IRasterWorkspace;
        //        IRasterDataset rasterDataset = rasterWorkspaceEx.OpenRasterDataset(item);
        //        IRasterDatasetEdit2 raster = (IRasterDatasetEdit2)rasterDataset;

        //        ESRI.ArcGIS.Geodatabase.IGeoDataset geoDataset = (ESRI.ArcGIS.Geodatabase.IGeoDataset)rasterDataset;
        //        raster.BuildAttributeTable();
        //        ITable vat = (raster as IRasterBandCollection).Item(0).AttributeTable;
        //        //IFeatureClass fclass= (PersonalWorkspace as IFeatureWorkspace).OpenFeatureClass(item);
        //        List<double> valueList = GetUniques(vat as ITable, "Value");
        //        double max = FindMaxValue(valueList);
        //        double min = FindMinValue(valueList);
        //        IFeatureLayer fLayer = new FeatureLayerClass();
        //        fLayer.Name = item;
        //        fLayer.FeatureClass = fclass;
        //        lastControl.SetRichTextBoxLabel("Öznitelik ekleniyor...");
        //        AddField(fLayer, "Normal", "");
        //        lastControl.SetRichTextBoxLabel("İşlem tamamlandı...");
        //        lastControl.SetRichTextBoxLabel("Normalleştirme işlemi yapılıyor...");
        //        foreach (var myLayer in AppSingleton.Instance().allLayersDict)
        //        {
        //            string layerName = myLayer.Key;
        //            if ("Reclassified_" + layerName == item)
        //            {
        //                LayerType lType = myLayer.Value;
        //                switch (lType.Metod)
        //                {
        //                    case "x/Maks":
        //                        SetFirstNormal(vat, max);
        //                        break;
        //                    case "1-(x/Maks)":
        //                        SetSecondNormal(vat, max);
        //                        break;
        //                    case "(x-Min)/(Maks-Min)":
        //                        SetThirdNormal(vat, max, min);
        //                        break;
        //                    case "(Maks-x)/(Maks-Min)":
        //                        SetFourthNormal(vat, max, min);
        //                        break;
        //                    default:
        //                        Console.WriteLine("Invalid selection. Please select 1, 2, or 3.");
        //                        break;
        //                }

        //            }

        //        }
        //        lastControl.SetRichTextBoxLabel("İşlem tamamlandı...");
        //        if (AppSingleton.Instance().IslemTipi == "TOPSIS")
        //        {
        //            lastControl.SetRichTextBoxLabel("Öznitelikler ekleniyor...");
        //            AddField(fLayer, "Ax", "");
        //            AddField(fLayer, "Bx", "");
        //            lastControl.SetRichTextBoxLabel("İşlem tamamlandı...");
        //            raster.BuildAttributeTable();
        //            List<double> normalValueList = GetUniques(vat as ITable, "Normal");
        //            List<double> carpimList = new List<double>();

        //            Dictionary<double, double> ilkCarpimDict = new Dictionary<double, double>();
        //            Dictionary<double, double> buyukDict = new Dictionary<double, double>();
        //            Dictionary<double, double> kucukDict = new Dictionary<double, double>();
        //            Dictionary<string, AgirlikType> agirlikDict = AppSingleton.Instance().agirlikDict;
        //            foreach (var ag in agirlikDict)
        //            {
        //                var agirlikType = ag.Value;

        //                if (item == "Reclassified_" + ag.Key)
        //                {
        //                    //Ağırlıkla Çarpılan Dict'i oluşturduk
        //                    foreach (double normIlk in normalValueList)
        //                    {
        //                        ilkCarpimDict.Add(normIlk, normIlk * ag.Value.Deger);
        //                        carpimList.Add(normIlk * ag.Value.Deger);
        //                    }
        //                    double normax = FindMaxValue(carpimList);
        //                    double normin = FindMinValue(carpimList);
        //                    foreach (var dictItem in ilkCarpimDict)
        //                    {
        //                        buyukDict.Add(dictItem.Key, (dictItem.Value - normax) * (dictItem.Value - normax));
        //                        kucukDict.Add(dictItem.Key, (dictItem.Value - normin) * (dictItem.Value - normin));
        //                    }
        //                }
        //            }
        //            SetAxBx(vat, kucukDict, buyukDict);
        //        }


        //    }
        //    if ((AppSingleton.Instance().IslemTipi == "TOPSIS"))
        //    {
        //        lastControl.SetRichTextBoxLabel("TOPSIS analizi adım 1 devam ediyor...");
        //        WeightedSumWithParam("Ax");
        //        lastControl.SetRichTextBoxLabel("İşlem tamamlandı...");
        //        lastControl.SetRichTextBoxLabel("TOPSIS analizi adım 2 devam ediyor...");
        //        WeightedSumWithParam("Bx");
        //        lastControl.SetRichTextBoxLabel("İşlem tamamlandı...");
        //        lastControl.SetRichTextBoxLabel("TOPSIS analizi adım 3 devam ediyor...");
        //        SquareRoot("Ax");
        //        lastControl.SetRichTextBoxLabel("İşlem tamamlandı...");
        //        lastControl.SetRichTextBoxLabel("TOPSIS analizi adım 4 devam ediyor...");
        //        SquareRoot("Bx");
        //        lastControl.SetRichTextBoxLabel("İşlem tamamlandı...");
        //        lastControl.SetRichTextBoxLabel("TOPSIS analizi adım 5 devam ediyor...");
        //        WeightedSumAxBx();
        //        lastControl.SetRichTextBoxLabel("İşlem tamamlandı...");
        //        lastControl.SetRichTextBoxLabel("TOPSIS analizi adım 6 devam ediyor...");
        //        Divide();
        //        lastControl.SetRichTextBoxLabel("İşlem tamamlandı...");
        //    }


        //    if (!(AppSingleton.Instance().IslemTipi == "TOPSIS"))
        //    {
        //        lastControl.SetRichTextBoxLabel("Genel ağırlık katmanı oluşturuluyor...");
        //        WeightedSum(); 
        //        lastControl.SetRichTextBoxLabel("İşlem tamamlandı...");
        //    }
        //    lastControl.SetRichTextBoxLabel("Başlangıç bitiş değerleri tanımlanıyor...");
        //    if (!CreateFeatures())
        //    {
        //        MessageBox.Show("Hata Kodu :2001 . Lütfen yöneticiniz ile görüşünüz.");
        //        return;
        //    }
        //    lastControl.SetRichTextBoxLabel("İşlem tamamlandı...");
        //    lastControl.SetRichTextBoxLabel("Maliyet yüzeyi oluşturuluyor...");
        //    if (!CostDistance())
        //    {
        //        MessageBox.Show("Hata Kodu :2002 . Lütfen yöneticiniz ile görüşünüz.");
        //        return;
        //    }
        //    lastControl.SetRichTextBoxLabel("İşlem tamamlandı...");
        //    lastControl.SetRichTextBoxLabel("En uygun yol hesaplanıyor...");
        //    if (!CostPath())
        //    {
        //        MessageBox.Show("Hata Kodu :2003 . Lütfen yöneticiniz ile görüşünüz.");
        //        return;
        //    }
        //    lastControl.SetRichTextBoxLabel("İşlem tamamlandı...");

        //    lastControl.SetRichTextBoxLabel("En uygun yol vektöre çevriliyor...");
        //    if (!RasterToPoly())
        //    {
        //        MessageBox.Show("Hata Kodu :2004 . Lütfen yöneticiniz ile görüşünüz.");
        //        return;
        //    }
        //    lastControl.SetRichTextBoxLabel("İşlem tamamlandı...");
        //    //this.Dispose();
        //    //MessageBox.Show("Done!"); //obviously you'd do something else in a real app...

        }
    }
}
