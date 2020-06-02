using System.ComponentModel.DataAnnotations;

namespace ModuleFrontend.Api.ViewModels
{
    public class StudiefaseViewModel
    {
        public long Id { get; set; }
        [Required]
        public string Fase { get; set; }
        [Required]
        public PeriodeViewModel Periode { get; set; }
    }
}