namespace ModuleFrontend.Api.Models
{
    public class Studiefase
    {
        public long Id { get; set; }
        public string Fase { get; set; }
        public Periode Periode { get; set; }
    }
}