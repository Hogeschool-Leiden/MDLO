using CompetentieAppFrontend.Services.Abstractions;
using CompetentieAppFrontend.Services.Projections;

namespace CompetentieAppFrontend.Services.ViewModels
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
    }
}