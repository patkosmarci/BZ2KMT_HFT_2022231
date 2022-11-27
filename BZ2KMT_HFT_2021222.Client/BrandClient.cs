using BZ2KMT_HFT_2021222.Logic;
using BZ2KMT_HFT_2021222.Logic.Classes;
using BZ2KMT_HFT_2021222.Logic.Interfaces;
using BZ2KMT_HFT_2021222.Models;
using System;


namespace BZ2KMT_HFT_2021222.Client
{
    public class BrandClient
    {
        BrandLogic brandLogic;

        public BrandClient(BrandLogic brandLogic)
        {
            this.brandLogic = brandLogic;
        }
        public void ReadAll()
        {
            var items = brandLogic.ReadAll();
            Console.WriteLine("Id\tBrand");
            foreach (var item in items)
            {
                Console.WriteLine($"{item.BrandId}\t{item.BrandName}");
            }
        }
        public void Read()
        {
            Console.Write("Give a brand's id:");
            int id = int.Parse(Console.ReadLine());
            var brand = brandLogic.Read(id);
            Console.WriteLine("Id\tBrand");
            Console.WriteLine($"{brand.BrandId}\t{brand.BrandName}");
        }
        public void Update()
        {
            Console.Write("\nEnter a Brand's id to update:");
            int id = int.Parse(Console.ReadLine());
            var brand = brandLogic.Read(id);
            Console.Write($"New brand name [old: {brand.BrandName}:");
            brand.BrandName = Console.ReadLine();
            brandLogic.Update(brand);
        }
        public void Create()
        {
            Brand brand = new Brand();
            Console.Write("Enter a brand name:");
            brand.BrandName = Console.ReadLine();
            brandLogic.Create(brand);
        }
        public void Delete()
        {
            Console.Write("\nPlease give an id to delete:");
            int id = int.Parse(Console.ReadLine());
            brandLogic.Delete(id);
        }
    }
}
