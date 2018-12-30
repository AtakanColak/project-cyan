using CyanDataTransactions.Classes;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CyanFight.Classes
{
    public class Tools
    {
        public static int CalculateAttackDamage(PokemonMove pm, Pokemon attacker,Pokemon defender)
        {
            IList list = CyanDataTransactions.Classes.Tools.ReadAllClassesFromFile("../../Data/TypeEffects.xml", Activator.CreateInstance(typeof(TypeEffect)), "TypeEffects");
            TypeEffect te = new TypeEffect();
            foreach (var item in list)
            {
                TypeEffect effect = (TypeEffect)item;
                if (effect.AttackerPokemonTypeid == pm.PokemonType().id && effect.DefenderPokemonTypeid == defender.PokemonBase().PrimaryPokemonType().id)
                {
                    te = effect;
                }
            }                        
            int factor = 0;
            switch (te.Factor)
            {
                case 0:
                    factor = 100;
                    break;
                case 1:
                    factor = 50;
                    break;
                case 2:
                    factor = 200;
                    break;
                case 3:
                    factor = 0;
                    break;
            }
            int damageBeforeCalc = (pm.Power * attacker.Attack*factor)/10000;
            int damageAfterCalc = (damageBeforeCalc * 100) / (100 + defender.Defense);
            return damageAfterCalc;
        }
    }
}
