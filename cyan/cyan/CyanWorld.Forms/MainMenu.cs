using CyanWorld.Forms.Classes;
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

namespace CyanWorld.Forms
{
    public partial class MainMenu : Form
    {
        public MainMenu()
        {
            InitializeComponent();
        }

        private void MainMenu_Load(object sender, EventArgs e)
        {
            LoadMenuButtons();
        }
        void LoadMenuButtons()
        {
            flpPanel.Controls.Clear();
            for (int i = 0; i < 5; i++)
            {
                Button btn = new Button();
                btn.Width = flpPanel.Width;
                btn.Height = (flpPanel.Height / 5)-5;
                switch (i)
                {
                    case 0:
                        btn.Text = "New Game";
                        btn.Click += NewGame;
                        break;
                    case 1:
                        btn.Text = "Load Game";
                        btn.Click += LoadGame;
                        break;
                    case 2:
                        btn.Text = "Map Editor";
                        btn.Click += MapEditor;
                        break;
                    case 3:
                        btn.Text = "Data";
                        btn.Click += Data;
                        break;
                    case 4:
                        
                        btn.Text = "Exit";
                        btn.Click += Exit;
                        break;
                }
                flpPanel.Controls.Add(btn);
            }
        }

        void Data(object sender, EventArgs e)
        {
            CyanDataTransactions.DataTransactions dt = new CyanDataTransactions.DataTransactions();
            this.Visible = false;
            dt.FormClosing += DataClosing;
            dt.ShowDialog();
        }

        void DataClosing(object sender, FormClosingEventArgs e)
        {
            this.Visible = true;
        }

        void Exit(object sender, EventArgs e)
        {
            this.Close();
        }

        void MapEditor(object sender, EventArgs e)
        {
            CyanMapEditor.MapEditor editor = new CyanMapEditor.MapEditor();
            editor.FormClosing += MapEditorClosing;
            this.Visible = false;
            editor.ShowDialog();
        }

        void MapEditorClosing(object sender, FormClosingEventArgs e)
        {
            this.Visible = true;
        }

        void LoadGame(object sender, EventArgs e)
        {
            flpPanel.Controls.Clear();
            foreach (string path in Directory.GetFiles("../../Saves"))
            {
                if (Path.GetExtension(path) == ".xml")
                {
                    SaveData sd = SaveData.Load(path);
                    Button btn = new Button();
                    btn.Height = 150;
                    btn.Width = 150;
                    btn.Tag = sd;
                    btn.Text = sd.PokemonName;
                    btn.Click += LoadClicked;
                    flpPanel.Controls.Add(btn);
                }

            }
            Button lastBut = new Button();
            lastBut.Text = "Main Menu";
            lastBut.Width = 150;
            lastBut.Height = 150;
            lastBut.Click += BackClicked;
            flpPanel.Controls.Add(lastBut);
        }

        void BackClicked(object sender, EventArgs e)
        {
            LoadMenuButtons();
        }

        void LoadClicked(object sender, EventArgs e)
        {
            CyanWorld.Forms.World world = new World((sender as Button).Tag as SaveData);
            world.FormClosed += GameClosed;
            this.Visible = false;
            world.ShowDialog();
        }

        void NewGame(object sender, EventArgs e)
        {
            World world = new World();
            world.FormClosed += GameClosed;
            this.Visible = false;
            world.ShowDialog();
        }

        void GameClosed(object sender, FormClosedEventArgs e)
        {
            LoadMenuButtons();
            this.Visible = true;
        }
    }
}
