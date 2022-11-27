using BZ2KMT_HFT_2021222.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BZ2KMT_HFT_2021222.Repository
{
    public class CarRepository : Repository<Car>, IRepository<Car>
    {
        public CarRepository(CarRentDbContext ctx) : base(ctx)
        {
            this.ctx = ctx;
        }
        public override Car Read(int id)
        {
            return ctx.Cars.First(t => t.CarId == id);
        }
        public override void Update(Car car)
        {
            var old = Read(car.CarId);
            foreach (var prop in old.GetType().GetProperties())
            {
                if(prop.GetAccessors().FirstOrDefault(x => x.IsVirtual) == null)
                {
                    prop.SetValue(old, prop.GetValue(car));
                }
            }
            ctx.SaveChanges();
        }
    }
}
