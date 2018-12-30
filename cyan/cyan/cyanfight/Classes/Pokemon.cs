using CyanDataTransactions.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace CyanFight.Classes
{
    public class Pokemon
    {
        public string PokemonName { get; set; }
        public int PokemonBaseId { get; set; }
        public int Experience { get; set; }
        public int Health
        {
            get
            {
                return PokemonBase().BH + (PokemonBase().HPL * Level());
            }
        }
        public int Energy
        {
            get
            {
                return PokemonBase().BE + (PokemonBase().EPL * Level());
            }
        }
        public int Attack
        {
            get
            {
                return PokemonBase().BA + (PokemonBase().APL * Level());
            }
        }
        public int Defense
        {
            get
            {
                return PokemonBase().BD + (PokemonBase().DPL * Level());
            }
        }
        public int Level()
        {
            return CalcLevel(1, Experience, 40);
        }
        private int CalcLevel(int currentLevel, int remainingExp, int lastestRequiredExp)
        {
            int requiredExp = lastestRequiredExp * (21 / 20);
            if (requiredExp <= remainingExp)
            {
                return CalcLevel(currentLevel + 1, remainingExp - requiredExp, requiredExp);
            }
            else
            { return currentLevel; }
        }
        public List<Button> Moves()
        {
            List<Button> moves = new List<Button>();
            foreach (MovePokemon mp in CyanDataTransactions.Classes.Tools.ReadAllClassesFromFile("MovePokemons", Activator.CreateInstance(typeof(MovePokemon)), "MovePokemons"))
            {
                if (mp.Pokemonid == PokemonBase().id && mp.Level <= Level())
                {
                    PokemonMove pm = new PokemonMove();
                    pm = (PokemonMove)CyanDataTransactions.Classes.Tools.FindTypeById("PokemonMoves", pm, mp.Moveid);

                    Button btn = new Button();
                    btn.Margin = new Padding(0);
                    btn.Tag = pm;
                    btn.Text = pm.Name;
                    moves.Add(btn);
                }
            }
            return moves;
        }
        public PokemonBase PokemonBase()
        {
            PokemonBase pb = new PokemonBase();
            return (PokemonBase)CyanDataTransactions.Classes.Tools.FindTypeById("PokemonBases", pb, PokemonBaseId);
        }
        public Image BackImage { get { return PokemonBase().BackImage(); } }
        public Image FrontImage { get { return PokemonBase().FrontImage(); } }
    }
}
