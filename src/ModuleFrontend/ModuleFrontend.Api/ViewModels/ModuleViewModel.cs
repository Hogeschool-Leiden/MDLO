using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ModuleFrontend.Api.ViewModels
{
    public class ModuleViewModel
    {
        public long Id { get; set; }
        [Required]
        public string ModuleNaam { get; set; }
        [Required]
        public string ModuleCode { get; set; }
        [Required]
        public int AantalEc { get; set; }
        [Required]
        public string Studiejaar { get; set; }
        [Required]
        public ModuleleiderViewModel Moduleleider { get; set; }
        [Required]
        public StudiefaseViewModel Studiefase { get; set; }
        public List<SpecialisatieViewModel> VerplichtVoor { get; set; }
        [Required]
        public List<SpecialisatieViewModel> AanbevolenVoor { get; set; }
        [Required]
        public string BeschrijvingLeerdoelen { get; set; }
        [Required]
        public string InhoudelijkeBeschrijving { get; set; }
        [Required]
        public string Eindeisen { get; set; }
        [Required]
        public string ContacturenWerkvormen { get; set; }
        [Required]
        public string Toetsvorm { get; set; }
        [Required]
        public string VoorwaardenVoldoende { get; set; }
        [Required]
        public string LetOp { get; set; }
        [Required]
        public bool Summatief { get; set; }
        [Required]
        public bool Formatief { get; set; }
        [Required]
        public bool Kwalitatief { get; set; }
        [Required]
        public bool Kwantitatief { get; set; }
        [Required]
        public string Examinatoren { get; set; }
    }
}
