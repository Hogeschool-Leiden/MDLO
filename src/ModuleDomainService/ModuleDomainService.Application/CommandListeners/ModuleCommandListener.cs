using System;
using Miffy.MicroServices.Commands;
using ModuleDomainService.Application.Constants;
using ModuleDomainService.Domain;
using ModuleDomainService.Domain.Commands;
using ModuleDomainService.Infrastructure.Exceptions;
using ModuleDomainService.Infrastructure.Repositories;

namespace ModuleDomainService.Application.CommandListeners
{
    public class ModuleCommandListener
    {
        private readonly IModuleRepository _moduleRepository;

        public ModuleCommandListener(IModuleRepository moduleRepository) => _moduleRepository = moduleRepository;

        [CommandListener(QueueNames.CreeerModule)]
        public CreeerModuleResponse HandleCreeerModule(CreeerModuleCommand command)
        {
            try
            {
                return CreeerModule(command);
            }
            catch (ModuleAlreadyExistException exception)
            {
                return CreeerModuleResponse.ModuleAlreadyExistResponse;
            }
        }

        private CreeerModuleResponse CreeerModule(CreeerModuleCommand command)
        {
            var module = new Module(command);

            _moduleRepository.SaveModule(module);

            return CreeerModuleResponse.OkResponse;
        }
    }
}