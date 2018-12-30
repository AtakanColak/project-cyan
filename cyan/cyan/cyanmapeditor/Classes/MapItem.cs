using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using CyanMapTools;
using System.Drawing.Imaging;


namespace CyanMapEditor.MapEditorTools
{
    public class MapItem
    {
        public int X { get; set; }
        public int Y { get; set; }
        public bool CanTresspass { get; set; }
        public bool HasEvent { get; set; }
        public bool Altered { get; set; }
        public string EventName { get; set; }
        public Image BackgroundImage
        {
            get
            {
                return MappingTools.Base64ToImage(BackgroundImageString);
            }
            set
            {               
                BackgroundImageString = MappingTools.ImageToBase64(value, ImageFormat.Png);
            }
        }
        public Image Image
        {
            get
            {
                return MappingTools.Base64ToImage(ImageString);
            }
            set
            {        
                ImageString = MappingTools.ImageToBase64(value, ImageFormat.Png);
            }
        }
        public string BackgroundImageString { get; set; }
        public string ImageString { get; set; }
    }
}
