using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using CompetentieAppFrontend.Domain;

namespace CompetentieAppFrontend.Services.Commands
{
    [ExcludeFromCodeCoverage]
    public class CreateStudiefasenCommand
    {
        public long ModuleId { get; set; }
        public IEnumerable<Specialisatie> VerplichtVoor { get; set; }
        public IEnumerable<Specialisatie> AanbevolenVoor { get; set; }
        public IEnumerable<int> PeriodenNummers { get; set; }
        public IEnumerable<Specialisatie> Specialisaties => VerplichtVoor.Union(AanbevolenVoor);

        public IEnumerable<Periode> Perioden
        {
            get
            {
                if (PeriodenNummers == null)
                {
                    return new List<Periode>();
                }
                
                return PeriodenNummers.Select(periodeNummer => new Periode {PeriodeNummer = periodeNummer});
            }
        }
    }
}