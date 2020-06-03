using Miffy.MicroServices.Commands;
using ModuleDomainService.Domain;
using ModuleDomainService.Domain.Commands;
using ModuleDomainService.Infrastructure.Repositories;

namespace ModuleDomainService.Application.CommandHandlers
{
    public class ModuleCommandHandler
    {
        private readonly IModuleRepository _moduleRepository;

        public ModuleCommandHandler(IModuleRepository moduleRepository) => _moduleRepository = moduleRepository;

        [CommandListener("ModuleDomainService.Module.CreeerModule")]
        public CreeerModuleResponse CreeerModule(CreeerModuleCommand command)
        {
            var module = new Module(command);
            
            _moduleRepository.SaveModule(module);

            return CreeerModuleResponse.OkResponse;
        }
    }
}