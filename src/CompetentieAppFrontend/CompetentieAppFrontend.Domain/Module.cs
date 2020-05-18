using System;
using System.Collections.Generic;

namespace CompetentieAppFrontend.Domain
{
    public class Module
    {
        public string ModuleCode { get; set; }

        public string ModuleNaam { get; set; }

        public string Studiepunten { get; set; }

        public IEnumerable<ArchitectuurLaag> ArchitectuurLagen { get; set; }
    }
}
