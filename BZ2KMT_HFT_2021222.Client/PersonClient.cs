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
        RestService rest;
        public PersonClient()
        {
            rest = new RestService("http://localhost:21067/");
        }

        public void ReadAll()
        {
            List<Person> persons = rest.Get<Person>("person");
            Console.WriteLine("Id\tName\t\t\tPhone");
            foreach (var item in persons)
            {
                Console.Write($"{item.PersonId}\t{item.FirstName} {item.LastName}\t\t{item.PhoneNumber}\n");
            }
        }
        public void Read()
        {
            Console.Write("Give a person's id:");
            int id = int.Parse(Console.ReadLine());
            Person person = rest.Get<Person>(id, "person");
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
            rest.Post(person, "person");
        }
        public void Update()
        {
            List<Person> persons = rest.Get<Person>("person");
            Console.WriteLine("Id\tName\t\t\tPhone");
            foreach (var item in persons)
            {
                Console.Write($"{item.PersonId}\t{item.FirstName} {item.LastName}\t\t{item.PhoneNumber}");
            }

            Console.Write("\nPick a Person's id to update:");
            int id = int.Parse(Console.ReadLine());
            Person person = rest.Get<Person>(id, "person");
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
            rest.Put(person, "person");
        }
        public void Delete()
        {
            List<Person> persons = rest.Get<Person>("person");
            Console.WriteLine("Id\tName\t\t\tPhone");
            foreach (var item in persons)
            {
                Console.Write($"{item.PersonId}\t{item.FirstName} {item.LastName}\t\t{item.PhoneNumber}");
            }

            Console.Write("\nPlease pick an id to delete:");
            int id = int.Parse(Console.ReadLine());
            rest.Delete(id, "person");
        }
    }
}
