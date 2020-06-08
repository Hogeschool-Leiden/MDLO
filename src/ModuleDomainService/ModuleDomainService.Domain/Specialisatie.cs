namespace ModuleDomainService.Domain
{
    public class Specialisatie
    {
        private Specialisatie(string naam) => Naam = naam;
        public Specialisatie(string naam, string code) : this(naam) => Code = code;

        public string Naam { get; }
        public string Code { get; }
    }
}