using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BZ2KMT_HFT_2021222.Models
{
    public class PersonsLoanCount
    {
        public PersonsLoanCount(string fullName, int loanCount)
        {
            FullName = fullName;
            LoanCount = loanCount;
        }

        public PersonsLoanCount()
        {

        }

        public string FullName { get; set; }
        public int LoanCount { get; set; }

        public override bool Equals(object obj)
        {
            PersonsLoanCount b = obj as PersonsLoanCount;
            if (b == null)
                return false;
            else
            {
                return FullName == b.FullName && LoanCount == b.LoanCount;
            }
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(FullName, LoanCount);
        }
    }
}
