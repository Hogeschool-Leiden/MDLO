using System.Collections.Generic;
using CompetentieAppFrontend.Domain;
using CompetentieAppFrontend.Infrastructure.Repositories;
using CompetentieAppFrontend.Services.Commands;
using CompetentieAppFrontend.Services.Eventing;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace CompetentieAppFrontend.Services.Test.Eventing
{
    [TestClass]
    public class EindeisServiceTest
    {
        private Mock<IEindeisRepository> _eindeisRepositoryMock;

        [TestInitialize]
        public void TestInitialize()
        {
            _eindeisRepositoryMock = new Mock<IEindeisRepository>();
        }

        [TestMethod]
        public void CreateEindeisen_Should_Call_CreateEindeisen_On_EindeisRepository()
        {
            // Arrange
            var eindeisService = new EindeisService(_eindeisRepositoryMock.Object);

            // Act
            eindeisService.CreateEindeisen(new CreateEindeisenCommand
            {
                ModuleId = 1,
                Beschrijvingen = new List<string> {"Hi test"}
            });

            // Assert
            _eindeisRepositoryMock.Verify(repository => repository.CreateEindeisen(It.IsAny<IEnumerable<Eindeis>>()));
        }
    }
}