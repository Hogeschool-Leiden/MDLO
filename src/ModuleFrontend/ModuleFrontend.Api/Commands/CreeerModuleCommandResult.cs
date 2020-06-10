using Miffy.MicroServices.Commands;
using System.Diagnostics.CodeAnalysis;

namespace ModuleFrontend.Api.Commands
{
    [ExcludeFromCodeCoverage]
    public class CreeerModuleCommandResponse : DomainCommand
    {
        public CreeerModuleCommandResponse() : base("MDLO.ModuleBeheerService.CreeerModuleResponse") {}

        public int StatusCode { get; set; }

        public string Message { get; set; }
    }
}
