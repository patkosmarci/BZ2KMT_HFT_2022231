using BZ2KMT_HFT_2021222.Logic;
using BZ2KMT_HFT_2021222.Logic.Classes;
using BZ2KMT_HFT_2021222.Logic.Interfaces;
using BZ2KMT_HFT_2021222.Models;
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
        public void Read()
        {
            Console.Write("Give a person's id:");
            int id = int.Parse(Console.ReadLine());
            var person = personLogic.Read(id);
            Console.Write($"{person.PersonId}\t{person.FirstName} {person.LastName}\t\t{person.PhoneNumber}");
            foreach (var loan in person.Loans)
            {
                Console.Write($"\t{loan.Car.Brand.BrandName} {loan.Car.Model}\n");
            }
        }
        public void Create()
        {
            Person person = new Person();
            Console.Write("\nEnter first name:");
            person.FirstName = Console.ReadLine();
            Console.Write("\nEnter last name:");
            person.LastName = Console.ReadLine();
            Console.Write("\nEnter adress:");
            person.Address = Console.ReadLine();
            Console.Write("\nEnter phone:");
            person.PhoneNumber = Console.ReadLine();
            Console.Write("\nEnter Id number:");
            person.IdCardNumber = int.Parse(Console.ReadLine());
            Console.Write("\nEnter license number:");
            person.LicenseNumber = int.Parse(Console.ReadLine());
            personLogic.Create(person);
        }
        public void Update()
        {
            Console.Write("\nEnter a Person's id to update:");
            int id = int.Parse(Console.ReadLine());
            var person = personLogic.Read(id);
            Console.Write($"\nEnter first name [old: {person.FirstName}]:");
            person.FirstName = Console.ReadLine();
            Console.Write($"\nEnter last name [old: {person.LastName}]:");
            person.LastName = Console.ReadLine();
            Console.Write($"\nEnter adress [old: {person.Address}]:");
            person.Address = Console.ReadLine();
            Console.Write($"\nEnter phone [old: {person.PhoneNumber}]:");
            person.PhoneNumber = Console.ReadLine();
            Console.Write($"\nEnter Id number [old: {person.IdCardNumber}]:");
            person.IdCardNumber = int.Parse(Console.ReadLine());
            Console.Write($"\nEnter license number [old: {person.LicenseNumber}]:");
            person.LicenseNumber = int.Parse(Console.ReadLine());
            personLogic.Update(person);
        }
        public void Delete()
        {
            Console.Write("\nPlease give an id to delete:");
            int id = int.Parse(Console.ReadLine());
            personLogic.Delete(id);
        }
    }
}
