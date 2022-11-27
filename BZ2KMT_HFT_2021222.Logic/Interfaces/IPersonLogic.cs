using BZ2KMT_HFT_2021222.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BZ2KMT_HFT_2021222.Logic.Interfaces
{
    public interface IPersonLogic
    {
        void Create(Person item);
        Person Read(int id);
        void Delete(int id);
        IEnumerable<Person> ReadAll();
        void Update(Person item);
    }
}
