using System.Collections.Generic;
using CompetentieAppFrontend.Domain;
using CompetentieAppFrontend.Infrastructure.Repositories;
using CompetentieAppFrontend.Services.Abstractions;
using CompetentieAppFrontend.Services.Commands;
using CompetentieAppFrontend.Services.Eventing;
using CompetentieAppFrontend.Services.Events;
using CompetentieAppFrontend.Services.ViewModels;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace CompetentieAppFrontend.Services.Test.Eventing
{
    [TestClass]
    public class ModuleEventsDeserializerTest
    {
        private Mock<ICohortRepository> _cohortRepositoryMock;
        private Mock<IModuleRepository> _moduleRepositoryMock;
        private Mock<IStudiefaseService> _studiefaseServiceMock;
        private Mock<ICompetentieService> _competentieServiceMock;
        private Mock<IEindeisService> _eindeisServiceMock;
        private Mock<IAuditLogEntryRepository> _auditLogEntryRepository;

        [TestInitialize]
        public void TestInitialize()
        {
            _cohortRepositoryMock = new Mock<ICohortRepository>();
            _competentieServiceMock = new Mock<ICompetentieService>();
            _moduleRepositoryMock = new Mock<IModuleRepository>();
            _studiefaseServiceMock = new Mock<IStudiefaseService>();
            _eindeisServiceMock = new Mock<IEindeisService>();
            _auditLogEntryRepository = new Mock<IAuditLogEntryRepository>();

            _cohortRepositoryMock
                .Setup(repository => repository.EnsureCohortExist(It.IsAny<string>()))
                .Returns(1);

            _moduleRepositoryMock
                .Setup(repository => repository.CreateModule(It.IsAny<Module>()))
                .Returns(1);
        }

        [TestMethod]
        public void CreateModule_Should_Call_CreateModule_On_ModuleRepository()
        {
            // Arrange
            var deserializer = new ModuleEventsDeserializer(
                _cohortRepositoryMock.Object,
                _moduleRepositoryMock.Object,
                _studiefaseServiceMock.Object,
                _competentieServiceMock.Object,
                _eindeisServiceMock.Object,
                _auditLogEntryRepository.Object
            );

            // Act
            deserializer.CreateModule(Dummy);

            // Assert
            _moduleRepositoryMock.Verify(repository => repository.CreateModule(It.IsAny<Module>()));
        }

        [TestMethod]
        public void CreateModule_Should_Call_CreateEindeisen_On_EindeisService()
        {
            // Arrange
            var deserializer = new ModuleEventsDeserializer(
                _cohortRepositoryMock.Object,
                _moduleRepositoryMock.Object,
                _studiefaseServiceMock.Object,
                _competentieServiceMock.Object,
                _eindeisServiceMock.Object,
                _auditLogEntryRepository.Object
            );

            // Act
            deserializer.CreateModule(Dummy);

            // Assert
            _eindeisServiceMock.Verify(service => service.CreateEindeisen(It.IsAny<CreateEindeisenCommand>()));
        }

        [TestMethod]
        public void CreateModule_Should_Call_CreateStudiefasen_On_StudiefaseService()
        {
            // Arrange
            var deserializer = new ModuleEventsDeserializer(
                _cohortRepositoryMock.Object,
                _moduleRepositoryMock.Object,
                _studiefaseServiceMock.Object,
                _competentieServiceMock.Object,
                _eindeisServiceMock.Object,
                _auditLogEntryRepository.Object
            );

            // Act
            deserializer.CreateModule(Dummy);

            // Assert
            _studiefaseServiceMock.Verify(service => service.CreateStudiefasen(It.IsAny<CreateStudiefasenCommand>()));
        }

        [TestMethod]
        public void CreateModule_Should_CreateCompetenties_On_CompetentieService()
        {
            // Arrange
            var deserializer = new ModuleEventsDeserializer(
                _cohortRepositoryMock.Object,
                _moduleRepositoryMock.Object,
                _studiefaseServiceMock.Object,
                _competentieServiceMock.Object,
                _eindeisServiceMock.Object,
                _auditLogEntryRepository.Object
            );

            // Act
            deserializer.CreateModule(Dummy);

            // Assert
            _competentieServiceMock.Verify(service =>
                service.CreateCompetenties(It.IsAny<CreateCompetentiesCommand>()));
        }
        
        [TestMethod]
        public void CreateModule_Should_EnsureCohortExist_On_CohortRepository()
        {
            // Arrange
            var deserializer = new ModuleEventsDeserializer(
                _cohortRepositoryMock.Object,
                _moduleRepositoryMock.Object,
                _studiefaseServiceMock.Object,
                _competentieServiceMock.Object,
                _eindeisServiceMock.Object,
                _auditLogEntryRepository.Object
            );

            // Act
            deserializer.CreateModule(Dummy);
            
            // Assert
            _cohortRepositoryMock.Verify(repository => repository.EnsureCohortExist(It.IsAny<string>()));
        }
        
        [TestMethod]
        public void CreateModule_Should_Call_Create_On_AuditLogRepository()
        {
            // Arrange
            var deserializer = new ModuleEventsDeserializer(
                _cohortRepositoryMock.Object,
                _moduleRepositoryMock.Object,
                _studiefaseServiceMock.Object,
                _competentieServiceMock.Object,
                _eindeisServiceMock.Object,
                _auditLogEntryRepository.Object
            );

            // Act
            deserializer.CreateModule(Dummy);
            
            // Assert
            _auditLogEntryRepository.Verify(repository => repository.Create(It.IsAny<AuditLogEntry>()));
        }

        private static ModuleGecreeerd Dummy => new ModuleGecreeerd
        {
            ModuleCode = "",
            ModuleNaam = "",
            Cohort = "",
            AantalEc = 3,
            Studiefase = new Fase
            {
                Perioden = new[] {1}
            },
            VerplichtVoor = new List<Specialisatie>(),
            AanbevolenVoor = new List<Specialisatie>(),
            Eindeisen = new List<string>(),
            Competenties = new MatrixDTO
            {
                XHeaders = new List<string>(),
                YHeaders = new List<string>(),
                Cells = new int[0][]
            }
        };
    }
}