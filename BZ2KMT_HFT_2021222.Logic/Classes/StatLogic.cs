using BZ2KMT_HFT_2021222.Logic.Interfaces;
using BZ2KMT_HFT_2021222.Models;
using BZ2KMT_HFT_2021222.Repository;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BZ2KMT_HFT_2021222.Logic.Classes
{
    public class StatLogic : IStatLogic
    {
        IRepository<Loan> loanRepository;
        IRepository<Person> personRepository;
        IRepository<Brand> brandRepository;

        public StatLogic(IRepository<Loan> loanRepository, IRepository<Person> personRepository, IRepository<Brand> brandRepository)
        {
            this.loanRepository = loanRepository;
            this.personRepository = personRepository;
            this.brandRepository = brandRepository;
    }

        public IEnumerable<AvgCostByPerson> AvgCostByPerson()
        {
            var loans = loanRepository.ReadAll().ToList();
            var persons = personRepository.ReadAll().ToList();

            var result = from x in loans
                         group x by x.Person.PersonId into g
                         select new AvgCostByPerson
                         {
                             PersonId = g.Key,
                             AvgCost = g.Average(x => x.CostInUSD),
                         };

            return result;
        }
        public IEnumerable<PersonWithMaxCost> MaxCostForLoan()
        {
            var loans = loanRepository.ReadAll().ToList();

            return from x in loans
                   group x by x.Person into g
                   select new PersonWithMaxCost
                   {
                       FullName = g.Key.FirstName + " " + g.Key.LastName,
                       MaxCost = g.Key.Loans.Max(t => t.CostInUSD)
                   };
                    
        }
        public IEnumerable<Person> PersonWithMostLoans()
        {
            var persons = personRepository.ReadAll().ToList();

            return (from x in persons
                   orderby x.Loans.Count descending
                   select x).Take(1);
        }
        public IEnumerable<BrandsDescending> BrandsWithCarReleaseDescending()
        {
            var brands = brandRepository.ReadAll().ToList();

            var result = from x in brands
                   select new BrandsDescending
                   {
                       BrandName = x.BrandName,
                       AvgYear = x.Cars.Average(x => x.ReleaseYear)
                   };

            return result.OrderByDescending(t => t.AvgYear);
        }
        public IEnumerable<PersonsLoanCount> PersonsLoanCount()
        {
            var persons = personRepository.ReadAll().ToList();

            return from x in persons
                   select new PersonsLoanCount
                   {
                       FullName = x.FirstName + " " + x.LastName,
                       LoanCount = x.Loans.Count
                   };
        }
    }
    public class BrandsDescending
    {
        public string BrandName { get; set; }
        public double? AvgYear { get; set; }

        public override bool Equals(object obj)
        {
            BrandsDescending b = obj as BrandsDescending;
            if (b == null)
                return false;
            else
            {
                return BrandName == b.BrandName && AvgYear == b.AvgYear;
            }
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(BrandName, AvgYear);
        }
    }
}
