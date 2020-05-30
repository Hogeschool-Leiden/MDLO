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
        private IEindcompetentieService _service;

        public EindCompetentieController(ILogger<EindCompetentieController> logger,
            IEindcompetentieService service)
        {
            _logger = logger;
            _service = service;
        }

        [HttpGet]
        [Route("{specialisatieNaam}/{periodeNummer}")]
        public Matrix<Eindniveau> GetCompetentieMatrix([FromRoute] string specialisatieNaam,
            [FromRoute] int periodeNummer)
        {
            _logger.LogInformation(
                $"Request received, specialisatie naam: {specialisatieNaam} and periode nummer: {periodeNummer}");

            return _service.GetEindcompetentieMatrixByCriteria(periodeNummer, specialisatieNaam);
        }
    }
}