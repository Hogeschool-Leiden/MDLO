using System.Collections.Generic;
using System.Linq;
using CompetentieAppFrontend.Domain;
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

        public long EnsureActiviteitExist(string activiteitNaam)
        {
            if (_context.Activiteiten.Any(laag => laag.ActiviteitNaam.Equals(activiteitNaam)))
            {
                return _context
                    .Activiteiten
                    .First(laag => laag.ActiviteitNaam.Equals(activiteitNaam))
                    .Id;
            }

            _context.Activiteiten.Add(new Activiteit {ActiviteitNaam = activiteitNaam});
            _context.SaveChanges();

            return EnsureActiviteitExist(activiteitNaam);
        }
    }
}