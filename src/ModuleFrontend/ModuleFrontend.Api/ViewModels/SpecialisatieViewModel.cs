using System.ComponentModel.DataAnnotations;

namespace ModuleFrontend.Api.ViewModels
{
    public class SpecialisatieViewModel
    {
        public long Id { get; set; }
        public string Naam { get; set; }
        [Required]
        public string Code { get; set; }
    }
}