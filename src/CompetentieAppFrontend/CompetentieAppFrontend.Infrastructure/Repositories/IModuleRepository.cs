using System.Collections.Generic;
using CompetentieAppFrontend.Domain;

namespace CompetentieAppFrontend.Infrastructure.Repositories
{
    public interface IModuleRepository
    {
        IList<Module> GetAllModules();
        long CreateModule(Module module);
    }
}