using Microsoft.AspNetCore.Mvc;

namespace RestaurantAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {

        private readonly IWeatherForecastService _service;
        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, IWeatherForecastService service)
        {
            _logger = logger;
            _service = service;
        }

        [HttpGet]
        public IEnumerable<WeatherForecast> Get()
        {
            var result = _service.Get(5, -30, 50);
            return result;
        }

        /*[HttpGet]
        [Route("currentDay")]*/
        /*[HttpGet("currentDay/{max}")]
        public IEnumerable<WeatherForecast> Get2([FromQuery] int take, [FromRoute] int max)
        {
            var result = _service.Get();
            return result;
        }*/

        /*[HttpPost]
        public string Hello([FromBody] string name)
        {
            return $"Hello {name}";
        }*/

        [HttpPost]
        public ActionResult<string> Hello([FromBody] string name)
        {
            //HttpContext.Response.StatusCode = 401; <- to nie dzia³a
            //return $"Hello {name}";

            //return StatusCode(401, $"Hello {name}");

            return NotFound($"Hello {name}");
        }

        [HttpPost("generate")]
        public ActionResult<IEnumerable<WeatherForecast>> Generate([FromQuery]int count,
            [FromBody]TemperatureRequest request)
        {
            if (count < 0)
            {
                return BadRequest($"Result number must be positive number");
            }

            if (request.Min > request.Max)
            {
                return BadRequest($"Max temp must be higher than min temp");
            }

            var result = _service.Get(count, request.Min, request.Max);
            return Ok(result);
        }
    }
}