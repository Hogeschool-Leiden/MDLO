using System.Collections.Generic;
using System.Linq;
using CompetentieAppFrontend.Domain;
using CompetentieAppFrontend.Infrastructure.Repositories;
using CompetentieAppFrontend.Services.Abstractions;
using CompetentieAppFrontend.Services.Commands;
using CompetentieAppFrontend.Services.Projections;
using CompetentieAppFrontend.Services.ViewModels;

namespace CompetentieAppFrontend.Services.Eventing
{
    public class CompetentieService : ICompetentieService
    {
        private readonly IArchitectuurLaagRepository _architectuurLaagRepository;
        private readonly IActiviteitRepository _activiteitRepository;
        private readonly IBeheersingsNiveauRepository _beheersingsNiveauRepository;
        private readonly ICompetentieRepository _competentieRepository;

        public CompetentieService(IArchitectuurLaagRepository architectuurLaagRepository,
            IActiviteitRepository activiteitRepository,
            IBeheersingsNiveauRepository beheersingsNiveauRepository,
            ICompetentieRepository competentieRepository)
        {
            _architectuurLaagRepository = architectuurLaagRepository;
            _activiteitRepository = activiteitRepository;
            _beheersingsNiveauRepository = beheersingsNiveauRepository;
            _competentieRepository = competentieRepository;
        }

        public void CreateCompetenties(CreateCompetentiesCommand command)
        {
            var beheersingsNiveaus = ExtractBeheersingsNiveaus(command.Competenties);
            var beheersingsNiveauIds = _beheersingsNiveauRepository.EnsureBeheersingsNiveausExist(beheersingsNiveaus);
            var competenties = ExtractCompetenties(beheersingsNiveauIds, command.ModuleId);
            _competentieRepository.CreateCompetenties(competenties);
        }

        private IEnumerable<BeheersingsNiveau> ExtractBeheersingsNiveaus(Matrix<int> competenties) =>
            (from architectuurLaag in competenties.XHeaders
            from activiteit in competenties.YHeaders
            select new BeheersingsNiveau
            {
                ArchitectuurLaagId = _architectuurLaagRepository.EnsureArchitectuurLaagExist(architectuurLaag),
                ActiviteitId = _activiteitRepository.EnsureActiviteitExist(activiteit),
                Niveau = competenties.ValueAt(architectuurLaag, activiteit)
            }).ToList();

        private static IEnumerable<Competentie> ExtractCompetenties(IEnumerable<long> beheersingsNiveauIds,
            long moduleId) =>
            beheersingsNiveauIds.Select(beheersingsNiveauId => new Competentie
            {
                ModuleId = moduleId,
                BeheersingsNiveauId = beheersingsNiveauId
            });
    }
}