using System.ComponentModel.DataAnnotations;

namespace ModuleFrontend.Api.Models
{
    public class Specialisatie
    {
        public long SpecialisatieId { get; set; }
        public string Naam { get; set; }
        public string Code { get; set; }
    }
}