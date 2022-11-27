using BZ2KMT_HFT_2021222.Logic.Interfaces;
using BZ2KMT_HFT_2021222.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BZ2KMT_HFT_2021222.Endpoint.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class BrandController : ControllerBase
    {
        IBrandLogic logic;

        public BrandController(IBrandLogic logic)
        {
            this.logic = logic;
        }

        // GET: api/<BrandController>
        [HttpGet]
        public IEnumerable<Brand> ReadAll()
        {
            return logic.ReadAll();
        }

        // GET api/<BrandController>/5
        [HttpGet("{id}")]
        public Brand Read(int id)
        {
            return logic.Read(id);
        }

        // POST api/<BrandController>
        [HttpPost]
        public void Brand([FromBody] Brand value)
        {
            logic.Create(value);
        }

        // PUT api/<BrandController>/5
        [HttpPut]
        public void Update([FromBody] Brand value)
        {
            logic.Update(value);
        }

        // DELETE api/<BrandController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            logic.Delete(id);
        }
    }
}
