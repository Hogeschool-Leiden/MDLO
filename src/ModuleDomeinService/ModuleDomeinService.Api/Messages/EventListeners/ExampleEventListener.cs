
using Miffy.MicroServices.Events;
using ModuleDomeinService.Api.Messages.Events;
using System;

namespace ModuleDomeinService.Api.Messages.EventListeners
{

    public class ExampleEventListener
    {
        [EventListener]
        [Topic("ExampleTopic")]
        public void Handles(ExampleEvent exampleEvent)
        {
            Console.WriteLine("ExampleEvent ontvangen");
        }
    }
}
