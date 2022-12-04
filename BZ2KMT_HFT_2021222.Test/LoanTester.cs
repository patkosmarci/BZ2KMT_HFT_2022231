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
    public class LoanTester
    {
        LoanLogic ll;
        Mock<IRepository<Loan>> mockLoanRepository;

        [SetUp]
        public void Init()
        {
            mockLoanRepository = new Mock<IRepository<Loan>>();
            ll = new LoanLogic(mockLoanRepository.Object);
        }
        [Test]
        public void CreateLoanTest1()
        {
            var sample = new Loan("1#2021-12-21#3#1#128");

            ll.Create(sample);
            mockLoanRepository.Verify(m => m.Create(sample), Times.Once);
        }
        [Test]
        public void CreateLoanTest2()
        {
            var sample = new Loan("1#2021-12-21#3#1#0");

            try
            {
                ll.Create(sample);
            }
            catch
            {

            }

            mockLoanRepository.Verify(m => m.Create(sample), Times.Never);
        }
    }
}
