using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace lab3.Models
{
    [Table("car", Schema = "public")]
    class Car
    {
        [Key]
        [Column("VIN")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long VIN { get; set; }

        [Column("Model")]
        public string Model { get; set; }

        [Column("Year")]
        public int Year { get; set; }

        public Car()
        {
        }

        public Car(long vIN, string model, int year)
        {
            VIN = vIN;
            Model = model;
            Year = year;
        }
    }
}
