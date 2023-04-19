using Microsoft.AspNetCore.Mvc;
using api_steelco;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace api_steelco.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UtentiController : ControllerBase
    {
        // GET: api/<UtentiController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<UtentiController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<UtentiController>
        [HttpPost]
        public void Post([FromBody] Utente utente)
        {

        }

        // PUT api/<UtentiController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<UtentiController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
