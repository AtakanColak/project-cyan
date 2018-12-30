using CyanMapEditor.MapEditorTools;
using CyanMapTools;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace CyanMapEditor
{
    public partial class MapEditor : Form
    {
        public MapEditor()
        {
            InitializeComponent();
        }

        string folderImagePath = "..\\..\\..\\CyanMapEditor\\Miscalleneous\\Folder.png";

        public string selectedPath { get; set; }

        public Image selectedImage { get; set; }

        public PictureBox selectedPicturebox { get; set; }

        //string configPathway = "C:/Program Files/Cyan/Cyan.cyanfig";

        private void MapEditor_Load(object sender, EventArgs e)
        {
            LoadEmptyMap();
            //GetTilesToPanel("C:\\Users\\Atakan\\Documents\\Visual Studio 2013\\Projects\\Cyan\\CyanMapEditor\\Tiles", flpTiles);

            GetCyanTilesToTreeView("..\\..\\..\\CyanMapEditor\\Tiles", tvResimler);

            SetEventsToCombobox();
            rbImageMode.Checked = true;
        }


        void GetCyanTilesToTreeView(string directory, TreeView tv)
        {
            tv.Nodes.Clear();
            ImageList il = new ImageList();
            il.Images.Add(Image.FromFile(folderImagePath));
            int index = 1;

            foreach (string folder in Directory.GetDirectories(directory))
            {
                TreeNode tn = new TreeNode();
                tn.ImageIndex = 0;
                tn.Text = Path.GetFileName(folder);
                foreach (Image img in GetCyanImagesFromDirectory(folder).Images)
                {
                    il.Images.Add(img);
                    TreeNode tile = new TreeNode();
                    tile.ImageIndex = index;
                    tn.Nodes.Add(tile);
                    index++;
                }
                tv.Nodes.Add(tn);
            }
            tv.ImageList = il;
            tv.AfterSelect += tv_AfterSelect;
        }

        void tv_AfterSelect(object sender, TreeViewEventArgs e)
        {
            TreeView tv = (TreeView)sender;
            if (tv.SelectedNode.Level == 1)
            {
                selectedImage = tv.ImageList.Images[tv.SelectedNode.ImageIndex];
            }
        }

        ImageList GetCyanImagesFromDirectory(string directory)
        {
            ImageList il = new ImageList();
            foreach (string path in Directory.GetFiles(directory))
            {
                if (Path.GetExtension(path) == ".cyni")
                {
                    il.Images.Add(Image.FromFile(path));
                }
            }
            return il;
        }

        void btn_Click(object sender, EventArgs e)
        {
            TreeNode clicked = sender as TreeNode;
            selectedImage = tvResimler.ImageList.Images[clicked.ImageIndex];
        }

        private void lblNewMap_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("If you have not saved this map, it ll be deleted for good...", "Warning", MessageBoxButtons.YesNo);
            if (dr == System.Windows.Forms.DialogResult.Yes)
            {
                LoadEmptyMap();
            }
        }

        void LoadEmptyMap()
        {
            flpMap.Controls.Clear();
            for (int y = 0; y < 15; y++)
            {
                for (int x = 0; x < 15; x++)
                {
                    MapItem mi = new MapItem();
                    mi.CanTresspass = true;
                    mi.X = x + 1;
                    mi.Y = y + 1;
                    PictureBox pb = CreatePictureBoxWithMapClick(15, 15, flpMap, mi);
                    flpMap.Controls.Add(pb);
                }

            }
            ClearThings();
        }

        void SetMapClickEvent(PictureBox pb)
        {

            pb.MouseDown += pb_MouseDown;
        }

        void pb_MouseDown(object sender, MouseEventArgs e)
        {
            PictureBox pb = (PictureBox)sender;
            if (e.Button == System.Windows.Forms.MouseButtons.Right)
            {
                pb.Tag = new MapItem();
                pb.Image = null;
                pb.BackgroundImage = null;
                SetImagesFromTags();
            }
            else
            {
                lbl_Click(sender, e);
            }
        }

        void SetTileClickEvent(PictureBox pb)
        {
            pb.Click += btn_Click;
        }

        PictureBox CreatePictureBoxWithNoEvents(int columnCount, int rowCount, FlowLayoutPanel panel, object tag)
        {
            PictureBox pb = new PictureBox();
            pb.Width = panel.Width / columnCount;
            pb.Height = panel.Height / rowCount;
            pb.BackColor = Color.Transparent;
            pb.Margin = new Padding(0);
            //Boyut değişince ekleme yapacağı yerleri bulması için
            pb.Tag = tag;
            pb.SizeMode = PictureBoxSizeMode.StretchImage;
            pb.BackgroundImageLayout = ImageLayout.Stretch;
            return pb;
        }

        PictureBox CreatePictureBoxWithMapClick(int columnCount, int rowCount, FlowLayoutPanel panel, object tag)
        {
            PictureBox pb = CreatePictureBoxWithNoEvents(columnCount, rowCount, panel, tag);
            SetMapClickEvent(pb);
            return pb;
        }

        void lbl_Click(object sender, EventArgs e)
        {
            PictureBox pb = sender as PictureBox;
            MapItem mi = pb.Tag as MapItem;
            if (rbImageMode.Checked)
            {
                if (selectedImage != null)
                {

                    if (rbBack.Checked)
                    {
                        mi.BackgroundImageString = MappingTools.ImageToBase64(selectedImage, ImageFormat.Png);
                        pb.BackgroundImage = mi.BackgroundImage;
                        pb.BackgroundImageLayout = ImageLayout.Stretch;
                        mi.Altered = true;

                    }
                    else if (rbMiddle.Checked)
                    {
                        mi.ImageString = MappingTools.ImageToBase64(selectedImage, ImageFormat.Png);
                        pb.Image = mi.Image;
                        pb.SizeMode = PictureBoxSizeMode.StretchImage;
                        mi.Altered = true;

                    }
                    else
                    {
                        MessageBox.Show("There is no layer selected...");
                    }
                }
                else
                {
                    MessageBox.Show("There is no image selected...");
                }
            }
            else if (rbTresspassMode.Checked)
            {
                mi.CanTresspass = !mi.CanTresspass;
                SetColors(pb);
            }
            else if (rbEventMode.Checked)
            {
                if (selectedPicturebox != null)
                {
                    MapItem old = selectedPicturebox.Tag as MapItem;
                    if (!old.HasEvent)
                    {
                        selectedPicturebox.BackColor = Color.White;
                    }
                    else
                    {
                        selectedPicturebox.BackColor = Color.Yellow;
                    }
                    
                }
                selectedPicturebox = pb;
                pb.BackColor = Color.Red;
                try
                {
                    if (mi.HasEvent)
                    {
                        string eventString = mi.EventName.Remove(0, 1);
                        int eventTypeI = 0;
                        switch (mi.EventName.ToCharArray()[0])
                        {
                            case 'L':
                                eventTypeI = 0;
                                break;
                            case 'S':
                                eventTypeI = 1;
                                break;
                            case 'F':
                                eventTypeI = 2;
                                break;
                            case 'W':
                                eventTypeI = 3;
                                break;
                        }
                        cmbEventType.SelectedItem = cmbEventType.Items[eventTypeI];
                        txtEventString.Text = eventString;
                    }
                }
                catch
                { }
            }
            else
            {
                MessageBox.Show("You have not chosen a mode...");
            }

        }

        void SetEventPropertiesToTrue(MapItem mi)
        {
            mi.Altered = true;
            mi.HasEvent = true;
        }

        void SetEventsToCombobox()
        {
            string[] events = { "Load Map", "Show Text", "Fight", "Wild Pokemon Area" };
            foreach (string s in events)
            {
                cmbEventType.Items.Add(s);
            }
        }

        private void rbImageMode_Click(object sender, EventArgs e)
        {
            SetImagesFromTags();
        }

        public void SetImagesFromTags()
        {
            foreach (PictureBox pb in flpMap.Controls)
            {

                MapItem mi = pb.Tag as MapItem;
                pb.BackColor = Color.Transparent;
                if (!String.IsNullOrEmpty(mi.BackgroundImageString))
                {
                    pb.BackgroundImage = mi.BackgroundImage;
                    pb.BackgroundImageLayout = ImageLayout.Stretch;
                }
                else
                {
                    if (pb.BackgroundImage != null)
                    {
                        pb.BackgroundImage = null;
                    }
                }
                if (!String.IsNullOrEmpty(mi.ImageString))
                {
                    pb.Image = mi.Image;
                    pb.SizeMode = PictureBoxSizeMode.StretchImage;
                }
                else
                {
                    if (pb.Image != null)
                    {
                        pb.Image = null;
                    }
                }
            }
        }

        void SetColors(PictureBox pb)
        {
            MapItem mi = pb.Tag as MapItem;

            if (!mi.CanTresspass)
            {
                pb.BackColor = Color.Red;
            }
            else
            {
                pb.BackColor = Color.White;
            }
        }

        private void rbTresspassMode_Click(object sender, EventArgs e)
        {

            foreach (PictureBox pb in flpMap.Controls)
            {
                if (pb.BackgroundImage != null)
                {
                    pb.BackgroundImage = null;
                }
                if (pb.Image != null)
                {


                    pb.Image = null;
                }

                if ((pb.Tag as MapItem).Altered)
                {
                    SetColors(pb);
                }

            }

        }

        private void lblSaveMap_Click(object sender, EventArgs e)
        {
            if (CheckIfTheyAreOk())
            {

                if (selectedPath == null)
                {
                    SaveAs();
                }
                else
                {
                    CreateAndSaveMapTo(selectedPath);
                }
            }
            else
            { MessageBox.Show("Please enter id and name of the map!!!"); }
        }

        void SaveAs()
        {
            if (CheckIfTheyAreOk())
            {
                string location = GetSaveLocation();
                selectedPath = location;
                CreateAndSaveMapTo(location);
            }
            else
            {
                MessageBox.Show("Please enter id and name of the map!!!");
            }
        }

        string GetSaveLocation()
        {
            SaveFileDialog sf = new SaveFileDialog();
            sf.Title = "Save Map";
            sf.Filter = "(*.cynm)|*.cynm";
            sf.ShowDialog();
            return sf.FileName;
        }

        void CreateAndSaveMapTo(string filePath)
        {
            try
            {
                XmlTextWriter mapWriter = new XmlTextWriter(filePath, null);
                CyanMap map = new CyanMap();
                map.MapId = Convert.ToInt32(txtMapId.Text);
                List<MapItem> antiBugList = new List<MapItem>();
                foreach (PictureBox pb in flpMap.Controls)
                {
                    MapItem mi = pb.Tag as MapItem;

                    
                        antiBugList.Add(mi);
                    

                }
                map.MapItems = antiBugList;
                map.MapName = txtMapName.Text;
                mapWriter.WriteStartDocument();
                mapWriter.WriteStartElement("Map");
                mapWriter.WriteAttributeString("name", map.MapName);
                mapWriter.WriteAttributeString("id", map.MapId.ToString());
                foreach (MapItem mi in map.MapItems)
                {
                    mapWriter.WriteStartElement("MapItem");

                    WriteElement(mapWriter, "X", mi.X.ToString());

                    WriteElement(mapWriter, "Y", mi.Y.ToString());

                    WriteElement(mapWriter, "Tresspassing", mi.CanTresspass.ToString());

                    WriteElement(mapWriter, "HasEvent", mi.HasEvent.ToString());

                    WriteElement(mapWriter, "Event", mi.EventName ?? "null");

                    WriteElement(mapWriter, "Altered", mi.Altered.ToString());

                    WriteElement(mapWriter, "BackgroundImage", mi.BackgroundImageString ?? "");

                    WriteElement(mapWriter, "Image", mi.ImageString ?? "");

                    mapWriter.WriteEndElement();
                }
                mapWriter.WriteEndElement();
                mapWriter.WriteEndDocument();
                mapWriter.Close();

                MessageBox.Show("Map Successfully Saved!");
            }
            catch
            {
                MessageBox.Show("Map Saving Failed!");
            }
        }

        void WriteElement(XmlTextWriter writer, string elementName, string value)
        {
            writer.WriteStartElement(elementName);
            writer.WriteString(value);
            writer.WriteEndElement();
        }

        private void lblLoadMap_Click(object sender, EventArgs e)
        {
            OpenFileDialog od = new OpenFileDialog();
            od.Multiselect = false;
            od.Title = "Load Map";
            od.Filter = "(*.cynm)|*.cynm";
            od.ShowDialog();
            if (!String.IsNullOrEmpty(od.FileName))
            {
                selectedPath = od.FileName;

                CyanMap map = MappingTools.XmlFileToMap(od.FileName);

                flpMap.Controls.Clear();

                foreach (MapItem mi in map.MapItems)
                {
                    PictureBox pb = CreatePictureBoxWithMapClick(15, 15, flpMap, mi);

                    if (!String.IsNullOrEmpty(mi.BackgroundImageString))
                        pb.BackgroundImage = MappingTools.Base64ToImage(mi.BackgroundImageString);

                    if (!String.IsNullOrEmpty(mi.ImageString))
                        pb.Image = MappingTools.Base64ToImage(mi.ImageString);

                    flpMap.Controls.Add(pb);
                }
                txtMapName.Text = map.MapName;

                txtMapId.Text = map.MapId.ToString();

                rbImageMode.Checked = true;
            }
            else
            {
                MessageBox.Show("Did not load any file...");
            }
        }

        private void lblSaveAs_Click(object sender, EventArgs e)
        {
            SaveAs();
        }

        void ClearThings()
        {
            txtMapId.Clear();
            txtMapName.Clear();
        }

        bool CheckIfTheyAreOk()
        {
            if (!String.IsNullOrEmpty(txtMapId.Text) && !String.IsNullOrEmpty(txtMapName.Text))
            {
                return true;
            }
            return false;
        }

        private void rbEventMode_Click(object sender, EventArgs e)
        {
            SetEventColors();
        }

        void SetEventColors()
        {
            foreach (PictureBox pb in flpMap.Controls)
            {
                if (pb.BackgroundImage != null)
                {
                    pb.BackgroundImage = null;
                }
                if (pb.Image != null)
                {
                    pb.Image = null;
                }
                MapItem mi = pb.Tag as MapItem;
                if (mi.Altered)
                {
                    if (!mi.HasEvent)
                    {
                        pb.BackColor = Color.White;
                    }
                    else
                    {
                        pb.BackColor = Color.Yellow;
                    }
                }

            }
        }

        private void btnSetEvent_Click(object sender, EventArgs e)
        {
            if (cmbEventType.SelectedItem != null && !String.IsNullOrEmpty(txtEventString.Text))
            {
                try
                {
                    MapItem mi = selectedPicturebox.Tag as MapItem;
                    switch (cmbEventType.SelectedItem.ToString())
                    {
                        case "Load Map":
                            try
                            {

                                mi.EventName = "L" + txtEventString.Text;
                                SetEventPropertiesToTrue(mi);
                            }
                            catch
                            {
                                MessageBox.Show("Please enter a proper map id...");
                            }
                            break;
                        case "Show Text":
                            mi.EventName = "S" + txtEventString.Text;
                            SetEventPropertiesToTrue(mi);
                            break;
                        case "Fight":
                            try
                            {
                                int pid = Convert.ToInt32(txtEventString.Text);
                                mi.EventName = "F" + pid.ToString();
                                SetEventPropertiesToTrue(mi);
                            }
                            catch
                            {
                                MessageBox.Show("Please enter a proper Pokemon Id...");
                            }
                            break;
                        case "Wild Pokemon Area":

                            try
                            {
                                int pid2 = Convert.ToInt32(txtEventString.Text);
                                mi.EventName = "W" + pid2.ToString();
                                SetEventPropertiesToTrue(mi);
                            }
                            catch
                            {
                                MessageBox.Show("Please enter a proper Pokemon Id...");
                            }
                            break;
                        default:
                            MessageBox.Show("There is a mistake on declaring event type");
                            break;
                    }
                    selectedPicturebox.BackColor = Color.Green;
                }
                catch
                {
                    MessageBox.Show("You have not selected an item to set an event...");
                }
            }
        }

        private void lblImager_Click(object sender, EventArgs e)
        {
            Imager img = new Imager();
            img.FormClosing += ImageAdded;
            img.ShowDialog();

        }

        void ImageAdded(object sender, FormClosingEventArgs e)
        {

            GetCyanTilesToTreeView("..\\..\\..\\CyanMapEditor\\Tiles", tvResimler);
        }


        //void GetTilesToPanel(string directory, FlowLayoutPanel flp)
        //{
        //    foreach (string i in Directory.GetFiles(directory))
        //    {

        //        string extensiyon = Path.GetExtension(i);
        //        switch (extensiyon)
        //        {

        //            case ".cyn":
        //                PictureBox pb = CreatePictureBoxWithTileClick(4,15, flpTiles, i);
        //                pb.BackgroundImage = Image.FromFile(i);                             
        //                flp.Controls.Add(pb);
        //                break;
        //        }
        //    }
        //    foreach (string i in Directory.GetDirectories(directory))
        //    {
        //        GetTilesToPanel(i,flpTiles);
        //    }
        //}


        //private void nuX_ValueChanged(object sender, EventArgs e)
        //{
        //    nuX.Enabled = false;
        //    int? oldx;
        //    int y;
        //    try
        //    {
        //        oldx = flpMap.Width / flpMap.Controls[0].Width;
        //        y = flpMap.Height / flpMap.Controls[0].Height;
        //    }
        //    catch
        //    {
        //        oldx = null;
        //        y = Convert.ToInt32(nuY.Value);
        //    }
        //    int newX = Convert.ToInt32(nuX.Value);
        //    Control.ControlCollection oldMap = flpMap.Controls;


        //    if (oldx != null)
        //    {


        //        if (oldx < newX)
        //        {

        //            flpMap.Controls.Clear();
        //            for (int currentY = 0; currentY < y; currentY++)
        //            {
        //                for (int currentX = 0; currentX < newX; currentX++)
        //                {
        //                    int[] position = { currentX, currentY };
        //                    Label lbl = null;
        //                    foreach (Control c in oldMap)
        //                    {
        //                        object[] tags = c.Tag as object[];
        //                        int[] cPosition = tags[0] as int[];
        //                        if (TheseArraysAreEqual(position, cPosition))
        //                        {
        //                            lbl = c as Label;
        //                            lbl.Width = flpMap.Width / newX;
        //                        }
        //                    }
        //                    if (lbl == null)
        //                    {
        //                        MapItem mi = new MapItem();
        //                        object[] tag = { position, mi };
        //                        lbl = CreateLabel(newX, y, Color.Gray, tag);
        //                    }
        //                    flpMap.Controls.Add(lbl);
        //                }
        //            }
        //        }
        //        else if (oldx > newX)
        //        {

        //            List<Control> newMap = new List<Control>();
        //            for (int currentY = 0; currentY < y; currentY++)
        //            {
        //                for (int currentX = 0; currentX < newX; currentX++)
        //                {
        //                    int[] position = { currentX, currentY };

        //                    foreach (Control c in oldMap)
        //                    {
        //                        object[] tag = c.Tag as object[];
        //                        int[] cPosition = tag[0] as int[];
        //                        if (TheseArraysAreEqual(position, cPosition))
        //                        {
        //                            Label lbl = c as Label;
        //                            lbl.Width = flpMap.Width / newX;
        //                            newMap.Add(c);
        //                        }
        //                    }
        //                }
        //            }
        //            flpMap.Controls.Clear();
        //            foreach (Control c in newMap)
        //            {
        //                flpMap.Controls.Add(c);
        //            }

        //        }
        //    }
        //    else
        //    { LoadEmptyMap(newX, y); }
        //    nuX.Enabled = true;
        //}
        //bool TheseArraysAreEqual(int[] a, int[] b)
        //{
        //    if (a[0] == b[0] && b[1] == a[1])
        //    {
        //        return true;
        //    }
        //    return false;


        //}
        //private void nuY_ValueChanged(object sender, EventArgs e)
        //{

        //}
    }
}
