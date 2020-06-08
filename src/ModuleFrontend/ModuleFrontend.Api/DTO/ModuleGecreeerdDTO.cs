using ModuleFrontend.Api.Models;
using System.Collections.Generic;

namespace ModuleFrontend.Api.DTO
{
    public class ModuleGecreeerdDTO
    {
        public long ModuleId { get; set; }
        public IEnumerable<Specialisatie> VerplichtVoor { get; set; }
        public string ModuleNaam { get; set; }
        public string ModuleCode { get; set; }
        public string Cohort { get; set; }
        public string Eindeisen { get; set; }
        public Studiefase Studiefase { get; set; }
        public Matrix Competenties { get; set; }
    }
}
