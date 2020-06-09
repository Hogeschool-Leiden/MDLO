using System.Collections.Generic;
using CompetentieAppFrontend.Domain;
using CompetentieAppFrontend.Infrastructure.DAL;

namespace CompetentieAppFrontend.Infrastructure.Repositories
{
    public class EindeisRepository : IEindeisRepository
    {
        private readonly CompetentieAppFrontendContext _context;

        public EindeisRepository(CompetentieAppFrontendContext context)
        {
            _context = context;
        }
        public void CreateEindeisen(IEnumerable<Eindeis> eindeisen)
        {
            _context.Eindeisen.AddRange(eindeisen);
            _context.SaveChanges();
        }
    }
}