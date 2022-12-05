using BZ2KMT_HFT_2021222.Logic.Classes;
using BZ2KMT_HFT_2021222.Logic.Interfaces;
using BZ2KMT_HFT_2021222.Models;
using BZ2KMT_HFT_2021222.Repository;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BZ2KMT_HFT_2021222.Endpoint.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class StatController : ControllerBase
    {
        IStatLogic logic;

        public StatController(IStatLogic logic)
        {
            this.logic = logic;
        }

        // GET: api/<StatController
        [HttpGet("/avgcostbyperson")]
        public IEnumerable<AvgCostByPerson> AvgCostByPerson()
        {
            return logic.AvgCostByPerson();
        }
        [HttpGet("/brandswithcarreleasedescending")]
        public IEnumerable<BrandsDescending> BrandsWithCarReleaseDescending()
        {
            return logic.BrandsWithCarReleaseDescending();
        }
        [HttpGet("/maxcostforloan")]
        public IEnumerable<PersonWithMaxCost> MaxCostForLoan()
        {
            return logic.MaxCostForLoan();
        }
        [HttpGet("/personswithmostloans")]
        public IEnumerable<Person> PersonsWithMostLoans()
        {
            return logic.PersonWithMostLoans();
        }
        [HttpGet("/personsloancount")]
        public IEnumerable<PersonsLoanCount> PersonsLoanCount()
        {
            return logic.PersonsLoanCount();
        }
    }
}
