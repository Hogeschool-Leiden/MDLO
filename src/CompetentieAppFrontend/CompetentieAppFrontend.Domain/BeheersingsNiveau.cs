using System.Collections.Generic;

namespace CompetentieAppFrontend.Domain
{
    public class BeheersingsNiveau
    {
        public long Id { get; set; }
        public long ArchitectuurLaagId { get; set; }
        
        public ArchitectuurLaag ArchitectuurLaag { get; set; }

        public long ActiviteitId { get; set; }
        
        public Activiteit Activiteit { get; set; }
        
        public int Niveau { get; set; }

        public IEnumerable<Competentie> Competenties { get; set; }
    }
}