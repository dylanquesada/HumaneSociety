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
        public static DateTime GetDateInput()
        {
            DateTime dateTime;
            while (!DateTime.TryParse(Console.ReadLine(), out dateTime))
            {
                Console.WriteLine("Please enter a Date. ex: (mm/dd/yyyy)");
            }            
            return dateTime;
        }
        public static void DisplayAnimal(Animal animal)
        {
            Console.WriteLine("Animal name = {0}", animal.PetName);
            Console.WriteLine("Animal type = {0}", animal.AnimalType);
            Console.WriteLine("AnimalID = {0}", animal.ID);
            Console.WriteLine("Animal size = {0}", animal.Size);
            Console.WriteLine("Animal gender = {0}", animal.Gender);
            Console.WriteLine("Animal vaccine shots = {0}", animal.VaccineStatus);
            Console.WriteLine("Animal adoption status = {0}", animal.AdoptionStatus);
        }
    }
}
