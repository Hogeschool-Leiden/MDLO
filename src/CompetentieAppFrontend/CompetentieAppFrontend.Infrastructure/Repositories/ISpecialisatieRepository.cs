using System.Collections.Generic;
using CompetentieAppFrontend.Domain;

namespace CompetentieAppFrontend.Infrastructure.Repositories
{
    public interface ISpecialisatieRepository
    {
        IList<long> EnsureSpecialisatiesExist(IEnumerable<Specialisatie> specialisaties);
    }
}