using ModuleFrontend.Api.DAL;
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
        public ModuleService(ModuleContext context)
        {
            _moduleContext = context;
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
                Moduleleider = new Moduleleider() { Email = module.Moduleleider.Email, Naam = module.Moduleleider.Naam, Telefoonnummer = module.Moduleleider.Telefoonnummer },
                Studiefase = new Studiefase() { Fase = module.Studiefase.Fase, Periode = new Periode() { PeriodeNummer = module.Studiefase.Periode.PeriodeNummer } },
                AanbevolenVoor = new List<Specialisatie>() { },
                VerplichtVoor = new List<Specialisatie>() { },
                BeschrijvingLeerdoelen = module.BeschrijvingLeerdoelen,
                InhoudelijkeBeschrijving = module.InhoudelijkeBeschrijving,
                Eindeisen = module.Eindeisen,
                ContacturenWerkvormen = module.ContacturenWerkvormen,
                Toetsvorm = module.Toetsvorm,
                VoorwaardenVoldoende = module.VoorwaardenVoldoende,
                LetOp = module.LetOp,
                Summatief = module.Summatief,
                Formatief = module.Formatief,
                Kwalitatief = module.Kwalitatief,
                Kwantitatief = module.Kwantitatief,
                Examinatoren = module.Examinatoren
            };

            foreach (var item in module.VerplichtVoor)
            {
                dbModule.VerplichtVoor.ToList().Add(new Specialisatie() { Code = item.Code, Naam = item.Naam});
            }

            foreach (var item in module.AanbevolenVoor)
            {
                dbModule.AanbevolenVoor.ToList().Add(new Specialisatie() { Code = item.Code, Naam = item.Naam });
            }

            var res = _moduleContext.Modules.Add(dbModule);
            _moduleContext.SaveChanges();
            return res.Entity;
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
    }
}
