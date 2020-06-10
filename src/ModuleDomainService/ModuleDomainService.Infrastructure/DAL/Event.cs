using System;
using Miffy.MicroServices.Events;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace ModuleDomainService.Infrastructure.DAL
{
    public class Event
    {
        private const string EventsLocation = "ModuleDomainService.Domain.Events.";
        private const string DomainProject = "ModuleDomainService.Domain";

        private Event(string id) => Id = id;

        private Event(string id, Stream stream)
            : this(id) =>
            Stream = stream;

        private Event(string id, Stream stream, string type)
            : this(id, stream) =>
            Type = type;

        private Event(string id, Stream stream, string type, string payload)
            : this(id, stream, type) =>
            Payload = payload;

        public string Id { get; set; }
        public Stream Stream { get; set; }
        public string Type { get; set; }
        public string Payload { get; set; }

        public DomainEvent ToDomainEvent() =>
            (DomainEvent) JObject.FromObject(JObject.Parse(Payload)).ToObject(EventType);

        public static Event FromDomainEvent(Stream stream, DomainEvent domainEvent)
        {
            var id = $"{stream.Id}:{stream.Version}:{domainEvent.Type}";
            var type = domainEvent.Type;
            var payload = JsonConvert.SerializeObject(domainEvent);
            return new Event(id, stream, type, payload);
        }

        private Type EventType =>
            System.Type.GetType($"{EventsLocation}{Type}, {DomainProject}");
    }
}