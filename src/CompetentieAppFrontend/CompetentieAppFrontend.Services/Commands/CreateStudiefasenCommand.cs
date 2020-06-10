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
        public IEnumerable<Specialisatie> VerplichtVoor { get; set; } = new List<Specialisatie>();
        public IEnumerable<Specialisatie> AanbevolenVoor { get; set; } = new List<Specialisatie>();
        public IEnumerable<int> PeriodenNummers { get; set; } = new List<int>();
        public IEnumerable<Specialisatie> Specialisaties => VerplichtVoor.Union(AanbevolenVoor);

        public IEnumerable<Periode> Perioden => PeriodenNummers
            .Select(periodeNummer => new Periode {PeriodeNummer = periodeNummer});
    }
}