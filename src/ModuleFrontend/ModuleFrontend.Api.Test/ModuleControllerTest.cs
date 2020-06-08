using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ModuleFrontend.Api.Controllers;
using ModuleFrontend.Api.Models;
using ModuleFrontend.Api.Services;
using Moq;
using System.Collections.Generic;
using System.Linq;

namespace ModuleFrontend.Api.Test
{
    [TestClass]
    public class ModuleControllerTest
    {
        [TestMethod]
        public void TestIfGetModuleByModuleCodeReturnsIActionResult404WhenNotFound()
        {
            // Arrange
            var mock = new Mock<IModuleService>();
            mock.Setup(svc => svc.GetByModuleCode("NonExistingModuleCode")).Returns((Module)null);
            ModuleController sut = new ModuleController(mock.Object);

            // Act
            var result = sut.GetModule("NonExistingModuleCode");

            // Assert
            Assert.IsInstanceOfType(result, typeof(NotFoundResult));
        }

        [TestMethod]
        public void TestIfGetModuleByModuleCodeReturnsIActionResult200WhenFound()
        {
            // Arrange
            var mock = new Mock<IModuleService>();
            mock.Setup(svc => svc.GetByModuleCode("ExistingCode")).Returns(new Module() { ModuleCode = "ExistingCode" });
            ModuleController sut = new ModuleController(mock.Object);

            // Act
            var result = sut.GetModule("ExistingCode");

            // Assert
            Assert.IsInstanceOfType(((OkObjectResult)result).Value, typeof(Module));
        }

        [TestMethod]
        public void TestIfIActionResultContainsModelWithTheSameModulecode()
        {
            // Arrange
            var mock = new Mock<IModuleService>();
            mock.Setup(svc => svc.GetByModuleCode("ExistingCode")).Returns(new Module() { ModuleCode = "ExistingCode" });
            ModuleController sut = new ModuleController(mock.Object);

            // Act
            var result = sut.GetModule("ExistingCode");

            // Assert
            var model = (Module)((OkObjectResult)result).Value;
            Assert.AreEqual(model.ModuleCode, "ExistingCode");
        }

        [TestMethod]
        public void TestIfGetModulesReturnsIEnumerableOfModule()
        {
            // Arrange
            IEnumerable<Module> modules = new List<Module>()
            {
                new Module(){ ModuleCode = "modcode123"},
                new Module(){ ModuleCode = "modcode124"},
                new Module(){ ModuleCode = "modcode125"},
                new Module(){ ModuleCode = "modcode126"},
                new Module(){ ModuleCode = "modcode127"},
                new Module(){ ModuleCode = "modcode128"},
                new Module(){ ModuleCode = "modcode129"},
            };
            var mock = new Mock<IModuleService>();
            mock.Setup(svc => svc.GetAllModules()).Returns(modules);
            ModuleController sut = new ModuleController(mock.Object);

            // Act
            var result = sut.GetAll();

            // Assert
            Assert.IsInstanceOfType(result, typeof(OkObjectResult));
        }

        [TestMethod]
        public void TestIfGetModulesReturnsAllModules()
        {
            // Arrange
            IEnumerable<Module> modules = new List<Module>()
            {
                new Module(){ ModuleCode = "modcode123"},
                new Module(){ ModuleCode = "modcode124"},
                new Module(){ ModuleCode = "modcode125"},
                new Module(){ ModuleCode = "modcode126"},
                new Module(){ ModuleCode = "modcode127"},
                new Module(){ ModuleCode = "modcode128"},
                new Module(){ ModuleCode = "modcode129"},
            };
            var mock = new Mock<IModuleService>();
            mock.Setup(svc => svc.GetAllModules()).Returns(modules);
            ModuleController sut = new ModuleController(mock.Object);

            // Act
            var result = sut.GetAll();

            // Assert
            var models = (IEnumerable<Module>)((OkObjectResult)result).Value;
            Assert.IsTrue(models.Count() == 7);
        }
    }
}
