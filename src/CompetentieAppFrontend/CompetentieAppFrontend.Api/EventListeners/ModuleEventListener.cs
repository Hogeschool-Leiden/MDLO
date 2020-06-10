using CompetentieAppFrontend.Constants;
using CompetentieAppFrontend.Services.Abstractions;
using CompetentieAppFrontend.Services.Events;
using Microsoft.Extensions.Logging;
using Miffy.MicroServices.Events;

namespace CompetentieAppFrontend.Api.EventListeners
{
    public class ModuleEventListener
    {
        private readonly IModuleEventsDeserializer _moduleEventsDeserializer;
        private readonly ILogger<ModuleEventListener> _logger;

        public ModuleEventListener(IModuleEventsDeserializer moduleEventsDeserializer, ILogger<ModuleEventListener> logger)
        {
            _moduleEventsDeserializer = moduleEventsDeserializer;
            _logger = logger;
        }

        [EventListener]
        [Topic(Topics.ModuleGecreeerd)]
        public void ModuleGecreeerd(ModuleGecreeerd @event)
        {
            _moduleEventsDeserializer.CreateModule(@event);
            
            _logger.LogInformation($"{nameof(ModuleGecreeerd)} triggerd");
        }
    }
}