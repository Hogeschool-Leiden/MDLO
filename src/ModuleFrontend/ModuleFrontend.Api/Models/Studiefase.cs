
using System.Collections.Generic;

namespace ModuleFrontend.Api.Models
{
    public class Studiefase
    {
        public long StudiefaseId { get; set; }
        public string Fase { get; set; }
        public List<int> Periode { get; set; }
    }
}