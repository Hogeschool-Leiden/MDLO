using System;

namespace CompetentieAppFrontend.Domain
{
    public class AuditLogEntry
    {
        public long Id { get; set; }
        public long ModuleId { get; set; }
        public Module Module { get; set; }
        public string Omschrijving { get; set; }
        public DateTime Timestamp { get; set; }
    }
}