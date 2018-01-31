using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HumaneSociety
{
    class Adopter
    {
        // Member variables
        
        // Constructor
        public Adopter()
        {

        }
        // member methods
        public string GetFirstName()
        {
            Console.WriteLine("Enter your first name: ");
            return UI.GetStringInput();
        }
    }
}
