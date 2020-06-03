using System;
using System.Collections.Generic;

namespace ModuleDomainService.Domain
{
    public class Module
    {
        private Guid _id;
        private string _code;
        private string _naam;
        private string _studieJaar;
        private int _ec;
        private bool _boekVerplicht;
        private int _lesUren;
        private Video _video;
        private Slide _slide;
        private Allen _allen;
        private IEnumerable<Specialisatie> _specialisaties;
        private List<Specialisatie> _specialisatie;
        private List<Competentie> _competenties;

        private Module() => Changes = new List<IEvent>();

        public Module(IEnumerable<IEvent> events) : this()
        {
            foreach (var @event in events)
            {
                Mutate(@event);
                Version++;
            }
        }

        public int Version { get; }

        public List<IEvent> Changes { get; }

        private void Apply(IEvent @event)
        {
            Changes.Add(@event);
            Mutate(@event);
        }

        private void Mutate(IEvent @event) => ((dynamic) this).When((dynamic) @event);
    }
}