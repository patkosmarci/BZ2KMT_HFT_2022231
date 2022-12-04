using BZ2KMT_HFT_2021222.Logic.Classes;
using BZ2KMT_HFT_2021222.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BZ2KMT_HFT_2021222.Logic.Interfaces
{
    public interface ILoanLogic
    {
        void Create(Loan item);
        Loan Read(int id);
        void Delete(int id);
        IEnumerable<Loan> ReadAll();
        void Update(Loan item);
    }
}
