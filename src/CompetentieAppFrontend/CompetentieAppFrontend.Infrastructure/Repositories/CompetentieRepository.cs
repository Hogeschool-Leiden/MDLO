using System.Collections.Generic;
using System.Linq;
using CompetentieAppFrontend.Domain;
using CompetentieAppFrontend.Infrastructure.DAL;
using Microsoft.EntityFrameworkCore;

namespace CompetentieAppFrontend.Infrastructure.Repositories
{
    public class CompetentieRepository : ICompetentieRepository
    {
        private readonly CompetentieAppFrontendContext _context;

        public CompetentieRepository(CompetentieAppFrontendContext context)
        {
            _context = context;
        }

        public IList<Competentie> GetAllCompetentiesByCriteria(int periodeNummer, string specialisatieNaam)
        {
            return (from beheersingsNiveau in _context.BeheersingsNiveaus
                    from competentie in beheersingsNiveau.Competenties
                    from studiefase in competentie.Module.Studiefasen
                    where studiefase.Periode.PeriodeNummer <= periodeNummer
                    where studiefase.Specialisatie.SpecialisatieNaam == specialisatieNaam
                    select competentie)
                .Include(competentie => competentie.BeheersingsNiveau)
                .ThenInclude(niveau => niveau.ArchitectuurLaag)
                .Include(competentie => competentie.BeheersingsNiveau)
                .ThenInclude(niveau => niveau.Activiteit)
                .Include(competentie => competentie.Module)
                .ToList();
        }
    }
}