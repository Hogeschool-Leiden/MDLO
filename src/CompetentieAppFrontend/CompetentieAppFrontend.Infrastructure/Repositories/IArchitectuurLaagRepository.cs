using System.Collections.Generic;

namespace CompetentieAppFrontend.Infrastructure.Repositories
{
    public interface IArchitectuurLaagRepository
    {
        IEnumerable<string> GetAllArchitectuurLaagNamen();
    }
}