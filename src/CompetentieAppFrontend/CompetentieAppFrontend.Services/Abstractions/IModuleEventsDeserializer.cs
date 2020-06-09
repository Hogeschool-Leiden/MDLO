using CompetentieAppFrontend.Services.Events;

namespace CompetentieAppFrontend.Services.Abstractions
{
    public interface IModuleEventsDeserializer
    {
        void CreateModule(ModuleGecreeerd @event);
    }
}