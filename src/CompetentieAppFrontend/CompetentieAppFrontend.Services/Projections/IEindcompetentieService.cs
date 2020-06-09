using CompetentieAppFrontend.Infrastructure.Repositories;

namespace CompetentieAppFrontend.Services.Projections
{
    public interface IEindcompetentieService
    {
        Matrix<Eindniveau> GetEindcompetentieMatrixByCriteria(ICompetentieRepository.Criteria criteria);
    }
}