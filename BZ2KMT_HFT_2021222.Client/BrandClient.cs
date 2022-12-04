using BZ2KMT_HFT_2021222.Logic;
using BZ2KMT_HFT_2021222.Logic.Classes;
using BZ2KMT_HFT_2021222.Logic.Interfaces;
using BZ2KMT_HFT_2021222.Models;
using System;
using System.Collections.Generic;

namespace BZ2KMT_HFT_2021222.Client
{
    public class BrandClient
    {
        RestService rest;

        public BrandClient(string url)
        {
            rest = new RestService(url);
        }
        public void ReadAll()
        {
            List<Brand> brands = rest.Get<Brand>("brand");
            Console.WriteLine("Id\tBrand");
            foreach (var item in brands)
            {
                Console.WriteLine($"{item.BrandId}\t{item.BrandName}");
            }
        }
        public void Read()
        {
            Console.Write("Give a brand's id:");
            int id = int.Parse(Console.ReadLine());
            Brand brand = rest.Get<Brand>(id, "brand");
            Console.WriteLine("Id\tBrand");
            Console.WriteLine($"{brand.BrandId}\t{brand.BrandName}");
        }
        public void Update()
        {
            List<Brand> brands = rest.Get<Brand>("brand");
            Console.WriteLine("Id\tBrand");
            foreach (var item in brands)
            {
                Console.WriteLine($"{item.BrandId}\t{item.BrandName}");
            }

            Console.Write("\nPick a Brand's id to update:");
            int id = int.Parse(Console.ReadLine());
            Brand brand = rest.Get<Brand>(id, "brand");
            Console.Write($"New brand name [old: {brand.BrandName}:");
            brand.BrandName = Console.ReadLine();
            rest.Put(brand, "brand");
        }
        public void Create()
        {
            Brand brand = new Brand();
            Console.Write("Enter a brand name:");
            brand.BrandName = Console.ReadLine();
            rest.Post(brand, "brand");
        }
        public void Delete()
        {
            List<Brand> brands = rest.Get<Brand>("brand");
            Console.WriteLine("Id\tBrand");
            foreach (var item in brands)
            {
                Console.WriteLine($"{item.BrandId}\t{item.BrandName}");
            }

            Console.Write("\nPlease pick an id to delete:");
            int id = int.Parse(Console.ReadLine());
            rest.Delete(id, "brand");
        }
    }
}
