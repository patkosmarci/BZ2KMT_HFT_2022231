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
        public DateTime RentDate { get; set; }
        [Required]
        [ForeignKey(nameof(Car))]
        public int CarId { get; set; }
        [ForeignKey(nameof(Person))]
        public int PersonId { get; set; }
        [Required]
        public int CostInUSD { get; set; }
        public virtual Car Car { get; set; }
        public virtual Person Person { get; set; }

        public Loan()
        {

        }

        public Loan(string line)
        {
            string[] split = line.Split('#');
            LoanId = int.Parse(split[0]);
            RentDate = DateTime.Parse(split[1]);
            CarId = int.Parse(split[2]);
            PersonId = int.Parse(split[3]);
            CostInUSD = int.Parse(split[4]);
        }
    }
}
