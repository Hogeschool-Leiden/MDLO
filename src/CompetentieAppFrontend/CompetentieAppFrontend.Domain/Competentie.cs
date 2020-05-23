namespace CompetentieAppFrontend.Domain
{
    public class Competentie
    {
        public long ModuleId { get; set; }
        public Module Module { get; set; }

        public long BeheersingsNiveauId { get; set; }
        public BeheersingsNiveau BeheersingsNiveau { get; set; }
    }
}