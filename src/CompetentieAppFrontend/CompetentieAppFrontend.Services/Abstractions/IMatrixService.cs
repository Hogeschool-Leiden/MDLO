using System.Collections.Generic;
using CompetentieAppFrontend.Domain;
using CompetentieAppFrontend.Services.ViewModels;

namespace CompetentieAppFrontend.Services.Abstractions
{
    public interface IMatrixService<T>
    {
        Matrix<T> CreateCompetentieMatrix(IEnumerable<Competentie> competenties);
    }
}