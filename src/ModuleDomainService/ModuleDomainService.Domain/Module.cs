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
        private string _studieJaar;
        private int _aantalEC;
        private ModuleLeider _moduleLeider;
        private Studiefase _studiefase;
        private Status _status;
        private List<string> _leerdoelen;
        private Voorkennis _voorkennis;
        private Competenties _competenties;
        private string _beschrijvingLeerdoelen;
        private string _inhoudelijkeBeschrijving;
        private string _eindeisen;
        private string _contacturenEnWerkvormen;
        private Beoordeling _beoordeling;
        private List<Examinator> _examinatoren;

        private Module() => Changes = new List<DomainEvent>();

        public Module(CreeerModuleCommand command)
        {
            Apply(new ModuleGecreeerd
            {
            });
        }

        public Module(IEnumerable<DomainEvent> events) : this() =>
            events.ToList().ForEach(@event =>
            {
                Mutate(@event);
                Version++;
            });

        public string Id => $"{_code}:{_studieJaar}";

        public int Version { get; private set; }

        public List<DomainEvent> Changes { get; }

        private void Apply(DomainEvent @event)
        {
            Changes.Add(@event);
            Mutate(@event);
        }

        private void Mutate(DomainEvent @event) => ((dynamic) this).When((dynamic) @event);

        private void When(ModuleGecreeerd @event)
        {
        }
    }
}