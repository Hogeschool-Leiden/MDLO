using CompetentieAppFrontend.Domain;

namespace CompetentieAppFrontend.Services
{
    public interface ICompetentieMatrixService
    {
        CompetentieMatrix CreateCompetentieMatrix(Module module);
    }
}