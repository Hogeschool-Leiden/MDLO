using System.Collections.Generic;

namespace CompetentieAppFrontend.Domain
{
    public class Module
    {
        public long Id { get; set; }
        
        public string ModuleCode { get; set; }

        public string ModuleNaam { get; set; }

        public int Studiepunten { get; set; }

        public IEnumerable<Studiefase> Studiefasen { get; set; }

        public IEnumerable<Competentie> Competenties { get; set; }

        public IEnumerable<Eindeis> Eindeisen { get; set; }
    }
}
