using System.Collections.Generic;
using System.Reflection;
using CompetentieAppFrontend.Api.Controllers;
using CompetentieAppFrontend.Domain;
using CompetentieAppFrontend.Services.Abstractions;
using CompetentieAppFrontend.Services.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace CompetentieAppFrontend.Api.Test
{
    [TestClass]
    public class AuditLogControllerTest
    {
        private Mock<IAuditLogEntryService> _auditLogEntryServiceMock;

        [TestInitialize]
        public void TestInitialize()
        {
            _auditLogEntryServiceMock = new Mock<IAuditLogEntryService>();
        }

        [TestMethod]
        public void GetAllAuditLogEntries_Should_Return_Instance_Of_Type_IEnumerable_With_AuditLogEntryViewModel()
        {
            // Arrange
            var controller = new AuditLogController(_auditLogEntryServiceMock.Object);

            // Act
            var result = controller.GetAllAuditLogEntries();
            
            // Assert
            Assert.IsInstanceOfType(result, typeof(IEnumerable<AuditLogEntryViewModel>));
        }

        [TestMethod]
        public void GetAllAuditLogEntries_Should_Call_GetAllAuditLogEntries_On_AuditLogEntryService()
        {
            // Arrange
            var controller = new AuditLogController(_auditLogEntryServiceMock.Object);

            // Act
            var result = controller.GetAllAuditLogEntries();
            
            // Assert
            _auditLogEntryServiceMock.Verify(service => service.GetAllAuditLogEntries());
        }

        [TestMethod]
        public void Should_Have_ApiControllerAttribute()
        {
            // Arrange
            var controller = new AuditLogController(_auditLogEntryServiceMock.Object);

            // Act
            var result = controller.GetType().GetCustomAttribute<ApiControllerAttribute>();

            // Assert
            Assert.IsNotNull(result);
        }
        
        [TestMethod]
        public void Should_Have_RouteAttribute()
        {
            // Arrange
            var controller = new AuditLogController(_auditLogEntryServiceMock.Object);

            // Act
            var result = controller.GetType().GetCustomAttribute<RouteAttribute>();

            // Assert
            Assert.IsNotNull(result);
        }
        
        [TestMethod]
        public void Should_Have_RouteAttribute_With_Template_Of_AuditLog()
        {
            // Arrange
            var controller = new AuditLogController(_auditLogEntryServiceMock.Object);

            // Act
            var result = controller.GetType().GetCustomAttribute<RouteAttribute>()?.Template;

            // Assert
            Assert.AreEqual("api/auditlog", result);
        }
        
        [TestMethod]
        public void GetAllAuditLogEntries_Should_Have_HttpGetAttribute()
        {
            // Arrange
            var controller = new AuditLogController(_auditLogEntryServiceMock.Object);

            // Act
            var result = controller.GetType().GetMethod(nameof(controller.GetAllAuditLogEntries))
                ?.GetCustomAttribute<HttpGetAttribute>();

            // Assert
            Assert.IsNotNull(result);
        }
    }
}