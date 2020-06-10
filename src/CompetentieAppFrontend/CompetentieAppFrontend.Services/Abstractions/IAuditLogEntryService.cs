using System.Collections.Generic;
using CompetentieAppFrontend.Services.ViewModels;

namespace CompetentieAppFrontend.Services.Abstractions
{
    public interface IAuditLogEntryService
    {
        IEnumerable<AuditLogEntryViewModel> GetAllAuditLogEntries();
    }
}