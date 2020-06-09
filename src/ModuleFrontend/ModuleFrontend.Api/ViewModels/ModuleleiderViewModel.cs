using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace ModuleFrontend.Api.ViewModels
{
    [ExcludeFromCodeCoverage]
    public class ModuleleiderViewModel
    {
        public long Id { get; set; }
        public string Naam { get; set; }
        public string Email { get; set; }
        public string Telefoonnummer { get; set; }
    }
}