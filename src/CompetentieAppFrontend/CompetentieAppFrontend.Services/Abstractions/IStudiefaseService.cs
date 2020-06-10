using CompetentieAppFrontend.Services.Commands;

namespace CompetentieAppFrontend.Services.Abstractions
{
    public interface IStudiefaseService
    {
        void CreateStudiefasen(CreateStudiefasenCommand command);
    }
}