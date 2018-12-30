using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace CyanDataTransactions.Classes
{
    public class PokemonBase
    {
        public int id { get; set; }
        public string PokemonBaseName { get; set; }
        public int PrimaryTypeid { get; set; }
        public int SecondaryTypeid { get; set; }
        public int XPGroupid { get; set; }
        public int EvolveToPokemonid { get; set; }
        public int EvolveLevel { get; set; }
        public int BA { get; set; }
        public int BD { get; set; }
        public int BH { get; set; }
        public int BE { get; set; }
        public int APL { get; set; }
        public int DPL { get; set; }
        public int HPL { get; set; }
        public int EPL { get; set; }
        public string imageFrontString { get; set; }
        public string imageBackString { get; set; }

        public PokemonType PrimaryPokemonType()
        {
            PokemonType pt = new PokemonType();
            return (PokemonType)Tools.FindTypeById("PokemonTypes", pt, PrimaryTypeid);
        }
        public PokemonType SecondaryPokemonType()
        {
            PokemonType pt = new PokemonType();
            if (SecondaryTypeid != 0)
                return (PokemonType)Tools.FindTypeById("PokemonTypes", pt, SecondaryTypeid);
            else
                return (PokemonType)Tools.FindTypeById("PokemonTypes", pt, 0);
        }
        public ExperienceGroup ExGroup()
        {
            ExperienceGroup ex = new ExperienceGroup();
            return (ExperienceGroup)Tools.FindTypeById("ExperienceGroups", ex, XPGroupid);
        }
        public PokemonBase EvolvesTo()
        {
            PokemonBase pb = new PokemonBase();
            return (PokemonBase)Tools.FindTypeById("PokemonBases", pb, EvolveToPokemonid);
        }
        public Image FrontImage()
        {
            return CyanMapTools.MappingTools.Base64ToImage(imageFrontString);
        }
        public Image BackImage()
        {
            return CyanMapTools.MappingTools.Base64ToImage(imageBackString);
        }
    }
}
