using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BZ2KMT_HFT_2021222.Models
{
    public class Loan
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int LoanId { get; set; }
        [Required]
        public int RentalId { get; set; }
        [Required]
        public DateTime RentDate { get; set; }
        [Required]
        [ForeignKey(nameof(Car))]
        public int CarId { get; set; }
        [Required]
        public int RentTimeInDay { get; set; }
        public virtual Car Car { get; set; }
        public virtual Person Rental { get; set; }

        public Loan()
        {

        }

        public Loan(string line)
        {
            string[] split = line.Split('#');
            LoanId = int.Parse(split[0]);
            RentalId = int.Parse(split[1]);
            RentDate = DateTime.Parse(split[2]);
            CarId = int.Parse(split[3]);
            RentTimeInDay = int.Parse(split[4]);
        }
    }
}
