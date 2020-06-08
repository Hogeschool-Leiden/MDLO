using System.Collections.Generic;
using Miffy.MicroServices.Events;
using ModuleDomainService.Domain.Abstractions;
using ModuleDomainService.Domain.Commands;
using ModuleDomainService.Domain.Events;

namespace ModuleDomainService.Domain
{
    public class Module : AggregateRoot
    {
        private string _code;
        private string _naam;
        private int _aantalEc;
        private string _cohort;
        private Studiefase _studiefase;
        private Status _status;
        private Matrix _competenties;
        private EindEisen _eindEisen;

        public Module(CreeerModuleCommand creeerModuleCommand) => Creeer(creeerModuleCommand);

        public Module(IEnumerable<DomainEvent> events) : base(events)
        {
        }

        public override string Id => $"{_code}:{_cohort}";

        private void Creeer(CreeerModuleCommand creeerModule)
        {
            Apply(new ModuleGecreeerd
            {
                ModuleNaam = creeerModule.ModuleNaam,
                ModuleCode = creeerModule.ModuleCode,
                AantalEc = creeerModule.AantalEc,
                Cohort = creeerModule.Cohort,
                Studiefase = creeerModule.Studiefase,
                Competenties = creeerModule.Competenties,
                Eindeisen = creeerModule.Eindeisen,
                VerplichtVoor = creeerModule.VerplichtVoor,
                AanbevolenVoor = creeerModule.AanbevolenVoor
            });
        }

        protected override void Mutate(DomainEvent @event) => ((dynamic) this).When((dynamic) @event);

        private void When(ModuleGecreeerd @event)
        {
            _naam = @event.ModuleNaam;
            _code = @event.ModuleCode;
            _aantalEc = @event.AantalEc;
            _cohort = @event.Cohort;
            _studiefase = @event.Studiefase;
            _competenties = @event.Competenties;
            _eindEisen = new EindEisen(@event.Eindeisen);
            _status = new Status(@event.VerplichtVoor, @event.AanbevolenVoor);
        }
    }
}