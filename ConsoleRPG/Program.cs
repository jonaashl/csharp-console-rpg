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
            Mage Jonas = new Mage("Jonas");
            Weapon CritStick = new Weapon("CritStick", 1, ArmorSlots.Weapon, WeaponTypes.Staff, 10);
            Armor AncestralTop = new Armor("Ancestral Top", 1, ArmorSlots.Body, ArmorTypes.Cloth, new HeroAttribute(1,1,2));
            Armor AncestralHat = new Armor("Ancestral Hat", 1, ArmorSlots.Head, ArmorTypes.Cloth, new HeroAttribute(1, 1, 2));
            Armor AncestralLegs = new Armor("Ancestral Legs", 1, ArmorSlots.Legs, ArmorTypes.Cloth, new HeroAttribute(1, 1, 2));
            Console.WriteLine(Jonas.Display());
            Jonas.PrintEquippedItems();
            Jonas.Equip(CritStick);
            Jonas.Equip(AncestralTop);
            Jonas.Equip(AncestralHat);
            Jonas.Equip(AncestralLegs);
            Jonas.PrintEquippedItems();
            Console.WriteLine(" ");
            Jonas.LevelUp();
            Jonas.LevelUp();
            Jonas.LevelUp();
            Jonas.LevelUp();
            Console.WriteLine(Jonas.Display());
            Warrior warrior = new Warrior("Garrosh");
            Console.WriteLine(warrior.Display());
            warrior.LevelUp();
            Console.WriteLine(warrior.Display());


        }
    }
}