using System.Collections.Generic;
using CompetentieAppFrontend.Domain;

namespace CompetentieAppFrontend.Infrastructure.Repositories
{
    public interface IEindeisRepository
    {
        public void CreateEindeisen(IEnumerable<Eindeis> eindeisen);
    }
}