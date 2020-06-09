using System.Collections.Generic;
using CompetentieAppFrontend.Domain;

namespace CompetentieAppFrontend.Infrastructure.Repositories
{
    public interface IAuditLogEntryRepository
    {
        IEnumerable<AuditLogEntry> GetAllAuditLogEntries();
        void Create(AuditLogEntry auditLogEntry);
    }
}