using ConsoleRPG.Hero;
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
            ValidWeaponTypes = new List<string>() { "Wand", "Staff" };
            ValidArmorTypes = new List<string>() { "Cloth" };
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
            LevelAttributes.IncreaseDexterity(1);
            LevelAttributes.IncreaseIntelligence(5);
        }
    }

}
