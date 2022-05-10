using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ApiCertificateAuthClient.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        readonly IClientHttpService clientSvc;
        private readonly ILogger<WeatherForecastController> _logger;
        public TestController(ILogger<WeatherForecastController> logger, IClientHttpService clientHttpService)
        {
            _logger = logger;
            clientSvc = clientHttpService;
        }
        // GET: api/<TestCertificateController>
        [HttpGet]
        public async Task<JsonDocument> Get()
        {
            //return new string[] { "value1", "value2" };
            return await clientSvc.GetAsync();   
        }

        // GET api/<TestCertificateController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<TestCertificateController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<TestCertificateController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<TestCertificateController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
