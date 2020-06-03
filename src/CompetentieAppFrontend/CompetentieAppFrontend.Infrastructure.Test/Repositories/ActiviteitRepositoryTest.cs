using System.Collections.Generic;
using CompetentieAppFrontend.Infrastructure.DAL;
using CompetentieAppFrontend.Infrastructure.Repositories;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CompetentieAppFrontend.Infrastructure.Test.Repositories
{
    [TestClass]
    public class ActiviteitRepositoryTest
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
        public void GetActiviteitNamen_Should_Return_Typeof_IList_Of_Strings()
        {
            // Arrange
            using var context = new CompetentieAppFrontendContext(_options);
            var repository = new ActiviteitRepository(context);
            
            // Act
            var result = repository.GetAllActiviteitNamen();
            
            // Assert
            Assert.IsInstanceOfType(result, typeof(IList<string>));
        }
        
        [DataTestMethod]
        [DataRow("analyseren")]
        [DataRow("adviseren")]
        [DataRow("ontwerpen")]
        [DataRow("realiseren")]
        [DataRow("manage & control")]
        public void GetActiviteitNamen_Should_Return_Names_Retrieved_From_Database(string activiteitNaam)
        {
            // Arrange
            using var context = new CompetentieAppFrontendContext(_options);
            var repository = new ActiviteitRepository(context);
            
            // Act
            var result = repository.GetAllActiviteitNamen();
            
            // Assert
            Assert.IsTrue(result.Contains(activiteitNaam));
        }
    }
}