using Miffy.MicroServices.Commands;

namespace ModuleDomainService.Domain.Commands
{
    public class CreeerModuleCommand : DomainCommand
    {
        public CreeerModuleCommand() : base("ModuleDomain.Module.CreeerModule")
        {
        }

        public string ModuleNaam { get; set; }
        public string ModuleCode { get; set; }
        public int AantalEc { get; set; }
        public string Studiejaar { get; set; }
    }
}