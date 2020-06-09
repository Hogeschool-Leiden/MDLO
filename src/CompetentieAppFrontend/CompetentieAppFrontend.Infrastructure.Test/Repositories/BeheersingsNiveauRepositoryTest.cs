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
    public class BeheersingsNiveauRepositoryTest
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
        public void EnsureBeheersingsNiveausExist_Should_Return_Instance_of_Type_IEnumerable_With_Long()
        {
            // Arrange
            using var context = new CompetentieAppFrontendContext(_options);
            var repository = new BeheersingsNiveauRepository(context);

            // Act
            var result = repository.EnsureBeheersingsNiveausExist(new[]
            {
                new BeheersingsNiveau
                {
                    ArchitectuurLaagId = 1,
                    ActiviteitId = 5,
                    Niveau = 3
                },
            });
            
            // Assert
            Assert.IsInstanceOfType(result, typeof(IEnumerable<long>));
        }

        [TestMethod]
        public void EnsureBeheersingsNiveausExist_Should_Not_Save_Duplicate_Entity_In_Database()
        {
            // Arrange
            using var context = new CompetentieAppFrontendContext(_options);
            var repository = new BeheersingsNiveauRepository(context);

            // Act
            var result = repository.EnsureBeheersingsNiveausExist(new[]
            {
                new BeheersingsNiveau
                {
                    ArchitectuurLaagId = 1,
                    ActiviteitId = 5,
                    Niveau = 3
                },
            });
            
            // Assert
            Assert.IsTrue(result.Any(id => id.Equals(30)));
        }

        [TestMethod]
        public void EnsureBeheersingsNiveausExist_Should_Add_Items_That_Do_Not_Exist()
        {
            // Arrange
            using var context = new CompetentieAppFrontendContext(_options);
            var repository = new BeheersingsNiveauRepository(context);

            // Act
            var result = repository.EnsureBeheersingsNiveausExist(new[]
            {
                new BeheersingsNiveau
                {
                    ArchitectuurLaagId = 1,
                    ActiviteitId = 5,
                    Niveau = 5
                },
            });
            
            // Assert
            Assert.IsTrue(result.Any(id => id.Equals(31)));
        }
    }
}