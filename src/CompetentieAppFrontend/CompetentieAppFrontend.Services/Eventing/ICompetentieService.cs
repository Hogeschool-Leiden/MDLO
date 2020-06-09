using CompetentieAppFrontend.Services.Projections;

namespace CompetentieAppFrontend.Services.Eventing
{
    public interface ICompetentieService
    {
        void CreateCompetenties(CreateCompetentiesCommand command);
        
        public class CreateCompetentiesCommand
        {
            public long ModuleId { get; set; }
            public Matrix<int> Competenties { get; set; }
        }
    }
}