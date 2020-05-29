using System.Linq;
using CompetentieAppFrontend.Domain;

namespace CompetentieAppFrontend.Services
{
    public class Eindcompetentie : IMatrixable<Eindniveau>
    {
        public Eindcompetentie(string xHeader, string yHeader, Eindniveau value)
        {
            XHeader = xHeader;
            YHeader = yHeader;
            Value = value;
        }

        public string XHeader { get; }
        public string YHeader { get; }
        public Eindniveau Value { get; }

        public static Eindcompetentie FromCompetentie(Competentie competentie)
        {
            return new Eindcompetentie(
                competentie.BeheersingsNiveau.ArchitectuurLaag.ArchitectuurLaagNaam,
                competentie.BeheersingsNiveau.Activiteit.ActiviteitNaam,
                new Eindniveau
                {
                    Niveau = competentie.BeheersingsNiveau.Niveau,
                    Modules = competentie.BeheersingsNiveau.Competenties.Select(beheersingsNiveauCompetentie =>
                        beheersingsNiveauCompetentie.Module.ModuleCode)
                }
            );
        }
    }
}