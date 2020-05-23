using System.Collections.Generic;
using System.Linq;
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
        
        public IEnumerable<string> GetAllArchitectuurLaagNamen()
        {
            return _context.ArchitectuurLagen.Select(laag => laag.ArchitectuurLaagNaam);
        }
    }
}