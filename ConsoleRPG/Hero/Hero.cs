using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleRPG;

namespace ConsoleRPG.Hero
{
    public abstract class Hero
    {
        public string Name { get; set; }
        public int Level { get; set; }
        // ??? hvilken attribute og hvor kombinerer man osv???
        public HeroAttribute LevelAttributes { get; set; }
        public Dictionary<string, string> Equipment { get; set; }
        public List<string> ValidWeaponTypes { get; set; }
        public List<string> ValidArmorTypes { get; set; }

        //Hero name constructor
        public Hero(string name)
        {
            Name = name;
            Level = 1;
            Equipment = new Dictionary<string, string>();

        }
        // Potential rename to "hero" ? overloading/polymorphism
        public abstract void SetValidWeaponTypes();
        public abstract void SetValidArmorTypes();

        // does this work??
        public void LevelUp(int Level)
        {
            Level++;
            IncreaseLevelAttributes();
        }
        public void Equip(string itemType, string itemName)
        {
            if (itemType == "Weapon")
            {
                if (ValidWeaponTypes.Contains(itemName))
                {
                    Equipment["Weapon"] = itemName;
                }
                else
                {
                    Console.WriteLine("Invalid weapon type for this hero");
                }
            }
            else if (itemType == "Armor")
            {
                if (ValidArmorTypes.Contains(itemName))
                {
                    Equipment["Armor"] = itemName;
                }
                else
                {
                    Console.WriteLine("Invalid armor type for this hero");
                }
            }
            else
            {
                Console.WriteLine("Invalid item type");
            }
        }
        public int Damage()
        {
            int damage = 0;

            return damage;
        }

        protected abstract void IncreaseLevelAttributes();

        public void Display()
        {
            Console.WriteLine("Name: " + Name);
            Console.WriteLine("Level: " + Level);
            Console.WriteLine("Level attributes: " + LevelAttributes);
            Console.WriteLine("Equipment" + string.Join(", ", Equipment));
            Console.WriteLine("Valid Weapon types" + string.Join(", ", ValidWeaponTypes));
            Console.WriteLine("Valid armor types" + string.Join(", ", ValidArmorTypes));
        }
    }
}
