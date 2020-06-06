using System.Collections.Generic;

namespace ModuleDomainService.Domain
{
    public struct Status
    {
        private IEnumerable<Specialisatie> _verplichtVoor;
        private IEnumerable<Specialisatie> _aanbevolenVoor;
    }
}