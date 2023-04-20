using Microsoft.AspNetCore.Mvc;
using api_steelco;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace api_steelco.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuestionarioController : ControllerBase
    {
        // GET: api/<QuestionarioController>
        [HttpGet]
        public List<Domanda> Get()
        {
            List<Domanda> list = DomandeLogic.GetDomande();
            return list;
        }

        // GET api/<QuestionarioController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            Domanda? domanda = DomandeLogic.GetDomanda(id);
            if (domanda != null)
            {
                return Ok(domanda);
            }
            else
            {
                return NotFound();
            }
        }

        // POST api/<QuestionarioController>
        [HttpPost]
        public IActionResult Post([FromBody] NuovaDomanda domanda)
        {
            return DomandeLogic.PostDomanda(domanda) ? Ok() : Conflict();
        }

        // PUT api/<QuestionarioController>/5
        [HttpPut("{id}")]
        public IActionResult Put([FromBody] Risposta risposta)
        {
            return RisposteLogic.PutRisposta(risposta) ? Ok() : NotFound();
        }

        // DELETE api/<QuestionarioController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            return DomandeLogic.DeleteDomanda(id) ? Ok() : NotFound();
        }
    }
}
