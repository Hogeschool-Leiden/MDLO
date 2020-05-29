using ModuleFrontend.Api.Models;
using System.Collections;
using System.Collections.Generic;

namespace ModuleFrontend.Api.Services
{
    public interface IModuleService
    {
        Module GetByModuleCode(string modulecode);
        IEnumerable<Module> GetAllModules();
    }
}
