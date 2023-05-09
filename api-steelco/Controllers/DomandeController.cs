using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace api_steelco.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DomandeController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private DomandeLogic d;
        public DomandeController(IConfiguration configuration)
        {
            _configuration = configuration;
            d = new DomandeLogic(_configuration);

        }
        // GET: api/<DomandeController>
        [Authorize]
        [HttpGet]
        public List<Domanda> GetDomande()
        {
            return d.GetDomande();
        }

        // GET api/<DomandeController>/5
        [HttpGet("{id}")]
        public IActionResult GetDomanda(int id)
        {
            Domanda? domanda = d.GetDomanda(id);
            if (domanda != null)
            {
                return Ok(domanda);
            }
            else
            {
                return NotFound();
            }
        }

        // POST api/<DomandeController>
        [HttpPost]
        public IActionResult PostDomanda([FromBody] NuovaDomanda domanda)
        {
            try
            {
                return Ok("{Righe_affette: " + d.PostDomanda(domanda) + "}");
            }
            catch (Exception e)
            {
                return Conflict(e.Message);
                throw;
            }
        }

        // PUT api/<DomandeController>/5
        [HttpPut]
        public IActionResult PutDomande([FromBody] Domanda domanda)
        {
            try
            {
                return Ok("{Righe_affette: " + d.PutDomanda(domanda) + "}");
            }
            catch (Exception e)
            {
                return NotFound(e.Message);
                throw;
            }
        }

        // DELETE api/<DomandeController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                return Ok("{Righe_affette: " + d.DeleteDomanda(id) + "}");
            }
            catch (Exception e)
            {
                NotFound(e.Message);
                throw;
            }
        }
    }
}
