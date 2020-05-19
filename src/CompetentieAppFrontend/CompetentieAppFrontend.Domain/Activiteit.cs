using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace CompetentieAppFrontend.Domain
{
    public class Activiteit
    {
        public long Id { get; set; }
        
        public string ActiviteitNaam { get; set; }
        
        public IEnumerable<BeheersingsNiveau> BeheersingsNiveaus { get; set; }
    }
}