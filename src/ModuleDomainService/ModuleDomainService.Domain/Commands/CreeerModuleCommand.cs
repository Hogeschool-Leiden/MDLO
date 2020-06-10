using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using Miffy.MicroServices.Commands;
using ModuleDomainService.Domain.Constants;

namespace ModuleDomainService.Domain.Commands
{
    [ExcludeFromCodeCoverage]
    public class CreeerModuleCommand : DomainCommand
    {
        public CreeerModuleCommand() : base(DestinationQueueNames.CreeerModule)
        {
        }

        public string ModuleNaam { get; set; }
        public string ModuleCode { get; set; }
        public int AantalEc { get; set; }
        public string Cohort { get; set; }
        public Studiefase Studiefase { get; set; }
        public IEnumerable<string> Eindeisen { get; set; }
        public IEnumerable<Specialisatie> VerplichtVoor { get; set; }
        public IEnumerable<Specialisatie> AanbevolenVoor { get; set; }
        public Matrix Competenties { get; set; }
    }
}