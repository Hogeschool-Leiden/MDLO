using System.Collections.Generic;

namespace CompetentieAppFrontend.Domain
{
    public class Periode
    {
        public int PeriodeNummer { get; set; }

        public IEnumerable<ArchitectuurLaag> ArchitectuurLagen { get; set; }
    }
}