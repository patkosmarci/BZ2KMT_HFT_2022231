using BZ2KMT_HFT_2021222.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BZ2KMT_HFT_2021222.Logic.Interfaces
{
    internal interface ICarLogic
    {
        void Create(Car item);
        Car Read(int id);
        void Delete(int id);
        IEnumerable<Car> ReadAll();
        void Update(Car item);
    }
}
