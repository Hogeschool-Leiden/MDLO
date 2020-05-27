using System.Collections.Generic;
using CompetentieAppFrontend.Domain;

namespace CompetentieAppFrontend.Infrastructure.Repositories
{
    public interface IModuleRepository
    {
        IEnumerable<Module> GetAllModules();
    }
}