using System;
using System.Net;
using Miffy.MicroServices.Commands;

namespace ModuleDomainService.Domain.Commands
{
    public class CreeerModuleResponse : DomainCommand
    {
        private CreeerModuleResponse(int statusCode) : base("") => StatusCode = statusCode;

        private CreeerModuleResponse(int statusCode, string message) : this(statusCode) => Message = message;

        public int StatusCode { get; }

        public string Message { get; }

        public static CreeerModuleResponse OkResponse => new CreeerModuleResponse(200, "OK");
    }
}