using System.Collections.Generic;

namespace ModuleFrontend.Api.Models
{
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
        //public IEnumerable<Specialisatie> AanbevolenVoor { get; set; }
        //public string BeschrijvingLeerdoelen { get; set; }
        //public string InhoudelijkeBeschrijving { get; set; }
        public string Eindeisen { get; set; }
        //public string ContacturenWerkvormen { get; set; }
        //public string Toetsvorm { get; set; }
        //public string VoorwaardenVoldoende { get; set; }
        //public string LetOp { get; set; }
        //public bool Summatief { get; set; }
        //public bool Formatief { get; set; }
        //public bool Kwalitatief { get; set; }
        //public bool Kwantitatief { get; set; }
        //public string Examinatoren { get; set; }
    }
}
