using System.ComponentModel.DataAnnotations;

namespace ModuleFrontend.Api.ViewModels
{
    public class ModuleleiderViewModel
    {
        public long Id { get; set; }
        public string Naam { get; set; }
        public string Email { get; set; }
        public string Telefoonnummer { get; set; }
    }
}