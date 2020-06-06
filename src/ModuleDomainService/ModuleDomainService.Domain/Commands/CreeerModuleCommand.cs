using System.Collections.Generic;
using Miffy.MicroServices.Commands;
using ModuleDomainService.Domain.Constants;

namespace ModuleDomainService.Domain.Commands
{
    public class CreeerModuleCommand : DomainCommand
    {
        public CreeerModuleCommand() : base(DestinationQueueNames.CreeerModule)
        {
        }

        public string ModuleNaam { get; set; }
        public string ModuleCode { get; set; }
        public int AantalEc { get; set; }
        public string Studiejaar { get; set; }
    }
}