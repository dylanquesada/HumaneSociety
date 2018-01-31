using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HumaneSociety
{
    class HumaneSociety
    {
        //Member variables
        HumaneSocietyDB db;
        HumaneSocietyBankBox bb;
        int IntrinsicValueOfAnimals;
        //Constructor
        public HumaneSociety()
        {
            IntrinsicValueOfAnimals = 100;
            db = new HumaneSocietyDB();
            bb = new HumaneSocietyBankBox();
        }

        //Member methods
        public void SelectUser()
        {
            Console.WriteLine("Welcome to the Humane Society Console Application!");
            while (true)
            {                
                Console.WriteLine("Enter '1' for Employee '2' for Adopter.");
                switch (UI.GetIntInput())
                {
                    case 1:
                        RunEmployeeHumaneSociety();
                        return;
                    case 2:
                        RunAdopterHumaneSociety();
                        return;
                    default:
                        Console.WriteLine("Please enter either '1' or '2'.");
                        break;
                }
            }

        }
        public void RunAdopterHumaneSociety()
       { 
            HumaneSocietyDB db = new HumaneSocietyDB();
            string option;
            bool done = false;
            while (!done)
            {
                Console.WriteLine("What would you like to do? 'Find' an animal, Fill out 'Adopter' profile, 'Pay' for animal, or 'exit'");
                option = Console.ReadLine().ToLower();
                switch (option)
                {
                    case "find":

                        break;
                    case "adopter":
                        Adopter adopter = new Adopter();
                        db.People.Add(adopter.person);
                        db.SaveChanges();
                        break;
                    case "pay":
                        PayForAnimal();
                        break;                    
                    case "exit":
                        done = true;
                        break;
                    default:
                        Console.WriteLine("Sorry, '{0}' is not a valid entry. Try Again.", option);
                        break;
                }
            }
        }
        public void RunEmployeeHumaneSociety()
        {
            HumaneSocietyDB db = new HumaneSocietyDB();
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
                        ChangeAdoptionStatus(db);
                        break;
                    case "payment":
                        PayForAnimal();
                        break;
                    case "vaccinate":
                        break;
                    case "done":
                        done = true;
                        break;
                    case "add":
                        db.Animals.Add(AddAnimal());
                        db.SaveChanges();

                        break;
                    default:
                        Console.WriteLine("Sorry, '{0}' is not a valid entry. Try Again.", option);
                        break;
                }
            }
        }

        public void ChangeAdoptionStatus(HumaneSocietyDB db)
        {
            Console.WriteLine("What is the AnimalID of the Animal being adopted?");
            int input = UI.GetIntInput();
                Animal animal = db.Animals.Single(n => n.ID == input);
                animal.AdoptionStatus = "adopted";
                db.SaveChanges();
           
                //Console.WriteLine("Sorry, that is an invalid AnimalID. Try Again.");
                //ChangeAdoptionStatus(db);
            
                    
        }
        public void PayForAnimal()
        {
            Console.WriteLine("Payment processing...");
            bb.AcceptMoney(IntrinsicValueOfAnimals);
            Console.WriteLine("Payment processed.");
        }
        public Animal AddAnimal()
        {
            Animal animal = new Animal();
            animal.SetName(animal);
            animal.SetType(animal);
            animal.SetBirthDate(animal);
            animal.SetSize(animal);
            animal.SetGender(animal);
            animal.SetVaccineStatus(animal);
            animal.SetFoodType(animal);
            animal.SetFoodAmount(animal);
            animal.SetAdoptionStatus(animal);
            animal.SetRoom(animal);
            return animal;
        }
        public List<Animal> SearchByName(string input)
        {
            var animals = new HumaneSocietyDB().Animals;
            
            List<Animal> list = new List<Animal>();
            var result = animals.Where(n => n.PetName.ToLower() == input.ToLower());
            foreach(var animal in result)
            {
                list.Add(animal);
            }
            return list;
        }
        public List<Animal> SearchByType(string input)
        {
            var animals = new HumaneSocietyDB().Animals;

            List<Animal> list = new List<Animal>();
            var result = animals.Where(n => n.AnimalType.ToLower() == input.ToLower());
            foreach (var animal in result)
            {
                list.Add(animal);
            }
            return list;
        }
        public List<Animal> SearchByBirthDate(DateTime input)
        {
            var animals = new HumaneSocietyDB().Animals;

            List<Animal> list = new List<Animal>();
            var result = animals.Where(n => n.BirthDate == input);
            foreach (var animal in result)
            {
                list.Add(animal);
            }
            return list;
        }

        public List<Animal> SearchBySize(string input)
        {
            var animals = new HumaneSocietyDB().Animals;

            List<Animal> list = new List<Animal>();
            var result = animals.Where(n => n.Size.ToLower() == input.ToLower());
            foreach (var animal in result)
            {
                list.Add(animal);
            }
            return list;
        }

        public List<Animal> SearchByGender(string input)
        {
            var animals = new HumaneSocietyDB().Animals;

            List<Animal> list = new List<Animal>();
            var result = animals.Where(n => n.Gender.ToLower() == input.ToLower());
            foreach (var animal in result)
            {
                list.Add(animal);
            }
            return list;
        }

        public List<Animal> SearchByVaccineStatus(string input)
        {
            var animals = new HumaneSocietyDB().Animals;

            List<Animal> list = new List<Animal>();
            var result = animals.Where(n => n.VaccineStatus.ToLower() == input.ToLower());
            foreach (var animal in result)
            {
                list.Add(animal);
            }
            return list;
        }

        public List<Animal> SearchByAdoptionStatus(string input)
        {
            var animals = new HumaneSocietyDB().Animals;

            List<Animal> list = new List<Animal>();
            var result = animals.Where(n => n.AdoptionStatus.ToLower() == input.ToLower());
            foreach (var animal in result)
            {
                list.Add(animal);
            }
            return list;
        }
    }
}
