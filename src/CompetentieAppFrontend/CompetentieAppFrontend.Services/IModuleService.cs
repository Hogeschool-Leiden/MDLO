using System.Collections.Generic;
using CompetentieAppFrontend.Domain;

namespace CompetentieAppFrontend.Services
{
    public interface IModuleService
    {
        IEnumerable<ModuleWithMatrix> GetAllModules();
    }
}