using BZ2KMT_HFT_2021222.Logic;
using BZ2KMT_HFT_2021222.Logic.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BZ2KMT_HFT_2021222.Client
{
    public class PersonClient
    {
        PersonLogic personLogic;
        public PersonClient(PersonLogic personLogic)
        {
            this.personLogic = personLogic;
        }

        public void ReadAll()
        {
            var items = personLogic.ReadAll();
            Console.WriteLine("Id\tName\t\t\tPhone\t\tRented car");
            foreach (var item in items)
            {
                Console.Write($"{item.PersonId}\t{item.FirstName} {item.LastName}\t\t{item.PhoneNumber}");
                foreach (var loan in item.Loans)
                {
                    Console.Write($"\t{loan.Car.Brand.BrandName} {loan.Car.Model}\n");
                }
            }
        }
    }
}
