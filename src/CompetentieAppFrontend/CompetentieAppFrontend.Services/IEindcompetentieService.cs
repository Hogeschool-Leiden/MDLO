namespace CompetentieAppFrontend.Services
{
    public interface IEindcompetentieService
    {
        Matrix<Eindniveau> GetEindcompetentieMatrixByCriteria(int periodeNummer, string specialisatieNaam);
    }
}