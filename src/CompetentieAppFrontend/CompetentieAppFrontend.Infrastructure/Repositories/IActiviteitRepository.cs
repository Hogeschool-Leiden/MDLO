using System.Collections.Generic;

namespace CompetentieAppFrontend.Infrastructure.Repositories
{
    public interface IActiviteitRepository
    {
        IEnumerable<string> GetAllActiviteitNamen();
    }
}