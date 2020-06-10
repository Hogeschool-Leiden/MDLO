using System.Collections.Generic;
using System.Linq;
using CompetentieAppFrontend.Domain;

namespace CompetentieAppFrontend.Services.Commands
{
    public class CreateStudiefasenCommand
    {
        public long ModuleId { get; set; }
        public IEnumerable<Specialisatie> VerplichtVoor { get; set; }
        public IEnumerable<Specialisatie> AanbevolenVoor { get; set; }
        public IEnumerable<int> PeriodenNummers { get; set; }
        public IEnumerable<Specialisatie> Specialisaties => VerplichtVoor.Union(AanbevolenVoor);

        public IEnumerable<Periode> Perioden => PeriodenNummers
            .Select(periodeNummer => new Periode {PeriodeNummer = periodeNummer});
    }
}