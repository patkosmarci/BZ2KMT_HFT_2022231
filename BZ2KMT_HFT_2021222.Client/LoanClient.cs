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

        public LoanClient()
        {
            rest = new RestService("http://localhost:21067/");
        }

        public void ReadAll()
        {
            List<Loan> loans = rest.Get<Loan>("loan");
            Console.WriteLine("Id\tRental\t\tRented car\tRent date");
            foreach (var item in loans)
            {
                Console.WriteLine($"{item.LoanId}\t{item.Person.FirstName} {item.Person.LastName}\t" +
                    $"{item.Car.Model}\t\t{item.RentDate.ToShortDateString()}\n" +
                    $"Cost of rent in USD: {item.CostInUSD}$\n");
            }
        }
        public void Read()
        {
            Console.Write("Give a loan's id:");
            int id = int.Parse(Console.ReadLine());
            Loan loan = rest.Get<Loan>(id, "loan");
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
            Console.WriteLine("Id\tRental\t\tRented car\tRent date");
            foreach (var item in loans)
            {
                Console.WriteLine($"{item.LoanId}\t{item.Person.FirstName} {item.Person.LastName}\t" +
                    $"{item.Car.Model}\t\t{item.RentDate.ToShortDateString()}\n" +
                    $"Cost of rent in USD: {item.CostInUSD}$\n");
            }

            Console.Write("\nPick a Loan's id to update:");
            int id = int.Parse(Console.ReadLine());
            Loan loan = rest.Get<Loan>(id, "loan");
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
            Console.WriteLine("Id\tRental\t\tRented car\tRent date");
            foreach (var item in loans)
            {
                Console.WriteLine($"{item.LoanId}\t{item.Person.FirstName} {item.Person.LastName}\t" +
                    $"{item.Car.Model}\t\t{item.RentDate.ToShortDateString()}\n" +
                    $"Cost of rent in USD: {item.CostInUSD}$\n");
            }

            Console.Write("\nPlease pick an id to delete:");
            int id = int.Parse(Console.ReadLine());
            rest.Delete(id, "loan");
        }
    }
}
