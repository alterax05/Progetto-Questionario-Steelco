using Microsoft.AspNetCore.Mvc;

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

        // GET: api/<RisposteController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                int max_domande = await Task.Run(() => r.GetMaxDomande());
                return Ok(max_domande);
            }
            catch (Exception e)
            {
                return NotFound(e.Message);
                throw;
            }
        }

        // POST api/<RisposteController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] RisposteUtente risposta)
        {
            try
            {
                bool result = await Task.Run(() => r.VerificaRisposteAsync(risposta));
                return Ok(result);
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
                r.PutRisposta(risposta);
            }
            catch (Exception e)
            {
                return NotFound(e.Message);
                throw;
            }
            return Ok();
        }
    }
}
