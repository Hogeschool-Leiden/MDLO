using CompetentieAppFrontend.Infrastructure.Repositories;
using CompetentieAppFrontend.Services.Abstractions;
using CompetentieAppFrontend.Services.Commands;

namespace CompetentieAppFrontend.Services.Eventing
{
    public class EindeisService : IEindeisService
    {
        private readonly IEindeisRepository _eindeisRepository;

        public EindeisService(IEindeisRepository eindeisRepository) =>
            _eindeisRepository = eindeisRepository;

        public void CreateEindeisen(CreateEindeisenCommand command) =>
            _eindeisRepository.CreateEindeisen(command.Eindeisen);
    }
}