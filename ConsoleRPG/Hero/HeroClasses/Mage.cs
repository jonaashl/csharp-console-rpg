using ConsoleRPG.Enumerators;
using ConsoleRPG.Hero;
using ConsoleRPG.Hero.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;


namespace ConsoleRPG.Hero.HeroClasses
{
    public class Mage : Hero
    {
        public Mage(string name) : base(name)
        {
            LevelAttributes = new HeroAttribute(1, 1, 8);
            ValidWeaponTypes = new List<WeaponTypes>() { WeaponTypes.Wand, WeaponTypes.Staff };
            ValidArmorTypes = new List<ArmorTypes>() { ArmorTypes.Cloth };
        }

        protected override void IncreaseLevelAttributes()
        {
            LevelAttributes.IncreaseStrength(1);
            LevelAttributes.IncreaseDexterity(1);
            LevelAttributes.IncreaseIntelligence(5);
        }
    }

}
