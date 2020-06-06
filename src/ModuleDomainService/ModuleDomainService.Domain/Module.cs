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
        private Cohort _cohort;
        private ModuleLeider _moduleLeider;
        private Studiefase _studiefase;
        private Status _status;
        private Competenties _competenties;
        private EindEisen _eindEisen;

        public Module(CreeerModuleCommand creeerModuleCommand) => Creeer(creeerModuleCommand);

        public Module(IEnumerable<DomainEvent> events) : base(events)
        {
        }

        public override string Id => $"{_code}:{_cohort.Studiejaar}";

        private void Creeer(CreeerModuleCommand creeerModuleCommand)
        {
            Apply(new ModuleGecreeerd
            {
                ModuleNaam = creeerModuleCommand.ModuleNaam,
                ModuleCode = creeerModuleCommand.ModuleCode,
                AantalEc = creeerModuleCommand.AantalEc
            });
        }

        protected override void Mutate(DomainEvent @event) => ((dynamic) this).When((dynamic) @event);

        private void When(ModuleGecreeerd @event)
        {
            _naam = @event.ModuleNaam;
            _code = @event.ModuleCode;
            _aantalEc = @event.AantalEc;
            _cohort = @event.Cohort;
            _moduleLeider = @event.ModuleLeider;
            _studiefase = @event.Studiefase;
            _status = @event.Status;
            _competenties = @event.Competenties;
            _eindEisen = @event.Eindeisen;
        }
    }
}