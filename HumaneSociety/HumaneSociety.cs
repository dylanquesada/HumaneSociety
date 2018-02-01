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
                        SearchMenu();
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
                Console.WriteLine("What would you like to do? 'Find' an animal, 'add' an animal to the database, set an animal for 'adoption', collect a 'payment',  'vaccinate' an animal, import animals from 'CSV' file, evaluate animal 'food' needs, 'display' all animals, or 'done' to exit.");
                option = Console.ReadLine().ToLower();
                switch (option)
                {
                    case "find":
                        SearchMenu();
                        break;
                    case "food":
                        FoodMenu();
                        break;
                    case "adoption":
                        ChangeAdoptionStatus();
                        break;
                    case "payment":
                        PayForAnimal();
                        break;
                    case "vaccinate":
                        VaccinateAnimal();
                        break;
                    case "done":
                        done = true;
                        break;
                    case "add":
                        db.Animals.Add(AddAnimal());
                        db.SaveChanges();
                        break;
                    case "csv":
                        CSVReader cs = new CSVReader();
                        cs.CSVMenu(db);
                        break;
                    case "display":
                        DisplayAnimals(db.Animals.ToList());
                        break;
                    default:
                        Console.WriteLine("Sorry, '{0}' is not a valid entry. Try Again.", option);
                        break;
                }
            }
        }
        public void FoodMenu()
        {
            var animals = new HumaneSocietyDB().Animals;
            foreach (var pet in animals)
            {
                Console.WriteLine("{0} eats {1} cups of {2} a day.", pet.PetName, pet.FoodAmount, pet.FoodType);
            }
        }
       
        public void SearchMenu()
        {
            bool done;
            done = false;
            List<Animal> animals = new HumaneSocietyDB().Animals.ToList();
            while (!(animals.Count == 1) && !done)
            {
                Console.WriteLine("What would you like to filter by? 'Name', 'room', 'type', 'size', 'vaccination' status, 'adoption' status, or 'gender'.");
                switch (UI.GetStringInput().ToLower())
                {
                    case "name":
                        Console.WriteLine("Enter name:");
                        animals = SearchByName(UI.GetStringInput(), animals);
                        DisplayAnimals(animals);
                        break;
                    case "type":
                        Console.WriteLine("Enter animal type:");
                        animals = SearchByType(UI.GetStringInput(), animals);
                        DisplayAnimals(animals);
                        break;
                    case "size":
                        Console.WriteLine("Enter size:");
                        animals = SearchBySize(UI.GetStringInput(), animals);
                        DisplayAnimals(animals);
                        break;
                    case "vaccination":
                        Console.WriteLine("Is the animal you're looking for vaccinated? 'yes' or 'no'.");
                        animals = SearchByVaccineStatus(UI.GetStringInput(), animals);
                        DisplayAnimals(animals);
                        break;
                    case "gender":
                        Console.WriteLine("Gender preferences");
                        animals = SearchByGender(UI.GetStringInput(), animals);
                        DisplayAnimals(animals);
                        break;
                    case "adoption":
                        Console.WriteLine("Is the animal you're searching for 'adopted' or 'notadopted'?");
                        animals = SearchByAdoptionStatus(UI.GetStringInput(), animals);
                        DisplayAnimals(animals);
                        break;
                    case "room":
                        Console.WriteLine("Which room is the animal in?");
                        animals = SearchByRoom(UI.GetIntInput(), animals);
                        DisplayAnimals(animals);
                        break;
                    case "restart":
                        animals = new HumaneSocietyDB().Animals.ToList();
                        break;
                    case "exit":
                        done = true;
                        break;
                    default:
                        Console.WriteLine("Sorry that is an invalid input. Try Again.");
                        break;
                }
            }
        }
        public void DisplayAnimals(List<Animal> list)
        {
            Console.WriteLine("Search Results:");
            for (int i = 0; i < list.Count; i++)
            {                
                Console.WriteLine("Animal name = {0}", list[i].PetName);
                Console.WriteLine("Animal type = {0}", list[i].AnimalType);
                Console.WriteLine("AnimalID = {0}", list[i].ID);
                Console.WriteLine("Animal size = {0}", list[i].Size);
                Console.WriteLine("Animal gender = {0}", list[i].Gender);
                Console.WriteLine("Animal vaccine shots = {0}", list[i].VaccineStatus);
                Console.WriteLine("Animal adoption status = {0}", list[i].AdoptionStatus);
                Console.WriteLine("_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_");
            }
        }
        public void ChangeAdoptionStatus()
        {
            Console.WriteLine("What is the AnimalID of the Animal being adopted?");
            int input = UI.GetIntInput();
                Animal animal = db.Animals.Single(n => n.ID == input);
                animal.AdoptionStatus = "adopted";
                db.SaveChanges();                   
        }
        public void VaccinateAnimal()
        {
            Console.WriteLine("What is the AnimalID of the Animal being vaccinated?");
            int input = UI.GetIntInput();
            Animal animal = db.Animals.Single(n => n.ID == input);
            animal.VaccineStatus = "yes";
            db.SaveChanges();
            Console.WriteLine("{0} has been vaccinated.", animal.PetName);
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

        public List<Animal> SearchByName(string input, List<Animal> animals)
        {
            List<Animal> list = new List<Animal>();
            var result = animals.Where(n => n.PetName.ToLower() == input.ToLower());
            foreach(var animal in result)
            {
                list.Add(animal);
            }
            return list;
        }
        public List<Animal> SearchByType(string input, List<Animal> animals)
        {            
            List<Animal> list = new List<Animal>();
            var result = animals.Where(n => n.AnimalType.ToLower() == input.ToLower());
            foreach (var animal in result)
            {
                list.Add(animal);
            }
            return list;
        }
        public List<Animal> SearchByBirthDate(DateTime input, List<Animal> animals)
        {
            List<Animal> list = new List<Animal>();
            var result = animals.Where(n => n.BirthDate == input);
            foreach (var animal in result)
            {
                list.Add(animal);
            }
            return list;
        }

        public List<Animal> SearchBySize(string input, List<Animal> animals)
        {
            List<Animal> list = new List<Animal>();
            var result = animals.Where(n => n.Size.ToLower() == input.ToLower());
            foreach (var animal in result)
            {
                list.Add(animal);
            }
            return list;
        }

        public List<Animal> SearchByGender(string input, List<Animal> animals)
        {
            List<Animal> list = new List<Animal>();
            var result = animals.Where(n => n.Gender.ToLower() == input.ToLower());
            foreach (var animal in result)
            {
                list.Add(animal);
            }
            return list;
        }

        public List<Animal> SearchByVaccineStatus(string input, List<Animal> animals)
        {
            List<Animal> list = new List<Animal>();
            var result = animals.Where(n => n.VaccineStatus.ToLower() == input.ToLower());
            foreach (var animal in result)
            {
                list.Add(animal);
            }
            return list;
        }

        public List<Animal> SearchByAdoptionStatus(string input, List<Animal> animals)
        {
            List<Animal> list = new List<Animal>();
            var result = animals.Where(n => n.AdoptionStatus.ToLower() == input.ToLower());
            foreach (var animal in result)
            {
                list.Add(animal);
            }
            return list;
        }
        public List<Animal> SearchByRoom(int input, List<Animal> animals)
        {
            List<Animal> list = new List<Animal>();
            var result = animals.Where(n => n.RoomID == input);
            foreach(var animal in result)
            {
                list.Add(animal);
            }
            return list;
        }
    }
}
