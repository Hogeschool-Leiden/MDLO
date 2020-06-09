using System.Collections.Generic;
using System.Linq;
using CompetentieAppFrontend.Domain;
using CompetentieAppFrontend.Infrastructure.DAL;

namespace CompetentieAppFrontend.Infrastructure.Repositories
{
    public class SpecialisatieRepository : ISpecialisatieRepository
    {
        private readonly CompetentieAppFrontendContext _context;

        public SpecialisatieRepository(CompetentieAppFrontendContext context) =>
            _context = context;

        public IList<long> EnsureSpecialisatiesExist(IEnumerable<Specialisatie> specialisaties) =>
            specialisaties.Select(EnsureSpecialisatieExist).ToList();

        private long EnsureSpecialisatieExist(Specialisatie newSpecialisatie)
        {
            if (Exist(newSpecialisatie))
            {
                return GetId(newSpecialisatie);
            }

            Create(newSpecialisatie);

            return EnsureSpecialisatieExist(newSpecialisatie);
        }

        private void Create(Specialisatie newSpecialisatie)
        {
            _context.Specialisaties.Add(newSpecialisatie);
            _context.SaveChanges();
        }

        private long GetId(Specialisatie newSpecialisatie) =>
            _context.Specialisaties.First(specialisatie =>
                specialisatie.SpecialisatieNaam == newSpecialisatie.SpecialisatieNaam).Id;

        private bool Exist(Specialisatie newSpecialisatie) =>
            _context.Specialisaties.Any(specialisatie =>
                specialisatie.SpecialisatieNaam == newSpecialisatie.SpecialisatieNaam);
    }
}