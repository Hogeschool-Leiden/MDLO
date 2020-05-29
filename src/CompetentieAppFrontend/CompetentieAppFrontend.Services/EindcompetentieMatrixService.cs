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
            var eindcompetenties = from eindcompetentie in competenties.Select(Eindcompetentie.FromCompetentie)
                group eindcompetentie by new {eindcompetentie.XHeader, eindcompetentie.YHeader}
                into groupedEindcompetentie
                select new Eindcompetentie(groupedEindcompetentie.Key.XHeader, groupedEindcompetentie.Key.YHeader,
                    new Eindniveau
                    {
                        Niveau = groupedEindcompetentie.ToList().Max(eindcompetentie => eindcompetentie.Value.Niveau),
                        Modules = groupedEindcompetentie.SelectMany(eindcompetentie => eindcompetentie.Value.Modules)
                    });
            return new Matrix<Eindniveau>(architectuurLaagNamen, activiteitNamen, eindcompetenties);
        }
    }
}