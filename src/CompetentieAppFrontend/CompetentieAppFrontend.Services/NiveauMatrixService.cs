using System.Collections.Generic;
using System.Linq;
using CompetentieAppFrontend.Domain;
using CompetentieAppFrontend.Infrastructure.Repositories;
using Microsoft.Extensions.Logging;

namespace CompetentieAppFrontend.Services
{
    public class NiveauMatrixService : IMatrixService<int>
    {
        private readonly ILogger<NiveauMatrixService> _logger;
        private readonly IArchitectuurLaagRepository _architectuurLaagRepository;
        private readonly IActiviteitRepository _activiteitRepository;

        public NiveauMatrixService(ILogger<NiveauMatrixService> logger,
            IArchitectuurLaagRepository architectuurLaagRepository, IActiviteitRepository activiteitRepository)
        {
            _logger = logger;
            _architectuurLaagRepository = architectuurLaagRepository;
            _activiteitRepository = activiteitRepository;
        }

        public Matrix<int> CreateCompetentieMatrix(IEnumerable<Competentie> competenties)
        {
            var architectuurLaagNamen = _architectuurLaagRepository.GetAllArchitectuurLaagNamen();
            var activiteitNamen = _activiteitRepository.GetAllActiviteitNamen();
            var niveaus = competenties.Select(Niveau.FromCompetentie);
            return new Matrix<int>(architectuurLaagNamen, activiteitNamen, niveaus);
        }
    }
}