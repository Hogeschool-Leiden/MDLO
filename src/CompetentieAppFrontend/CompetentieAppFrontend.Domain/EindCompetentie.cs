using System.Collections.Generic;

namespace CompetentieAppFrontend.Domain
{
    public class EindCompetentie
    {
        public IEnumerable<Module> Modules { get; set; }

        public int Niveau { get; set; }

        public string ActiviteitNaam { get; set; }

        public string ArchitectuurLaagNaam { get; set; }
    }
}