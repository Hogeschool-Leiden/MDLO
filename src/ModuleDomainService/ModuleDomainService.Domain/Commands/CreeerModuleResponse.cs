using System.Diagnostics.CodeAnalysis;
using Miffy.MicroServices.Commands;
using ModuleDomainService.Domain.Constants;

namespace ModuleDomainService.Domain.Commands
{
    [ExcludeFromCodeCoverage]
    public class CreeerModuleResponse : DomainCommand
    {
        private CreeerModuleResponse(int statusCode)
            : base(DestinationQueueNames.CreeerModuleResponse) =>
            StatusCode = statusCode;

        private CreeerModuleResponse(int statusCode, string message) : this(statusCode) => Message = message;

        public int StatusCode { get; }

        public string Message { get; }

        public static CreeerModuleResponse OkResponse => new CreeerModuleResponse(200, "OK");
        public static CreeerModuleResponse ModuleAlreadyExistResponse => new CreeerModuleResponse(400, "Module already exists");
    }
}