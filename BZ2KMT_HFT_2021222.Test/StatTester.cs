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

        [SetUp]
        public void Init()
        {
            mockPersonRepository = new Mock<IRepository<Person>>();

        }
    }
}
