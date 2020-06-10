using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace ModuleDomainService.Domain
{
    [ExcludeFromCodeCoverage]
    public class Studiefase
    {
        private Studiefase(string fase) => Fase = fase;

        public Studiefase(string fase, IEnumerable<int> perioden)
            : this(fase)
            => Perioden = perioden;

        public string Fase { get; }
        public IEnumerable<int> Perioden { get; }
    }
}