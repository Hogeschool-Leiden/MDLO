using System.Collections.Generic;
using System.Linq;
using CompetentieAppFrontend.Domain;
using CompetentieAppFrontend.Infrastructure.Repositories;
using CompetentieAppFrontend.Services.Abstractions;
using CompetentieAppFrontend.Services.ViewModels;
using Microsoft.Extensions.Logging;

namespace CompetentieAppFrontend.Services.Projections
{
    public class ModuleService : IModuleService
    {
        private readonly ILogger<EindcompetentieService> _logger;
        private readonly IMatrixService<int> _matrixService;
        private readonly IModuleRepository _moduleRepository;

        public ModuleService(ILogger<EindcompetentieService> logger,
            IMatrixService<int> service,
            IModuleRepository moduleRepository)
        {
            _logger = logger;
            _matrixService = service;
            _moduleRepository = moduleRepository;
        }

        public IEnumerable<ModuleViewModel> GetAllModules()
        {
            var modules = _moduleRepository.GetAllModules();

            _logger.LogTrace($"Retrieved {modules.Count} modules.");

            return modules.Select(module => new ModuleViewModel
            {
                CohortNaam = module.Cohort.CohortNaam,
                Specialisaties = module.Studiefasen.Select(studiefase => studiefase.Specialisatie.SpecialisatieNaam),
                ModuleCode = module.ModuleCode,
                Matrix = _matrixService.CreateCompetentieMatrix(module.Competenties),
                Perioden = module.Studiefasen.Select(studiefase => studiefase.Periode.PeriodeNummer),
                Eindeisen = module.Eindeisen.Select(eindeis => eindeis.EindeisBeschrijving),
                AuditLogEntries = module.AuditLogEntries.Select(entry => new AuditLogEntryViewModel{Omschrijving = entry.Omschrijving, Timestamp = entry.Timestamp})
            });
        }
    }
}