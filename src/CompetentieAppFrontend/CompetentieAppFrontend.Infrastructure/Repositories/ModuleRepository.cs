using System.Collections.Generic;
using System.Linq;
using CompetentieAppFrontend.Domain;
using CompetentieAppFrontend.Infrastructure.DAL;
using Microsoft.EntityFrameworkCore;

namespace CompetentieAppFrontend.Infrastructure.Repositories
{
    public class ModuleRepository : IModuleRepository
    {
        private readonly CompetentieAppFrontendContext _context;

        public ModuleRepository(CompetentieAppFrontendContext context)
        {
            _context = context;
        }

        public IList<Module> GetAllModules()
        {
            return _context
                .Modules
                .Include(module => module.Competenties)
                .ThenInclude(competentie => competentie.BeheersingsNiveau)
                .ThenInclude(niveau => niveau.ArchitectuurLaag)
                .Include(module => module.Competenties)
                .ThenInclude(competentie => competentie.BeheersingsNiveau)
                .ThenInclude(niveau => niveau.Activiteit)
                .Include(module => module.Studiefasen)
                .ThenInclude(studiefase => studiefase.Specialisatie)
                .Include(module => module.Studiefasen)
                .ThenInclude(studiefase => studiefase.Periode)
                .Include(module => module.Eindeisen)
                .Include(module => module.Cohort)
                .ToList();
        }

        public long CreateModule(Module module)
        {
            var entityEntry = _context.Modules.Add(module);
            _context.SaveChanges();

            return entityEntry.Entity.Id;
        }
    }
}