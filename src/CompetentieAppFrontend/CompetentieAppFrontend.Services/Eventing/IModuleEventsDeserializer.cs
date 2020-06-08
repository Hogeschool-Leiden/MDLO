namespace CompetentieAppFrontend.Services.Eventing
{
    public interface IModuleEventsDeserializer
    {
        void CreateModule(ModuleGecreeerd @event);
    }
}