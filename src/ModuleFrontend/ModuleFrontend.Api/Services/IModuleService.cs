using ModuleFrontend.Api.Models;
using ModuleFrontend.Api.ViewModels;
using System.Collections.Generic;

namespace ModuleFrontend.Api.Services
{
    public interface IModuleService
    {
        Module GetByModuleCode(string modulecode);
        IEnumerable<Module> GetAllModules();
        Module AddModule(ModuleViewModel module);
        Module SendCreeerModuleCommand(ModuleViewModel module);
    }
}
