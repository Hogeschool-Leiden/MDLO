using System.Collections.Generic;
using CompetentieAppFrontend.Domain;

namespace CompetentieAppFrontend.Infrastructure.Repositories
{
    public interface IEindCompetentieRepository
    {
        IEnumerable<EindCompetentie> GetEindCompetenties(int periodeNummer, string specialisatieNaam);
    }
}