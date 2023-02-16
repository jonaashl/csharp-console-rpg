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
            Weapon CritStick = new Weapon("CritStick", 1, ArmorSlots.Weapon, WeaponTypes.Staff, 5);
            Armor AncestralTop = new Armor("Ancestral Top", 1, ArmorSlots.Body, ArmorTypes.Cloth, new HeroAttribute(2,2,2));
            Console.WriteLine(Jonas.Display());
        }
    }
}