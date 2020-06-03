using System.ComponentModel.DataAnnotations;

namespace ModuleFrontend.Api.Models
{
    public class Studiefase
    {
        public long StudiefaseId { get; set; }
        public string Fase { get; set; }
        public Periode Periode { get; set; }
    }
}