using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BZ2KMT_HFT_2021222.Models
{
    public class Loans
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int LoanId { get; set; }
        [Required]
        [StringLength(100)]
        public string Rental { get; set; }
        [Required]
        public DateTime RentDate { get; set; }
        [Required]
        public int CarId { get; set; }
        [Required]
        public int RentTimeInDay { get; set; }

        public Loans()
        {

        }

        public Loans(string line)
        {
            string[] split = line.Split('#');
            LoanId = int.Parse(split[0]);
            Rental = split[1];
            RentDate = DateTime.Parse(split[2]);
            CarId = int.Parse(split[3]);
            RentTimeInDay = int.Parse(split[4]);
        }
    }
}
