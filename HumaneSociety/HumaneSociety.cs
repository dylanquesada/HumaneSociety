using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HumaneSociety
{
    class HumaneSociety
    {
        // Member variables

        // Constructor
        public HumaneSociety()
        {

        }

        // Member methods
        public void RunHumaneSociety()
        {
            string option;
            bool done = false;
            while (!done)
            {
                Console.WriteLine("What would you like to do? 'Find' an animal, set an animal for 'adoption', collect a 'payment', 'vaccinate' an animal, ");
                option = Console.ReadLine().ToLower();
                switch (option)
                {
                    case "find":
                        break;
                    case "adoption":
                        break;
                    case "payment":
                        break;
                    case "vaccinate":
                        break;
                    case "done":
                        done = true;
                        break;
                    default:
                        Console.WriteLine("Sorry, {0} is not a valid entry. Try Again.", option);
                        break;
                }
            }
        }
        public Animal AddAnimal()
        {
            Animal animal = new Animal();

            return animal;
        }
    }
}
