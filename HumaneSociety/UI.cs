using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HumaneSociety
{
    class UI
    {
        public static int GetIntInput()
        {
            int result;
            while (!int.TryParse(Console.ReadLine(), out result))
            {
                Console.WriteLine("Please enter a number.");
            }
            return result;      
        }
        public static string GetStringInput()
        {
            string value;
            value = Console.ReadLine().ToString();
            return value;
        }
    }
}
