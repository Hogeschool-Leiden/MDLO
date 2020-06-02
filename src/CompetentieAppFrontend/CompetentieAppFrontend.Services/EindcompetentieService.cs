using CompetentieAppFrontend.Infrastructure.Repositories;
using Microsoft.Extensions.Logging;

namespace CompetentieAppFrontend.Services
{
    public class EindcompetentieService : IEindcompetentieService
    {
        private readonly ILogger<EindcompetentieService> _logger;
        private readonly ICompetentieRepository _competentieRepository;
        private readonly IMatrixService<Eindniveau> _matrixService;

        public EindcompetentieService(ILogger<EindcompetentieService> logger,
            ICompetentieRepository competentieRepository,
            IMatrixService<Eindniveau> matrixService)
        {
            _logger = logger;
            _competentieRepository = competentieRepository;
            _matrixService = matrixService;
        }

        public Matrix<Eindniveau> GetEindcompetentieMatrixByCriteria(ICompetentieRepository.Criteria criteria)
        {
            _logger.LogTrace($"Retrieving competentie-matrix: {criteria.SpecialisatieNaam} in periode: {criteria.PeriodeNummer}");
            var competenties = _competentieRepository.GetAllCompetentiesByCriteria(criteria);
            return _matrixService.CreateCompetentieMatrix(competenties);
        }
    }
}