using Microsoft.AspNetCore.Mvc;
using ModuleFrontend.Api.ViewModels;
using ModuleFrontend.Api.Services;
using System.Linq;
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
            if (!module.VerplichtVoor.Any())
            {
                return BadRequest("Een module moest minstens voor één specialisatie verplicht zijn.");
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