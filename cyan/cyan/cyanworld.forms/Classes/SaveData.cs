using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CyanFight.Classes;
using CyanDataTransactions.Classes;

namespace CyanWorld.Forms.Classes
{
    public class SaveData
    {
        public string PokemonName { get; set; }
        public int Experience { get; set; }
        public int PokemonBaseId { get; set; }
        public void Save(string saveName)
        { 
            SaveData sd = new SaveData();
            sd = this;
            CyanDataTransactions.Classes.Tools.AddGivenClassWithDelete("../../../CyanWorld.Forms/Saves/" + saveName + ".xml", sd,true);
        }
        public static SaveData Load(string path)
        {
            SaveData sd = new SaveData();
            return (SaveData)CyanDataTransactions.Classes.Tools.ReadAllClassesFromFile(path, sd, path)[0];
        }
        public int MapId { get; set; }
        public int MapX { get; set; }
        public int MapY { get; set; }
        public Pokemon Pokemon()
        {
            Pokemon pk = new Pokemon();
            pk.PokemonName = PokemonName;
            pk.Experience = Experience;
            pk.PokemonBaseId = PokemonBaseId;
            return pk;
        }
    }
}
