using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Demo.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;
        private readonly IDateTimeProvider _dateTimeProvider;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, IDateTimeProvider dateTimeProvider)
        {
            _logger = logger;
            _dateTimeProvider = dateTimeProvider;
        }

        [HttpGet]
        public IEnumerable<WeatherForecast> Get()
        {
            var random = new Random();
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
                {
                    Date = _dateTimeProvider.Now.AddDays(index),
                    TemperatureC = random.Next(-20, 55),
                    Summary = Summaries[random.Next(Summaries.Length)]
                })
                .ToArray();
        }
    }
}