using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace ModuleFrontend.Api.Models
{
    [ExcludeFromCodeCoverage]
    public class Specialisatie
    {
        public long SpecialisatieId { get; set; }
        public string Naam { get; set; }
        public string Code { get; set; }
    }
}