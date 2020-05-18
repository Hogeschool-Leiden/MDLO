using System.Collections.Generic;

namespace CompetentieAppFrontend.Domain
{
    public class Eindcompentie
    {
        public string EindcompentieNaam { get; set; }

        public IEnumerable<Periode> Perioden { get; set; }
    }
}