using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace api_steelco.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RisposteController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private RisposteLogic r;
        public RisposteController(IConfiguration configuration)
        {
            this._configuration = configuration;
            r = new RisposteLogic(_configuration);
        }

        // POST api/<RisposteController>
        [HttpPost]
        public IActionResult Post([FromBody] RisposteUtente risposta)
        {
            try
            {
                return Ok(r.VerificaRisposte(risposta));
            }
            catch (Exception e)
            {
                return NotFound(e.Message);
                throw;
            }
        }

        // PUT api/<RisposteController>
        [HttpPut]
        public IActionResult PutRisposta([FromBody] Risposta risposta)
        {
            try
            {
                return Ok("{Righe_affette: " + r.PutRisposta(risposta) + "}");
            }
            catch (Exception e)
            {
                return NotFound(e.Message);
                throw;
            }
        }
    }
}
