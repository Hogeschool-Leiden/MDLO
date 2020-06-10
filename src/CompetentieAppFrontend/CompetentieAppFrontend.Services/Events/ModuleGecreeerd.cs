using System.Collections.Generic;
using CompetentieAppFrontend.Constants;
using CompetentieAppFrontend.Domain;
using CompetentieAppFrontend.Services.Eventing;
using CompetentieAppFrontend.Services.Projections;
using CompetentieAppFrontend.Services.ViewModels;
using Miffy.MicroServices.Events;

namespace CompetentieAppFrontend.Services.Events
{
    public class ModuleGecreeerd : DomainEvent
    {
        public ModuleGecreeerd() : base(Topics.ModuleGecreeerd)
        {
        }
        
        public string ModuleNaam { get; set; }
        public string ModuleCode { get; set; }
        public int AantalEc { get; set; }
        public string Cohort { get; set; }
        public Fase Studiefase { get; set; }
        public Matrix<int> Competenties { get; set; }
        public IEnumerable<string> Eindeisen { get; set; }
        public IEnumerable<Specialisatie> VerplichtVoor { get; set; }
        public IEnumerable<Specialisatie> AanbevolenVoor { get; set; }
    }
}