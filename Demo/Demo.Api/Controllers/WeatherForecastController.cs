using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
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
        private readonly IRandomProvider _randomProvider;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, IDateTimeProvider dateTimeProvider,
            IRandomProvider randomProvider)
        {
            _logger = logger;
            _dateTimeProvider = dateTimeProvider;
            _randomProvider = randomProvider;
        }

        [EnableCors("AllowAllHeaders")]
        [HttpGet]
        public IEnumerable<WeatherForecast> Get() =>
            Enumerable.Range(1, 5).Select(index => new WeatherForecast
                {
                    Date = _dateTimeProvider.Now.AddDays(index),
                    TemperatureC = _randomProvider.Next(-20, 55),
                    Summary = Summaries[_randomProvider.Next(Summaries.Length)]
                })
                .ToArray();
    }
}