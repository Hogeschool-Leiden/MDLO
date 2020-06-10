namespace ModuleDomainService.Domain
{
    public struct Eindeis
    {
        public Eindeis(string omschrijving) =>
            Omschrijving = omschrijving;

        public string Omschrijving { get; }
    }
}