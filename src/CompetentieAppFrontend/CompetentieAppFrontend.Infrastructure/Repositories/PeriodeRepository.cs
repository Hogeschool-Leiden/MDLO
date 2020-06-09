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
            if (Exists(newPeriode))
            {
                return GetId(newPeriode);
            }

            Create(newPeriode);

            return EnsurePeriodeExist(newPeriode);
        }

        private void Create(Periode newPeriode)
        {
            _context.Perioden.Add(newPeriode);
            _context.SaveChanges();
        }

        private long GetId(Periode newPeriode) =>
            _context.Perioden.First(periode => periode.PeriodeNummer == newPeriode.PeriodeNummer).Id;

        private bool Exists(Periode newPeriode) =>
            _context.Perioden.Any(periode => periode.PeriodeNummer == newPeriode.PeriodeNummer);
    }
}