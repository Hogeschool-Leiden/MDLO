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
            if (_context.Specialisaties.Any(specialisatie => specialisatie.Equals(newSpecialisatie)))
            {
                return _context.Specialisaties.First(specialisatie => specialisatie.Equals(newSpecialisatie)).Id;
            }

            _context.Specialisaties.Add(newSpecialisatie);
            _context.SaveChanges();

            return EnsureSpecialisatieExist(newSpecialisatie);
        }
    }
}