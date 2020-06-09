using System;

namespace CompetentieAppFrontend.Services.Projections
{
    public class AuditLogEntryView
    {
        public string Omschrijving { get; set; }
        public DateTime Timestamp { get; set; }
    }
}