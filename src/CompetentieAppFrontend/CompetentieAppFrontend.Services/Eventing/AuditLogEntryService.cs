using System.Collections.Generic;
using System.Linq;
using CompetentieAppFrontend.Domain;
using CompetentieAppFrontend.Infrastructure.Repositories;
using CompetentieAppFrontend.Services.Abstractions;
using CompetentieAppFrontend.Services.ViewModels;

namespace CompetentieAppFrontend.Services.Eventing
{
    public class AuditLogEntryService : IAuditLogEntryService
    {
        private readonly IAuditLogEntryRepository _auditLogRepository;

        public AuditLogEntryService(IAuditLogEntryRepository auditLogRepository) =>
            _auditLogRepository = auditLogRepository;

        public IEnumerable<AuditLogEntryViewModel> GetAllAuditLogEntries() =>
            _auditLogRepository.GetAllAuditLogEntries().Select(entry => new AuditLogEntryViewModel
            {
                Omschrijving = entry.Omschrijving,
                Timestamp = entry.Timestamp
            }).ToList();
    }
}