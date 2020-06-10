using CompetentieAppFrontend.Services.Commands;

namespace CompetentieAppFrontend.Services.Abstractions
{
    public interface ICompetentieService
    {
        void CreateCompetenties(CreateCompetentiesCommand command);
        
    }
}