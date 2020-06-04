using System.Collections.Generic;

namespace CompetentieAppFrontend.Infrastructure.Repositories
{
    public interface IArchitectuurLaagRepository
    {
        IList<string> GetAllArchitectuurLaagNamen();
    }
}