﻿using System.ComponentModel.DataAnnotations;

namespace ModuleFrontend.Api.Models
{
    public class Periode
    {
        public long Id { get; set; }
        [Required]
        public int PeriodeNummer { get; set; }

    }
}
