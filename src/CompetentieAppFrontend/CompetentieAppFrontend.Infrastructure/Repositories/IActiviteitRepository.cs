using System.Collections.Generic;
using CompetentieAppFrontend.Domain;

namespace CompetentieAppFrontend.Infrastructure.Repositories
{
    public interface IActiviteitRepository
    {
        IList<string> GetAllActiviteitNamen();
        long EnsureActiviteitExist(string activiteitNaam);
    }
}