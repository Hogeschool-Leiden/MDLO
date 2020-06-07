using ModuleFrontend.Api.Models;
using System.Collections.Generic;

namespace ModuleFrontend.Api.DTO
{
    public class Module
    {
        public IEnumerable<Specialisatie> VerplichtVoor { get; set; }
        public string ModuleNaam { get; set; }
        public string ModuleCode { get; set; }
        public string Cohort { get; set; }
        public string Eindeisen { get; set; }
        public Studiefase Studiefase { get; set; }
    }
}
