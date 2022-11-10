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
            Console.WriteLine("Id\tName\t\t\tPhone");
            foreach (var item in items)
            {
                Console.WriteLine($"{item.PersonId}\t{item.FirstName} {item.LastName}\t\t{item.PhoneNumber}");
            }
        }
    }
}
