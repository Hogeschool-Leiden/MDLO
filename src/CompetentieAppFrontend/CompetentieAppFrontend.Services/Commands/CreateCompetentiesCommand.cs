using CompetentieAppFrontend.Services.Projections;
using CompetentieAppFrontend.Services.ViewModels;

namespace CompetentieAppFrontend.Services.Commands
{
    public class CreateCompetentiesCommand
    {
        public long ModuleId { get; set; }
        public Matrix<int> Competenties { get; set; }
    }
}