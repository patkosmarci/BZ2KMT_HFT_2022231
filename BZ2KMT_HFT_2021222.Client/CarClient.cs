using BZ2KMT_HFT_2021222.Logic;
using BZ2KMT_HFT_2021222.Logic.Classes;
using BZ2KMT_HFT_2021222.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BZ2KMT_HFT_2021222.Client
{
    public class CarClient
    {
        RestService rest;
        public CarClient(string url)
        {
            rest = new RestService(url);
        }

        public void ReadAll()
        {
            List<Car> cars = rest.Get<Car>("car");
            Console.WriteLine("Id\tName\t\tModel");
            foreach (var item in cars)
            {
                Console.WriteLine($"{item.CarId}\t{item.Brand.BrandName}\t\t{item.Model}");
            }
        }
        public void Read()
        {
            Console.Write("\nPick a car's id:");
            int id = int.Parse(Console.ReadLine());
            Car car = rest.Get<Car>(id, "car");
            Console.WriteLine("Id\tName\t\tModel");
            Console.WriteLine($"{car.CarId}\t{car.Brand.BrandName}\t\t{car.Model}");
        }
        public void Update()
        {
            List<Car> cars = rest.Get<Car>("car");
            Console.WriteLine("Id\tName\t\tModel");
            foreach (var item in cars)
            {
                Console.WriteLine($"{item.CarId}\t{item.Brand.BrandName}\t\t{item.Model}");
            }
            Console.Write("\nEnter Car's id to update:");
            int id = int.Parse(Console.ReadLine());
            Car car = rest.Get<Car>(id, "car");
            Console.Write($"\nNew model name [old: {car.Model}]:");
            car.Model = Console.ReadLine();
            Console.Write($"\nNew type [old: {car.Type}]:");
            car.Type = Console.ReadLine();
            Console.Write($"\nNew fuel type [old: {car.FuelType}]:");
            car.FuelType = Console.ReadLine();
            Console.Write($"\nNew release year [old: {car.ReleaseYear}]:");
            car.ReleaseYear = int.Parse(Console.ReadLine());

            List<Brand> brands = rest.Get<Brand>("brand");

            Console.WriteLine($"\nPlease choose a new brand from listed above [old: {car.BrandId}:");

            foreach (var item in brands)
            {
                Console.WriteLine($"{item.BrandId}. - {item.BrandName}");
            }

            car.BrandId = int.Parse(Console.ReadLine());
            rest.Put(car, "car");
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

            List<Brand> brands = rest.Get<Brand>("brand");

            Console.WriteLine("\nPlease choose a brand from listed above:");

            foreach (var item in brands)
            {
                Console.WriteLine($"{item.BrandId}. - {item.BrandName}");
            }

            car.BrandId = int.Parse(Console.ReadLine());

            rest.Post(car, "car");
        }
        public void Delete()
        {
            List<Car> cars = rest.Get<Car>("car");
            Console.WriteLine("Id\tName\t\tModel");
            foreach (var item in cars)
            {
                Console.WriteLine($"{item.CarId}\t{item.Brand.BrandName}\t\t{item.Model}");
            }
            Console.Write("\nPlease give an id to delete:");
            int id = int.Parse(Console.ReadLine());
            rest.Delete(id, "car");
        }
    }
}
