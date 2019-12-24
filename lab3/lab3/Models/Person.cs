using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace lab3.Models
{
    [Table("person", Schema = "public")]
    class Person
    {
        [Key]
        [Column("person-id")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        [Column("address")]
        public string Address { get; set; }

        [Column("name")]
        public string Name { get; set; }

        [Column("phone")]
        public string Phone { get; set; }

        [ForeignKey("car")]
        public virtual Car Car { get; set; }

        public Person()
        {
        }

        public Person(string address, string name, string phone, Car car)
        {
            Address = address;
            Name = name;
            Phone = phone;
            Car = car;
        }

    }
}
