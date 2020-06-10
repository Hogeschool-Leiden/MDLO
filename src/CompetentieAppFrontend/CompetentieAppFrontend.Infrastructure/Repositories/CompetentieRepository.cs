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

        public IList<Competentie> GetAllCompetentiesByCriteria(ICompetentieRepository.Criteria criteria)
        {
            return (from beheersingsNiveau in _context.BeheersingsNiveaus
                    from competentie in beheersingsNiveau.Competenties
                    where competentie.Module.Cohort.CohortNaam == criteria.CohortNaam
                    from studiefase in competentie.Module.Studiefasen
                    where studiefase.Periode.PeriodeNummer <= criteria.PeriodeNummer
                    where studiefase.Specialisatie.Naam == criteria.SpecialisatieNaam
                    select competentie)
                .Include(competentie => competentie.BeheersingsNiveau)
                .ThenInclude(niveau => niveau.ArchitectuurLaag)
                .Include(competentie => competentie.BeheersingsNiveau)
                .ThenInclude(niveau => niveau.Activiteit)
                .Include(competentie => competentie.Module)
                .ThenInclude(module => module.Cohort)
                .ToList();
        }

        public void CreateCompetenties(IEnumerable<Competentie> competenties)
        {
            _context.Competenties.AddRange(competenties);
            _context.SaveChanges();
        }
    }
}