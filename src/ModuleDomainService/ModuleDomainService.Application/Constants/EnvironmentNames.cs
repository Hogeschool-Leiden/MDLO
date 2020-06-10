using System.Diagnostics.CodeAnalysis;

namespace ModuleDomainService.Application.Constants
{
    [ExcludeFromCodeCoverage]
    internal static class EnvironmentNames
    {
        internal const string BrokerExchangeName = "BROKER_QUEUE_NAME";
        internal const string LogLevel = "LOG_LEVEL";
        internal const string DbConnectionString = "DB_CONNECTION_STRING";
    }
}