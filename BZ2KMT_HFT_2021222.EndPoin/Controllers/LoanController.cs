using BZ2KMT_HFT_2021222.Logic.Classes;
using BZ2KMT_HFT_2021222.Logic.Interfaces;
using BZ2KMT_HFT_2021222.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BZ2KMT_HFT_2021222.Endpoint.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class LoanController : ControllerBase
    {
        ILoanLogic logic;

        public LoanController(ILoanLogic logic)
        {
            this.logic = logic;
        }

        // GET: api/<LoanController>
        [HttpGet]
        public IEnumerable<Loan> ReadAll()
        {
            return logic.ReadAll();
        }

        // GET api/<LoanController>/5
        [HttpGet("{id}")]
        public Loan Read(int id)
        {
            return logic.Read(id);
        }

        // POST api/<LoanController>
        [HttpPost]
        public void Create([FromBody] Loan value)
        {
            logic.Create(value);
        }

        // PUT api/<LoanController>/5
        [HttpPut]
        public void Update([FromBody] Loan value)
        {
            logic.Update(value);
        }

        // DELETE api/<LoanController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            logic.Delete(id);
        }
    }
}
