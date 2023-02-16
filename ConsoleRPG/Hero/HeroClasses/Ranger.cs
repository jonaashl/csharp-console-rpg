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
        public Ranger(string name) : base(name)
        {
            LevelAttributes = new HeroAttribute(1, 7, 1);
            ValidWeaponTypes = new List<WeaponTypes>() { WeaponTypes.Bow };
            ValidArmorTypes = new List<ArmorTypes>() { ArmorTypes.Mail, ArmorTypes.Leather };
        }

        protected override void IncreaseLevelAttributes()
        {
            LevelAttributes.IncreaseStrength(1);
            LevelAttributes.IncreaseDexterity(5);
            LevelAttributes.IncreaseIntelligence(1);
        }
    }
}
