using System.Collections.Generic;
using CompetentieAppFrontend.Domain;

namespace CompetentieAppFrontend.Services.Abstractions
{
    public interface IAuditLogEntryService
    {
        IEnumerable<AuditLogEntry> GetAllAuditLogEntries();
    }
}