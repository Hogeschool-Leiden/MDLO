using CompetentieAppFrontend.Services.Commands;

namespace CompetentieAppFrontend.Services.Abstractions
{
    public interface IEindeisService
    {
        void CreateEindeisen(CreateEindeisenCommand command);
    }
}