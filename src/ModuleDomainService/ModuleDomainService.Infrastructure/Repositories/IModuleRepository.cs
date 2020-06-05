using ModuleDomainService.Domain;

namespace ModuleDomainService.Infrastructure.Repositories
{
    public interface IModuleRepository
    {
        Module LoadModule(string id);
        void SaveModule(Module module);
    }
}