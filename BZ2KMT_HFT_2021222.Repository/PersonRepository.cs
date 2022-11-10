using BZ2KMT_HFT_2021222.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BZ2KMT_HFT_2021222.Repository
{
    public class PersonRepository : Repository<Person>, IRepository<Person> 
    {
        public PersonRepository(CarRentDbContext ctx) : base(ctx)
        {
            this.ctx = ctx;
        }
        public override Person Read(int id)
        {
            return ctx.Persons.First(t => t.PersonId == id);
        }
        public override void Update(Person person)
        {

        }
    }
}
