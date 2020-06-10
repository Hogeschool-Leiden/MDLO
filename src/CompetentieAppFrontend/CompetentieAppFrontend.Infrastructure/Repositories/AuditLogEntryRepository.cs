using System.Collections.Generic;
using System.Linq;
using CompetentieAppFrontend.Domain;
using CompetentieAppFrontend.Infrastructure.DAL;

namespace CompetentieAppFrontend.Infrastructure.Repositories
{
    public class AuditLogEntryRepository : IAuditLogEntryRepository
    {
        private readonly CompetentieAppFrontendContext _context;

        public AuditLogEntryRepository(CompetentieAppFrontendContext context) =>
            _context = context;

        public IList<AuditLogEntry> GetAllAuditLogEntries() =>
            _context.AuditLogEntries.ToList();

        public void Create(AuditLogEntry auditLogEntry)
        {
            _context.AuditLogEntries.Add(auditLogEntry);
            _context.SaveChanges();
        }
    }
}