using Miffy.MicroServices.Commands;
using ModuleFrontend.Api.Commands;
using ModuleFrontend.Api.DAL;
using ModuleFrontend.Api.DTO;
using ModuleFrontend.Api.Models;
using ModuleFrontend.Api.ViewModels;
using System.Collections.Generic;
using System.Linq;

namespace ModuleFrontend.Api.Services
{
    public class ModuleService : IModuleService
    {
        private readonly ModuleContext _moduleContext;
        private readonly ICommandPublisher _publisher;
        public ModuleService(ModuleContext context, ICommandPublisher publisher)
        {
            _moduleContext = context;
            _publisher = publisher;
        }

        public IEnumerable<Module> GetAllModules()
        {
            return _moduleContext.Modules;
        }

        public Module GetByModuleCode(string modulecode)
        {
            var module = _moduleContext.Modules.Where(m => m.ModuleCode == modulecode).FirstOrDefault();
            return module;
        }

        public CreeerModuleCommandResponse SendCreeerModuleCommand(ModuleViewModel module)
        {
            var verplichtVoor = new List<Specialisatie>() { };
            foreach (var specialisatie in module.VerplichtVoor)
            {
                verplichtVoor.Add(new Specialisatie() { Code = specialisatie.Code, Naam = specialisatie.Naam });
            }

            var aanbevolenVoor = new List<Specialisatie>() { };
            foreach (var specialisatie in module.AanbevolenVoor)
            {
                aanbevolenVoor.Add(new Specialisatie() { Code = specialisatie.Code, Naam = specialisatie.Naam });
            }

            ModuleDTO moduleToSend = new ModuleDTO()
            {
                Cohort = module.Cohort,
                Competenties = module.Competenties,
                ModuleCode = module.ModuleCode,
                ModuleNaam = module.ModuleNaam,
                Eindeisen = module.Eindeisen,
                Studiefase = new Studiefase() { Fase = module.Studiefase.Fase, Periode = module.Studiefase.Periode },
                VerplichtVoor = verplichtVoor,
                AanbevolenVoor = aanbevolenVoor
            };

            CreeerModuleCommand command = new CreeerModuleCommand() { Module = moduleToSend };

            CreeerModuleCommandResponse result = _publisher.PublishAsync<CreeerModuleCommandResponse>(command).Result;
            return result;
        }
    }
}
