using Microsoft.AspNetCore.Mvc;
using api_steelco;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace api_steelco.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UtentiController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private UtenteLogic u;
        public UtentiController(IConfiguration configuration)
        {
            _configuration = configuration;
            u = new UtenteLogic(_configuration);
        }

        // GET: api/<UtentiController>
        [HttpGet]
        public List<Utente> Get()
        {
            return u.GetUtenti();
        }

        // GET: api/<UtentiController>/5
        [HttpGet("{id}")]
        public IActionResult Get(string id)
        {
            var utente = u.GetUtente(id);
            if (utente is null)
            {
                return NotFound();
            }
            else
            {
                return Ok(utente);
            }
        }

        // POST api/<UtentiController>
        [HttpPost]
        public IActionResult Post([FromBody] Utente utente)
        {
            try
            {
                u.PostUtente(utente);
                return Ok();
            }
            catch (Exception e)
            {
                return Conflict(e.Message);
                throw;
            }
        }

        // DELETE api/<UtentiController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(string id)
        {
            try
            {
                u.DeleteUtente(id);
                return Ok();
            }
            catch (Exception e)
            {
                return NotFound(e.Message);
                throw;
            }
        }
    }
}
