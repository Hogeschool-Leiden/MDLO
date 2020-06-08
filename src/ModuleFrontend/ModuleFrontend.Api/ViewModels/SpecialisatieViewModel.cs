using System.ComponentModel.DataAnnotations;

namespace ModuleFrontend.Api.ViewModels
{
    public class SpecialisatieViewModel
    {
        public long Id { get; set; }
        public string Naam { get; set; }
        public string Code { get; set; }
    }
}