using System.Diagnostics.CodeAnalysis;

namespace ModuleFrontend.Api.ViewModels
{
    [ExcludeFromCodeCoverage]
    public class SpecialisatieViewModel
    {
        public long Id { get; set; }
        public string Naam { get; set; }
        public string Code { get; set; }
    }
}