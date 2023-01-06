using BZ2KMT_HFT_2021222.Logic;
using BZ2KMT_HFT_2021222.Logic.Classes;
using BZ2KMT_HFT_2021222.Models;
using BZ2KMT_HFT_2021222.Repository;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BZ2KMT_HFT_2021222.Client
{
    public class LoanClient
    {
        RestService rest;

        public LoanClient(string url)
        {
            rest = new RestService(url);
        }

        public void ReadAll()
        {
            List<Loan> loans = rest.Get<Loan>("loan");
            Console.WriteLine("Id\tRental\t\t\tRented car");
            foreach (var item in loans)
            {
                WriteToConsole(item);
            }
        }
        public void Read()
        {
            Console.Write("Give a loan's id:");
            int id = int.Parse(Console.ReadLine());
            Loan loan = rest.Get<Loan>(id, "loan");
            Console.WriteLine("Id\tRental\t\t\tRented car");
            WriteToConsole(loan);
        }
        public void Create()
        {
            Loan loan = new Loan();
            loan.RentDate = DateTime.Now;
            Console.Write("\nEnter the cost of the rent:");
            loan.CostInUSD = int.Parse(Console.ReadLine());

            List<Car> cars = rest.Get<Car>("car");

            Console.WriteLine("\nPlease choose a car from listed above:");

            foreach (var item in cars)
            {
                Console.WriteLine($"{item.CarId}. - {item.Model}");
            }

            loan.CarId = int.Parse(Console.ReadLine());

            List<Person> persons = rest.Get<Person>("person");

            Console.WriteLine("\nPlease choose a brand from listed above:");

            foreach (var item in persons)
            {
                Console.WriteLine($"{item.PersonId}. - {item.FirstName} {item.LastName}");
            }

            loan.PersonId = int.Parse(Console.ReadLine());
            rest.Post(loan, "loan");
        }
        public void Update()
        {
            List<Loan> loans = rest.Get<Loan>("loan");
            Console.WriteLine("Id\tRental\t\t\tRented car");
            foreach (var item in loans)
            {
                WriteToConsole(item);
            }

            Console.Write("\nPick a Loan's id to update:");
            int id = int.Parse(Console.ReadLine());
            Loan loan = rest.Get<Loan>(id, "loan");
            Console.WriteLine("Do you want to change update the date of the rent?(Y/N)");
            string choice = "";
            do
            {
                choice = Console.ReadLine();
            } while (choice.ToLower() != "y" || choice.ToLower() != "n");

            if(choice == "y")
                loan.RentDate = DateTime.Now;

            Console.Write($"\nEnter the cost of the rent [old: {loan.CostInUSD}]:");
            loan.CostInUSD = int.Parse(Console.ReadLine());

            List<Car> cars = rest.Get<Car>("car");

            Console.WriteLine("\nPlease choose a brand from listed above:");

            foreach (var item in cars)
            {
                Console.WriteLine($"{item.CarId}. - {item.Model}");
            }

            loan.CarId = int.Parse(Console.ReadLine());

            List<Person> persons = rest.Get<Person>("person");

            Console.WriteLine("\nPlease choose a person from listed above:");

            foreach (var item in persons)
            {
                Console.WriteLine($"{item.PersonId}. - {item.FirstName} {item.LastName}");
            }

            loan.PersonId = int.Parse(Console.ReadLine());
            rest.Put(loan, "loan");
        }
        public void Delete()
        {
            List<Loan> loans = rest.Get<Loan>("loan");
            Console.WriteLine("Id\tRental\t\t\tRented car");
            foreach (var item in loans)
            {
                WriteToConsole(item);
            }

            Console.Write("\nPlease pick an id to delete:");
            int id = int.Parse(Console.ReadLine());
            rest.Delete(id, "loan");
        }

        public void WriteToConsole(Loan item)
        {
            if(item.Person != null)
            {
                if (item.Person.FirstName.Length + item.Person.LastName.Length < 7)
                {
                    Console.Write($"{item.LoanId}\t{item.Person.FirstName} {item.Person.LastName}\t\t\t");
                }
                else if (item.Person.FirstName.Length + item.Person.LastName.Length >= 21)
                {
                    Console.Write($"{item.LoanId}\t{item.Person.FirstName} {item.Person.LastName.Substring(0, 3)}...\t\t");
                }
                else
                {
                    Console.Write($"{item.LoanId}\t{item.Person.FirstName} {item.Person.LastName}\t\t");
                }
            }
            else
            {
                Console.Write($"{item.LoanId}\tCan't find a person\t");
            }
            Console.WriteLine($"{(item.Car == null ? "We couldn't find a car to this loan" : item.Car.Brand.BrandName + " " + item.Car.Model)}\n" +
                $"Date: {item.RentDate.ToShortDateString()}\nCost of rent: {item.CostInUSD}$\n");
        }
    }
}
