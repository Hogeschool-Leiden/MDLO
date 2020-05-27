using System.Linq;
using CompetentieAppFrontend.Domain;
using CompetentieAppFrontend.Infrastructure.Repositories;
using Microsoft.Extensions.Logging;

namespace CompetentieAppFrontend.Services
{
    public class EindCompetentieService : IEindCompetentieService
    {
        private readonly ILogger<EindCompetentieService> _logger;
        private readonly IEindCompetentieRepository _eindCompetentieRepository;
        private readonly IArchitectuurLaagRepository _architectuurLaagRepository;
        private readonly IActiviteitRepository _activiteitRepository;

        public EindCompetentieService(ILogger<EindCompetentieService> logger,
            IEindCompetentieRepository eindCompetentieRepository,
            IArchitectuurLaagRepository architectuurLaagRepository,
            IActiviteitRepository activiteitRepository)
        {
            _logger = logger;
            _eindCompetentieRepository = eindCompetentieRepository;
            _architectuurLaagRepository = architectuurLaagRepository;
            _activiteitRepository = activiteitRepository;
        }

        public CompetentieMatrix GetEindCompetentieMatrix(int periodeNummer, string specialisatieNaam)
        {
            _logger.LogInformation(
                $"Retrieving eind competenties for specialisatie: {specialisatieNaam} in periode: {periodeNummer}");
            var architectuurLaagNamen = _architectuurLaagRepository.GetAllArchitectuurLaagNamen().ToList();
            var activiteitNamen = _activiteitRepository.GetAllActiviteitNamen().ToList();
            var eindCompetenties = _eindCompetentieRepository.GetEindCompetenties(periodeNummer, specialisatieNaam)
                .ToList();
            return new CompetentieMatrix(architectuurLaagNamen, activiteitNamen, eindCompetenties.ToList());
        }
    }
}