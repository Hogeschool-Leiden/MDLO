using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using CompetentieAppFrontend.Api.Controllers;
using CompetentieAppFrontend.Domain;
using CompetentieAppFrontend.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace CompetentieAppFrontend.Api.Test
{
    [TestClass]
    public class ModuleControllerTest
    {
        private Mock<IModuleService> _moduleServiceMock;
        private Mock<ILogger<ModuleController>> _loggerMock;

        [TestInitialize]
        public void TestInitialize()
        {
            _moduleServiceMock = new Mock<IModuleService>();
            _loggerMock = new Mock<ILogger<ModuleController>>();

            _moduleServiceMock.Setup(service => service.GetAllModules()).Returns(new List<ModuleView>());
        }

        [TestMethod]
        public void Should_Have_ApiControllerAttribute()
        {
            // Arrange
            var controller = new ModuleController(_loggerMock.Object, _moduleServiceMock.Object);

            // Act
            var result = controller.GetType().GetCustomAttribute<ApiControllerAttribute>();

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void Should_Have_RouteAttribute()
        {
            // Arrange
            var controller = new ModuleController(_loggerMock.Object, _moduleServiceMock.Object);

            // Act
            var result = controller.GetType().GetCustomAttribute<RouteAttribute>();

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void Should_Have_RouteAttribute_With_Modules_As_Template()
        {
            // Arrange
            var controller = new ModuleController(_loggerMock.Object, _moduleServiceMock.Object);

            // Act
            var result = controller.GetType().GetCustomAttribute<RouteAttribute>()?.Template;

            // Assert
            Assert.AreEqual("modules", result);
        }

        [TestMethod]
        public void GetAllModules_Should_Return_Typeof_IEnumerable_Of_ModuleWithMatrix()
        {
            // Arrange
            var controller = new ModuleController(_loggerMock.Object, _moduleServiceMock.Object);

            // Act
            var result = controller.GetAllModules();

            // Assert
            Assert.IsInstanceOfType(result, typeof(IEnumerable<ModuleView>));
        }

        [TestMethod]
        public void GetAllModules_Should_Call_GetAllModules_On_ModuleService()
        {
            // Arrange
            var controller = new ModuleController(_loggerMock.Object, _moduleServiceMock.Object);

            // Act
            var result = controller.GetAllModules();

            // Assert
            _moduleServiceMock.Verify(service => service.GetAllModules());
        }

        [TestMethod]
        public void GetAllModules_Should_Return_Data_Received_From_ModuleService()
        {
            // Arrange
            _moduleServiceMock.Setup(service => service.GetAllModules()).Returns(new List<ModuleView>
                {new ModuleView {ModuleCode = "TestCode"}});
            var controller = new ModuleController(_loggerMock.Object, _moduleServiceMock.Object);

            // Act
            var result = controller.GetAllModules();

            // Assert
            Assert.IsTrue(result.Any(matrix => matrix.ModuleCode.Equals("TestCode")));
        }

        [TestMethod]
        public void GetAllModules_Should_Have_HttpGetAttribute()
        {
            // Arrange
            var controller = new ModuleController(_loggerMock.Object, _moduleServiceMock.Object);

            // Act
            var result = controller.GetType().GetMethod(nameof(controller.GetAllModules))
                ?.GetCustomAttribute<HttpGetAttribute>();
            
            // Assert
            Assert.IsNotNull(result);
        }
    }
}