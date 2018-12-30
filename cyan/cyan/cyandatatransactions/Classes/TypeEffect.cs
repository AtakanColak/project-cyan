using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CyanDataTransactions.Classes
{
    public class TypeEffect
    {
        public int AttackerPokemonTypeid { get; set; }
        public int DefenderPokemonTypeid { get; set; }
        public int Factor { get; set; }

        public PokemonType AttackerPokemonType() 
        {
            PokemonType pt = new PokemonType();
            return (PokemonType)Tools.FindTypeById("PokemonTypes", pt, AttackerPokemonTypeid);
        }
        public PokemonType DefenderPokemonType() 
        {
            PokemonType pt = new PokemonType();
            return (PokemonType)Tools.FindTypeById("PokemonTypes", pt, DefenderPokemonTypeid);
        }
        
    }
}
