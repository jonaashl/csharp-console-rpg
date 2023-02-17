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
        public List<WeaponTypes> ValidWeaponTypes { get; set; } = new List<WeaponTypes>();
        public List<ArmorTypes> ValidArmorTypes { get; set; } = new List<ArmorTypes>();
        public Dictionary<ArmorSlots, Item> Equipment { get; set; }

        //Hero constructor
        public Hero(string name)
        {
            Name = name;
            Level = 1;
            TotalAttributes = new HeroAttribute(0, 0, 0);
            Equipment = new Dictionary<ArmorSlots, Item>()
            {
                { ArmorSlots.Head, null },
                { ArmorSlots.Body, null },
                { ArmorSlots.Legs, null },
                { ArmorSlots.Weapon, null }
            };
        }

        /// <summary>
        /// LevelUp function which also calls 2 other functions on levelUp.
        /// Increases HeroAttributes LevelingAttributes, before it calls UpdateAttributes which calculate totalAttributes
        /// </summary>
        public void LevelUp()
        {
            Level = Level + 1;
            IncreaseLevelAttributes();
            UpdateAttributes();

        }
        // Abstract method that is being overridden in the Subclasses depending on how their Attributes increase
        protected abstract void IncreaseLevelAttributes();

        // Method that prints the items a Hero has equipped, mostly just for my own sake to see if stuff worked.
        public void PrintEquippedItems()
        {
            foreach (var kvp in Equipment)
            {
                if (kvp.Value != null)
                {
                    Console.WriteLine($"{kvp.Key}: {kvp.Value.Name}");
                }
            }
        }

        /// <summary>
        /// Method Equip takes in a weapon as parameter, it checks if the weapon is equippable based on level and type.
        /// If it is not equippable it throws a custom error. else; Equip the weapon
        /// </summary>
        /// <param name="weapon"></param>
        /// <exception cref="InvalidWeaponException"></exception>
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
            // Also added a check for if a weapon is equipped. if a weapon is equipped, replace the weapon.
            if (Equipment.ContainsKey(ArmorSlots.Weapon) && Equipment[weapon.ItemSlot] is Weapon)
            {
                Weapon equippedWeapon = (Weapon)Equipment[ArmorSlots.Weapon];
                equippedWeapon.WeaponDamage = weapon.WeaponDamage;
            }

            Equipment[weapon.ItemSlot] = weapon;
            UpdateAttributes();
        }

        /// <summary>
        /// Method equip takes in armor as a parameter, it checks if the armor is equippable based on required level and armorType.
        /// if its not equippable, throw custom error. if it is equippable- Equip armor item.
        /// </summary>
        /// <param name="armor"></param>
        /// <exception cref="InvalidArmorException"></exception>
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
            // Also added a check for if an armor piece is equipped. if an armor piece is equipped, replace the armor piece.
            if (Equipment.ContainsKey(armor.ItemSlot) && Equipment[armor.ItemSlot] is Armor)
            {
                Armor equippedArmor = (Armor)Equipment[armor.ItemSlot];
                equippedArmor.ArmorAttribute = armor.ArmorAttribute;
            }
            else
            {
                Equipment[armor.ItemSlot] = armor;
            }
            UpdateAttributes();
        }

        /// <summary>
        /// Damage function to calculate damage. Checks if weapon is equipped, sets weaponDamage to the weapons Damage.
        /// If no weapon damage, set weaponDamage to 1
        /// a subclass' mainstat is also their damagingAttribute, made a switch statement based on what class is calling the damage method.
        /// then returns the damage.
        /// </summary>
        /// <returns></returns>
        public double Damage()
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

            return (int)weaponDamage * (1 + damagingAttribute / 100.0);
        }

        // Small method to update the totalAttributes of a Hero. This function adds Level and Armor attributes to the TotalAttributes variable.
        public void UpdateAttributes()
        {
            TotalAttributes = new HeroAttribute(0, 0, 0);
            TotalAttributes += LevelAttributes;
            foreach (KeyValuePair<ArmorSlots, Item> item in Equipment)
            {
                if (item.Key != ArmorSlots.Weapon && item.Value != null && item.Value is Armor)
                {
                    Armor armor = (Armor)item.Value;
                    TotalAttributes += armor.ArmorAttribute;
                }
            }
        }

        // Displays the Hero using a string builder
        public virtual string Display()
        {
            UpdateAttributes();
            StringBuilder builder = new StringBuilder();
            builder.Append("Name: ").Append(Name).AppendLine();
            builder.Append("Class: ").Append(GetType().Name).AppendLine();
            builder.Append("Level: ").Append(Level).AppendLine();
            builder.Append("Strength from levels: ").Append(LevelAttributes.Strength).AppendLine();
            builder.Append("Dexterity from levels: ").Append(LevelAttributes.Dexterity).AppendLine();
            builder.Append("Intelligence from levels: ").Append(LevelAttributes.Intelligence).AppendLine();

            builder.Append("Total Strength: ").Append(TotalAttributes.Strength).AppendLine();
            builder.Append("Total Dexterity: ").Append(TotalAttributes.Dexterity).AppendLine();
            builder.Append("Total Intelligence: ").Append(TotalAttributes.Intelligence).AppendLine();
            builder.Append("Damage: ").Append(Damage()).AppendLine();
            return builder.ToString();
        }

    }
}
