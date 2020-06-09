﻿using Miffy.MicroServices.Commands;
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

            CreeerModuleCommand command = new CreeerModuleCommand()
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
            
            CreeerModuleCommandResponse result = _publisher.PublishAsync<CreeerModuleCommandResponse>(command).Result;
            return result;
        }
    }
}
