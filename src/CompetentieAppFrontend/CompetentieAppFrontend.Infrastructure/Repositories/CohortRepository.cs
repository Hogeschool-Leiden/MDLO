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
            if (Exists(cohortNaam))
            {
                return GetId(cohortNaam);
            }

            Create(new Cohort {CohortNaam = cohortNaam});

            return EnsureCohortExist(cohortNaam);
        }

        private void Create(Cohort cohort)
        {
            _context.Cohorts.Add(cohort);
            _context.SaveChanges();
        }

        private long GetId(string cohortNaam) =>
            _context.Cohorts.First(cohort => cohort.CohortNaam.Equals(cohortNaam)).Id;

        private bool Exists(string cohortNaam) =>
            _context.Cohorts.Any(cohort => cohort.CohortNaam.Equals(cohortNaam));
    }
}