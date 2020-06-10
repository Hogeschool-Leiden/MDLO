using System.Collections.Generic;
using System.Linq;
using CompetentieAppFrontend.Domain;
using CompetentieAppFrontend.Infrastructure.Repositories;
using CompetentieAppFrontend.Services.Abstractions;
using CompetentieAppFrontend.Services.Commands;

namespace CompetentieAppFrontend.Services.Eventing
{
    public class StudiefaseService : IStudiefaseService
    {
        private readonly ISpecialisatieRepository _specialisatieRepository;
        private readonly IStudiefaseRepository _studiefaseRepository;
        private readonly IPeriodeRepository _periodeRepository;

        public StudiefaseService(ISpecialisatieRepository specialisatieRepository,
            IStudiefaseRepository studiefaseRepository,
            IPeriodeRepository periodeRepository)
        {
            _specialisatieRepository = specialisatieRepository;
            _studiefaseRepository = studiefaseRepository;
            _periodeRepository = periodeRepository;
        }

        public void CreateStudiefasen(CreateStudiefasenCommand command)
        {
            var specialisatieIds = _specialisatieRepository.EnsureSpecialisatiesExist(command.Specialisaties);
            var periodeIds = _periodeRepository.EnsurePeriodenExist(command.Perioden);
            var studiefasen = ExtractStudiefasen(specialisatieIds, periodeIds, command.ModuleId);
            _studiefaseRepository.CreateStudiefasen(studiefasen);
        }

        private static IEnumerable<Studiefase> ExtractStudiefasen(
            IEnumerable<long> specialisatieIds,
            IEnumerable<long> periodeIds,
            long moduleId) =>
            from specialisatieId in specialisatieIds
            from periodeId in periodeIds
            select new Studiefase
            {
                SpecialisatieId = specialisatieId,
                PeriodeId = periodeId, ModuleId = moduleId
            };
    }
}