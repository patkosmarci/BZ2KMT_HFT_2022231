using BZ2KMT_HFT_2021222.Logic.Classes;
using BZ2KMT_HFT_2021222.Models;
using BZ2KMT_HFT_2021222.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
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
            List<AvgCostByPerson> avgCost = rest.Get<AvgCostByPerson>("stat/avgcostbyperson");

            Console.WriteLine("Full name\tAverage cost");
            foreach (var item in avgCost)
            {
                Console.WriteLine($"{item.RentalName}\t{item.AvgCost}$");
            }
        }
        public void BrandsWithCarReleaseDescending()
        {
            List<Brand> brands = rest.Get<Brand>("stat/BrandsWithCarReleaseDescending");

            Console.Write("\tBrands");

            foreach (var item in brands)
            {
                Console.WriteLine($"{item.BrandId}\t{item.BrandName}");
            }
        }
        public void MaxCostForLoan()
        {
            var objects = rest.Get<object>("stat/MaxCostForLoan");
            Console.WriteLine("Max cost for loan:");
            foreach (var item in objects)
            {
                Console.WriteLine(item);
            }
        }
        public void PersonWithMostLoans()
        {
            var person = rest.Get<Person>("stat/PersonWithMostLoans");
            Console.WriteLine("Person with most loans:");
            foreach (var item in person)
            {
                Console.WriteLine(item.FirstName + item.LastName);
            }
        }
    }
}
