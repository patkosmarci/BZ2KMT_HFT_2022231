using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BZ2KMT_HFT_2021222.Models
{
    public class AvgCostByPerson
    {
        public AvgCostByPerson(int personId, double? avgCost)
        {
            PersonId = personId;
            AvgCost = avgCost;
        }
        public AvgCostByPerson()
        {

        }

        public int PersonId { get; set; }
        public double? AvgCost { get; set; }

        public override bool Equals(object obj)
        {
            AvgCostByPerson b = obj as AvgCostByPerson;
            if (b == null)
            {
                return false;
            }
            else
            {
                return this.PersonId == b.PersonId &&
                    this.AvgCost == b.AvgCost;
            }
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(this.PersonId, this.AvgCost);
        }
    }
}
