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
    public class StatLogic
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

            return from x in loans
                   group x by x.Person.PersonId into g
                   select new AvgCostByPerson
                   {
                       Id = g.Key,
                       RentalName = g.Select(t => t.Person.FirstName + " " + t.Person.LastName).First(),
                       AvgCost = g.Average(t => t.CostInUSD)
                   };
        }
        public IEnumerable<object> MaxCostForLoan()
        {
            var loans = loanRepository.ReadAll().ToList();

            return from x in loans
                   group x by x.Person.PersonId into g
                   select new
                   {
                       PersonId = g.Key,
                       MaxCost = g.Max(t => t.CostInUSD)
                   };
                    
        }
        public IEnumerable<Person> PersonWithMostLoans()
        {
            var persons = personRepository.ReadAll().ToList();

            return (from x in persons
                   orderby x.Loans.Count descending
                   select x).Take(1);
        }
        public IEnumerable<Brand> BrandsWithCarReleaseDescending()
        {
            var brands = brandRepository.ReadAll().ToList();

            return brands.OrderByDescending(x => x.Cars.Select(t => t.ReleaseYear));
        }
    }
}
