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
        public int Strength { get; set; }
        public int Dexterity { get; set; }
        public int Intelligence { get; set; }
        
        // Constructor
        public HeroAttribute(int strength, int dexterity, int intelligence)
        {
            Strength = strength;
            Dexterity = dexterity;
            Intelligence = intelligence;
        }

        // Methods to increment the attributes of a hero
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

        // overload plus operator to be able to add to instances of an object
        public static HeroAttribute operator +(HeroAttribute attr1, HeroAttribute attr2)
        {
            return new HeroAttribute(
                attr1.Strength + attr2.Strength,
                attr1.Dexterity + attr2.Dexterity,
                attr1.Intelligence + attr2.Intelligence);
        }
    }
}
