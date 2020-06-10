using System.Diagnostics.CodeAnalysis;

namespace ModuleDomainService.Domain.Constants
{
    [ExcludeFromCodeCoverage]
    internal static class DestinationQueueNames
    {
        internal const string CreeerModule = "MDLO.ModuleDomainService.CreeerModule";
        internal const string CreeerModuleResponse = "MDLO.ModuleBeheerService.CreeerModuleResponse";
    }
}