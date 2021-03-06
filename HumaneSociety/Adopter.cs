﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HumaneSociety
{
    class Adopter
    {
        // Member variables
        public Person person;
        // Constructor
        public Adopter()
        {
            person = new Person();
            person.FirstName = GetFirstName();
            person.LastName = GetLastName();
            person.DateOfBirth = GetBirthDate();
            person.GoodWithPets = DetermineAdopterEligibility();
            person.Gender = getGender();
        }
        // member methods
        public string GetFirstName()
        {
            Console.WriteLine("Enter your first name: ");
            return UI.GetStringInput();
        }
        public string GetLastName()
        {
            Console.WriteLine("Enter your last name: ");
            return UI.GetStringInput();
        }
        public DateTime GetBirthDate()
        {
            Console.WriteLine("Enter your birthdate: ex. (mm/dd/yyyy)");
            return UI.GetDateInput();
        }
        public string DetermineAdopterEligibility()
        {
            Console.WriteLine("Are you good with pets? yes or no? Don't be specific.");
            return UI.GetStringInput();
        }
        public string getGender()
        {
            Console.WriteLine("How do you identify? (Gender)");
            return UI.GetStringInput();
        }

    }
}
