using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using ModuleFrontend.Api.ViewModels;
using ModuleFrontend.Api.Services;
using System.Linq;
using System.Reflection;
using Miffy;
using Microsoft.AspNetCore.Http;
using ModuleFrontend.Api.Utility;
using Module = ModuleFrontend.Api.Models.Module;
using ModuleFrontend.Api.Commands;

namespace ModuleFrontend.Api.Controllers
{
    public class ModuleController : Controller
    {
        private readonly IModuleService _service;
        private readonly ICsvLoader _csvLoader;
        public ModuleController(IModuleService service, ICsvLoader loader)
        {
            _service = service;
            _csvLoader = loader;
        }

        [Route("module")]
        [HttpPost]
        public IActionResult PostModule([FromBody]ModuleViewModel moduleViewModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState.Values);
            }
            if (!moduleViewModel.VerplichtVoor.Any())
            {
                return BadRequest("Een module moest minstens voor één specialisatie verplicht zijn.");
            }
            Module module = new Module()
            {
                Cohort = moduleViewModel.Cohort,
                Competenties = moduleViewModel.Competenties,
                Eindeisen = moduleViewModel.Eindeisen,
                Moduleleider = moduleViewModel.Moduleleider,
                Studiefase = moduleViewModel.Studiefase,
                AanbevolenVoor = moduleViewModel.AanbevolenVoor,
                VerplichtVoor = moduleViewModel.VerplichtVoor,
                Studiejaar = moduleViewModel.Studiejaar,
                AantalEc = moduleViewModel.AantalEc,
                ModuleCode = moduleViewModel.ModuleCode,
                ModuleNaam = moduleViewModel.ModuleNaam
            };
            
            try
            {
                var result = _service.SendCreeerModuleCommand(module);
                if(result.StatusCode == 400)
                {
                    return BadRequest("De combinatie van modulecode en cohort bestaat al.");
                }
                return Ok(result.Message);
            }
            catch (DestinationQueueException)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Er is een fout op de server opgetreden. Probeer het later opnieuw.");
            }
        }

        [Route("modulesinladen")]
        [HttpPost]
        
        public IActionResult PostCsvFile([FromForm] CsvInlaadFormViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var stream = model.File.OpenReadStream();
            IEnumerable<Module> modules = _csvLoader.ReadFromStream(stream);
            List<CreeerModuleCommandResponse> responses = new List<CreeerModuleCommandResponse>();
            foreach (var module in modules)
            {
                module.Cohort = model.Cohort;

                    try
                    {
                        var response = _service.SendCreeerModuleCommand(module);
                    responses.Add(response);
                    }
                    catch (DestinationQueueException)
                    {
                    }
            }
            return Ok(responses.Where(r => r.StatusCode==200).Count());
        }
        
    }
}