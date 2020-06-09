﻿
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace ModuleFrontend.Api.Models
{
    public class Studiefase
    {
        [ExcludeFromCodeCoverage]
        public long StudiefaseId { get; set; }
        public string Fase { get; set; }
        public List<int> Periode { get; set; }
    }
}