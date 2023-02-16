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
        public Warrior(string name) : base(name)
        {
            LevelAttributes = new HeroAttribute(5, 2, 1);
            TotalAttributes = new HeroAttribute(5, 2, 1);
            ValidWeaponTypes = new List<WeaponTypes>() { WeaponTypes.Axe, WeaponTypes.Hammer, WeaponTypes.Sword };
            ValidArmorTypes = new List<ArmorTypes>() { ArmorTypes.Mail, ArmorTypes.Plate };
        }
        protected override void IncreaseLevelAttributes()
        {
            LevelAttributes.IncreaseStrength(3);
            LevelAttributes.IncreaseDexterity(2);
            LevelAttributes.IncreaseIntelligence(1);
        }
    }
}
