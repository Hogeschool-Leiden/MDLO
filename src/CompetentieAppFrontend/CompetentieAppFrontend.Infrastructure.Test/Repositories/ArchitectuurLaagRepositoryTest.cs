using System.Collections.Generic;
using CompetentieAppFrontend.Infrastructure.DAL;
using CompetentieAppFrontend.Infrastructure.Repositories;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CompetentieAppFrontend.Infrastructure.Test.Repositories
{
    [TestClass]
    public class ArchitectuurLaagRepositoryTest
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
        public void GetArchitectuurLaagNamen_Should_Return_Typeof_IList_Strings()
        {
            // Arrange
            using var context = new CompetentieAppFrontendContext(_options);
            var repository = new ArchitectuurLaagRepository(context);
            
            // Act
            var result = repository.GetAllArchitectuurLaagNamen();
            
            // Assert
            Assert.IsInstanceOfType(result, typeof(IList<string>));
        }

        [DataTestMethod]
        [DataRow("gebruikersinteractie")]
        [DataRow("organisatieprocessen")]
        [DataRow("infrastructuur")]
        [DataRow("software")]
        [DataRow("hardware interfacing")]
        public void GetArchitectuurLaagNamen_Should_Return_Names_Retrieved_From_Database(string architectuurLaagNaam)
        {
            // Arrange
            using var context = new CompetentieAppFrontendContext(_options);
            var repository = new ArchitectuurLaagRepository(context);
            
            // Act
            var result = repository.GetAllArchitectuurLaagNamen();
            
            // Assert
            Assert.IsTrue(result.Contains(architectuurLaagNaam));
        }
    }
}