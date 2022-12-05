using BZ2KMT_HFT_2021222.Logic.Classes;
using BZ2KMT_HFT_2021222.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BZ2KMT_HFT_2021222.Logic.Interfaces
{
    public interface IStatLogic
    {
        public IEnumerable<AvgCostByPerson> AvgCostByPerson();
        public IEnumerable<PersonWithMaxCost> MaxCostForLoan();
        public IEnumerable<Person> PersonWithMostLoans();
        public IEnumerable<BrandsDescending> BrandsWithCarReleaseDescending();
        public IEnumerable<PersonsLoanCount> PersonsLoanCount();
    }
}
