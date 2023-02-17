using ConsoleRPG.CustomException;
using ConsoleRPG.Enumerators;
using ConsoleRPG.Hero.HeroClasses;
using ConsoleRPG.Hero.Items;
using ConsoleRPG.Hero;
using System.ComponentModel.DataAnnotations;

namespace ConsoleRPG
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Main program to run the application, added some dummy code
            Mage mage = new Mage("Khadgar");
            Weapon Atiesh = new Weapon("Atiesh", 1, ArmorSlots.Weapon, WeaponTypes.Staff, 50);
            Armor AncestralTop = new Armor("Ancestral Top", 1, ArmorSlots.Body, ArmorTypes.Cloth, new HeroAttribute(1, 1, 10));
            Armor AncestralHat = new Armor("Ancestral Hat", 1, ArmorSlots.Head, ArmorTypes.Cloth, new HeroAttribute(1, 1, 10));
            Armor AncestralLegs = new Armor("Ancestral Legs", 1, ArmorSlots.Legs, ArmorTypes.Cloth, new HeroAttribute(1, 1, 10));
            Console.WriteLine(mage.Display());
            mage.Equip(Atiesh);
            mage.Equip(AncestralTop);
            mage.Equip(AncestralHat);
            mage.Equip(AncestralLegs);
            Console.WriteLine("Display after Equipped items \n");
            mage.PrintEquippedItems();
            Console.WriteLine(mage.Display());
            Console.WriteLine(" ");
            mage.LevelUp();
            mage.LevelUp();
            mage.LevelUp();
            mage.LevelUp();
            Console.WriteLine("Display after Equipped and levelUp to lvl 5: ");
            Console.WriteLine(mage.Display());


        }
    }
}