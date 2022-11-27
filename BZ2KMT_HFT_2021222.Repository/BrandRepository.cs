using BZ2KMT_HFT_2021222.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace BZ2KMT_HFT_2021222.Repository
{
    public class BrandRepository : Repository<Brand>, IRepository<Brand>
    {
        public BrandRepository(CarRentDbContext ctx) : base(ctx)
        {
            this.ctx = ctx;
        }

        public override Brand Read(int id)
        {
            return ctx.Brand.First(t => t.BrandId == id);
        }

        public override void Update(Brand brand)
        {
            var old = Read(brand.BrandId);
            foreach (var prop in old.GetType().GetProperties())
            {
                if (prop.GetAccessors().FirstOrDefault(x => x.IsVirtual) == null)
                {
                    prop.SetValue(old, prop.GetValue(brand));
                }
            }
            ctx.SaveChanges();
        }
    }
}
