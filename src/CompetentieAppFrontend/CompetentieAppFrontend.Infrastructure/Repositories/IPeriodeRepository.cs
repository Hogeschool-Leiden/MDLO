using System.Collections.Generic;
using CompetentieAppFrontend.Domain;

namespace CompetentieAppFrontend.Infrastructure.Repositories
{
    public interface IPeriodeRepository
    {
        IList<long> EnsurePeriodenExist(IEnumerable<Periode> perioden);
    }
}