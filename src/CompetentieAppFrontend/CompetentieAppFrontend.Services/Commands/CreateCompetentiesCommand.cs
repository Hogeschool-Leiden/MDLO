using System.Diagnostics.CodeAnalysis;
using CompetentieAppFrontend.Services.ViewModels;

namespace CompetentieAppFrontend.Services.Commands
{
    [ExcludeFromCodeCoverage]
    public class CreateCompetentiesCommand
    {
        public long ModuleId { get; set; }
        public Matrix<int> Competenties { get; set; }
    }
}