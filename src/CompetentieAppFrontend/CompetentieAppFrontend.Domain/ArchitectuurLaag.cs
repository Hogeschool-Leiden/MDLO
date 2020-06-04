using System.Collections.Generic;

namespace CompetentieAppFrontend.Domain
{
    public class ArchitectuurLaag
    {
        public long Id { get; set; }

        public string ArchitectuurLaagNaam { get; set; }
        
        public IEnumerable<BeheersingsNiveau> BeheersingsNiveaus { get; set; }
    }
}