using System.ComponentModel.DataAnnotations;

namespace ModuleFrontend.Api.ViewModels
{
    public class PeriodeViewModel
    {
        public long Id { get; set; }
        [Required]
        public int PeriodeNummer { get; set; }

    }
}
