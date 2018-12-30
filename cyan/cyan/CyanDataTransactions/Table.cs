using CyanDataTransactions.Classes;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CyanDataTransactions
{
    public partial class Table : Form
    {
        public Table()
        {
            InitializeComponent();
        }

        private void Table_Load(object sender, EventArgs e)
        {
            CreateTable();
            CheckCounters();
        }
        void CreateTable()
        {
            IList pts = Tools.ReadAllClassesFromFile("../../../CyanDataTransactions/Data/PokemonTypes.xml", Activator.CreateInstance(typeof(PokemonType)), "PokemonType");
            Label firstBox = CreateLabel(pts.Count + 1);
            firstBox.Text = "Atk\\Def";
            flpTypes.Controls.Add(firstBox);
            foreach (var item in pts)
            {
                PokemonType pt = (PokemonType)item;
                Label lbl = CreateLabel(pt, pts.Count + 1);
                flpTypes.Controls.Add(lbl);
            }
            foreach (var item in pts)
            {
                PokemonType pt = (PokemonType)item;
                Label lbl = CreateLabel(pt, pts.Count + 1);
                flpTypes.Controls.Add(lbl);
                for (int i = 0; i < pts.Count; i++)
                {
                    Button emptyButton = CreateButton(pt, pts.Count + 1, (PokemonType)pts[i]);
                    flpTypes.Controls.Add(emptyButton);
                }
            }
        }
        void CheckCounters()
        {
            IList list = Tools.ReadAllClassesFromFile("../../Data/TypeEffects.xml", Activator.CreateInstance(typeof(TypeEffect)), "TypeEffects");
            foreach (var item in list)
            {
                TypeEffect te = (TypeEffect)item;
                foreach (Control cntrl in flpTypes.Controls)
                {
                    try
                    {
                        Button btn = cntrl as Button;
                        int[] tag = (int[])btn.Tag;
                        if (te.AttackerPokemonTypeid == tag[0] && te.DefenderPokemonTypeid == tag[1])
                        {
                            switch (te.Factor)
                            {
                                case 0 /*normal %100*/:
                                    btn.BackColor = Color.Green;
                                    btn.Text = "%100";
                                    break;
                                case 1/*not effective %50*/:
                                    btn.BackColor = Color.Red;
                                    btn.Text = "%50";
                                    break;
                                case 2/*effective %200*/:
                                    btn.BackColor = Color.Yellow;
                                    btn.Text = "%200";
                                    break;
                                case 3/*no effect %0*/:
                                    btn.BackColor = Color.Gray;
                                    btn.Text = "%0";
                                    break;
                            }
                        }
                    }
                    catch
                    { }
                }
            }
        }
        Button CreateButton(PokemonType pt, int count, PokemonType def)
        {
            Button btn = new Button();
            btn.Height = flpTypes.Height / count;
            btn.Width = flpTypes.Width / count;
            btn.Margin = new Padding(0);
            int[] data = { pt.id, def.id };
            btn.Tag = data;
            btn.BackColor = Color.White;
            btn.Click += ButtonClicked;
            return btn;
        }
        Label CreateLabel(PokemonType pt, int count)
        {
            Label lbl = CreateLabel(count);
            lbl.Text = pt.name;
            lbl.Tag = pt.id;
            return lbl;
        }
        Label CreateLabel(int count)
        {
            Label lbl = new Label();
            lbl.Height = flpTypes.Height / count;
            lbl.Width = flpTypes.Width / count;
            lbl.BorderStyle = BorderStyle.FixedSingle;
            lbl.Margin = new Padding();
            return lbl;
        }
        void ButtonClicked(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            if (btn.BackColor.Equals(Color.White) || btn.BackColor.Equals(Color.Gray))
            {
                btn.BackColor = Color.Red;
                btn.Text = "%50";
            }
            else if (btn.BackColor.Equals(Color.Green))
            {
                btn.BackColor = Color.Yellow;
                btn.Text = "%200";
            }
            else if (btn.BackColor.Equals(Color.Red))
            {
                btn.BackColor = Color.Green;
                btn.Text = "%100";
            }
            else if (btn.BackColor.Equals(Color.Yellow))
            {
                btn.BackColor = Color.Gray;
                btn.Text = "%0";
            }
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            foreach (object objct in flpTypes.Controls)
            {
                try
                {
                    Button btn = (Button) objct;
                    if (btn.BackColor != Color.White)
                    {
                        TypeEffect te = new TypeEffect();
                        int[] data = (int[])btn.Tag;
                        te.AttackerPokemonTypeid = data[0];
                        te.DefenderPokemonTypeid = data[1];
                        if (btn.BackColor.Equals(Color.Green))
                        {
                            te.Factor = 0;
                        }
                        else if (btn.BackColor.Equals(Color.Red))
                        {
                            te.Factor = 1;
                        }
                        else if (btn.BackColor.Equals(Color.Yellow))
                        {
                            te.Factor = 2;
                        }
                        else if (btn.BackColor.Equals(Color.Gray))
                        {
                            te.Factor = 3;
                        }
                        if (te.AttackerPokemonTypeid == 0 && te.DefenderPokemonTypeid == 0)
                        {
                            Tools.AddGivenClassWithDelete("../../Data/TypeEffects.xml", te, true);
                            
                        }
                        else
                        {
                            Tools.AddGivenClass("../../Data/TypeEffects.xml", te);
                        }
                       
                    }
                }
                catch 
                {
                                     
                }
            }
            MessageBox.Show("Succesfully saved!");
        }
    }
}
