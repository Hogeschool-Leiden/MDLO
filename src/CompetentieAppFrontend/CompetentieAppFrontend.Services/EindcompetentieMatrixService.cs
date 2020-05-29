using System.Collections.Generic;
using System.Linq;
using CompetentieAppFrontend.Domain;
using CompetentieAppFrontend.Infrastructure.Repositories;
using Microsoft.Extensions.Logging;

namespace CompetentieAppFrontend.Services
{
    public class EindcompetentieMatrixService : IMatrixService<Eindniveau>
    {
        private readonly ILogger<EindcompetentieMatrixService> _logger;
        private readonly IArchitectuurLaagRepository _architectuurLaagRepository;
        private readonly IActiviteitRepository _activiteitRepository;

        public EindcompetentieMatrixService(ILogger<EindcompetentieMatrixService> logger,
            IArchitectuurLaagRepository architectuurLaagRepository, 
            IActiviteitRepository activiteitRepository)
        {
            _logger = logger;
            _architectuurLaagRepository = architectuurLaagRepository;
            _activiteitRepository = activiteitRepository;
        }

        public Matrix<Eindniveau> CreateCompetentieMatrix(IEnumerable<Competentie> competenties)
        {
            var architectuurLaagNamen = _architectuurLaagRepository.GetAllArchitectuurLaagNamen();
            var activiteitNamen = _activiteitRepository.GetAllActiviteitNamen();
            // TODO: Filter eindcompetenties to be distinct on the eindcompetentie with the highest niveau.
            var eindcompetenties = competenties.Select(Eindcompetentie.FromCompetentie);
            return new Matrix<Eindniveau>(architectuurLaagNamen, activiteitNamen, eindcompetenties);
        }
    }
}