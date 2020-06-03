using System.Collections.Generic;
using Miffy.MicroServices.Events;

namespace ModuleDomainService.Infrastructure.DAL
{
    public interface IEventStore
    {
        EventStream LoadStream(string streamId);
  
        void AppendToStream(string streamId, int version, IEnumerable<DomainEvent> events);
    }
}