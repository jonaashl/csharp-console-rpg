using ConsoleRPG.Enumerators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleRPG.Hero.HeroClasses
{
    public class Ranger : Hero
    {
        // Constructor. Sets Level and total attributes on creatiion, also defines what armor and weapontypes this class can use.

        public Ranger(string name) : base(name)
        {
            LevelAttributes = new HeroAttribute(1, 7, 1);
            TotalAttributes = new HeroAttribute(1, 7, 1);
            ValidWeaponTypes = new List<WeaponTypes>() { WeaponTypes.Bow };
            ValidArmorTypes = new List<ArmorTypes>() { ArmorTypes.Mail, ArmorTypes.Leather };
        }

        //overrides the abstract method in the Hero class
        protected override void IncreaseLevelAttributes()
        {
            LevelAttributes.IncreaseStrength(1);
            LevelAttributes.IncreaseDexterity(5);
            LevelAttributes.IncreaseIntelligence(1);
        }
    }
}
