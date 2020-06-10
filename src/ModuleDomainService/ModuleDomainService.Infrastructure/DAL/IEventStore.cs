namespace ModuleDomainService.Infrastructure.DAL
{
    public interface IEventStore
    {
        EventStream LoadStream(string streamId);
        void AppendToStream(EventStream eventStream);
    }
}