using System.Linq;
using CompetentieAppFrontend.Infrastructure.DAL;
using CompetentieAppFrontend.Infrastructure.Repositories;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CompetentieAppFrontend.Infrastructure.Test.Repositories
{
    [TestClass]
    public class CohortRepositoryTest
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
        public void EnsureCohortExist_Should_Return_Instance_Of_Type_Long()
        {
            // Arrange
            var context = new CompetentieAppFrontendContext(_options);
            var repository = new CohortRepository(context);

            // Act
            var result = repository.EnsureCohortExist("2030/2031");

            // Assert
            Assert.IsInstanceOfType(result, typeof(long));
        }

        [TestMethod]
        public void EnsureCohortExist_Should_Not_Duplicate_Entry()
        {
            // Arrange
            var context = new CompetentieAppFrontendContext(_options);
            var repository = new CohortRepository(context);

            // Act
            var result = repository.EnsureCohortExist("2018-2019");

            // Assert
            Assert.AreEqual(1, result);
        }

        [TestMethod]
        public void EnsureCohortExist_Should_Save_New_Cohorts()
        {
            // Arrange
            var context = new CompetentieAppFrontendContext(_options);
            var repository = new CohortRepository(context);

            // Act
            var result = repository.EnsureCohortExist("2030/2031");

            // Assert
            Assert.AreEqual(2, result);
        }
    }
}