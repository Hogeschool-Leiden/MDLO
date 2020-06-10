using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

namespace ModuleDomainService.Domain
{
    [ExcludeFromCodeCoverage]
    public class EindEisen
    {
        public EindEisen(IEnumerable<string> eindeisen) =>
            Eindeisen = eindeisen.Select(omschrijving => new Eindeis(omschrijving));

        public IEnumerable<Eindeis> Eindeisen { get; }
    }
}