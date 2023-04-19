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
        public List<Utente> Get()
        {
            return UtenteLogic.GetUtenti();
        }

        // GET api/<UtentiController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            Utente? utente = UtenteLogic.GetUtente(id);
            if (utente != null)
            {
                return Ok(utente);
            }
            else
            {
                return NotFound();
            }
        }

        // POST api/<UtentiController>
        [HttpPost]
        public IActionResult Post([FromBody] Utente utente)
        {
            return UtenteLogic.PostUtente(utente) ? Ok() : Conflict();
        }

        //// PUT api/<UtentiController>/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{

        //}

        // DELETE api/<UtentiController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            return UtenteLogic.DeleteUtente(id) ? Ok() : NotFound();
        }
    }
}
