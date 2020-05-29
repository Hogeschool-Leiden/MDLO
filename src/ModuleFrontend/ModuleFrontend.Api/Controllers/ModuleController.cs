using Microsoft.AspNetCore.Mvc;
using ModuleFrontend.Api.Services;

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
    }
}