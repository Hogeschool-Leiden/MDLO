
using System.Diagnostics.CodeAnalysis;

namespace ModuleFrontend.Api.Commands
{
    [ExcludeFromCodeCoverage]
    public class CreeerModuleCommandResponse
    {
        public string Message { get; set; }
        public int StatusCode { get; set; }
    }
}
