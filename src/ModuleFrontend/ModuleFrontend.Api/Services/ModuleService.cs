using Miffy.MicroServices.Commands;
using ModuleFrontend.Api.Commands;
using ModuleFrontend.Api.Models;
using ModuleFrontend.Api.ViewModels;
using System.Collections.Generic;

namespace ModuleFrontend.Api.Services
{
    public class ModuleService : IModuleService
    {
        private readonly ICommandPublisher _publisher;
        public ModuleService(ICommandPublisher publisher)
        {
            _publisher = publisher;
        }
        public CreeerModuleCommandResponse SendCreeerModuleCommand(Module module)
        {
            CreeerModuleCommand command = new CreeerModuleCommand()
            {
                Cohort = module.Cohort,
                Competenties = module.Competenties,
                ModuleCode = module.ModuleCode,
                ModuleNaam = module.ModuleNaam,
                Eindeisen = module.Eindeisen,
                Studiefase = module.Studiefase,
                VerplichtVoor = module.VerplichtVoor,
                AanbevolenVoor = module.AanbevolenVoor
            };
            
            CreeerModuleCommandResponse result = _publisher.PublishAsync<CreeerModuleCommandResponse>(command).Result;
            return result;
        }
    }
}
