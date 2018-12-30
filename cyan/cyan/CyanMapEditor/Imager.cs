using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace CyanMapEditor
{
    public partial class Imager : Form
    {
        public Imager()
        {
            InitializeComponent();
        }

        private void Imager_Load(object sender, EventArgs e)
        {
            AddCategoriesToComboBox();
        }

        void GetTheImageToPanel()
        {

            OpenFileDialog od = new OpenFileDialog();
            od.Title = "Select an image...";
            DialogResult dr = od.ShowDialog();
            if (dr == System.Windows.Forms.DialogResult.OK)
            {
                try
                {
                    lblLoading.Text = "Loading...";
                    Bitmap bmp = new Bitmap(Image.FromFile(od.FileName));
                    if (bmp.Width * bmp.Height < 4000)
                    {
                        final = new Bitmap(bmp.Width, bmp.Height);
                        List<Label> list = GetTheList(bmp);
                        AddLabelsToPanel(list);
                        lblLoading.Text = od.SafeFileName + " loaded...";
                        btnOk.Enabled = true;
                    }
                    else
                    {
                        MessageBox.Show("Error : Picture is too big...");
                        lblLoading.Text = "";
                    }
                }
                catch
                {
                    MessageBox.Show("Error : No file was loaded...");
                    lblLoading.Text = "";
                }
            }

        }

        void PixelClicked(object sender, EventArgs e)
        {
            Label lbl = (Label)sender;

            if (lbl.BackColor == Color.Transparent)
            {
                lbl.BackColor = (Color)lbl.Tag;
                if (lbl.BackColor.A == 0)
                {
                    lbl.Text = "T";
                }
                else
                {
                    lbl.Text = "";
                }
            }
            else
            {
                lbl.Tag = lbl.BackColor;
                lbl.Text = "T";
                lbl.BackColor = Color.Transparent;
            }
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            GetTheImageToPanel();
        }

        List<Label> GetTheList(Bitmap bmp)
        {
            int width = flpImage.Width / bmp.Width;
            int height = flpImage.Height / bmp.Height;
            List<Label> list = new List<Label>();
            for (int y = 0; y < bmp.Height; y++)
            {
                for (int x = 0; x < bmp.Width; x++)
                {
                    Label lbl = new Label();
                    lbl.Height = height;
                    lbl.Width = width;
                    lbl.BackColor = bmp.GetPixel(x, y);
                    if (lbl.BackColor.A == 0)
                    {
                        lbl.Text = "T";
                    }
                    lbl.Margin = new Padding(0);
                    lbl.Click += PixelClicked;
                    xList.Add(x);
                    yList.Add(y);
                    list.Add(lbl);
                }
            }
            return list;
        }

        void AddLabelsToPanel(List<Label> list)
        {
            pgProgress.Maximum = list.Count;
            pgProgress.Value = 0;
            flpImage.Controls.Clear();

            flpImage.SuspendLayout();
            foreach (var item in list)
            {
                pgProgress.Value++;
                flpImage.Controls.Add(item);
            }
            flpImage.ResumeLayout();
        }

        void AddCategoriesToComboBox()
        {
            foreach (string item in Directory.GetDirectories("../../../CyanMapEditor/Tiles"))
            {
                string filename = Path.GetFileName(item);
                cmbType.Items.Add(filename);
            }
            cmbType.SelectedIndex = 0;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        Bitmap final;
        List<int> xList = new List<int>();
        List<int> yList = new List<int>();
        private void btnOk_Click(object sender, EventArgs e)
        {
            foreach (Label lbl in flpImage.Controls)
            {
                int index = flpImage.Controls.IndexOf(lbl);
                int x = xList[index];
                int y = yList[index];
                final.SetPixel(x, y, lbl.BackColor);
            }
            final.Save("../../../CyanMapEditor/Tiles/" + cmbType.SelectedItem.ToString() + "/" +txtName.Text +".cyni",System.Drawing.Imaging.ImageFormat.Png);
            MessageBox.Show("Saved!");
            this.Close();
        }
    }
}
