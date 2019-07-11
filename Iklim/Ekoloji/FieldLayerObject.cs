using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Iklim
{
    public class FieldLayerObject
    {
        public Dictionary<string, string> FieldList { get; set; }
        public LayerObject LayerObject { get; set; }
        public string FieldName { get; set; }
    }
}
