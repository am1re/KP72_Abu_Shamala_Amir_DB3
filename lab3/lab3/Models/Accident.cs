using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace lab3.Models
{
    [Table("accident", Schema = "public")]
    class Accident
    {
        [Key]
        [Column("record-number")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Record_Number { get; set; }

        [Column("location")]
        public string Location { get; set; }

        [Column("date")]
        public DateTime Date { get; set; }

        [Column("damage-amount")]
        public string Damage_Amount { get; set; }

        [ForeignKey("person")]
        public virtual Person Person { get; set; }

        public Accident()
        {
        }

        public Accident(string location, DateTime date, string damage_Amount, Person person)
        {
            Location = location;
            Date = date;
            Damage_Amount = damage_Amount;
            Person = person;
        }
    }
}
