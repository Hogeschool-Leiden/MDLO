using Miffy.MicroServices.Commands;
using ModuleFrontend.Api.Commands;
using ModuleFrontend.Api.DAL;
using ModuleFrontend.Api.DTO;
using ModuleFrontend.Api.Exceptions;
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

        public Module AddModule(ModuleViewModel module)
        {
            bool exists = _moduleContext.Modules.Any(mod => mod.ModuleCode == module.ModuleCode);
            if (exists)
            {
                throw new AlreadyExistsException($"Duplicate ModuleCode: {module.ModuleCode}");
            }
            var dbModule = new Module()
            {
                ModuleNaam = module.ModuleNaam,
                ModuleCode = module.ModuleCode,
                AantalEc = module.AantalEc,
                Studiejaar = module.Studiejaar,
                Cohort = module.Cohort,
                Moduleleider = new Moduleleider() { Email = module.Moduleleider.Email, Naam = module.Moduleleider.Naam, Telefoonnummer = module.Moduleleider.Telefoonnummer },
                Studiefase = new Studiefase() { Fase = module.Studiefase.Fase, Periode = new Periode() { PeriodeNummer = module.Studiefase.Periode.PeriodeNummer } },
                VerplichtVoor = new List<Specialisatie>() { },
                Competenties = module.Competenties,
                Eindeisen = module.Eindeisen,
            };

            foreach (var item in module.VerplichtVoor)
            {
                dbModule.VerplichtVoor.ToList().Add(new Specialisatie() { Code = item.Code, Naam = item.Naam });
            }

            //foreach (var item in module.AanbevolenVoor)
            //{
            //    dbModule.AanbevolenVoor.ToList().Add(new Specialisatie() { Code = item.Code, Naam = item.Naam });
            //}
            return dbModule;
            //var res = _moduleContext.Modules.Add(dbModule);
            //_moduleContext.SaveChanges();
            //return res.Entity;
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

        public Module SendCreeerModuleCommand(ModuleViewModel module)
        {
            var verplichtVoor = new List<Specialisatie>() { };
            foreach (var specialisatie in module.VerplichtVoor)
            {
                verplichtVoor.Add(new Specialisatie() { Code = specialisatie.Code, Naam = specialisatie.Naam });
            }
            ModuleDTO moduleToSend = new ModuleDTO()
            {
                Cohort = module.Cohort,
                Competenties = module.Competenties,
                ModuleCode = module.ModuleCode,
                ModuleNaam = module.ModuleNaam,
                Eindeisen = module.Eindeisen,
                Studiefase = new Studiefase() { Fase = module.Studiefase.Fase, Periode = new Periode() { PeriodeNummer = module.Studiefase.Periode.PeriodeNummer } },
                VerplichtVoor = verplichtVoor,
            };

            CreeerModuleCommand command = new CreeerModuleCommand() { Module = moduleToSend };

            CreeerModuleCommandResult res = _publisher.PublishAsync<CreeerModuleCommandResult>(command).Result;
            var retMod = res.Module;
            Module returnedModule = new Module()
            {
                Cohort = retMod.Cohort,
                Competenties = retMod.Competenties,
                ModuleCode = retMod.ModuleCode,
                ModuleNaam = retMod.ModuleNaam,
                Eindeisen = retMod.Eindeisen,
                Studiefase = retMod.Studiefase,
                VerplichtVoor = retMod.VerplichtVoor
            };
        }
    }
}
