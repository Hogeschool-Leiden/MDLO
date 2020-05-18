using System.Collections.Generic;

namespace CompetentieAppFrontend.Domain
{
    public class ArchitectuurLaag
    {
        public string ArchitectuurLaagNaam { get; set; }

        public IEnumerable<Activiteit> Activiteiten { get; set; }    
    }
}