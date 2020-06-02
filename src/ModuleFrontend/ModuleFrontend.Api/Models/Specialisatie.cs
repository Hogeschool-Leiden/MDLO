﻿using System.ComponentModel.DataAnnotations;

namespace ModuleFrontend.Api.Models
{
    public class Specialisatie
    {
        public long Id { get; set; }
        public string Naam { get; set; }
        [Required]
        public string Code { get; set; }
    }
}