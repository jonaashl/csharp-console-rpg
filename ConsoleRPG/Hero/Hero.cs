using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleRPG;
using ConsoleRPG.CustomException;
using ConsoleRPG.Enumerators;
using ConsoleRPG.Hero.HeroClasses;
using ConsoleRPG.Hero.Items;

namespace ConsoleRPG.Hero
{
    public abstract class Hero
    {
        public string Name { get; set; }
        public int Level { get; set; }
        public HeroAttribute LevelAttributes { get; set; }
        public HeroAttribute TotalAttributes { get; set; }
        public List<WeaponTypes> ValidWeaponTypes { get; set; }
        public List<ArmorTypes> ValidArmorTypes { get; set; }
        public Dictionary<ArmorSlots, Item> Equipment { get; set; }

        //Hero name constructor
        public Hero(string name)
        {
            Name = name;
            Level = 1;
            Equipment = new Dictionary<ArmorSlots, Item>();
        }

        // does this work??
        public void LevelUp()
        {
            Level++;
            IncreaseLevelAttributes();

        }
        protected abstract void IncreaseLevelAttributes();

        public void Equip(Weapon weapon)
        {
            if (Level < weapon.RequiredLevel) 
            {
                throw new InvalidWeaponException("You cannot equip this Weapon");
            }
            if (!ValidWeaponTypes.Contains(weapon.WeaponType))
            {
                throw new InvalidWeaponException("Weapon is of wrong type");
            }
            Equipment[weapon.ItemSlot] = weapon;

        }
        public void Equip(Armor armor)
        {
            if (!ValidArmorTypes.Contains(armor.ArmorType))
            {
                throw new InvalidArmorException("You cannot equip this armor type");
            }

            if (Level < armor.RequiredLevel)
            {
                throw new InvalidArmorException("You are not high enough level");
            }
            Equipment[armor.ItemSlot] = armor;

        }
        public int Damage()
        {
            int weaponDamage = 0;
            if (Equipment.ContainsKey(ArmorSlots.Weapon) && Equipment[ArmorSlots.Weapon] != null && Equipment[ArmorSlots.Weapon] is Weapon weapon)
            {
                weaponDamage = weapon.WeaponDamage;
            }
            else
            {
                weaponDamage = 1;
            }

            int damagingAttribute = 0;

            switch (this)
            {
                case Warrior:
                    damagingAttribute = TotalAttributes.Strength;
                    break;
                case Mage:
                    damagingAttribute = TotalAttributes.Intelligence;
                    break;
                case Ranger:
                case Rogue:
                    damagingAttribute = TotalAttributes.Dexterity;
                    break;
                default:
                    break;
            }

            return (int)weaponDamage * (1 + damagingAttribute / 100);
        }



        public HeroAttribute GetTotalAttributes()
        {
            HeroAttribute TotalAttributes = LevelAttributes;
            foreach(var equipment in Equipment)
            {
                if (equipment.Key != ArmorSlots.Weapon)
                {
                    if (equipment.Value is Armor armor)
                    {
                        TotalAttributes += armor.ArmorAttribute;
                    }
                }
            }
            return TotalAttributes;


        }

        public virtual string Display()
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("Name: ").Append(Name).AppendLine();
            builder.Append("Class: ").Append(GetType().Name).AppendLine();
            builder.Append("Level: ").Append(Level).AppendLine();
            builder.Append("Total Strength: ").Append(TotalAttributes.Strength).AppendLine();
            builder.Append("Total Dexterity: ").Append(TotalAttributes.Dexterity).AppendLine();
            builder.Append("Total Intelligence: ").Append(TotalAttributes.Intelligence).AppendLine();
            builder.Append("Damage: ").Append(Damage()).AppendLine();
            return builder.ToString();
        }

    }
}
