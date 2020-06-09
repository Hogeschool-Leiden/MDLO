using System.Collections.Generic;
using CompetentieAppFrontend.Domain;

namespace CompetentieAppFrontend.Infrastructure.Repositories
{
    public interface IArchitectuurLaagRepository
    {
        IList<string> GetAllArchitectuurLaagNamen();
        long EnsureArchitectuurLaagExist(string architectuurLaag);
    }
}