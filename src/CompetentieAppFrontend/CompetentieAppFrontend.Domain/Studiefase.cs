namespace CompetentieAppFrontend.Domain
{
    public class Studiefase
    {
        public long ModuleId { get; set; }
        public Module Module { get; set; }

        public long SpecialisatieId { get; set; }
        public Specialisatie Specialisatie { get; set; }

        public long PeriodeId { get; set; }
        public Periode Periode { get; set; }
    }
}