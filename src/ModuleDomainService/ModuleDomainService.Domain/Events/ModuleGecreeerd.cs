using System.Collections.Generic;
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
        public string Cohort { get; set; }
        public Studiefase Studiefase { get; set; }
        public Matrix Competenties { get; set; }
        public IEnumerable<string> Eindeisen { get; set; }
        public IEnumerable<Specialisatie> VerplichtVoor { get; set; }
        public IEnumerable<Specialisatie> AanbevolenVoor { get; set; }
    }
}