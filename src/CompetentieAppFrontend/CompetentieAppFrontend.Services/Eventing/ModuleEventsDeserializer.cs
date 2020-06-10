using System;
using CompetentieAppFrontend.Domain;
using CompetentieAppFrontend.Infrastructure.Repositories;
using CompetentieAppFrontend.Services.Abstractions;
using CompetentieAppFrontend.Services.Commands;
using CompetentieAppFrontend.Services.Events;
using RabbitMQ.Client;

namespace CompetentieAppFrontend.Services.Eventing
{
    public class ModuleEventsDeserializer : IModuleEventsDeserializer
    {
        private readonly ICohortRepository _cohortRepository;
        private readonly IModuleRepository _moduleRepository;
        private readonly IStudiefaseService _studiefaseService;
        private readonly ICompetentieService _competentieService;
        private readonly IEindeisService _eindeisService;
        private readonly IAuditLogEntryRepository _auditLogRepository;

        public ModuleEventsDeserializer(ICohortRepository cohortRepository,
            IModuleRepository moduleRepository,
            IStudiefaseService studiefaseService,
            ICompetentieService competentieService,
            IEindeisService eindeisService,
            IAuditLogEntryRepository auditLogRepository)
        {
            _cohortRepository = cohortRepository;
            _moduleRepository = moduleRepository;
            _studiefaseService = studiefaseService;
            _competentieService = competentieService;
            _eindeisService = eindeisService;
            _auditLogRepository = auditLogRepository;
        }

        public void CreateModule(ModuleGecreeerd @event)
        {
            var cohortId = EnsureCohortExist(@event.Cohort);
            var moduleId = CreateModule(@event, cohortId);

            CreateStudiefasen(@event, moduleId);
            CreateCompetenties(@event, moduleId);
            CreateEindeisen(@event, moduleId);
            CreateAuditLogEntry(@event, moduleId);
        }

        private void CreateAuditLogEntry(ModuleGecreeerd @event, long moduleId)
        {
            _auditLogRepository.Create(new AuditLogEntry
            {
                ModuleId = moduleId,
                Omschrijving = $"{@event.Type} on {@event.ModuleCode} in cohort {@event.Cohort}",
                Timestamp = new DateTime(@event.Timestamp)
            });
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
            _eindeisService.CreateEindeisen(new CreateEindeisenCommand
            {
                ModuleId = moduleId,
                Beschrijvingen = @event.Eindeisen
            });

        private void CreateStudiefasen(ModuleGecreeerd @event, long moduleId) =>
            _studiefaseService.CreateStudiefasen(new CreateStudiefasenCommand
            {
                ModuleId = moduleId,
                PeriodenNummers = @event.Studiefase.Perioden,
                VerplichtVoor = @event.VerplichtVoor,
                AanbevolenVoor = @event.AanbevolenVoor
            });

        private void CreateCompetenties(ModuleGecreeerd @event, long moduleId) =>
            _competentieService.CreateCompetenties(new CreateCompetentiesCommand
            {
                ModuleId = moduleId,
                Competenties = @event.Competenties.ToMatrix()
            });

        private long EnsureCohortExist(string cohort) =>
            _cohortRepository.EnsureCohortExist(cohort);
    }
}