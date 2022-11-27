using BZ2KMT_HFT_2021222.Logic;
using BZ2KMT_HFT_2021222.Logic.Classes;
using BZ2KMT_HFT_2021222.Models;
using BZ2KMT_HFT_2021222.Repository;
using System;
using System.Linq;

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
        public void Read()
        {
            Console.Write("Give a loan's id:");
            int id = int.Parse(Console.ReadLine());
            var loan = loanLogic.Read(id);
            Console.WriteLine("Id\tRental\t\tRented car\tRent date");
            Console.WriteLine($"{loan.LoanId}\t{loan.Person.FirstName} {loan.Person.LastName}\t{loan.Car.Brand.BrandName} " +
                    $"{loan.Car.Model}\t{loan.RentDate.ToShortDateString()}");
        }
        public void Create()
        {
            Loan loan = new Loan();
            loan.RentDate = DateTime.Now;
            Console.Write("\nEnter the cost of the rent:");
            loan.CostInUSD = int.Parse(Console.ReadLine());

            var cars = loanLogic.ReadAll().GroupBy(x => x.Car).OrderBy(x => x.Key.CarId);

            Console.WriteLine("\nPlease choose a brand from listed above:");

            foreach (var item in cars)
            {
                Console.WriteLine($"{item.Key.CarId}. - {item.Key.Model}");
            }

            loan.CarId = int.Parse(Console.ReadLine());

            var persons = loanLogic.ReadAll().GroupBy(x => x.Person).OrderBy(x => x.Key.PersonId);

            Console.WriteLine("\nPlease choose a brand from listed above:");

            foreach (var item in persons)
            {
                Console.WriteLine($"{item.Key.PersonId}. - {item.Key.FirstName} {item.Key.LastName}");
            }

            loan.PersonId = int.Parse(Console.ReadLine());
            loanLogic.Create(loan);
        }
        public void Update()
        {
            Console.Write("\nEnter Loan's id to update:");
            int id = int.Parse(Console.ReadLine());
            var loan = loanLogic.Read(id);
            loan.RentDate = DateTime.Now;
            Console.Write($"\nEnter the cost of the rent [old: {loan.CostInUSD}]:");
            loan.CostInUSD = int.Parse(Console.ReadLine());

            var cars = loanLogic.ReadAll().GroupBy(x => x.Car).OrderBy(x => x.Key.CarId);

            Console.WriteLine("\nPlease choose a brand from listed above:");

            foreach (var item in cars)
            {
                Console.WriteLine($"{item.Key.CarId}. - {item.Key.Model}");
            }

            loan.CarId = int.Parse(Console.ReadLine());

            var persons = loanLogic.ReadAll().GroupBy(x => x.Person).OrderBy(x => x.Key.PersonId);

            Console.WriteLine("\nPlease choose a brand from listed above:");

            foreach (var item in persons)
            {
                Console.WriteLine($"{item.Key.PersonId}. - {item.Key.FirstName} {item.Key.LastName}");
            }

            loan.PersonId = int.Parse(Console.ReadLine());
            loanLogic.Update(loan);
        }
        public void Delete()
        {
            Console.Write("\nPlease give an id to delete:");
            int id = int.Parse(Console.ReadLine());
            loanLogic.Delete(id);
        }
    }
}
