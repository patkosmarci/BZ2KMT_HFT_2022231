using BZ2KMT_HFT_2021222.Logic.Interfaces;
using BZ2KMT_HFT_2021222.Models;
using BZ2KMT_HFT_2021222.Repository;
using System;
using System.Collections.Generic;

namespace BZ2KMT_HFT_2021222.Logic.Classes
{
    public class BrandLogic : IBrandLogic
    {
        IRepository<Brand> repository;

        public BrandLogic(IRepository<Brand> repository)
        {
            this.repository = repository;
        }

        public void Create(Brand brand)
        {
            if (brand.BrandName == "")
                throw new ArgumentNullException("You must add a brand name");
            else
                repository.Create(brand);
        }
        public Brand Read(int id)
        {
            var brand = repository.Read(id);
            if(brand == null)
                throw new ArgumentNullException("Brand not exist");
            else
                return brand;
        }
        public void Delete(int id)
        {
            var brand = repository.Read(id);
            if (brand == null)
                throw new ArgumentNullException($"Brand with {id} not exist");
            else
                repository.Delete(id);
        }
        public IEnumerable<Brand> ReadAll()        
        {
            return repository.ReadAll();
        }
        public void Update(Brand brand)
        {
            repository.Update(brand);
        }
    }
}
