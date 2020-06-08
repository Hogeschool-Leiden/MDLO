using System.Collections.Generic;
using System.Linq;

namespace ModuleDomainService.Domain
{
    public class EindEisen
    {
        public EindEisen(IEnumerable<string> eindeisen) =>
            Eindeisen = eindeisen.Select(omschrijving => new Eindeis(omschrijving));

        public IEnumerable<Eindeis> Eindeisen { get; }
    }
}