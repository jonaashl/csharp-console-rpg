using ConsoleRPG.Enumerators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleRPG.Hero.Items
{
    public class Weapon : Item
    {
        // Props
        public WeaponTypes WeaponType { get; set; }
        public int WeaponDamage { get; set; }

        // Constructor
        public Weapon(string name, int requiredLevel, ArmorSlots ItemSlot, WeaponTypes weaponType, int weaponDamage)
            : base(name, requiredLevel, ItemSlot)
        {
            WeaponType = weaponType;
            WeaponDamage = weaponDamage;
        }
    }

}
