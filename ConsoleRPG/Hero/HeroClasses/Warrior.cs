using ConsoleRPG.Enumerators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleRPG.Hero.HeroClasses
{
    public class Warrior : Hero
    {
        // Constructor. Sets Level and total attributes on creatiion, also defines what armor and weapontypes this class can use.

        public Warrior(string name) : base(name)
        {
            LevelAttributes = new HeroAttribute(5, 2, 1);
            TotalAttributes = new HeroAttribute(5, 2, 1);
            ValidWeaponTypes = new List<WeaponTypes>() { WeaponTypes.Axe, WeaponTypes.Hammer, WeaponTypes.Sword };
            ValidArmorTypes = new List<ArmorTypes>() { ArmorTypes.Mail, ArmorTypes.Plate };
        }

        //overrides the abstract method in the Hero class
        protected override void IncreaseLevelAttributes()
        {
            LevelAttributes.IncreaseStrength(3);
            LevelAttributes.IncreaseDexterity(2);
            LevelAttributes.IncreaseIntelligence(1);
        }
    }
}
