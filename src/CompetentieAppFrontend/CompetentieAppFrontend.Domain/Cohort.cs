using System;
using System.Collections.Generic;

namespace CompetentieAppFrontend.Domain
{
    public class Cohort
    {
        public long Id { get; set; }
        public string CohortNaam { get; set; }
        public DateTime StartDatum { get; set; }
        public IEnumerable<Module> Modules { get; set; }
    }
}