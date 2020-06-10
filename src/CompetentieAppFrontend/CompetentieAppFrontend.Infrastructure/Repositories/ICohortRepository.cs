namespace CompetentieAppFrontend.Infrastructure.Repositories
{
    public interface ICohortRepository
    {
        public long EnsureCohortExist(string cohortNaam);
    }
}