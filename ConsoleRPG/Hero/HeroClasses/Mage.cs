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
        // Constructor. Sets Level and total attributes on creatiion, also defines what armor and weapontypes this class can use.
        public Mage(string name) : base(name)
        {
            LevelAttributes = new HeroAttribute(1, 1, 8);
            TotalAttributes = new HeroAttribute(1, 1, 8);
            ValidWeaponTypes = new List<WeaponTypes>() { WeaponTypes.Wand, WeaponTypes.Staff };
            ValidArmorTypes = new List<ArmorTypes>() { ArmorTypes.Cloth };
        }

        //overrides the abstract method in the Hero class
        protected override void IncreaseLevelAttributes()
        {
            LevelAttributes.IncreaseStrength(1);
            LevelAttributes.IncreaseDexterity(1);
            LevelAttributes.IncreaseIntelligence(5);
        }
    }

}
