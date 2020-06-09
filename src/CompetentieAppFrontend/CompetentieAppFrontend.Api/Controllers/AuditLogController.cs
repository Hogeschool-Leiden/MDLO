using System.Collections.Generic;
using CompetentieAppFrontend.Domain;
using CompetentieAppFrontend.Services.Abstractions;
using CompetentieAppFrontend.Services.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace CompetentieAppFrontend.Api.Controllers
{
    [ApiController]
    [Route("api/auditlog")]
    public class AuditLogController
    {
        private readonly IAuditLogEntryService _auditLogEntryService;

        public AuditLogController(IAuditLogEntryService auditLogEntryService) =>
            _auditLogEntryService = auditLogEntryService;

        [HttpGet]
        public IEnumerable<AuditLogEntryViewModel> GetAllAuditLogEntries() =>
            _auditLogEntryService.GetAllAuditLogEntries();
    }
}