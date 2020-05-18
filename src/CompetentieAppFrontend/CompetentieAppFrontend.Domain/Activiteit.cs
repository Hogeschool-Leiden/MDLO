using System.Collections.Generic;

namespace CompetentieAppFrontend.Domain
{
    public class Activiteit
    {
        public string ActiviteitNaam { get; set; }

        public int ActiviteitNiveau { get; set; }

        public IEnumerable<Module> Modules { get; set; }
    }
}