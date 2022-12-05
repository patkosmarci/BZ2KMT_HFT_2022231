using BZ2KMT_HFT_2021222.Logic.Classes;
using BZ2KMT_HFT_2021222.Models;
using BZ2KMT_HFT_2021222.Repository;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BZ2KMT_HFT_2021222.Test
{
    [TestFixture]
    public class StatTester
    {
        StatLogic sl;
        Mock<IRepository<Person>> mockPersonRepository;
        Mock<IRepository<Loan>> mockLoanRepository;
        Mock<IRepository<Brand>> mockBrandRepository;
        List<Person> persons;
        List<Loan> loans;
        List<Car> cars;
        List<Brand> brands;

        [SetUp]
        public void Init()
        {
            mockPersonRepository = new Mock<IRepository<Person>>();
            mockLoanRepository = new Mock<IRepository<Loan>>();
            mockBrandRepository = new Mock<IRepository<Brand>>();

            persons = new List<Person>()
            {
                new Person("1#Walter#White#Albaquerque 303699 Pizza Street 42#+35234124123567#12341234#51234151"),
                new Person("2#Horváth#Benjámin#Budapest 1131 Kőfejtő utca 32#+363082341249#84131484#5154245"),
                new Person("3#John#Doe#Kistarcsa 4851 Eger utca 48#+36704229123#86345692#3521352"),
                new Person("4#Emily#White#Albaquerque 303699 Pizza Street#+352381248213#84184823#7462937"),
            };
            loans = new List<Loan>()
            {
                new Loan("1#2021-12-21#3#1#128"),
                new Loan("2#2021-10-30#2#2#212"),
                new Loan("3#2019-05-03#5#3#50"),
                new Loan("4#2011-07-12#4#4#98"),
                new Loan("5#2000-12-22#6#4#330"),
                new Loan("12#2022-08-05#5#2#240"),
                new Loan("13#1998-10-09#8#4#440"),
            };
            brands = new List<Brand>()
            {
                new Brand("1#Volkswagen"),
                new Brand("2#Suzuki"),
                new Brand("3#Opel"),
                new Brand("4#Fiat"),
                new Brand("5#Chevrolet"),
                new Brand("6#Ford"),
                new Brand("7#Peugeot"),
            };
            cars = new List<Car>()
            {
                new Car("1#Swift#Sport#Petrol#1989#2"),
                new Car("2#Bora#Sedanl#Petro#2003#1"),
                new Car("3#Atreon#Sedanl#Diesel#2017#1"),
                new Car("4#Astra#Combi#Petrol#1997#3"),
                new Car("5#Camaro#Sport#Petrol#2004#5"),
                new Car("6#Cinquecento#Combi#Petrol#1989#4"),
                new Car("7#200#Combi#Diesel#2006#7"),
                new Car("8#Mondeo#Combi#Diesel#2006#6"),
            };
            foreach (var item in loans)
            {
                item.Person = persons.Where(x => x.PersonId == item.PersonId).ToList().First();
                item.Car = cars.Where(x => x.CarId == item.CarId).ToList().First();
            }
            foreach (var item in persons)
            {
                item.Loans = loans.Where(x => x.PersonId == item.PersonId).ToList();
            }
            foreach (var item in cars)
            {
                item.Brand = brands.Where(x => x.BrandId == item.BrandId).ToList().First();
            }
            foreach (var item in brands)
            {
                item.Cars = cars.Where(x => x.BrandId == item.BrandId).ToList();
            }

            mockPersonRepository.Setup(m => m.ReadAll()).Returns(persons.AsQueryable());

            mockLoanRepository.Setup(m => m.ReadAll()).Returns(loans.AsQueryable());

            mockBrandRepository.Setup(m => m.ReadAll()).Returns(brands.AsQueryable());

            sl = new StatLogic(mockLoanRepository.Object, mockPersonRepository.Object, mockBrandRepository.Object);
        }
        [Test]
        public void AvgCostByPersonTest()
        {
            List<AvgCostByPerson> avgCost = sl.AvgCostByPerson().ToList();
            var expected = new List<AvgCostByPerson>()
            {
                new AvgCostByPerson(1, 128),
                new AvgCostByPerson(2, 226),
                new AvgCostByPerson(3, 50),
                new AvgCostByPerson(4, 289.33333333333331),
            };

            Assert.AreEqual(avgCost, expected);
        }
        [Test]
        public void MaxCostForLoanTest()
        {
            List<PersonWithMaxCost> maxCost = sl.MaxCostForLoan().ToList();
            var expected = new List<PersonWithMaxCost>()
            {
                new PersonWithMaxCost("Walter White", 128),
                new PersonWithMaxCost("Horváth Benjámin", 240),
                new PersonWithMaxCost("John Doe", 50),
                new PersonWithMaxCost("Emily White", 440),
            };

            Assert.AreEqual(maxCost, expected);
        }
        [Test]
        public void PersonWithMostLoansTest()
        {
            Person personWithMostLoans = sl.PersonWithMostLoans().First();
            var expected = new Person("4#Emily#White#Albaquerque 303699 Pizza Street#+352381248213#84184823#7462937");

            Assert.AreEqual(personWithMostLoans, expected);
        }
        [Test]
        public void BrandsWithCarReleaseDescendingTest()
        {
            List<BrandsDescending> descendingBrands = sl.BrandsWithCarReleaseDescending().ToList();

            var expected = new List<BrandsDescending>()
            {
                new BrandsDescending("Volkswagen", 2010),
                new BrandsDescending("Ford", 2006),
                new BrandsDescending("Peugeot", 2006),
                new BrandsDescending("Chevrolet", 2004),
                new BrandsDescending("Opel", 1997),
                new BrandsDescending("Suzuki",1989),
                new BrandsDescending("Fiat",1989),
            };

            Assert.AreEqual(descendingBrands, expected);
        }
        [Test]
        public void PersonsLoanCountTest()
        {
            List<PersonsLoanCount> loanCount = sl.PersonsLoanCount().ToList();

            var expected = new List<PersonsLoanCount>()
            {
                new PersonsLoanCount("Walter White", 1),
                new PersonsLoanCount("Horváth Benjámin", 2),
                new PersonsLoanCount("John Doe", 1),
                new PersonsLoanCount("Emily White", 3),
            };

            Assert.AreEqual(loanCount, expected);
        }
    }
}
