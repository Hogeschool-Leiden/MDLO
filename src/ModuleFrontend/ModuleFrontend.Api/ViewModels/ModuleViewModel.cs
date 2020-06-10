using ModuleFrontend.Api.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace ModuleFrontend.Api.ViewModels
{
    [ExcludeFromCodeCoverage]
    public class ModuleViewModel
    {
        public long Id { get; set; }
        public string ModuleNaam { get; set; }
        [Required]
        public string ModuleCode { get; set; }
        public int AantalEc { get; set; }
        public string Studiejaar { get; set; }
        [Required]
        public string Cohort { get; set; }
        public Moduleleider Moduleleider { get; set; }
        public Studiefase Studiefase { get; set; }
        [Required]
        public List<Specialisatie> VerplichtVoor { get; set; }
        public List<Specialisatie> AanbevolenVoor { get; set; }
        public Matrix Competenties { get; set; }
        public List<string> Eindeisen { get; set; }
    }
}
