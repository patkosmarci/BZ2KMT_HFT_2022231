using BZ2KMT_HFT_2021222.Logic.Classes;
using BZ2KMT_HFT_2021222.Models;
using BZ2KMT_HFT_2021222.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace BZ2KMT_HFT_2021222.Client
{
    public class StatClient
    {
        RestService rest;

        public StatClient(string url)
        {
            rest = new RestService(url);
        }

        public void AvgCostByPerson()
        {
            List<AvgCostByPerson> avgCost = rest.Get<AvgCostByPerson>("/avgcostbyperson");
            List<Person> persons = rest.Get<Person>("/person");

            Console.WriteLine("Full name\t\tAverage cost");
            foreach (var item in avgCost)
            {
                foreach (var person in persons)
                {
                    if((person.FirstName + " " + person.LastName).Length >= 16)
                    {
                        if(item.PersonId == person.PersonId)
                            Console.WriteLine($"{person.FirstName + " " + person.LastName}\t{Math.Round((double)item.AvgCost, 0)}$");
                    }
                    else if((person.FirstName + " " + person.LastName).Length < 8)
                    {
                        if (item.PersonId == person.PersonId)
                            Console.WriteLine($"{person.FirstName + " " + person.LastName}\t\t\t{Math.Round((double)item.AvgCost, 0)}$");
                    }
                    else
                    {
                        if (item.PersonId == person.PersonId)
                            Console.WriteLine($"{person.FirstName + " " + person.LastName}\t\t{Math.Round((double)item.AvgCost, 0)}$");
                    }
                }
            }
        }
        public void BrandsWithCarReleaseDescending()
        {
            List<BrandsDescending> brands = rest.Get<BrandsDescending>("/brandswithcarreleasedescending");

            Console.Write("\nBrands\t\tYear\n");

            foreach (var item in brands)
            {
                Console.WriteLine($"{item.BrandName}{(item.BrandName.Length > 7 ? "\t" : "")}\t{item.AvgYear}");
            }
        }
        public void MaxCostForLoan()
        {
            List<PersonWithMaxCost> max = rest.Get<PersonWithMaxCost>("/maxcostforloan");
            foreach (var item in max)
            {
                Console.WriteLine($"Name: {item.FullName}\n\tMax cost: {item.MaxCost}");
            }
        }
        public void PersonWithMostLoans()
        {
            var person = rest.Get<Person>("/personswithmostloans");
            Console.WriteLine("Person with most loans:");
            foreach (var item in person)
            {
                Console.WriteLine(item.FirstName + " " + item.LastName + " Loans count: " + item.Loans.Count);
            }
        }
        public void PersonsLoanAccount()
        {
            List<PersonsLoanCount> personLoans = rest.Get<PersonsLoanCount>("/personsloancount");
            Console.WriteLine("Full name\t\tLoan count");
            foreach (var item in personLoans)
            {
                if(item.FullName.Length > 15)
                    Console.WriteLine($"{item.FullName}\t{item.LoanCount}");
                else if(item.FullName.Length < 8)
                    Console.WriteLine($"{item.FullName}\t\t\t{item.LoanCount}");
                else
                    Console.WriteLine($"{item.FullName}\t\t{item.LoanCount}");
            }
        }
    }
}
