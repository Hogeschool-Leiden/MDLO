namespace CompetentieAppFrontend.Domain
{
    public class Eindeis
    {
        public long Id { get; set; }
        public long ModuleId { get; set; }
        public Module Module { get; set; }
        public string EindeisBeschrijving { get; set; }
    }
}