using System.Diagnostics.CodeAnalysis;

namespace ModuleDomainService.Domain
{
    [ExcludeFromCodeCoverage]
    public class Eindeis
    {
        public Eindeis(string omschrijving) =>
            Omschrijving = omschrijving;

        public string Omschrijving { get; }
    }
}