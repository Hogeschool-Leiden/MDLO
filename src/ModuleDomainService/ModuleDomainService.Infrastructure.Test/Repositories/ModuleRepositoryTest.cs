using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Miffy.MicroServices.Events;
using ModuleDomainService.Domain;
using ModuleDomainService.Domain.Commands;
using ModuleDomainService.Domain.Events;
using ModuleDomainService.Infrastructure.DAL;
using ModuleDomainService.Infrastructure.Exceptions;
using ModuleDomainService.Infrastructure.Repositories;
using Moq;

namespace ModuleDomainService.Infrastructure.Test.Repositories
{
    [TestClass]
    public class ModuleRepositoryTest
    {
        private Mock<IEventStore> _eventStoreMock = new Mock<IEventStore>();
        private Mock<IEventPublisher> _eventPublisherMock = new Mock<IEventPublisher>();

        [TestInitialize]
        public void TestInitialize()
        {
            _eventStoreMock = new Mock<IEventStore>();
            _eventPublisherMock = new Mock<IEventPublisher>();
        }

        [TestMethod]
        public void LoadModule_Should_Return_Instance_Of_Type_Module()
        {
            // Arrange
            _eventStoreMock
                .Setup(store => store.LoadStream(It.IsAny<string>()))
                .Returns(new EventStream("module:testid", 3, new[]
                {
                    new ModuleGecreeerd
                    {
                        ModuleCode = "IOPR",
                        ModuleNaam = "Object georienteerd programeren",
                        AantalEc = 3,
                        Cohort = "2019/2020",
                        Studiefase = new Studiefase("", new List<int>()),
                        Competenties = new Matrix(),
                        Eindeisen = new List<string>(),
                        VerplichtVoor = new List<Specialisatie>(),
                        AanbevolenVoor = new List<Specialisatie>()
                    }
                }));
            var repository = new ModuleRepository(_eventStoreMock.Object, _eventPublisherMock.Object);

            // Act
            var result = repository.LoadModule("testid");

            // Assert
            Assert.IsInstanceOfType(result, typeof(Module));
        }

        [TestMethod]
        public void LoadModule_Should_Return_Call_LoadStream_On_EventStore()
        {
            // Arrange
            _eventStoreMock
                .Setup(store => store.LoadStream(It.IsAny<string>()))
                .Returns(new EventStream("module:testid", 3, new[]
                {
                    new ModuleGecreeerd
                    {
                        ModuleCode = "IOPR",
                        ModuleNaam = "Object georienteerd programeren",
                        AantalEc = 3,
                        Cohort = "2019/2020",
                        Studiefase = new Studiefase("", new List<int>()),
                        Competenties = new Matrix(),
                        Eindeisen = new List<string>(),
                        VerplichtVoor = new List<Specialisatie>(),
                        AanbevolenVoor = new List<Specialisatie>()
                    }
                }));
            var repository = new ModuleRepository(_eventStoreMock.Object, _eventPublisherMock.Object);

            // Act
            var result = repository.LoadModule("testid");

            // Assert
            _eventStoreMock.Verify(store => store.LoadStream("module:testid"));
        }

        [TestMethod]
        public void SaveModule_While_Module_Has_No_Changes_Should_Not_Call_AppendToStream()
        {
            // Arrange
            var module = new Module(new List<DomainEvent>
            {
                new ModuleGecreeerd
                {
                    ModuleCode = "IOPR",
                    ModuleNaam = "Object georienteerd programeren",
                    AantalEc = 3,
                    Cohort = "2019/2020",
                    Studiefase = new Studiefase("", new List<int>()),
                    Competenties = new Matrix(),
                    Eindeisen = new List<string>(),
                    VerplichtVoor = new List<Specialisatie>(),
                    AanbevolenVoor = new List<Specialisatie>()
                }
            });
            var repository = new ModuleRepository(_eventStoreMock.Object, _eventPublisherMock.Object);

            // Act
            repository.SaveModule(module);

            // Assert
            _eventStoreMock.Verify(store => store.AppendToStream(It.IsAny<EventStream>()), Times.Never);
        }

        [TestMethod]
        public void SaveModule_Should_Throw_ModuleAlreadyExistException_If_Module_Already_Exist()
        {
            // Arrange
            _eventStoreMock
                .Setup(store => store.LoadStream(It.IsAny<string>()))
                .Throws<ModuleAlreadyExistException>();
            var module = new Module(
                new CreeerModuleCommand
                {
                    ModuleCode = "IOPR",
                    ModuleNaam = "Object georienteerd programeren",
                    AantalEc = 3,
                    Cohort = "2019/2020",
                    Studiefase = new Studiefase("", new List<int>()),
                    Competenties = new Matrix(),
                    Eindeisen = new List<string>(),
                    VerplichtVoor = new List<Specialisatie>(),
                    AanbevolenVoor = new List<Specialisatie>()
                });
            var repository = new ModuleRepository(_eventStoreMock.Object, _eventPublisherMock.Object);

            // Act
            var exception = Assert.ThrowsException<ModuleAlreadyExistException>(() => repository.SaveModule(module));

            // Assert
            Assert.AreEqual("Module already exist", exception.Message);
        }

        [TestMethod]
        public void SaveModule_Should_Call_AppendToStream_On_EventStore()
        {
            // Arrange
            var module = new Module(
                new CreeerModuleCommand
                {
                    ModuleCode = "IOPR",
                    ModuleNaam = "Object georienteerd programeren",
                    AantalEc = 3,
                    Cohort = "2019/2020",
                    Studiefase = new Studiefase("", new List<int>()),
                    Competenties = new Matrix(),
                    Eindeisen = new List<string>(),
                    VerplichtVoor = new List<Specialisatie>(),
                    AanbevolenVoor = new List<Specialisatie>()
                });
            var repository = new ModuleRepository(_eventStoreMock.Object, _eventPublisherMock.Object);

            // Act
            repository.SaveModule(module);

            // Assert
            _eventStoreMock.Verify(store => store.AppendToStream(It.IsAny<EventStream>()), Times.Once);
        }
    }
}