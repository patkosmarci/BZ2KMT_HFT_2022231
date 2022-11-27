using BZ2KMT_HFT_2021222.Logic.Interfaces;
using BZ2KMT_HFT_2021222.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BZ2KMT_HFT_2021222.Endpoint.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CarController : ControllerBase
    {
        ICarLogic logic;

        public CarController(ICarLogic logic)
        {
            this.logic = logic;
        }

        // GET: api/<CarController>
        [HttpGet]
        public IEnumerable<Car> ReadAll()
        {
            return logic.ReadAll();
        }

        // GET api/<CarController>/5
        [HttpGet("{id}")]
        public Car Read(int id)
        {
            return logic.Read(id);
        }

        // POST api/<CarController>
        [HttpPost]
        public void Post([FromBody] Car value)
        {
            logic.Create(value);
        }

        // PUT api/<CarController>/5
        [HttpPut]
        public void Update([FromBody] Car value)
        {
            logic.Update(value);
        }

        // DELETE api/<CarController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            logic.Delete(id);
        }
    }
}
