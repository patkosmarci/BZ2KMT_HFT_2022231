using BZ2KMT_HFT_2021222.Logic.Classes;
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
    }
}
