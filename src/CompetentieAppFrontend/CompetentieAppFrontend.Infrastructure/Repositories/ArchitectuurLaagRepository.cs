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
            if (Exist(architectuurLaagNaam))
            {
                return GetId(architectuurLaagNaam);
            }

            Create(new ArchitectuurLaag {ArchitectuurLaagNaam = architectuurLaagNaam});

            return EnsureArchitectuurLaagExist(architectuurLaagNaam);
        }

        private void Create(ArchitectuurLaag architectuurLaag)
        {
            _context.ArchitectuurLagen.Add(architectuurLaag);
            _context.SaveChanges();
        }

        private long GetId(string architectuurLaagNaam) =>
            _context
                .ArchitectuurLagen
                .First(laag => laag.ArchitectuurLaagNaam.Equals(architectuurLaagNaam))
                .Id;

        private bool Exist(string architectuurLaagNaam) =>
            _context
                .ArchitectuurLagen
                .Any(laag => laag.ArchitectuurLaagNaam.Equals(architectuurLaagNaam));
    }
}