using System.Collections.Generic;

namespace CompetentieAppFrontend.Services
{
    public class Eindniveau
    {
        public int Niveau { get; set; }

        public IEnumerable<string> Modules { get; set; }
    }
}