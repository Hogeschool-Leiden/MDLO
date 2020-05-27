using System.Collections.Generic;
using System.Linq;
using CompetentieAppFrontend.Domain;
using CompetentieAppFrontend.Infrastructure.Repositories;
using Microsoft.Extensions.Logging;

namespace CompetentieAppFrontend.Services
{
    public class ModuleService : IModuleService
    {
        private readonly ILogger<EindCompetentieService> _logger;
        private readonly ICompetentieMatrixService _competentieMatrixService;
        private readonly IModuleRepository _moduleRepository;

        public ModuleService(ILogger<EindCompetentieService> logger,
            ICompetentieMatrixService competentieService,
            IModuleRepository moduleRepository)
        {
            _logger = logger;
            _competentieMatrixService = competentieService;
            _moduleRepository = moduleRepository;
        }

        public IEnumerable<ModuleWithMatrix> GetAllModules()
        {
            return from module in _moduleRepository.GetAllModules()
                select new ModuleWithMatrix
                {
                    Specialisaties =
                        module.Studiefasen.Select(studiefase => studiefase.Specialisatie.SpecialisatieNaam),
                    ModuleCode = module.ModuleCode,
                    Matrix = _competentieMatrixService.CreateCompetentieMatrix(module),
                    Perioden = module.Studiefasen.Select(studiefase => studiefase.Periode.PeriodeNummer),
                    Eindeisen = module.Eindeisen.Select(eindeis => eindeis.EindeisBeschrijving),
                };
        }
    }
}