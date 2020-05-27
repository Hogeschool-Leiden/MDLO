using System.Collections.Generic;

namespace CompetentieAppFrontend.Domain
{
    public class ModuleWithMatrix
    {
        public IEnumerable<string> Specialisaties { get; set; }
        public string ModuleCode { get; set; }
        public IEnumerable<int> Perioden { get; set; }
        public CompetentieMatrix Matrix { get; set; }
        public IEnumerable<string> Eindeisen { get; set; }
    }
}