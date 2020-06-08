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
            if (_context.BeheersingsNiveaus.Any(niveau => niveau.Equals(beheersingsNiveau)))
            {
                return _context.BeheersingsNiveaus.First(niveau => niveau.Equals(beheersingsNiveau)).Id;
            }

            _context.BeheersingsNiveaus.Add(beheersingsNiveau);
            _context.SaveChanges();
            
            return EnsureBeheersingsNiveauExist(beheersingsNiveau);
        }
    }
}