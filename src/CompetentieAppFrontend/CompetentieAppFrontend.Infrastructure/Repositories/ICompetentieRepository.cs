using System.Collections.Generic;
using CompetentieAppFrontend.Domain;

namespace CompetentieAppFrontend.Infrastructure.Repositories
{
    public interface ICompetentieRepository
    {
        IList<Competentie> GetAllCompetentiesByCriteria(Criteria criteria);
        
        public struct Criteria
        {
            public int PeriodeNummer { get; set; }
            public string SpecialisatieNaam { get; set; }
            public string CohortNaam { get; set; }
        }
    }
}