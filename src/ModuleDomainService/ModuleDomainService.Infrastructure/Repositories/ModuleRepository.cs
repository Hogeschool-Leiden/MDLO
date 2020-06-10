using Miffy.MicroServices.Events;
using ModuleDomainService.Domain;
using ModuleDomainService.Domain.Abstractions;
using ModuleDomainService.Infrastructure.DAL;
using ModuleDomainService.Infrastructure.Exceptions;

namespace ModuleDomainService.Infrastructure.Repositories
{
    public class ModuleRepository : IModuleRepository
    {
        private readonly IEventStore _eventStore;
        private readonly IEventPublisher _eventPublisher;

        public ModuleRepository(IEventStore eventStore, IEventPublisher eventPublisher)
        {
            _eventStore = eventStore;
            _eventPublisher = eventPublisher;
        }

        public Module LoadModule(string id)
        {
            var streamId = $"module:{id}";

            var eventStream = _eventStore.LoadStream(streamId);

            return new Module(eventStream.Events);
        }

        public void SaveModule(Module module)
        {
            if (module.HasNoChanges) return;

            DoesModuleExist(module);

            _eventStore.AppendToStream(new EventStream($"module:{module.Id}", module.Version, module.Changes));

            module.Changes.ForEach(@event => _eventPublisher.Publish(@event));
        }

        private void DoesModuleExist(AggregateRoot module)
        {
            var stream = _eventStore.LoadStream(module.Id);

            if (!stream.IsNullOrEmpty)
            {
                throw new ModuleAlreadyExistException();
            }
        }
    }
}