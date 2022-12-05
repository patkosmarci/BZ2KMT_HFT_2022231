using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BZ2KMT_HFT_2021222.Models
{
    public class PersonWithMaxCost
    {
        public string FullName { get; set; }
        public int MaxCost { get; set; }
        public override bool Equals(object obj)
        {
            PersonWithMaxCost b = obj as PersonWithMaxCost;
            if (b == null)
                return false;
            else
                return b.FullName == FullName && b.MaxCost == MaxCost;
        }
        public override int GetHashCode()
        {
            return HashCode.Combine(FullName, MaxCost);
        }
    }
}
