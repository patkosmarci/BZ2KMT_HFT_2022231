using BZ2KMT_HFT_2021222.Logic;
using BZ2KMT_HFT_2021222.Models;
using BZ2KMT_HFT_2021222.Repository;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BZ2KMT_HFT_2021222.Test
{
    [TestFixture]
    public class CarTester
    {
        CarLogic cl;
        Mock<IRepository<Car>> mockCarRepository;

        [SetUp]
        public void Init()
        {
            var inputdata = new List<Car>()
            {
                new Car("1#Swift#Sport#Petrol#1989#2"),
                new Car("2#Bora#Sedanl#Petro#2003#1"),
                new Car("3#Atreon#Sedanl#Diesel#2017#1"),
                new Car("4#Astra#Combi#Petrol#1997#3"),
                new Car("5#Camaro#Sport#Petrol#2004#5"),
                new Car("6#Cinquecento#Combi#Petrol#1989#4")
            }.AsQueryable();

            mockCarRepository = new Mock<IRepository<Car>>();
            mockCarRepository.Setup(m => m.ReadAll()).Returns(inputdata);
            mockCarRepository.Setup(m => m.Read(5)).Returns(inputdata.ElementAt(5));
            cl = new CarLogic(mockCarRepository.Object);
        }

        [Test]
        public void CreateCarTest1()
        {
            var sample = new Car("8#Orion#Sport#Petrol#2000#7");
            cl.Create(sample);

            mockCarRepository.Verify(m => m.Create(sample), Times.Once);
        }
        [Test]
        public void CreateCarTest2()
        {
            var sample = new Car("9#X#Combi#Petrol#2100#9");
            try
            {
                cl.Create(sample);
            }
            catch
            {

            }

            mockCarRepository.Verify(m => m.Create(sample), Times.Never);
        }
        [Test]
        public void ReadCarTest1()
        {
            cl.Read(5);
            mockCarRepository.Verify(m => m.Read(5), Times.Once);
        }
        [Test]
        public void ReadCarTest2()
        {
            mockCarRepository.Verify(m => m.Read(8), Times.Never);
        }
    }
}
