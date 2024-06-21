using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ServiceCore.Utilities;

namespace ServiceCore
{
    [ApiController]
    [Route("api/wake-up")]
    [AllowAnonymous]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<WeatherForecast> Get()
        {
            var rng = new Random();
            // Console.WriteLine("Woke up at " + DateTime.Now.ToString("dd-MM-yyyy HH:mm:ss"));
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            })
            .ToArray();
        }
        [HttpGet("round")]
        public IActionResult Round([FromQuery] Dictionary<string, string> QueryString)
        {
            var Check = QueryString.TryGetValue("number", out var NumberString);
            if (Check)
            {
                var CheckDouble = Double.TryParse(NumberString, out var Number);
                if (CheckDouble)
                {
                    return Ok(Number);
                }
            }
            return BadRequest();
        }
    }
}
