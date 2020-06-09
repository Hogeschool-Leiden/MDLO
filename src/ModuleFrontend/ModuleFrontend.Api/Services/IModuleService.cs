using ModuleFrontend.Api.Commands;
using ModuleFrontend.Api.Models;
using ModuleFrontend.Api.ViewModels;
using System.Collections.Generic;

namespace ModuleFrontend.Api.Services
{
    public interface IModuleService
    {
        CreeerModuleCommandResponse SendCreeerModuleCommand(ModuleViewModel module);
    }
}
