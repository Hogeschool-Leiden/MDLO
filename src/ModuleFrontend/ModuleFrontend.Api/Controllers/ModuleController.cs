using Microsoft.AspNetCore.Mvc;
using ModuleFrontend.Api.ViewModels;
using ModuleFrontend.Api.Services;
using System.Linq;
using ModuleFrontend.Api.Exceptions;

namespace ModuleFrontend.Api.Controllers
{
    public class ModuleController : Controller
    {
        private readonly IModuleService _service;
        public ModuleController(IModuleService service)
        {
            _service = service;
        }

        public IActionResult GetModule(string modulecode)
        {
            var module = _service.GetByModuleCode(modulecode);
            if (module == null)
            {
                return NotFound();
            }

            return Ok(module);
        }

        public IActionResult GetAll()
        {
            return Ok(_service.GetAllModules());
        }

        [Route("module")]
        [HttpPost]
        public IActionResult PostModule([FromBody]ModuleViewModel module) 
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState.Values);
            } else if(module.VerplichtVoor.Count() < 1)
            {
                ModelState.AddModelError("VerplichtVoorError", "Een module moet voor minstens één specialisatie verplicht zijn, of een keuzevak zijn.");
                return BadRequest(ModelState.Values);
            }
            try
            {
                _service.AddModule(module);
            }
            catch (AlreadyExistsException e)
            {
                ModelState.AddModelError("BestaatAlError", e.Message);
                return BadRequest(ModelState.Values);
            }
            return Ok(module);
        }
    }
}