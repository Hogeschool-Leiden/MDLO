using Miffy.MicroServices.Events;
using ModuleDomainService.Domain.Constants;

namespace ModuleDomainService.Domain.Events
{
    public class ModuleGecreeerd : DomainEvent
    {
        public ModuleGecreeerd() : base(Topics.ModuleGecreeerd)
        {
        }

        public string ModuleNaam { get; set; }
        public string ModuleCode { get; set; }
        public int AantalEc { get; set; }
        public Cohort Cohort { get; set; }
        public ModuleLeider ModuleLeider { get; set; }
        public Studiefase Studiefase { get; set; }
        public Status Status { get; set; }
        public Competenties Competenties { get; set; }
        public EindEisen Eindeisen { get; set; }
    }
}