using System.Collections.Generic;

namespace CompetentieAppFrontend.Infrastructure.Repositories
{
    public interface IActiviteitRepository
    {
        IList<string> GetAllActiviteitNamen();
    }
}