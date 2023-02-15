using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleRPG.Hero
{
    public class HeroAttribute
    {
        public int Strength { get; private set; }
        public int Dexterity { get; private set; }
        public int Intelligence { get; private set; }

        public HeroAttribute(int strength, int dexterity, int intelligence)
        {
            Strength = strength;
            Dexterity = dexterity;
            Intelligence = intelligence;
        }
        public void IncreaseStrength(int amount)
        {
            Strength += amount;
        }

        public void IncreaseDexterity(int amount)
        {
            Dexterity += amount;
        }

        public void IncreaseIntelligence(int amount)
        {
            Intelligence += amount;
        }

        // Might not need this - overload plus
        public static HeroAttribute operator +(HeroAttribute attr1, HeroAttribute attr2)
        {
            return new HeroAttribute(
                attr1.Strength + attr2.Strength,
                attr1.Dexterity + attr2.Dexterity,
                attr1.Intelligence + attr2.Intelligence);
        }
    }
}
