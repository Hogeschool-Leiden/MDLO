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
    }
}