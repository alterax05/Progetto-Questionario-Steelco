using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace api_steelco.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DBController : ControllerBase
    {
        // GET: api/<DBController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<DBController>/5
        [HttpGet("{id_risposta_corretta}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<DBController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<DBController>/5
        [HttpPut("{id_risposta_corretta}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<DBController>/5
        [HttpDelete("{id_risposta_corretta}")]
        public void Delete(int id)
        {
        }
    }
}
