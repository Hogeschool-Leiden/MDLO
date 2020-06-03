using Miffy.MicroServices.Commands;

namespace ModuleDomainService.Domain.Commands
{
    public class CreeerModuleCommand : DomainCommand
    {
        public CreeerModuleCommand(string destinationQueue) : base("ModuleDomain.Module.CreeerModule")
        {
        }
    }
}