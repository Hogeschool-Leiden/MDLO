namespace ModuleDomainService.Infrastructure.DAL
{
    public class Stream
    {
        private Stream(string id) =>
            Id = id;

        public Stream(string id, int version) : this(id) =>
            Version = version;

        public string Id { get; set; }
        public int Version { get; set; }
    }
}