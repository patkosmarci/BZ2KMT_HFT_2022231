using BZ2KMT_HFT_2021222.Models;
using BZ2KMT_HFT_2021222.Repository;
using System;
using System.Collections;
using System.Collections.Generic;

namespace BZ2KMT_HFT_2021222.Logic
{
    public class CarLogic
    {
        IRepository<Car> repository;
        public CarLogic(IRepository<Car> repository)
        {
            this.repository = repository;
        }

        public void Create(Car item)
        {
            if(item.Model == null)
            {
                throw new ArgumentNullException("You must need to give a modell name");
            }
            else
            {
                repository.Create(item);
            }
        }
        public Car Read(int id)
        {
            var car = repository.Read(id);
            if(car == null)
            {
                throw new ArgumentNullException("Car not exists");
            }
            return car;
        }
        public void Delete(int id)
        {
            repository.Delete(id);
        }
        public IEnumerable<Car> ReadAll()
        {
            return repository.ReadAll();
        }
        public void Update(Car item)
        {
            repository.Update(item);
        }
    }
}
