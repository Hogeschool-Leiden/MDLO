using System.Collections.Generic;

namespace CompetentieAppFrontend.Services.ViewModels
{
    public class ModuleViewModel
    {
        public string CohortNaam { get; set; }
        public IEnumerable<string> Specialisaties { get; set; }
        public string ModuleCode { get; set; }
        public IEnumerable<int> Perioden { get; set; }
        public Matrix<int> Matrix { get; set; }
        public IEnumerable<string> Eindeisen { get; set; }
        public IEnumerable<AuditLogEntryViewModel> AuditLogEntries { get; set; }
    }
}