﻿using System.ComponentModel.DataAnnotations;

namespace ModuleFrontend.Api.Models
{
    public class Studiefase
    {
        public long Id { get; set; }
        [Required]
        public string Fase { get; set; }
        [Required]
        public Periode Periode { get; set; }
    }
}