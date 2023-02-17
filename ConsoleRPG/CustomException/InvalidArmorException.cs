using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleRPG.CustomException
{
    public class InvalidArmorException : Exception
    {
        // Custom exception

        public InvalidArmorException(string? message) : base(message)
        {

        }
    }
}
