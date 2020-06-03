using Miffy.MicroServices.Events;

namespace ModuleDomainService.Domain.Events
{
    public class ModuleGecreeerd : DomainEvent
    {
        public ModuleGecreeerd() : base("ModuleDomainService.ModuleGecreeerd")
        {
        }
    }
}