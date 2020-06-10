using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

namespace ModuleDomainService.Domain
{
    [ExcludeFromCodeCoverage]
    public class EindEisen
    {
        public EindEisen(IEnumerable<string> eindeisen)
        {
            try
            {
                Eindeisen = eindeisen.Select(omschrijving => new Eindeis(omschrijving));
            }
            catch (ArgumentNullException exception)
            {
                Eindeisen = new List<Eindeis>();
            }
        }

        public IEnumerable<Eindeis> Eindeisen { get; }
    }
}