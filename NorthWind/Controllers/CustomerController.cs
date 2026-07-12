using Microsoft.AspNetCore.Mvc;
using NorthWind.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace NorthWind.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        // GET: api/<CustomerController>
        [HttpGet]
        public CustomerViewModel Get()
        {
            return new CustomerViewModel();
        }

        // GET api/<CustomerController>/5
        [HttpGet("{id}")]
        public CustomerViewModel Get(int id)
        {
            return new CustomerViewModel();
        }

        // POST api/<CustomerController>
        [HttpPost]
        public void Post([FromBody] CustomerViewModel customerViewModel)
        {
        }

        // PUT api/<CustomerController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] CustomerViewModel customerViewModel)
        {
        }

        // DELETE api/<CustomerController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
