using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

namespace ModuleFrontend.Api.ViewModels
{
    public class CsvInlaadFormViewModel
    {
        [Required]
        public string Cohort { get; set; }
        [Required]
        public IFormFile File { get; set; }        
    }
}