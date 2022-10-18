using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BZ2KMT_HFT_2021222.Models
{
    public enum Fuel { Gasoline = 1, Diesel = 2, Ethanol = 3, Electricity  = 4}
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
        public Fuel FuelType { get; set; }
        [Required]
        [Range(1900, 2100)]
        public int ReleaseYear { get; set; }
        [ForeignKey(nameof(Brand))]
        public int BrandId { get; set; }


        public Car()
        {

        }

        public Car(string line)
        {
            string[] split = line.Split('#');
            CarId = int.Parse(split[0]);
            Model = split[1];
            Type = split[2];
            FuelType = (Fuel)int.Parse(split[3]);
            ReleaseYear = int.Parse(split[4]);
            BrandId = int.Parse(split[5]);
        }
    }
}
