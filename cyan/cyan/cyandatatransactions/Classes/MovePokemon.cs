using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CyanDataTransactions.Classes
{
    public class MovePokemon
    {
        public int Pokemonid { get; set; }
        public int Moveid { get; set; }
        public int Level { get; set; }

        public PokemonBase PokemonBase()
        {
            return (PokemonBase)Tools.FindTypeById("PokemonBases", Activator.CreateInstance(typeof(PokemonBase)), Pokemonid);
        }
        public PokemonMove Move()
        {
            PokemonMove pm = new PokemonMove();
            return (PokemonMove)Tools.FindTypeById("PokemonMoves", pm, Moveid);
        }
    }
}
