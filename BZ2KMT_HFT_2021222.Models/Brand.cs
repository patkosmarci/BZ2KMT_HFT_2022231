using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BZ2KMT_HFT_2021222.Models
{
    public class Brand
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int BrandId { get; set; }
        [Required]
        [StringLength(50)]
        public string BrandName { get; set; }

        public Brand()
        {

        }

        public Brand(string line)
        {
            string[] split = line.Split('#');
            BrandId = int.Parse(split[0]);
            BrandName = split[1];
        }
    }
}
