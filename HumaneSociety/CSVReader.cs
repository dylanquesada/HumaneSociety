using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualBasic.FileIO;

namespace HumaneSociety
{

    class CSVReader
    {
        string filePath = @"C:\Users\dques\Documents\Visual Studio 2015\Projects\HumaneSociety\AnimalTable.csv";
        public void CSVMenu(HumaneSocietyDB db)
        {
            Console.WriteLine("Welcome to the CSV reader.");
            Console.WriteLine("What would you like to do? 'Read' a csv file or change the 'filepath'?");
            switch (UI.GetStringInput())
            {
                case "filepath":
                    Console.WriteLine("Enter your filepath:");
                    filePath = "@" + UI.GetStringInput();
                    break;
                case "read":
                    Read(db);
                    break;
                default:
                    Console.WriteLine("Sorry, try again.");
                    break;
                
            }
        }
        public void Read(HumaneSocietyDB db)
        {
            using (TextFieldParser parser = new TextFieldParser(filePath))
            {
                parser.TextFieldType = FieldType.Delimited;
                parser.SetDelimiters(",");
                while (!parser.EndOfData)
                {
                    string[] fields = parser.ReadFields();
                    Animal animal = new Animal();
                    animal.PetName = fields[1];
                    animal.AnimalType = fields[0];
                    animal.Size = fields[2];
                    animal.Gender = fields[3];
                    animal.BirthDate = Convert.ToDateTime(fields[4]);
                    animal.RoomID = Convert.ToInt32(fields[5]);
                    animal.FoodType = fields[6];
                    animal.FoodAmount = Convert.ToInt32(fields[7]);
                    animal.VaccineStatus = fields[8];
                    animal.AdoptionStatus = fields[9];
                    UI.DisplayAnimal(animal);
                    Console.WriteLine("Would you like to accept this entry to the database? 'Yes' or 'no'.");
                    string input = UI.GetStringInput();
                    if(input.ToLower() == "yes")
                    {
                        try
                        {
                            db.Animals.Add(animal);
                            db.SaveChanges();
                        }
                        catch
                        {
                            Console.WriteLine("Sorry not enough rooms.");
                        }
                    }                    
                }
            }
        }
    }
}
