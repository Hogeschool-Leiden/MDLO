using System.Collections.Generic;
using CompetentieAppFrontend.Domain;

namespace CompetentieAppFrontend.Infrastructure.Repositories
{
    public interface ICompetentieRepository
    {
        IList<Competentie> GetAllCompetentiesByCriteria(int periodeNummer, string specialisatieNaam);
    }
}