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
            ValidWeaponTypes = new List<string>() { "Dagger", "Sword"};
            ValidArmorTypes = new List<string>() { "Mail", "Leather" };
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
            LevelAttributes.IncreaseStrength(1);
            LevelAttributes.IncreaseDexterity(4);
            LevelAttributes.IncreaseIntelligence(1);
        }
    }
}
