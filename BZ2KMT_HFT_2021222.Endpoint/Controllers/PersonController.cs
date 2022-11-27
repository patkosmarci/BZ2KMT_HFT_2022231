using BZ2KMT_HFT_2021222.Logic.Interfaces;
using BZ2KMT_HFT_2021222.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BZ2KMT_HFT_2021222.Endpoint.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        IPersonLogic logic;

        public PersonController(IPersonLogic logic)
        {
            this.logic = logic;
        }

        // GET: api/<PersonController>
        [HttpGet]
        public IEnumerable<Person> ReadAll()
        {
            return logic.ReadAll();
        }

        // GET api/<PersonController>/5
        [HttpGet("{id}")]
        public Person Read(int id)
        {
            return logic.Read(id);
        }

        // POST api/<PersonController>
        [HttpPost]
        public void Create([FromBody] Person value)
        {
            logic.Create(value);
        }

        // PUT api/<PersonController>/5
        [HttpPut]
        public void Update([FromBody] Person value)
        {
            logic.Update(value);
        }

        // DELETE api/<PersonController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            logic.Delete(id);
        }
    }
}
