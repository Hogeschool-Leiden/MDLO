using CompetentieAppFrontend.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CompetentieAppFrontend.Api.Controllers
{
    [ApiController]
    [Route("eindcompetentie")]
    public class EindCompetentieMatrixController : ControllerBase
    {
        private ILogger<EindCompetentieMatrixController> _logger;
        private IEindCompetentieMatrixService _service;

        public EindCompetentieMatrixController(ILogger<EindCompetentieMatrixController> logger,
            IEindCompetentieMatrixService service)
        {
            _logger = logger;
            _service = service;
        }

        [HttpGet]
        [Route("{specialisatieNaam}/{periodeNummer}")]
        public IActionResult GetCompetentieMatrix([FromRoute] string specialisatieNaam, [FromRoute] int periodeNummer)
        {
            _logger.LogInformation(
                $"Request received, specialisatie naam: {specialisatieNaam} and periode nummer: {periodeNummer}");

            return Ok(_service.GetEindCompetentieMatrix(periodeNummer, specialisatieNaam));
        }
    }
}