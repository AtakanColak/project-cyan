using CyanFight.Classes;
using CyanMapEditor.MapEditorTools;
using CyanMapTools;
using CyanWorld.Forms.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CyanWorld.Forms
{
    public partial class World : Form
    {
        public World()
        {
            InitializeComponent();
            currentSd = new SaveData();
            currentSd.MapX = 8;
            currentSd.MapY = 10;
            currentSd.MapId = 2;
            currentSd.PokemonName = "Minnos";
            currentSd.Experience = 100;
            
        }
        public World(SaveData sd)
        {
            InitializeComponent();
            currentSd = sd;
            
        }
        SaveData currentSd;
        private void World_Load(object sender, EventArgs e)
        {
            PictureBox pb = new PictureBox();
            pb.Height = 50;
            pbCharacter.Tag = pb;
            LoadMap(currentSd.MapId, currentSd.MapX, currentSd.MapY);
            
        }
        int currentMapId = 0;
        void LoadMap(int mapId, int startX, int startY)
        {
            currentMapId = mapId;
            CyanMap map = new CyanMap();
            foreach (string file in Directory.GetFiles("../../Maps"))
            {
                if (Path.GetExtension(file) == ".cynm")
                {
                    if (MappingTools.XmlFileToMap(file).MapId == mapId)
                    {
                        map = MappingTools.XmlFileToMap(file);
                    }
                }
            }
            this.Tag = pbCharacter;
            this.Controls.Clear();
            this.Controls.Add(this.Tag as PictureBox);
            this.SuspendLayout();
           
            int Xnumbuh = 0;
            int Ynumbuh = 0;
            foreach (MapItem mi in map.MapItems)
            {
                PictureBox pb = new PictureBox();
                pb.Width = 44;
                pb.Height = 44;
                pb.BackgroundImageLayout = ImageLayout.Stretch;
                pb.Location = new Point(44 * Xnumbuh, 44 * Ynumbuh);
                Xnumbuh++;
                if (Xnumbuh == 15)
                {
                    Xnumbuh = 0;
                    Ynumbuh++;
                }
                pb.SizeMode = PictureBoxSizeMode.StretchImage;
                if (!String.IsNullOrEmpty(mi.BackgroundImageString))
                {
                    pb.BackgroundImage = mi.BackgroundImage;
                }
                if (!String.IsNullOrEmpty(mi.ImageString))
                {
                    pb.Image = mi.Image;
                }
                pb.Margin = new Padding(0);
                pb.Parent = this;
                pb.Tag = mi;
                this.Controls.Add(pb);
                if (mi.X == startX && mi.Y == startY)
                {
                    SetCharacterPosition(startX, startY, pb);
                }
            }
            this.ResumeLayout();
        }

        void SetCharacterPosition(int X, int Y, PictureBox pb)
        {
            pbCharacter.SizeMode = PictureBoxSizeMode.StretchImage;
            pbCharacter.Location = new Point(44 * (X-1), 44 * (Y-1));
            pbCharacter.BackColor = Color.Transparent;
            pbCharacter.Tag = pb;
            tmrMover.Enabled = false;
            isMoving = false;
            remaining = 22;
        }

        private void World_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Up:
                    MoveUp();
                    break;
                case Keys.Down:
                    MoveDown();
                    break;
                case Keys.Left:
                    MoveLeft();
                    break;
                case Keys.Right:
                    MoveRight();
                    break;
                case Keys.S:
                    DialogResult dr = MessageBox.Show("Are you sure that you want to save?","Warning",MessageBoxButtons.YesNo);
                    if (dr == System.Windows.Forms.DialogResult.Yes)
                    {
                        currentSd.MapId = currentMapId;
                        MapItem mi = (pbCharacter.Tag as PictureBox).Tag as MapItem;
                        currentSd.MapX = mi.X ;
                        currentSd.MapY = mi.Y ;
                        currentSd.Save(currentSd.PokemonName);
                        MessageBox.Show("Save succesfull...");
                    }
                    break;
            }
        }

        void MoveUp()
        {
            MoveChar(-15, 0, -1,Image.FromFile("../../Other/walktop.gif"));
        }

        void MoveDown()
        {
            MoveChar(15, 0, 1, Image.FromFile("../../Other/walkbottom.gif"));
        }

        void MoveRight()
        {
            MoveChar(1, 1, 0, Image.FromFile("../../Other/walkright.gif"));
        }

        void MoveLeft()
        {
            MoveChar(-1, -1, 0,Image.FromFile("../../Other/walkleft.gif"));
        }

        void MoveChar(int indexDif, int Xchange, int Ychange,Image img)
        {
            if (!isMoving)
            {
                PictureBox now = pbCharacter.Tag as PictureBox;
                MapItem mi1 = now.Tag as MapItem;
                int currentIndex = this.Controls.IndexOf(now);
                try
                {
                    PictureBox toMove = this.Controls[currentIndex + indexDif] as PictureBox;
                    MapItem mi2 = toMove.Tag as MapItem;
                    if (mi1.Y != mi2.Y && mi1.X == mi2.X)
                    {
                        if (mi2.CanTresspass)
                        {
                            valX = Xchange;
                            valY = Ychange;
                            isMoving = true;
                            tmrMover.Enabled = true;
                            pbCharacter.Image = img;
                            pbCharacter.Tag = toMove;
                            
                        }
                        EventReader(toMove);
                    }
                    else if (mi1.Y == mi2.Y && mi1.X != mi2.X)
                    {
                        if (mi2.CanTresspass)
                        {
                            valX = Xchange;
                            valY = Ychange;
                            isMoving = true;
                            tmrMover.Enabled = true;
                            pbCharacter.Image = img;
                            pbCharacter.Tag = toMove;
                            
                        }
                        EventReader(toMove);
                    }
                }
                catch
                { }
            }
        }

        bool isMoving = false;

        int remaining = 22;       

        int valX = 0;

        int valY = 0;

        private void tmrMover_Tick(object sender, EventArgs e)
        {
            if (remaining != 0 )
            {
                pbCharacter.Location = new Point(pbCharacter.Location.X + (2*valX), pbCharacter.Location.Y + (2*valY));
                remaining--;
            }
            else
            {
                valX = 0;
                valY = 0;
                remaining = 22;
                tmrMover.Enabled = false;
                isMoving = false;
                pbCharacter.Image = Image.FromFile("../../Other/standing.png");
            }
        }

        void EventReader(PictureBox pb)
        {
            MapItem mi = pb.Tag as MapItem;
            if (mi.HasEvent)
            {
                string eventString = mi.EventName.Remove(0, 1);
                
                switch (mi.EventName.ToCharArray()[0])
                {
                    case 'L':
                        string[] datas = eventString.Split(',');
                        LoadMap(Convert.ToInt32(datas[0]), Convert.ToInt32(datas[1]), Convert.ToInt32(datas[2]));
                        break;
                    case 'S':
                        MessageBox.Show(eventString);
                        break;
                    case 'W':
                        Random rnd = new Random();
                        int random = rnd.Next(10);
                        if (random > 6)
                        {
                            LoadFight(Convert.ToInt32(eventString));
                        }
                        break;
                }
            }
        }
        void LoadFight(int pokemonId)
        {
            Random rnd = new Random();

            Pokemon enemy = new Pokemon();
            enemy.PokemonBaseId = pokemonId-1;
            enemy.PokemonName = enemy.PokemonBase().PokemonBaseName;
            enemy.Experience = currentSd.Experience-rnd.Next(currentSd.Experience/2);
            CyanFight.Fight fight = new CyanFight.Fight(currentSd.Pokemon(), enemy);
            fight.FormClosing += FightEnded;
            fight.ShowDialog();
        }
        int xpf = 50;
        void FightEnded(object sender, FormClosingEventArgs e)
        {
            CyanFight.Fight fight = (CyanFight.Fight)sender;
            if (fight.Won)
            {
                MessageBox.Show("You have gained " + xpf.ToString() + " XP!");
                currentSd.Experience += xpf;
            }
            else
            {
                MessageBox.Show("You have lost! Maybe this place is above your level...");
            }
        }
    }
}
