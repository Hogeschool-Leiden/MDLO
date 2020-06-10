using CompetentieAppFrontend.Domain;
using CompetentieAppFrontend.Services.Abstractions;

namespace CompetentieAppFrontend.Services.ViewModels
{
    public class Niveau : IMatrixable<int>
    {
        public Niveau(string xHeader, string yHeader, int value)
        {
            XHeader = xHeader;
            YHeader = yHeader;
            Value = value;
        }

        public string XHeader { get; }
        public string YHeader { get; }
        public int Value { get; }

        public static Niveau FromCompetentie(Competentie competentie)
        {
            return new Niveau(
                competentie.BeheersingsNiveau.ArchitectuurLaag.ArchitectuurLaagNaam,
                competentie.BeheersingsNiveau.Activiteit.ActiviteitNaam,
                competentie.BeheersingsNiveau.Niveau
            );
        }
    }
}