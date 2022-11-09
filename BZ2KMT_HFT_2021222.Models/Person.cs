using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BZ2KMT_HFT_2021222.Models
{
    public class Person
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PersonId { get; set; }
        [Required]
        [StringLength(50)]
        public string FirstName { get; set; }
        [StringLength(50)]
        public string LastName { get; set; }
        [StringLength(100)]
        public string Address { get; set; }
        [StringLength(15)]
        public string PhoneNumber { get; set; }
        [Required]
        public int IdCardNumber { get; set; }
        [Required]
        public int LicenseNumber { get; set; }
        public virtual ICollection<Car> Cars { get; set; }
        public virtual ICollection<Loan> Loans { get; set; }

        public Person()
        {
            Cars = new HashSet<Car>();
            Loans = new HashSet<Loan>();
        }

        public Person(string line)
        {
            string[] split = line.Split('#');
            PersonId = int.Parse(split[0]);
            FirstName = split[1];
            LastName = split[2];
            Address = split[3];
            PhoneNumber = split[4];
            IdCardNumber = int.Parse(split[5]);
            LicenseNumber = int.Parse(split[6]);
            Cars = new HashSet<Car>();
            Loans = new HashSet<Loan>();
        }
    }
}
