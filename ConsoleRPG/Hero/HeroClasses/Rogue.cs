using ConsoleRPG.Enumerators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleRPG.Hero.HeroClasses
{
    public class Rogue : Hero
    {
        public Rogue(string name) : base(name)
        {
            LevelAttributes = new HeroAttribute(2, 6, 1);
            ValidWeaponTypes = new List<WeaponTypes>() { WeaponTypes.Dagger, WeaponTypes.Sword };
            ValidArmorTypes = new List<ArmorTypes>() { ArmorTypes.Mail, ArmorTypes.Leather };
        }

        protected override void IncreaseLevelAttributes()
        {
            LevelAttributes.IncreaseStrength(1);
            LevelAttributes.IncreaseDexterity(4);
            LevelAttributes.IncreaseIntelligence(1);
        }
    }
}
