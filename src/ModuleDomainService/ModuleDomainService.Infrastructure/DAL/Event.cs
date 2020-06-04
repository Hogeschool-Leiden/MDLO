namespace ModuleDomainService.Infrastructure.DAL
{
    public class Event
    {
        public string Id { get; set; }
        public Stream Stream { get; set; }
        public string Type { get; set; }
        public string Payload { get; set; }
    }
}