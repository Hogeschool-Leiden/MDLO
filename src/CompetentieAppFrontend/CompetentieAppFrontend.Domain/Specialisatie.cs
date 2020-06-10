using System.Collections.Generic;

namespace CompetentieAppFrontend.Domain
{
    public class Specialisatie
    {
        public long Id { get; set; }
        public string Naam { get; set; }

        public IEnumerable<Studiefase> Studiefasen { get; set; }
    }
}