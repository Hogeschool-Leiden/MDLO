using Miffy.MicroServices.Commands;
using ModuleDomainService.Domain;
using ModuleDomainService.Domain.Commands;
using ModuleDomainService.Infrastructure.Repositories;

namespace ModuleDomainService.Application.CommandListeners
{
    public class ModuleCommandListener
    {
        private readonly IModuleRepository _moduleRepository;

        public ModuleCommandListener(IModuleRepository moduleRepository) => _moduleRepository = moduleRepository;

        [CommandListener("ModuleDomain.Module.CreeerModule")]
        public CreeerModuleResponse CreeerModule(CreeerModuleCommand command)
        {
            var module = new Module(command);
            
            _moduleRepository.SaveModule(module);

            return CreeerModuleResponse.OkResponse;
        }
    }
}