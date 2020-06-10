using System;
using System.Collections.Generic;
using CompetentieAppFrontend.Domain;
using CompetentieAppFrontend.Infrastructure.Repositories;
using CompetentieAppFrontend.Services.Eventing;
using CompetentieAppFrontend.Services.ViewModels;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace CompetentieAppFrontend.Services.Test.Eventing
{
    [TestClass]
    public class AuditLogEntryServiceTest
    {
        private Mock<IAuditLogEntryRepository> _auditLogRepositoryMock;

        [TestInitialize]
        public void TestInitialize()
        {
            _auditLogRepositoryMock = new Mock<IAuditLogEntryRepository>();

            _auditLogRepositoryMock
                .Setup(repository => repository.GetAllAuditLogEntries())
                .Returns(new List<AuditLogEntry>
                {
                    new AuditLogEntry
                    {
                        Omschrijving = "Test omschrijving",
                        Timestamp = new DateTime(2020, 4, 5)
                    }
                });
        }

        [TestMethod]
        public void GetAllAuditLogEntries_Should_Return_Typeof_IEnumerable_With_AuditLogEntryViewModel()
        {
            // Arrange
            var service = new AuditLogEntryService(_auditLogRepositoryMock.Object);

            // Act
            var result = service.GetAllAuditLogEntries();

            // Assert
            Assert.IsInstanceOfType(result, typeof(IEnumerable<AuditLogEntryViewModel>));
        }

        [TestMethod]
        public void GetAllAuditLogEntries_Should_Call_GetAllAuditLogEntries_On_Repository()
        {
            // Arrange
            var service = new AuditLogEntryService(_auditLogRepositoryMock.Object);

            // Act
            var result = service.GetAllAuditLogEntries();

            // Assert
            _auditLogRepositoryMock.Verify(repository => repository.GetAllAuditLogEntries());
        }
    }
}