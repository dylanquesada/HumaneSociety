namespace HumaneSociety
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Model1 : DbContext
    {
        public Model1()
            : base("name=HumaneSocietyDB")
        {
        }

        public virtual DbSet<Animal> Animals { get; set; }
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
