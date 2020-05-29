using System.Collections.Generic;
using CompetentieAppFrontend.Domain;
using CompetentieAppFrontend.Infrastructure.DAL;
using CompetentieAppFrontend.Infrastructure.Repositories;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CompetentieAppFrontend.Infrastructure.Test
{
    [TestClass]
    public class CompetentieRepositoryTest
    {
        private const string DATA_SOURCE = "DataSource=:memory:";
        private static SqliteConnection _connection;
        private static DbContextOptions<CompetentieAppFrontendContext> _options;

        [ClassInitialize]
        public static void ClassInitialize(TestContext tc)
        {
            _connection = new SqliteConnection(DATA_SOURCE);
            _connection.Open();
            _options = new DbContextOptionsBuilder<CompetentieAppFrontendContext>()
                .UseSqlite(_connection).Options;

            using var context = new CompetentieAppFrontendContext(_options);
            context.Database.EnsureCreated();
        }

        [ClassCleanup]
        public static void ClassCleanup()
        {
            _connection.Close();
        }

        [TestInitialize]
        public void TestInitialize()
        {
            using var context = new CompetentieAppFrontendContext(_options);
            context.Set<Module>().RemoveRange(context.Set<Module>());
            context.SaveChanges();
            context.EnsureDataSeeded();
        }

        [TestMethod]
        public void GetCompetentieMatrix_Should_Return_Typeof_IEnumerable_Of_EindCompetentie()
        {
            // Arrange
            using var context = new CompetentieAppFrontendContext(_options);
            var repository = new CompetentieRepository(context);

            // Act
            var result = repository.GetAllCompetentiesByCriteria(1, "Propedeuse");

            // Assert
            Assert.IsInstanceOfType(result, typeof(IList<Competentie>));
        }
    }
}