using System.Collections.Generic;
using CompetentieAppFrontend.Domain;

namespace CompetentieAppFrontend.Infrastructure.Repositories
{
    public interface IMatrixRepository
    {
        IEnumerable<MatrixCell> GetCompetentieMatrix(int periodeNummer, string specialisatieNaam);
    }
}