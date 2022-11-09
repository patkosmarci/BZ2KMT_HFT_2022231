using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BZ2KMT_HFT_2021222.Models
{
    public class Car
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CarId { get; set; }
        [Required]
        [StringLength(50)]
        public string Model { get; set; }
        [StringLength(50)]
        public string Type { get; set; }
        public string FuelType { get; set; }
        [Required]
        [Range(1900, 2100)]
        public int ReleaseYear { get; set; }
        [ForeignKey(nameof(Brand))]
        public int BrandId { get; set; }
        public virtual Brand Brand { get; set; }
        public virtual ICollection<Person> Persons { get; set; }
        public virtual ICollection<Loan> Loans { get; set; }


        public Car()
        {
            Persons = new HashSet<Person>();
            Loans = new HashSet<Loan>();
        }

        public Car(string line)
        {
            string[] split = line.Split('#');
            CarId = int.Parse(split[0]);
            Model = split[1];
            Type = split[2];
            FuelType = split[3];
            ReleaseYear = int.Parse(split[4]);
            BrandId = int.Parse(split[5]);
            Persons = new HashSet<Person>();
            Loans = new HashSet<Loan>();
        }
    }
}
