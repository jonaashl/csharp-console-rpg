using ConsoleRPG.CustomException;
using System.ComponentModel.DataAnnotations;

namespace ConsoleRPG
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            try
            {

            }
            catch(InvalidWeaponException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public static void TestException(bool throwException)
        {
            if(throwException)
            {
                throw new InvalidWeaponException("Custom logic resultet in an error");

            }
        }
    }
}