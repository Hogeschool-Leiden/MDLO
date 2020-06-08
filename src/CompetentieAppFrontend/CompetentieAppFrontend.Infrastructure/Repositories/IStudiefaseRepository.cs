using System.Collections.Generic;
using CompetentieAppFrontend.Domain;

namespace CompetentieAppFrontend.Infrastructure.Repositories
{
    public interface IStudiefaseRepository
    {
        void CreateStudiefasen(IEnumerable<Studiefase> studiefasen);
    }
}