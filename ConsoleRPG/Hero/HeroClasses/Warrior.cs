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
            ValidWeaponTypes = new List<string>() { "Axe", "Hammer", "Sword" };
            ValidArmorTypes = new List<string>() { "Mail", "Plate" };
        }
        public override void SetValidArmorTypes()
        {
            throw new NotImplementedException();
        }

        public override void SetValidWeaponTypes()
        {
            throw new NotImplementedException();
        }
        protected override void IncreaseLevelAttributes()
        {
            LevelAttributes.IncreaseStrength(3);
            LevelAttributes.IncreaseDexterity(2);
            LevelAttributes.IncreaseIntelligence(1);
        }
    }
}
