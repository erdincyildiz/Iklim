using ESRI.ArcGIS.Carto;

namespace Iklim
{
    public class LayerObject
    {
        public string Name { get; set; }
        public ILayer layer { get; set; }
    }
}