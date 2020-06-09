using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace ModuleFrontend.Api.ViewModels
{
    [ExcludeFromCodeCoverage]
    public class StudiefaseViewModel
    {
        public long Id { get; set; }
        public string Fase { get; set; }
        [Required]
        public List<int> Periode { get; set; }
    }
}