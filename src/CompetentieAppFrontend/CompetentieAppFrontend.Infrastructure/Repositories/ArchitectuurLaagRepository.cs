using System.Collections.Generic;
using System.Linq;
using CompetentieAppFrontend.Domain;
using CompetentieAppFrontend.Infrastructure.DAL;

namespace CompetentieAppFrontend.Infrastructure.Repositories
{
    public class ArchitectuurLaagRepository : IArchitectuurLaagRepository
    {
        private readonly CompetentieAppFrontendContext _context;

        public ArchitectuurLaagRepository(CompetentieAppFrontendContext context)
        {
            _context = context;
        }

        public IList<string> GetAllArchitectuurLaagNamen()
        {
            return _context
                .ArchitectuurLagen
                .Select(laag => laag.ArchitectuurLaagNaam)
                .ToList();
        }

        public long EnsureArchitectuurLaagExist(string architectuurLaagNaam)
        {
            if (_context.ArchitectuurLagen.Any(laag => laag.ArchitectuurLaagNaam.Equals(architectuurLaagNaam)))
            {
                return _context
                    .ArchitectuurLagen
                    .First(laag => laag.ArchitectuurLaagNaam.Equals(architectuurLaagNaam))
                    .Id;
            }

            _context.ArchitectuurLagen.Add(new ArchitectuurLaag {ArchitectuurLaagNaam = architectuurLaagNaam});
            _context.SaveChanges();
            
            return EnsureArchitectuurLaagExist(architectuurLaagNaam);
        }
    }
}