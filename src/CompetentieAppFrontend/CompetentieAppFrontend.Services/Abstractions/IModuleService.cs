using System.Collections.Generic;
using CompetentieAppFrontend.Services.Projections;
using CompetentieAppFrontend.Services.ViewModels;

namespace CompetentieAppFrontend.Services.Abstractions
{
    public interface IModuleService
    {
        IEnumerable<ModuleViewModel> GetAllModules();
    }
}