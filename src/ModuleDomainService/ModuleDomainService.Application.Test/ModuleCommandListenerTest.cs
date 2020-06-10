using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ModuleDomainService.Application.CommandListeners;
using ModuleDomainService.Domain;
using ModuleDomainService.Domain.Commands;
using ModuleDomainService.Infrastructure.Exceptions;
using ModuleDomainService.Infrastructure.Repositories;
using Moq;

namespace ModuleDomainService.Application.Test
{
    [TestClass]
    public class ModuleCommandListenerTest
    {
        private Mock<IModuleRepository> _moduleCommandListenerMock;

        [TestInitialize]
        public void TestInitialize()
        {
            _moduleCommandListenerMock = new Mock<IModuleRepository>();
        }

        [TestMethod]
        public void HandleCreeerModule_Should_Return_Typeof_CreeerModuleResponse()
        {
            // Arrange
            var commandListener = new ModuleCommandListener(_moduleCommandListenerMock.Object);

            // Act
            var result = commandListener.HandleCreeerModule(
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
                }
            );

            // Assert
            Assert.IsInstanceOfType(result, typeof(CreeerModuleResponse));
        }

        [TestMethod]
        public void HandleCreeerModule_Should_Call_SaveModule_On_ModuleRepository()
        {
            // Arrange
            var commandListener = new ModuleCommandListener(_moduleCommandListenerMock.Object);

            // Act
            var result = commandListener.HandleCreeerModule(
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
                }
            );
            
            // Assert
            _moduleCommandListenerMock.Verify(repository => repository.SaveModule(It.IsAny<Module>()));
        }

        [TestMethod]
        public void HandleCreeer_Should_Return_BadRequestResponse_If_Module_Already_Exist()
        {
            // Arrange
            _moduleCommandListenerMock
                .Setup(repository => repository.SaveModule(It.IsAny<Module>()))
                .Throws<ModuleAlreadyExistException>();
            var commandListener = new ModuleCommandListener(_moduleCommandListenerMock.Object);

            // Act
            var result = commandListener.HandleCreeerModule(
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
                }
            );

            // Assert
            Assert.AreEqual(400, result.StatusCode);
            Assert.AreEqual("Module already exists", result.Message);
        }

        [TestMethod]
        public void HandleCreeerModule_Should_Respond_With_OkResponse()
        {
            // Arrange
            var commandListener = new ModuleCommandListener(_moduleCommandListenerMock.Object);

            // Act
            var result = commandListener.HandleCreeerModule(
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
                }
            );

            // Assert
            Assert.AreEqual(200, result.StatusCode);
            Assert.AreEqual("OK", result.Message);
        }
    }
}