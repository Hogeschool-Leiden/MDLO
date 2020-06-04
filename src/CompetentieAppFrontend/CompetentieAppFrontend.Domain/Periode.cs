using System.Collections.Generic;

namespace CompetentieAppFrontend.Domain
{
    public class Periode
    {
        public long Id { get; set; }
        
        public int PeriodeNummer { get; set; }

        public IEnumerable<Studiefase> Studiefasen { get; set; }
    }
}