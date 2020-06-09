using CompetentieAppFrontend.Domain;
using CompetentieAppFrontend.Infrastructure.Repositories;

namespace CompetentieAppFrontend.Services.Eventing
{
    public class ModuleEventsDeserializer : IModuleEventsDeserializer
    {
        private readonly ICohortRepository _cohortRepository;
        private readonly IModuleRepository _moduleRepository;
        private readonly IStudiefaseService _studiefaseService;
        private readonly ICompetentieService _competentieService;
        private readonly IEindeisService _eindeisService;

        public ModuleEventsDeserializer(ICohortRepository cohortRepository,
            IModuleRepository moduleRepository,
            IStudiefaseService studiefaseService,
            ICompetentieService competentieService,
            IEindeisService eindeisService)
        {
            _cohortRepository = cohortRepository;
            _moduleRepository = moduleRepository;
            _studiefaseService = studiefaseService;
            _competentieService = competentieService;
            _eindeisService = eindeisService;
        }

        public void CreateModule(ModuleGecreeerd @event)
        {
            var cohortId = EnsureCohortExist(@event.Cohort);
            var moduleId = CreateModule(@event, cohortId);

            CreateStudiefasen(@event, moduleId);
            CreateCompetenties(@event, moduleId);
            CreateEindeisen(@event, moduleId);
        }

        private long CreateModule(ModuleGecreeerd @event, long cohortId) =>
            _moduleRepository.CreateModule(new Module
            {
                ModuleCode = @event.ModuleCode,
                ModuleNaam = @event.ModuleNaam,
                CohortId = cohortId,
                Studiepunten = @event.AantalEc
            });

        private void CreateEindeisen(ModuleGecreeerd @event, long moduleId) =>
            _eindeisService.CreateEindeisen(new IEindeisService.CreateEindeisenCommand
            {
                ModuleId = moduleId,
                Beschrijvingen = @event.Eindeisen
            });

        private void CreateStudiefasen(ModuleGecreeerd @event, long moduleId) =>
            _studiefaseService.CreateStudiefasen(new IStudiefaseService.CreateStudiefasenCommand
            {
                ModuleId = moduleId,
                PeriodenNummers = @event.Studiefase.Perioden,
                VerplichtVoor = @event.VerplichtVoor,
                AanbevolenVoor = @event.AanbevolenVoor
            });

        private void CreateCompetenties(ModuleGecreeerd @event, long moduleId) =>
            _competentieService.CreateCompetenties(new ICompetentieService.CreateCompetentiesCommand
            {
                ModuleId = moduleId,
                Competenties = @event.Competenties
            });

        private long EnsureCohortExist(string cohort) =>
            _cohortRepository.EnsureCohortExist(cohort);
    }
}