using CompetentieAppFrontend.Infrastructure.Repositories;
using CompetentieAppFrontend.Services.Projections;
using CompetentieAppFrontend.Services.ViewModels;

namespace CompetentieAppFrontend.Services.Abstractions
{
    public interface IEindcompetentieService
    {
        Matrix<Eindniveau> GetEindcompetentieMatrixByCriteria(ICompetentieRepository.Criteria criteria);
    }
}