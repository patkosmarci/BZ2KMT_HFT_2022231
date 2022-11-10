using BZ2KMT_HFT_2021222.Logic.Classes;
using System;

namespace BZ2KMT_HFT_2021222.Client
{
    public class LoanClient
    {
        LoanLogic loanLogic;

        public LoanClient(LoanLogic loanLogic)
        {
            this.loanLogic = loanLogic;
        }

        public void ReadAll()
        {
            var items = loanLogic.ReadAll();
            Console.WriteLine("Id\tRental\t\tRented car\tRent date");
            foreach (var item in items)
            {
                Console.WriteLine($"{item.LoanId}\t{item.Person.FirstName} {item.Person.LastName}\t{item.Car.Brand.BrandName} " +
                    $"{item.Car.Model}\t{item.RentDate.ToShortDateString()}");
            }
        }
    }
}
