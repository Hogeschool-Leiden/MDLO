using System.Collections.Generic;
using CompetentieAppFrontend.Domain;

namespace CompetentieAppFrontend.Services
{
    public interface IEindCompetentieMatrixService
    {
        IEnumerable<EindCompetentie> GetCompetentieMatrix(int periodeNummer, string specialisatieNaam);
    }
}