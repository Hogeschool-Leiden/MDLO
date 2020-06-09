using System.Collections.Generic;
using CompetentieAppFrontend.Domain;
using CompetentieAppFrontend.Infrastructure.Repositories;
using CompetentieAppFrontend.Services.Abstractions;

namespace CompetentieAppFrontend.Services.Eventing
{
    public class AuditLogEntryService : IAuditLogEntryService
    {
        private readonly IAuditLogEntryRepository _auditLogRepository;

        public AuditLogEntryService(IAuditLogEntryRepository auditLogRepository) =>
            _auditLogRepository = auditLogRepository;

        public IEnumerable<AuditLogEntry> GetAllAuditLogEntries() =>
            _auditLogRepository.GetAllAuditLogEntries();
    }
}