using System.Collections.Generic;

namespace ModuleDomainService.Domain
{
    public class Status
    {
        private IEnumerable<Specialisatie> _verplichtVoor;
        private IEnumerable<Specialisatie> _aanbevolenVoor;
    }
}