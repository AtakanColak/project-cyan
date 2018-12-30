using CyanDataTransactions.Classes;
using CyanMapTools;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace CyanDataTransactions
{
    public partial class DataTransactions : Form
    {
        public DataTransactions()
        {
            InitializeComponent();
        }
        private void DataTransactions_Load(object sender, EventArgs e)
        {

        }

        private void btnAddPokemonType_Click(object sender, EventArgs e)
        {
            PokemonType newType = new PokemonType();
            newType.name = txtPokemonTypeName.Text;
            Tools.AddGivenClass("../../../CyanDataTransactions/Data/PokemonTypes.xml", newType);
            SuccesfullySaved();
        }
        private void btnAddExperienceGroup_Click(object sender, EventArgs e) 
        {
            ExperienceGroup eg = new ExperienceGroup();
            eg.Name = txtExperienceGroupName.Text;
            Tools.AddGivenClass("../../../CyanDataTransactions/Data/ExperienceGroups.xml", eg);
            SuccesfullySaved();
        }
        private void btnAddMove_Click(object sender, EventArgs e)
        {
            PokemonMove pm = new PokemonMove();
            pm.Name = txtMoveName.Text;
            pm.Typeid = Con(nuTypeId);
            pm.Power = Con(nuPower);
            pm.Cost = Con(nuCost);
            pm.Accuracy = Con(nuAccuracy);
            Tools.AddGivenClass("../../../CyanDataTransactions/Data/PokemonMoves.xml", pm);
            SuccesfullySaved();
        }
        private void btnAddTypeEffect_Click(object sender, EventArgs e)
        {
            Table tb = new Table();
            tb.ShowDialog();
        }
        private void btnAddMovePokemon_Click(object sender, EventArgs e)
        {
            MovePokemon mp = new MovePokemon();
            mp.Moveid = Convert.ToInt32(nuMoveId.Value);
            mp.Level = Convert.ToInt32(nuLevel.Value);
            mp.Pokemonid = Convert.ToInt32(nuPokemonId.Value);
            Tools.AddGivenClass("../../../CyanDataTransactions/Data/MovePokemons.xml", mp);
            SuccesfullySaved();
        }
        private void btnAddPokemon_Click(object sender, EventArgs e)
        {
            PokemonBase pb = new PokemonBase();
            pb.PokemonBaseName = txtPokemonName.Text;
            pb.APL = Con(nuAPL);
            pb.BA = Con(nuBA);
            pb.BD = Con(nuBD);
            pb.BE = Con(nuBE);
            pb.BH = Con(nuBH);
            pb.DPL = Con(nuDPL);
            pb.EPL = Con(nuEPL);
            pb.EvolveLevel = Con(nuEvolveLevel);
            pb.EvolveToPokemonid = Con(nuEvolveId);
            pb.HPL = Con(nuHPL);
            pb.PrimaryTypeid = Con(nuPrimaryTypeId);
            pb.SecondaryTypeid = Con(nuSecondaryTypeId);
            pb.XPGroupid = Con(nuExperienceGroupId);
            pb.imageFrontString = btnSetFrontImage.Tag as string;
            pb.imageBackString = btnBackImage.Tag as string;
            Tools.AddGivenClass("../../../CyanDataTransactions/Data/PokemonBases.xml", pb);
            SuccesfullySaved();

        }
        private void btnSetFrontImage_Click(object sender, EventArgs e)
        {
            SetImageAsTag(btnSetFrontImage);
        }
        private void btnBackImage_Click(object sender, EventArgs e)
        {
            SetImageAsTag(btnBackImage);
        }
        private void SetImageAsTag(Button btn)
        {
            OpenFileDialog od = new OpenFileDialog();
            DialogResult dr = od.ShowDialog();
            if (dr == System.Windows.Forms.DialogResult.OK)
            {
                try
                {
                    string image = MappingTools.ImageToBase64(Image.FromFile(od.FileName), System.Drawing.Imaging.ImageFormat.Png);
                    btn.Tag = image;
                }
                catch
                {

                    MessageBox.Show("Image could not be loaded...");
                }
            }
        }
        private int Con(NumericUpDown nu)
        {
            return Convert.ToInt32(nu.Value);
        }
        void SuccesfullySaved()
        { MessageBox.Show("Data is succesfully saved!"); }

    }
}
