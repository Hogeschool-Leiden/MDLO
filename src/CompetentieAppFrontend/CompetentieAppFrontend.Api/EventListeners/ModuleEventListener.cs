using CompetentieAppFrontend.Constants;
using CompetentieAppFrontend.Services.Eventing;
using Miffy.MicroServices.Events;

namespace CompetentieAppFrontend.Api.EventListeners
{
    public class ModuleEventListener
    {
        [EventListener]
        [Topic(Topics.ModuleGecreeerd)]
        public void ModuleGecreeerd(ModuleGecreeerd @event)
        {
            
        }
    }
}