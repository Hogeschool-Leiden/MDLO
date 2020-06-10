using Miffy.MicroServices.Commands;

namespace ModuleFrontend.Api.Commands
{
    [ExcludeFromCodeCoverage]
    public class CreeerModuleCommandResponse : DomainCommand
    {
        public CreeerModuleResponse() : base("MDLO.ModuleBeheerService.CreeerModuleResponse") {}

        public int StatusCode { get; set; }

        public string Message { get; set; }
    }
}
