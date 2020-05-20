using System.Collections.Generic;
using CompetentieAppFrontend.Domain;
using CompetentieAppFrontend.Infrastructure.Repositories;
using Microsoft.Extensions.Logging;

namespace CompetentieAppFrontend.Services
{
    public class EindCompetentieMatrixService : IEindCompetentieMatrixService
    {
        private ILogger<EindCompetentieMatrixService> _logger;
        private IEindCompetentieRepository _repository;

        public EindCompetentieMatrixService(ILogger<EindCompetentieMatrixService> logger, IEindCompetentieRepository repository)
        {
            _logger = logger;
            _repository = repository;
        }

        public IEnumerable<EindCompetentie> GetCompetentieMatrix(int periodeNummer, string specialisatieNaam)
        {
            return _repository.GetEindCompetenties(periodeNummer, specialisatieNaam);
        }
    }
}