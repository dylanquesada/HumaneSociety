namespace HumaneSociety
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using System.Collections;

    public partial class HumaneSocietyDB : DbContext: IEnumerable
    {
        public HumaneSocietyDB()
            : base("name=HumaneSocietyDB1")
        {
        }

        public IEnumerator GetEnumerator()
        {
            for(int index = 0; index < this; index++)
        }
        public virtual DbSet<Animal> Animals { get; set; }
        public virtual DbSet<Person> People { get; set; }
        public virtual DbSet<Room> Rooms { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Animal>()
                .Property(e => e.PetName)
                .IsUnicode(false);

            modelBuilder.Entity<Animal>()
                .Property(e => e.AnimalType)
                .IsUnicode(false);

            modelBuilder.Entity<Animal>()
                .Property(e => e.Size)
                .IsUnicode(false);

            modelBuilder.Entity<Animal>()
                .Property(e => e.Gender)
                .IsUnicode(false);

            modelBuilder.Entity<Animal>()
                .Property(e => e.VaccineStatus)
                .IsUnicode(false);

            modelBuilder.Entity<Animal>()
                .Property(e => e.FoodType)
                .IsUnicode(false);

            modelBuilder.Entity<Animal>()
                .Property(e => e.AdoptionStatus)
                .IsUnicode(false);

            modelBuilder.Entity<Animal>()
                .HasMany(e => e.Rooms)
                .WithOptional(e => e.Animal)
                .HasForeignKey(e => e.AnimalID);

            modelBuilder.Entity<Person>()
                .Property(e => e.FirstName)
                .IsUnicode(false);

            modelBuilder.Entity<Person>()
                .Property(e => e.LastName)
                .IsUnicode(false);

            modelBuilder.Entity<Person>()
                .Property(e => e.GoodWithPets)
                .IsUnicode(false);

            modelBuilder.Entity<Person>()
                .Property(e => e.Gender)
                .IsUnicode(false);

            modelBuilder.Entity<Room>()
                .Property(e => e.Vacancy)
                .IsUnicode(false);

            modelBuilder.Entity<Room>()
                .HasMany(e => e.Animals)
                .WithOptional(e => e.Room)
                .HasForeignKey(e => e.RoomID);
        }
    }
}
