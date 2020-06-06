using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Miffy.MicroServices.Events;
using ModuleDomainService.Domain;
using ModuleDomainService.Domain.Events;
using ModuleDomainService.Infrastructure.DAL;
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

            _eventStoreMock
                .Setup(store => store.LoadStream(It.IsAny<string>()))
                .Returns(new EventStream("module:testid", 3, new[]
                {
                    new ModuleGecreeerd
                    {
                        ModuleCode = "IOPR",
                        ModuleNaam = "Object georienteerd programeren",
                        AantalEc = 3,
                        Cohort = new Cohort(),
                        ModuleLeider = new ModuleLeider(),
                        Status = new Status(),
                        Studiefase = new Studiefase(),
                        Competenties = new Competenties(),
                        Eindeisen = new EindEisen()
                    }
                }));
        }

        [TestMethod]
        public void LoadModule_Should_Return_Instance_Of_Type_Module()
        {
            // Arrange
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
                    Cohort = new Cohort(),
                    ModuleLeider = new ModuleLeider(),
                    Status = new Status(),
                    Studiefase = new Studiefase(),
                    Competenties = new Competenties(),
                    Eindeisen = new EindEisen()
                }
            });
            var repository = new ModuleRepository(_eventStoreMock.Object, _eventPublisherMock.Object);

            // Act
            repository.SaveModule(module);
            
            // Assert
            _eventStoreMock.Verify(store => store.AppendToStream(It.IsAny<EventStream>()), Times.Never);
        }
    }
}