using BZ2KMT_HFT_2021222.Logic;
using System;

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
    }
}
