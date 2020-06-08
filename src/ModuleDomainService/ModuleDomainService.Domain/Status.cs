using System.Collections.Generic;

namespace ModuleDomainService.Domain
{
    public class Status
    {
        private Status(IEnumerable<Specialisatie> verplichtVoor) => VerplichtVoor = verplichtVoor;

        public Status(IEnumerable<Specialisatie> verplichtVoor, IEnumerable<Specialisatie> aanbevolenVoor) :
            this(verplichtVoor) =>
            AanbevolenVoor = aanbevolenVoor;

        public IEnumerable<Specialisatie> VerplichtVoor { get; }
        public IEnumerable<Specialisatie> AanbevolenVoor { get; }
    }
}