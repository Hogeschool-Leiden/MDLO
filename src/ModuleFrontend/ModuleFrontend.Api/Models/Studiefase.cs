
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace ModuleFrontend.Api.Models
{
    [ExcludeFromCodeCoverage]
    public class Studiefase
    {
        [ExcludeFromCodeCoverage]
        public long StudiefaseId { get; set; }
        public string Fase { get; set; }
        public List<int> Perioden { get; set; }
    }
}