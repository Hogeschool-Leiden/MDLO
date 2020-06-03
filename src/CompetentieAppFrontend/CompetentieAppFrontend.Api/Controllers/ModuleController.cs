using System.Collections;
using System.Collections.Generic;
using CompetentieAppFrontend.Domain;
using CompetentieAppFrontend.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CompetentieAppFrontend.Api.Controllers
{
    [ApiController]
    [Route("modules")]
    public class ModuleController
    {
        private readonly IModuleService _moduleService;
        private readonly ILogger<ModuleController> _logger;

        public ModuleController(ILogger<ModuleController> logger, IModuleService moduleService)
        {
            _moduleService = moduleService;
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<ModuleView> GetAllModules()
        {
            _logger.LogInformation("Received call to get all modules.");
            return _moduleService.GetAllModules();
        }
    }
}