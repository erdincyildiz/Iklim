using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ESRI.ArcGIS.Geodatabase;
using System.Runtime.InteropServices;

namespace Iklim
{
    public static class UtilMethods
    {
        public static Dictionary<string, string> CountUniques(ITable table, string fldName)
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

            var outDict = new Dictionary<string, string>(StringComparer.CurrentCultureIgnoreCase);
            ICursor cur = null;
            IRow row = null;
            try
            {
                cur = table.Search(qf, true);
                while ((row = cur.NextRow()) != null)
                {
                    try
                    {
                        string key = row.get_Value(idx) is DBNull ? "<Null>" :
                                               row.get_Value(idx).ToString();
                        if (outDict.ContainsKey(key))
                            outDict[key] = "";
                        else
                            outDict.Add(key, "");
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
                string msg = row == null ? "error getting value" :
                    "error getting value for row " + row.OID.ToString();
                throw new Exception(msg, ex);
            }
            finally
            {
                if (cur != null)
                    System.Runtime.InteropServices.Marshal.FinalReleaseComObject(cur);
            }

            return outDict;
        }
        public static Dictionary<string, string> GetEgim()
        {
            return null;
        }
    }
}
