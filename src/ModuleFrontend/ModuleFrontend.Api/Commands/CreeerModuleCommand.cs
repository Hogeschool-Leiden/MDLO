using Miffy.MicroServices.Commands;
using ModuleFrontend.Api.DTO;

namespace ModuleFrontend.Api.Commands
{
    public class CreeerModuleCommand : DomainCommand
    {
        public CreeerModuleCommand() : base("ModuleDomain.Module.CreeerModule")
        {
        }
        public ModuleDTO Module { get; set; }
    }
}
