using System.Collections.Generic;
using CompetentieAppFrontend.Domain;
using CompetentieAppFrontend.Infrastructure.Repositories;
using Microsoft.Extensions.Logging;

namespace CompetentieAppFrontend.Services
{
    public class EindCompetentieMatrixService : IEindCompetentieMatrixService
    {
        private ILogger<EindCompetentieMatrixService> _logger;
        private IMatrixRepository _repository;

        public EindCompetentieMatrixService(ILogger<EindCompetentieMatrixService> logger, IMatrixRepository repository)
        {
            _logger = logger;
            _repository = repository;
        }

        public IEnumerable<MatrixCell> GetCompetentieMatrix(int periodeNummer, string specialisatieNaam)
        {
            return _repository.GetCompetentieMatrix(periodeNummer, specialisatieNaam);
        }
    }
}