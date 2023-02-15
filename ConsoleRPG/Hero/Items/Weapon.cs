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
        public WeaponTypes WeaponType { get; set; }
        public int WeaponDamage { get; set; }

        public Weapon(string name, int requiredLevel, ArmorSlots ItemSlot, WeaponTypes weaponType, int weaponDamage)
            : base(name, requiredLevel, ItemSlot)
        {
            WeaponType = weaponType;
            WeaponDamage = weaponDamage;
        }
    }

}
