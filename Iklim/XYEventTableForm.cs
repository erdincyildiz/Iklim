using ExcelDataReader;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Iklim
{
    public partial class XYEventTableForm : Form
    {
        public XYEventTableForm()
        {
            InitializeComponent();
        }

        private void btnExcelOpen_Click(object sender, EventArgs e)
        {
            OpenFileDialog file = new OpenFileDialog();
            file.Filter = "Excel Dosyası |*.xlsx| Excel Dosyası|*.xls";
            file.ShowDialog();
            if (file.ShowDialog() == DialogResult.OK)
            {
                string dosyaYolu = file.FileName;
                txtExcel.Text = dosyaYolu;
            }
        }

        private void txtExcel_TextChanged(object sender, EventArgs e)
        {
            FillCombosWithColumnName();
        }

        private void FillCombosWithColumnName()
        {
            var fileName = txtExcel.Text;
            List<string> fieldList = new List<string>();
            using (var stream = File.Open(fileName, FileMode.Open, FileAccess.Read))
            {
                // Auto-detect format, supports:
                //  - Binary Excel files (2.0-2003 format; *.xls)
                //  - OpenXml Excel files (2007 format; *.xlsx)
                using (var reader = ExcelReaderFactory.CreateReader(stream))
                {
                    reader.Read();
                    for (int fieldIndex = 0; fieldIndex < reader.FieldCount; fieldIndex++)
                    {
                        fieldList.Add(reader.GetString(fieldIndex));
                    }                    
                }
            }

            cmbXColumn.BindingContext = new BindingContext();
            cmbXColumn.DataSource = null;
            cmbXColumn.DataSource = fieldList;
            cmbXColumn.SelectedIndex = 0;

            cmbYColumn.BindingContext = new BindingContext();
            cmbYColumn.DataSource = null;
            cmbYColumn.DataSource = fieldList;
            cmbYColumn.SelectedIndex = 0;
        }

        private void btnUygula_Click(object sender, EventArgs e)
        {

            ESRI.ArcGIS.Geoprocessor.Geoprocessor gp = new ESRI.ArcGIS.Geoprocessor.Geoprocessor();
            ESRI.ArcGIS.ConversionTools.ExcelToTable excelToTable = new ESRI.ArcGIS.ConversionTools.ExcelToTable();
            excelToTable.Input_Excel_File = txtExcel.Text;
            excelToTable.Output_Table = @"C:\Users\Administrator\AppData\Roaming\64d4d8c1-c21e-4da4-b914-a3baa0a55bcc.mdb\test";
            gp.AddOutputsToMap = AppSingleton.Instance().AralariEkle;
            gp.OverwriteOutput = true;
            gp.Execute(excelToTable, null);

            ESRI.ArcGIS.DataManagementTools.MakeXYEventLayer makeLayer = new ESRI.ArcGIS.DataManagementTools.MakeXYEventLayer();
            makeLayer.table =  @"C:\Users\Administrator\AppData\Roaming\64d4d8c1-c21e-4da4-b914-a3baa0a55bcc.mdb\test";
            makeLayer.in_x_field = cmbXColumn.SelectedItem.ToString();
            makeLayer.in_y_field = cmbYColumn.SelectedItem.ToString();
            makeLayer.out_layer = @"C:\Users\Administrator\AppData\Roaming\64d4d8c1-c21e-4da4-b914-a3baa0a55bcc.mdb\test_layer";
            makeLayer.spatial_reference = "WGS 1984";

            gp.AddOutputsToMap = AppSingleton.Instance().AralariEkle;
            gp.OverwriteOutput = true;
            gp.Execute(makeLayer, null);
        }
    }
}
