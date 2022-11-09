using BZ2KMT_HFT_2021222.Models;
using System;
using System.Linq;

namespace BZ2KMT_HFT_2021222.Repository
{
    public class LoanRepository : Repository<Loan>, IRepository<Loan>
    {
        public LoanRepository(CarRentDbContext ctx) : base(ctx)
        {
            this.ctx = ctx;
        }

        public override Loan Read(int id)
        {
            return ctx.Loans.First(t => t.LoanId == id);
        }
        public override void Update(Loan item)
        {
            throw new NotImplementedException();
        }
    }
}
