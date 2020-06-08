using System.Linq;
using CompetentieAppFrontend.Domain;
using CompetentieAppFrontend.Infrastructure.DAL;

namespace CompetentieAppFrontend.Infrastructure.Repositories
{
    public class CohortRepository : ICohortRepository
    {
        private readonly CompetentieAppFrontendContext _context;

        public CohortRepository(CompetentieAppFrontendContext context) =>
            _context = context;

        public long EnsureCohortExist(string cohortNaam)
        {
            if (_context.Cohorts.Any(cohort => cohort.CohortNaam.Equals(cohortNaam)))
            {
                return _context.Cohorts.First(cohort => cohort.CohortNaam.Equals(cohortNaam)).Id;
            }

            _context.Cohorts.Add(new Cohort {CohortNaam = cohortNaam});
            _context.SaveChanges();

            return EnsureCohortExist(cohortNaam);
        }
    }
}