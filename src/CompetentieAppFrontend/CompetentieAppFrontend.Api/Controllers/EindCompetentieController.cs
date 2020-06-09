using CompetentieAppFrontend.Infrastructure.Repositories;
using CompetentieAppFrontend.Services;
using CompetentieAppFrontend.Services.Projections;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CompetentieAppFrontend.Api.Controllers
{
    [ApiController]
    [Route("api/eindcompetentie")]
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
        [Route("{specialisatieNaam}/{periodeNummer}/{cohortNaam}")]
        public Matrix<Eindniveau> GetCompetentieMatrix([FromRoute] string specialisatieNaam,
            [FromRoute] int periodeNummer, [FromRoute] string cohortNaam)
        {
            _logger.LogInformation(
                $"Request received, specialisatie naam: {specialisatieNaam} and periode nummer: {periodeNummer}");

            return _service.GetEindcompetentieMatrixByCriteria(new ICompetentieRepository.Criteria
            {
                PeriodeNummer = periodeNummer,
                SpecialisatieNaam = specialisatieNaam,
                CohortNaam = cohortNaam
            });
        }
    }
}