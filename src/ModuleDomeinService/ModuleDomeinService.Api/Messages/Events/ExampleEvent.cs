
using Miffy.MicroServices.Events;

namespace ModuleDomeinService.Api.Messages.Events
{
    public class ExampleEvent : DomainEvent
    {
        public string ExampleData { get; set; }
        public ExampleEvent() : base("ExampleTopic") { }
    }
}

