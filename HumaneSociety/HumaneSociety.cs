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
        HumaneSocietyDB db = new HumaneSocietyDB();
        //Constructor
        public HumaneSociety()
        {

        }

        //Member methods
        public void RunHumaneSociety()
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
                        break;
                    case "payment":
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
        public List<Animal> SearchByName(string name)
        {
            var animals = new HumaneSocietyDB().Animals;
            
            List<Animal> list = new List<Animal>();
            var result = animals.Where(n => n.PetName == name);
            foreach(var animal in animals)
            {
                list.Add(animal);
            }
            return list;
        }
    }
}
