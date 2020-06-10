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
            if (Exist(activiteitNaam))
            {
                return GetId(activiteitNaam);
            }

            Create(new Activiteit {ActiviteitNaam = activiteitNaam});

            return EnsureActiviteitExist(activiteitNaam);
        }

        private void Create(Activiteit activiteit)
        {
            _context.Activiteiten.Add(activiteit);
            _context.SaveChanges();
        }

        private long GetId(string activiteitNaam) =>
            _context
                .Activiteiten
                .First(laag => laag.ActiviteitNaam.Equals(activiteitNaam))
                .Id;

        private bool Exist(string activiteitNaam) =>
            _context.Activiteiten.Any(laag => laag.ActiviteitNaam.Equals(activiteitNaam));
    }
}