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
        // Props

        public string Name { get; set; }
        public int RequiredLevel { get; }
        public ArmorSlots ItemSlot { get; set; }

        // Constructor
        public Item(string name, int requiredLevel, ArmorSlots ItemSlot)
        {
            this.Name = name;
            this.RequiredLevel = requiredLevel;
            this.ItemSlot = ItemSlot;
        }
    }
}
