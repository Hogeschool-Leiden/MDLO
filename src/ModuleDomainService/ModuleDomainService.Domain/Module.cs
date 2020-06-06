using System.Collections.Generic;
using System.Linq;
using Miffy.MicroServices.Events;
using ModuleDomainService.Domain.Commands;
using ModuleDomainService.Domain.Events;

namespace ModuleDomainService.Domain
{
    public class Module
    {
        private string _code;
        private string _naam;
        private string _studiejaar;
        private int _aantalEc;
        private ModuleLeider _moduleLeider;
        private Studiefase _studiefase;
        private Status _status;
        private Competenties _competenties;
        private EindEisen _eindEisen;

        private Module() => Changes = new List<DomainEvent>();

        public Module(CreeerModuleCommand creeerModuleCommand) => Creeer(creeerModuleCommand);

        public Module(IEnumerable<DomainEvent> events) : this() => CreeerFromExistingEvents(events);

        public string Id => $"{_code}:{_studiejaar}";

        public int Version { get; private set; }

        public List<DomainEvent> Changes { get; }

        private void Creeer(CreeerModuleCommand creeerModuleCommand)
        {
            Apply(new ModuleGecreeerd
            {
                ModuleNaam = creeerModuleCommand.ModuleNaam,
                ModuleCode = creeerModuleCommand.ModuleCode,
                AantalEc = creeerModuleCommand.AantalEc,
                Studiejaar = creeerModuleCommand.Studiejaar
            });
        }

        private void CreeerFromExistingEvents(IEnumerable<DomainEvent> events)
        {
            events.ToList().ForEach(@event =>
            {
                Mutate(@event);
                Version++;
            });
        }

        private void Apply(DomainEvent @event)
        {
            Changes.Add(@event);
            Mutate(@event);
        }

        private void Mutate(DomainEvent @event) => ((dynamic) this).When((dynamic) @event);

        private void When(ModuleGecreeerd @event)
        {
            _naam = @event.ModuleNaam;
            _code = @event.ModuleCode;
            _aantalEc = @event.AantalEc;
            _studiejaar = @event.Studiejaar;
        }
    }
}