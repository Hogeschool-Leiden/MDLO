using System.Collections.Generic;

namespace CompetentieAppFrontend.Services
{
    public interface IModuleService
    {
        IEnumerable<ModuleView> GetAllModules();
    }
}