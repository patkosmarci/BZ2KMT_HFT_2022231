using BZ2KMT_HFT_2021222.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BZ2KMT_HFT_2021222.Logic.Interfaces
{
    public interface IBrandLogic
    {
        void Create(Brand item);
        Brand Read(int id);
        void Delete(int id);
        IEnumerable<Brand> ReadAll();
        void Update(Brand item);
    }
}
