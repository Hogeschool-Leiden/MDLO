using System.Collections.Generic;
using CompetentieAppFrontend.Domain;

namespace CompetentieAppFrontend.Infrastructure.Repositories
{
    public interface IBeheersingsNiveauRepository
    {
        IList<long> EnsureBeheersingsNiveausExist(IEnumerable<BeheersingsNiveau> beheersingsNiveaus);
    }
}