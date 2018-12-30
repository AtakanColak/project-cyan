using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CyanMapEditor.MapEditorTools
{
    public class CyanMap
    {
        public string MapName { get; set; }
        public int MapId { get; set; }
        public List<MapItem> MapItems { get; set; }
    }
}
