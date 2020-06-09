using ModuleFrontend.Api.Commands;
using ModuleFrontend.Api.Models;
using ModuleFrontend.Api.ViewModels;
using System.Collections.Generic;

namespace ModuleFrontend.Api.Services
{
    public interface IModuleService
    {
        Module GetByModuleCode(string modulecode);
        IEnumerable<Module> GetAllModules();
        CreeerModuleCommandResponse SendCreeerModuleCommand(ModuleViewModel module);
    }
}
