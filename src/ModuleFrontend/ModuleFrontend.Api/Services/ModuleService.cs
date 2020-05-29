using ModuleFrontend.Api.DAL;
using ModuleFrontend.Api.Models;
using System.Collections.Generic;
using System.Linq;

namespace ModuleFrontend.Api.Services
{
    public class ModuleService : IModuleService
    {
        private readonly ModuleContext _moduleContext;
        public ModuleService(ModuleContext context)
        {
            _moduleContext = context;
        }

        public IEnumerable<Module> GetAllModules()
        {
            return _moduleContext.Modules;
        }

        public Module GetByModuleCode(string modulecode)
        {
            return _moduleContext.Modules.Where(m => m.ModuleCode == modulecode).FirstOrDefault();
        }
    }
}
