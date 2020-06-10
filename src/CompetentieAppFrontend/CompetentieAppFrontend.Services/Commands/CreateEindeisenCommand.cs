using System.Collections.Generic;
using System.Linq;
using CompetentieAppFrontend.Domain;

namespace CompetentieAppFrontend.Services.Commands
{
    public class CreateEindeisenCommand
    {
        public long ModuleId { get; set; }
        public IEnumerable<string> Beschrijvingen { get; set; }

        public IEnumerable<Eindeis> Eindeisen =>
            Beschrijvingen.Select(beschrijving => new Eindeis
            {
                ModuleId = ModuleId,
                EindeisBeschrijving = beschrijving
            });
    }
}