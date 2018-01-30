namespace HumaneSociety
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("HumaneSociety.People")]
    public partial class Person
    {
        [Key]
        public int CustomerID { get; set; }

        [StringLength(50)]
        public string FirstName { get; set; }

        [StringLength(50)]
        public string LastName { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime? DateOfBirth { get; set; }

        [StringLength(10)]
        public string GoodWithPets { get; set; }

        [StringLength(10)]
        public string Gender { get; set; }
    }
}
