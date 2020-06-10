using CompetentieAppFrontend.Constants;
using CompetentieAppFrontend.Services.Abstractions;
using CompetentieAppFrontend.Services.Eventing;
using CompetentieAppFrontend.Services.Events;
using Miffy.MicroServices.Events;

namespace CompetentieAppFrontend.Api.EventListeners
{
    public class ModuleEventListener
    {
        private readonly IModuleEventsDeserializer _moduleEventsDeserializer;

        public ModuleEventListener(IModuleEventsDeserializer moduleEventsDeserializer) =>
            _moduleEventsDeserializer = moduleEventsDeserializer;

        [EventListener]
        [Topic(Topics.ModuleGecreeerd)]
        public void ModuleGecreeerd(ModuleGecreeerd @event) =>
            _moduleEventsDeserializer.CreateModule(@event);
    }
}