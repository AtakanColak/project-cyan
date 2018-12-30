using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CyanDataTransactions.Classes
{
    public class PokemonMove
    {
        public int id { get; set; }
        public string Name { get; set; }
        public int Typeid { get; set; }
        public int Power { get; set; }
        public int Accuracy { get; set; }
        public int Cost { get; set; }

        public PokemonType PokemonType() 
        {
            PokemonType pt = new PokemonType();
            return (PokemonType)Tools.FindTypeById("PokemonTypes", pt, Typeid);
        }
    }
}
