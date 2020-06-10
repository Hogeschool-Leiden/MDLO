using Microsoft.AspNetCore.Mvc;
using ModuleFrontend.Api.ViewModels;
using ModuleFrontend.Api.Services;
using System.Linq;
using ModuleFrontend.Api.Exceptions;
using Miffy;
using Microsoft.AspNetCore.Http;

namespace ModuleFrontend.Api.Controllers
{
    public class ModuleController : Controller
    {
        private readonly IModuleService _service;
        public ModuleController(IModuleService service)
        {
            _service = service;
        }

        [Route("module")]
        [HttpPost]
        public IActionResult PostModule([FromBody]ModuleViewModel module)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState.Values);
            }
            else if (module.VerplichtVoor.Count() < 1)
            {
                ModelState.AddModelError("VerplichtVoorError", "Een module moet voor minstens één specialisatie verplicht zijn, of een keuzevak zijn.");
                return BadRequest(ModelState.Values);
            }

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
    }
}