using BZ2KMT_HFT_2021222.Logic;
using BZ2KMT_HFT_2021222.Logic.Classes;
using BZ2KMT_HFT_2021222.Models;
using System;
using System.Linq;

namespace BZ2KMT_HFT_2021222.Client
{
    public class CarClient
    {
        CarLogic carLogic;
        public CarClient(CarLogic carLogic)
        {
            this.carLogic = carLogic;
        }

        public void ReadAll()
        {
            var items = carLogic.ReadAll();
            Console.WriteLine("Id\tName\t\tModel");
            foreach (var item in items)
            {
                Console.WriteLine($"{item.CarId}\t{item.Brand.BrandName}\t\t{item.Model}");
            }
        }
        public void Read()
        {
            Console.Write("Give a car's id:");
            int id = int.Parse(Console.ReadLine());
            var car = carLogic.Read(id);
            Console.WriteLine("Id\tName\t\tModel");
            Console.WriteLine($"{car.CarId}\t{car.Brand.BrandName}\t\t{car.Model}");
        }
        public void Update()
        {
            Console.Write("\nEnter Car's id to update:");
            int id = int.Parse(Console.ReadLine());
            var car = carLogic.Read(id);
            Console.Write($"\nNew model name [old: {car.Model}]:");
            car.Model = Console.ReadLine();
            Console.Write($"\nNew type [old: {car.Type}]:");
            car.Type = Console.ReadLine();
            Console.Write($"\nNew fuel type [old: {car.FuelType}]:");
            car.FuelType = Console.ReadLine();
            Console.Write($"\nNew release year [old: {car.ReleaseYear}]:");
            car.ReleaseYear = int.Parse(Console.ReadLine());
            
            var brands = carLogic.ReadAll().GroupBy(x => x.Brand).OrderBy(x => x.Key.BrandId);

            Console.WriteLine($"\nPlease choose a new brand from listed above [old: {car.BrandId}:");

            foreach (var item in brands)
            {
                Console.WriteLine($"{item.Key.BrandId}. - {item.Key.BrandName}");
            }

            car.BrandId = int.Parse(Console.ReadLine());
            carLogic.Update(car);
        }
        public void Create()
        {
            Car car = new Car();
            Console.Write("Enter model name:");
            car.Model = Console.ReadLine();
            Console.Write("\nEnter car type:");
            car.Type = Console.ReadLine();
            Console.Write("\nEnter fuel type:");
            car.FuelType = Console.ReadLine();
            Console.Write("\nEnter release year:");
            car.ReleaseYear = int.Parse(Console.ReadLine());

            var brands = carLogic.ReadAll().GroupBy(x => x.Brand).OrderBy(x => x.Key.BrandId);

            Console.WriteLine("\nPlease choose a brand from listed above:");

            foreach (var item in brands)
            {
                Console.WriteLine($"{item.Key.BrandId}. - {item.Key.BrandName}");
            }

            car.BrandId = int.Parse(Console.ReadLine());

            carLogic.Create(car);
        }
        public void Delete()
        {
            Console.Write("\nPlease give an id to delete:");
            int id = int.Parse(Console.ReadLine());
            carLogic.Delete(id);
        }
    }
}
