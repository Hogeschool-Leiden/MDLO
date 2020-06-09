using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ModuleFrontend.Api.ViewModels
{
    public class StudiefaseViewModel
    {
        public long Id { get; set; }
        public string Fase { get; set; }
        [Required]
        public List<int> Periode { get; set; }
    }
}