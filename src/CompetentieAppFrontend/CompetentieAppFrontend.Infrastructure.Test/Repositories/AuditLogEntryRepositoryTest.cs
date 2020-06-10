using System;
using System.Collections.Generic;
using System.Linq;
using CompetentieAppFrontend.Domain;
using CompetentieAppFrontend.Infrastructure.DAL;
using CompetentieAppFrontend.Infrastructure.Repositories;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CompetentieAppFrontend.Infrastructure.Test.Repositories
{
    [TestClass]
    public class AuditLogEntryRepositoryTest
    {
        private const string DATA_SOURCE = "DataSource=:memory:";
        private static SqliteConnection _connection;
        private static DbContextOptions<CompetentieAppFrontendContext> _options;

        [TestInitialize]
        public void TestInitialize()
        {
            _connection = new SqliteConnection(DATA_SOURCE);
            _connection.Open();
            _options = new DbContextOptionsBuilder<CompetentieAppFrontendContext>()
                .UseSqlite(_connection).Options;
            using var context = new CompetentieAppFrontendContext(_options);
            context.Database.EnsureCreated();
            context.EnsureDataSeeded();
        }

        [TestCleanup]
        public void TestCleanUp()
        {
            using var context = new CompetentieAppFrontendContext(_options);
            context.Database.EnsureDeleted();
            _connection.Close();
        }

        [TestMethod]
        public void GetAllAuditLogEntries_Should_Return_Instance_Of_Type_IList_With_AuditLogEntry()
        {
            // Arrange
            using var context = new CompetentieAppFrontendContext(_options);
            var repository = new AuditLogEntryRepository(context);
            
            // Act
            var result = repository.GetAllAuditLogEntries();

            // Assert
            Assert.IsInstanceOfType(result, typeof(IList<AuditLogEntry>));
        }
        
        [TestMethod]
        public void GetAllAuditLogEntries_Should_Return_Data_From_Database()
        {
            // Arrange
            using var context = new CompetentieAppFrontendContext(_options);
            var repository = new AuditLogEntryRepository(context);
            
            // Act
            var result = repository.GetAllAuditLogEntries();

            // Assert
            Assert.IsTrue(result.Any(entry=> entry.Omschrijving == "Henk creeerde dit"));
        }

        [TestMethod]
        public void Create_Should_Save_New_Entry_To_Database()
        {
            // Arrange
            using var context = new CompetentieAppFrontendContext(_options);
            var repository = new AuditLogEntryRepository(context);
            
            // Act
            repository.Create(new AuditLogEntry
            {
                ModuleId = 1,
                Omschrijving = "Dit is een nieuwe log entry",
                Timestamp = new DateTime(2020,6,19)
            });
            
            // Assert
            Assert.IsTrue(context.AuditLogEntries.Any(entry => entry.Omschrijving == "Dit is een nieuwe log entry"));
        }
    }
}