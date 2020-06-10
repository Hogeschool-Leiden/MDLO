using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using Miffy.MicroServices.Commands;
using ModuleFrontend.Api.Models;

namespace ModuleFrontend.Api.Commands
{
    [ExcludeFromCodeCoverage]
    public class CreeerModuleCommand : DomainCommand
    {
        public CreeerModuleCommand() : base("MDLO.ModuleDomainService.CreeerModule")
        {
        }
        public IEnumerable<Specialisatie> VerplichtVoor { get; set; }
        public IEnumerable<Specialisatie> AanbevolenVoor { get; set; }

        public string ModuleNaam { get; set; }
        public string ModuleCode { get; set; }
        public string Cohort { get; set; }
        public List<string> Eindeisen { get; set; }
        public Studiefase Studiefase { get; set; }
        public Matrix Competenties { get; set; }
    }
}
