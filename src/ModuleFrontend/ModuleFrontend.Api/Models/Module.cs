using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace ModuleFrontend.Api.Models
{
    [ExcludeFromCodeCoverage]
    public class Module
    {
        public long ModuleId { get; set; }
        public string ModuleNaam { get; set; }
        public string ModuleCode { get; set; }
        public string Cohort { get; set; }
        public int AantalEc { get; set; }
        public string Studiejaar { get; set; }
        public Moduleleider Moduleleider { get; set; }
        public Studiefase Studiefase { get; set; }
        public IEnumerable<Specialisatie> VerplichtVoor { get; set; }
        public Matrix Competenties { get; set; }
        public IEnumerable<Specialisatie> AanbevolenVoor { get; set; }
        public List<string> Eindeisen { get; set; }
    }
}
