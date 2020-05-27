using CompetentieAppFrontend.Domain;
using CompetentieAppFrontend.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CompetentieAppFrontend.Api.Controllers
{
    [ApiController]
    [Route("eindcompetentie")]
    public class EindCompetentieController
    {
        private ILogger<EindCompetentieController> _logger;
        private IEindCompetentieService _service;

        public EindCompetentieController(ILogger<EindCompetentieController> logger,
            IEindCompetentieService service)
        {
            _logger = logger;
            _service = service;
        }

        [HttpGet]
        [Route("{specialisatieNaam}/{periodeNummer}")]
        public CompetentieMatrix GetCompetentieMatrix([FromRoute] string specialisatieNaam,
            [FromRoute] int periodeNummer)
        {
            _logger.LogInformation(
                $"Request received, specialisatie naam: {specialisatieNaam} and periode nummer: {periodeNummer}");

            return _service.GetEindCompetentieMatrix(periodeNummer, specialisatieNaam);
        }
    }
}