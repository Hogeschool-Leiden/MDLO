using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using Microsoft.AspNetCore.Http;

namespace ModuleFrontend.Api.ViewModels
{
    [ExcludeFromCodeCoverage]
    public class CsvInlaadFormViewModel
    {
        [Required]
        public string Cohort { get; set; }
        [Required]
        public IFormFile File { get; set; }        
    }
}