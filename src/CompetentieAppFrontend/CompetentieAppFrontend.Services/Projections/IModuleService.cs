using System.Collections.Generic;
using CompetentieAppFrontend.Domain;

namespace CompetentieAppFrontend.Services.Projections
{
    public interface IModuleService
    {
        IEnumerable<ModuleView> GetAllModules();
    }
}