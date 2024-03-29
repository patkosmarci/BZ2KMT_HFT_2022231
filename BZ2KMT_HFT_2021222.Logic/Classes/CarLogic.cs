﻿using BZ2KMT_HFT_2021222.Logic.Interfaces;
using BZ2KMT_HFT_2021222.Models;
using BZ2KMT_HFT_2021222.Repository;
using System;
using System.Collections;
using System.Collections.Generic;

namespace BZ2KMT_HFT_2021222.Logic
{
    public class CarLogic : ICarLogic
    {
        IRepository<Car> repository;
        public CarLogic(IRepository<Car> repository)
        {
            this.repository = repository;
        }

        public void Create(Car car)
        {
            if (car.ReleaseYear > DateTime.Now.Year)
            {
                throw new ArgumentException("Release year must be between 1900 and 2100");
            }
            
            repository.Create(car);
        }
        public Car Read(int id)
        {
            var car = repository.Read(id);
            if(car == null)
                throw new ArgumentNullException("Car not exists");
            else
                return car;
        }
        public void Delete(int id)
        {
            var car = repository.Read(id);
            if (car == null)
                throw new ArgumentNullException($"Car with {id} not exists");
            else
                repository.Delete(id);
        }
        public IEnumerable<Car> ReadAll()
        {
            return repository.ReadAll();
        }
        public void Update(Car car)
        {
            repository.Update(car);
        }
    }
}
