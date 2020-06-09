using System.Collections.Generic;
using System.Linq;
using CompetentieAppFrontend.Domain;
using CompetentieAppFrontend.Infrastructure.DAL;

namespace CompetentieAppFrontend.Infrastructure.Repositories
{
    public class BeheersingsNiveauRepository : IBeheersingsNiveauRepository
    {
        private readonly CompetentieAppFrontendContext _context;

        public BeheersingsNiveauRepository(CompetentieAppFrontendContext context) => _context = context;

        public IList<long> EnsureBeheersingsNiveausExist(IEnumerable<BeheersingsNiveau> beheersingsNiveaus) =>
            beheersingsNiveaus.Select(EnsureBeheersingsNiveauExist).ToList();

        private long EnsureBeheersingsNiveauExist(BeheersingsNiveau beheersingsNiveau)
        {
            if (Exists(beheersingsNiveau))
            {
                return GetId(beheersingsNiveau);
            }

            Create(beheersingsNiveau);

            return EnsureBeheersingsNiveauExist(beheersingsNiveau);
        }

        private void Create(BeheersingsNiveau beheersingsNiveau)
        {
            _context.BeheersingsNiveaus.Add(beheersingsNiveau);
            _context.SaveChanges();
        }

        private long GetId(BeheersingsNiveau beheersingsNiveau) =>
            _context.BeheersingsNiveaus.First(niveau =>
                niveau.ArchitectuurLaagId == beheersingsNiveau.ArchitectuurLaagId &&
                niveau.ActiviteitId == beheersingsNiveau.ActiviteitId &&
                niveau.Niveau == beheersingsNiveau.Niveau).Id;

        private bool Exists(BeheersingsNiveau beheersingsNiveau) =>
            _context.BeheersingsNiveaus.Any(niveau =>
                niveau.ArchitectuurLaagId == beheersingsNiveau.ArchitectuurLaagId &&
                niveau.ActiviteitId == beheersingsNiveau.ActiviteitId &&
                niveau.Niveau == beheersingsNiveau.Niveau);
    }
}