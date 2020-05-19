using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace CompetentieAppFrontend.Domain
{
    public class ArchitectuurLaag
    {
        public long Id { get; set; }

        public string ArchitectuurLaagNaam { get; set; }
        
        public IEnumerable<BeheersingsNiveau> BeheersingsNiveaus { get; set; }
    }
}