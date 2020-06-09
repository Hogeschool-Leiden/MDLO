using System.Collections.Generic;
using CompetentieAppFrontend.Domain;
using CompetentieAppFrontend.Infrastructure.DAL;

namespace CompetentieAppFrontend.Infrastructure.Repositories
{
    public class StudiefaseRepository : IStudiefaseRepository
    {
        private readonly CompetentieAppFrontendContext _context;

        public StudiefaseRepository(CompetentieAppFrontendContext context) => _context = context;

        public void CreateStudiefasen(IEnumerable<Studiefase> studiefasen)
        {
            _context.Studiefasen.AddRange(studiefasen);
            _context.SaveChanges();
        }
    }
}