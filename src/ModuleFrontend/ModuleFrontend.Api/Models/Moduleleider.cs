using System.Diagnostics.CodeAnalysis;

namespace ModuleFrontend.Api
{
    [ExcludeFromCodeCoverage]
    public class Moduleleider
    {
        public long ModuleLeiderId { get; set; }
        public string Naam { get; set; }
        public string Email { get; set; }
        public string Telefoonnummer { get; set; }
    }
}