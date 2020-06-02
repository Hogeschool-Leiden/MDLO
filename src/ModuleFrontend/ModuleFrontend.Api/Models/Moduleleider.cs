﻿using System.ComponentModel.DataAnnotations;

namespace ModuleFrontend.Api
{
    public class Moduleleider
    {
        public long Id { get; set; }
        [Required]
        public string Naam { get; set; }
        [EmailAddress]
        [Required]
        public string Email { get; set; }
        [Phone]
        [Required]
        public string Telefoonnummer { get; set; }
    }
}