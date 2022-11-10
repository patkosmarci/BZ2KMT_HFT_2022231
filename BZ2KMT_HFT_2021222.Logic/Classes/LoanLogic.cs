using BZ2KMT_HFT_2021222.Logic.Interfaces;
using BZ2KMT_HFT_2021222.Models;
using BZ2KMT_HFT_2021222.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BZ2KMT_HFT_2021222.Logic.Classes
{
    public class LoanLogic : ILoanLogic
    {
        IRepository<Loan> repository;

        public LoanLogic(IRepository<Loan> repository)
        {
            this.repository = repository;
        }

        public void Create(Loan loan)
        {
            if(loan == null)
            {
                throw new ArgumentNullException("You must add a rental");
            }
            else
            {
                repository.Create(loan);
            }
        }
        public Loan Read(int id)
        {
            var loan = repository.Read(id);
            if (loan == null)
                throw new ArgumentNullException("Loan not exist");
            return loan;
        }
        public void Delete(int id)
        {
            repository.Delete(id);
        }
        public IEnumerable<Loan> ReadAll()
        {
            return repository.ReadAll();
        }
        public void Update(Loan loan)
        {
            repository.Update(loan);
        }
    }
}
