using System.Collections.Generic;
using System.Linq;
using CompetentieAppFrontend.Infrastructure.DAL;

namespace CompetentieAppFrontend.Infrastructure.Repositories
{
    public class ActiviteitRepository : IActiviteitRepository
    {
        private readonly CompetentieAppFrontendContext _context;

        public ActiviteitRepository(CompetentieAppFrontendContext context)
        {
            _context = context;
        }

        public IList<string> GetAllActiviteitNamen()
        {
            return _context
                .Activiteiten
                .Select(activiteit => activiteit.ActiviteitNaam)
                .ToList();
        }
    }
}