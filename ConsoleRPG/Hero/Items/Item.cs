using ConsoleRPG.Enumerators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleRPG.Hero.Items
{
    public abstract class Item
    {
        public string Name { get; set; }
        public int RequiredLevel { get; }
        public ArmorSlots ItemSlot { get; private set; }

        public Item(string name, int requiredLevel, ArmorSlots ItemSlot)
        {
            Name = name;
            RequiredLevel = requiredLevel;
            this.ItemSlot = ItemSlot;
        }
        public abstract void EquipItem(Hero hero);

    }
}
