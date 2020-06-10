using System;
using System.Collections.Generic;
using System.Linq;
using CompetentieAppFrontend.Domain;

namespace CompetentieAppFrontend.Services.Commands
{
    public class CreateEindeisenCommand
    {
        public long ModuleId { get; set; }
        public IEnumerable<string> Beschrijvingen { get; set; } = new List<string>();

        public IEnumerable<Eindeis> Eindeisen
        {
            get
            {
                try
                {
                    return Beschrijvingen.Select(beschrijving => new Eindeis
                    {
                        ModuleId = ModuleId,
                        EindeisBeschrijving = beschrijving
                    });
                }
                catch (ArgumentNullException e)
                {
                    return new List<Eindeis>();
                }
            }
        }
    }
}