using System.Collections.Generic;
using System.Linq;
using CompetentieAppFrontend.Domain;
using CompetentieAppFrontend.Infrastructure.Repositories;
using CompetentieAppFrontend.Services.Abstractions;
using CompetentieAppFrontend.Services.ViewModels;
using Microsoft.Extensions.Logging;

namespace CompetentieAppFrontend.Services.Projections
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
            var eindcompetenties = MapToEindcompetenties(competenties);
            return new Matrix<Eindniveau>(architectuurLaagNamen, activiteitNamen, eindcompetenties);
        }

        private static IEnumerable<Eindcompetentie> MapToEindcompetenties(IEnumerable<Competentie> competenties)
        {
            return from competentie in competenties
                group competentie by new
                {
                    competentie.BeheersingsNiveau.ArchitectuurLaag.ArchitectuurLaagNaam,
                    competentie.BeheersingsNiveau.Activiteit.ActiviteitNaam
                }
                into groupedEindcompetentie
                select new Eindcompetentie(groupedEindcompetentie.Key.ArchitectuurLaagNaam,
                    groupedEindcompetentie.Key.ActiviteitNaam,
                    new Eindniveau
                    {
                        Niveau = groupedEindcompetentie.ToList()
                            .Max(competentie => competentie.BeheersingsNiveau.Niveau),
                        Modules = groupedEindcompetentie.Select(competentie => competentie.Module.ModuleCode)
                    });
        }
    }
}