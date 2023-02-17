using ConsoleRPG.Enumerators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleRPG.Hero.Items
{
    public class Armor : Item
    {
        // Props

        public ArmorTypes ArmorType { get; set; }
        public HeroAttribute ArmorAttribute { get; set; }

        // Constructor
        public Armor(string name, int requiredLevel, ArmorSlots ItemSlot,  ArmorTypes armorType, HeroAttribute armorAttribute) : base(name, requiredLevel, ItemSlot)
        {
            ArmorType = armorType;
            ArmorAttribute = armorAttribute;
        }
    }
}
