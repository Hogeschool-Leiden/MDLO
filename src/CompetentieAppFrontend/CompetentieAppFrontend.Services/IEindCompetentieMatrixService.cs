using System.Collections.Generic;
using CompetentieAppFrontend.Domain;

namespace CompetentieAppFrontend.Services
{
    public interface IEindCompetentieMatrixService
    {
        CompetentieMatrix GetEindCompetentieMatrix(int periodeNummer, string specialisatieNaam);
    }
}