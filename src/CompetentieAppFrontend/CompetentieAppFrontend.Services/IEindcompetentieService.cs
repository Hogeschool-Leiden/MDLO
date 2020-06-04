using CompetentieAppFrontend.Infrastructure.Repositories;

namespace CompetentieAppFrontend.Services
{
    public interface IEindcompetentieService
    {
        Matrix<Eindniveau> GetEindcompetentieMatrixByCriteria(ICompetentieRepository.Criteria criteria);
    }
}