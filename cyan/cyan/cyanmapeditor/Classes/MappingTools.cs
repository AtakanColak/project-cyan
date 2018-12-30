using CyanMapEditor.MapEditorTools;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace CyanMapTools
{
    public class MappingTools
    {
        public static CyanMap XmlFileToMap(string xmlFilePath)
        {
            CyanMap map = new CyanMap();

            XmlDocument xDoc = new XmlDocument();
            xDoc.Load(xmlFilePath);
            map.MapName = xDoc.LastChild.Attributes[0].Value;
            map.MapId = Convert.ToInt32(xDoc.LastChild.Attributes[1].Value);
            List<MapItem> mapItems = new List<MapItem>();

            foreach (XmlNode node in xDoc.LastChild.ChildNodes)
            {
                MapItem mi = new MapItem();

                mi.X = Convert.ToInt32(node.ChildNodes[0].InnerText);
                mi.Y = Convert.ToInt32(node.ChildNodes[1].InnerText);
                mi.CanTresspass = Convert.ToBoolean(node.ChildNodes[2].InnerText);
                mi.HasEvent = Convert.ToBoolean(node.ChildNodes[3].InnerText);
                mi.EventName = node.ChildNodes[4].InnerText;
                mi.Altered = Convert.ToBoolean(node.ChildNodes[5].InnerText);
                mi.BackgroundImageString = node.ChildNodes[6].InnerText;              
                mi.ImageString = node.ChildNodes[7].InnerText;
                

                mapItems.Add(mi);
            }
            map.MapItems = mapItems;
            return map;
        }
        public static void CyanMapToPanelReadOnly(CyanMap map, FlowLayoutPanel flp)
        {
            flp.Controls.Clear();
            foreach (MapItem mi in map.MapItems)
            {
                PictureBox pb = new PictureBox();
                pb.Width = flp.Width / 15;
                pb.Height = flp.Height / 15;
                pb.Margin = new Padding(0);
                if (mi.Image != null)
                {
                    pb.Image = mi.Image;
                }
                if (mi.BackgroundImage != null)
                {
                    pb.BackgroundImage = mi.BackgroundImage;
                }
                pb.SizeMode = PictureBoxSizeMode.StretchImage;
                pb.BackgroundImageLayout = ImageLayout.Stretch;
                pb.Tag = mi;                
                flp.Controls.Add(pb);
            }
        }      
        public static void XmlFileToPanelReadOnly(string xmlFilePath, FlowLayoutPanel flp)
        {
            CyanMap map = XmlFileToMap(xmlFilePath);
            CyanMapToPanelReadOnly(map, flp);
        }
        public static string ImageToBase64(Image image,
System.Drawing.Imaging.ImageFormat format)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                // Convert Image to byte[]
                image.Save(ms, format);
                byte[] imageBytes = ms.ToArray();

                // Convert byte[] to Base64 String
                string base64String = Convert.ToBase64String(imageBytes);
                return base64String;
            }
        }
        public static Image Base64ToImage(string base64String)
        {
            // Convert Base64 String to byte[]
            byte[] imageBytes = Convert.FromBase64String(base64String);
            MemoryStream ms = new MemoryStream(imageBytes, 0,
              imageBytes.Length);

            // Convert byte[] to Image
            ms.Write(imageBytes, 0, imageBytes.Length);
            Image image = Image.FromStream(ms, true);
            return image;
        }
    }
}
