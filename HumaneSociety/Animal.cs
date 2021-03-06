﻿namespace HumaneSociety
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("HumaneSociety.Animals")]
    public partial class Animal
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Animal()
        {
            Rooms = new HashSet<Room>();
        }

        public int ID { get; set; }

        [Required]
        [StringLength(50)]
        public string PetName { get; set; }

        [StringLength(50)]
        public string AnimalType { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime? BirthDate { get; set; }

        [Required]
        [StringLength(10)]
        public string Size { get; set; }

        [Required]
        [StringLength(10)]
        public string Gender { get; set; }

        [StringLength(25)]
        public string VaccineStatus { get; set; }

        [StringLength(50)]
        public string FoodType { get; set; }

        public int? FoodAmount { get; set; }

        [StringLength(12)]
        public string AdoptionStatus { get; set; }

        public int? RoomID { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Room> Rooms { get; set; }

        public virtual Room Room { get; set; }
        // Member methods
        public void SetName(Animal animal)
        {
            string input;
            Console.WriteLine("What is the animal's name.");
            input = UI.GetStringInput();
            animal.PetName = input;
        }
        public void SetType(Animal animal)
        {
            string input;
            Console.WriteLine("What is the animal? (dog, cat, etc.?)");
            input = UI.GetStringInput();
            animal.AnimalType = input;
        }
        public void SetBirthDate(Animal animal)
        {
            DateTime input;
            Console.WriteLine("When is the animal's birthday?");
            input = UI.GetDateInput();
            animal.BirthDate = input;
        }
        public void SetSize(Animal animal)
        {
            string input;
            Console.WriteLine("What is the animal's size?");
            input = UI.GetStringInput();
            animal.Size = input;
        }
        public void SetGender(Animal animal)
        {
            string input;
            Console.WriteLine("What is the animal's preferred gender?");
            input = UI.GetStringInput();
            animal.Gender = input;
        }
        public void SetVaccineStatus(Animal animal)
        {
            string input;
            Console.WriteLine("Has the animal been vaccinated?");
            input = UI.GetStringInput();
            animal.VaccineStatus = input;
        }
        public void SetFoodType(Animal animal)
        {
            string input;
            Console.WriteLine("What kind of food does the animal eat?");
            input = UI.GetStringInput();
            animal.FoodType = input;
        }
        public void SetFoodAmount(Animal animal)
        {
            int input;
            Console.WriteLine("How many cups of food does the animal eat per day?");
            input = UI.GetIntInput();
            animal.FoodAmount = input;
        }
        public void SetAdoptionStatus(Animal animal)
        {
            string input;
            Console.WriteLine("Is the animal adopted or not-adopted?");
            input = UI.GetStringInput();
            animal.AdoptionStatus = input;
        }
        public void SetRoom(Animal animal)
        {
            int input;
            Console.WriteLine("What room is the animal in?");
            input = UI.GetIntInput(); 
            animal.RoomID = input;
        }
    }
}
