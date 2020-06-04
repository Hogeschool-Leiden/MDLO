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
        public string Studiejaar { get; set; }
    }
}