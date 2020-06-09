using CompetentieAppFrontend.Infrastructure.Repositories;

namespace CompetentieAppFrontend.Services.Eventing
{
    public class EindeisService : IEindeisService
    {
        private readonly IEindeisRepository _eindeisRepository;

        public EindeisService(IEindeisRepository eindeisRepository) =>
            _eindeisRepository = eindeisRepository;

        public void CreateEindeisen(IEindeisService.CreateEindeisenCommand command) =>
            _eindeisRepository.CreateEindeisen(command.Eindeisen);
    }
}