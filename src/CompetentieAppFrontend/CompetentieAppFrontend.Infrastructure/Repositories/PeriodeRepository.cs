using System.Collections.Generic;
using System.Linq;
using CompetentieAppFrontend.Domain;
using CompetentieAppFrontend.Infrastructure.DAL;

namespace CompetentieAppFrontend.Infrastructure.Repositories
{
    public class PeriodeRepository : IPeriodeRepository
    {
        private readonly CompetentieAppFrontendContext _context;

        public PeriodeRepository(CompetentieAppFrontendContext context) =>
            _context = context;

        public IList<long> EnsurePeriodenExist(IEnumerable<Periode> perioden) =>
            perioden.Select(EnsurePeriodeExist).ToList();

        private long EnsurePeriodeExist(Periode newPeriode)
        {
            if (_context.Perioden.Any(periode => periode.Equals(newPeriode)))
            {
                return _context.Perioden.First(periode => periode.Equals(newPeriode)).Id;
            }

            _context.Perioden.Add(newPeriode);
            _context.SaveChanges();

            return EnsurePeriodeExist(newPeriode);
        }
    }
}