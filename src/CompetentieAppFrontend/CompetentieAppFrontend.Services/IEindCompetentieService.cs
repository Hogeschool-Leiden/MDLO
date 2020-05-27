using System.Collections.Generic;
using CompetentieAppFrontend.Domain;

namespace CompetentieAppFrontend.Services
{
    public interface IEindCompetentieService
    {
        CompetentieMatrix GetEindCompetentieMatrix(int periodeNummer, string specialisatieNaam);
    }
}