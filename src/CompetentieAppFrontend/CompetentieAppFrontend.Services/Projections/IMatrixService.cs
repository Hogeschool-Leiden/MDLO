using System.Collections.Generic;
using CompetentieAppFrontend.Domain;

namespace CompetentieAppFrontend.Services.Projections
{
    public interface IMatrixService<T>
    {
        Matrix<T> CreateCompetentieMatrix(IEnumerable<Competentie> competenties);
    }
}