using Microsoft.AspNetCore.Mvc;

namespace Demo.LoadTesting.Locust.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly ILogger<ValuesController> _logger;

        public ValuesController(ILogger<ValuesController> logger)
        {
            _logger = logger;
            _logger.LogInformation("Instantiated {0}", nameof(ValuesController));
        }

        [HttpGet]
        public IActionResult GetFast()
        {
            _logger.LogInformation("Invoked {0}", nameof(GetFast));
            return Ok("Hello World");
        }

        [HttpGet("slow")]
        public async Task<IActionResult> GetSlow()
        {
            _logger.LogInformation("Invoked {0}", nameof(GetSlow));
            await Task.Delay(3000);
            return Ok("Hello World");
        }
    }
}
