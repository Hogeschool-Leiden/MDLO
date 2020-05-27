using System.Collections.Generic;
using System.Linq;
using CompetentieAppFrontend.Domain;
using CompetentieAppFrontend.Infrastructure.DAL;

namespace CompetentieAppFrontend.Infrastructure.Repositories
{
    public class EindCompetentieRepository : IEindCompetentieRepository
    {
        private readonly CompetentieAppFrontendContext _context;

        public EindCompetentieRepository(CompetentieAppFrontendContext context)
        {
            _context = context;
        }

        public IEnumerable<EindCompetentie> GetEindCompetenties(int periodeNummer, string specialisatieNaam)
        {
            return from beheersingsNiveau in _context.BeheersingsNiveaus
                from competentie in beheersingsNiveau.Competenties
                from studiefase in competentie.Module.Studiefasen
                where studiefase.Periode.PeriodeNummer <= periodeNummer
                where studiefase.Specialisatie.SpecialisatieNaam == specialisatieNaam
                select new EindCompetentie
                {
                    ArchitectuurLaagNaam = beheersingsNiveau.ArchitectuurLaag.ArchitectuurLaagNaam,
                    ActiviteitNaam = beheersingsNiveau.Activiteit.ActiviteitNaam,
                    Niveau = beheersingsNiveau.Niveau,
                    Modules = beheersingsNiveau.Competenties.Select(competentie => competentie.Module).ToList()
                };
        }
    }
}