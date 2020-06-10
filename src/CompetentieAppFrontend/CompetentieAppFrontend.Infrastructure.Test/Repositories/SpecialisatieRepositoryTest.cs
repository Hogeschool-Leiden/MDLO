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
    public class SpecialisatieRepositoryTest
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
        public void EnsureSpecialisatiesExist_Should_Return_Typeof_IEnumerable_Of_Long()
        {
            // Arrange
            using var context = new CompetentieAppFrontendContext(_options);
            var repository = new SpecialisatieRepository(context);

            // Act
            var result = repository.EnsureSpecialisatiesExist(new List<Specialisatie>
            {
                new Specialisatie
                {
                    SpecialisatieNaam = "Software engineering"
                }
            });

            // Assert
            Assert.IsInstanceOfType(result, typeof(IEnumerable<long>));
        }

        [TestMethod]
        public void EnsureSpecialisatiesExist_Should_Not_Create_A_Duplicate_Entry()
        {
            // Arrange
            using var context = new CompetentieAppFrontendContext(_options);
            var repository = new SpecialisatieRepository(context);

            // Act
            var result = repository.EnsureSpecialisatiesExist(new List<Specialisatie>
            {
                new Specialisatie
                {
                    SpecialisatieNaam = "Software engineering"
                }
            });

            // Assert
            Assert.IsTrue(result.Any(id => id == 3));
        }
        
        [TestMethod]
        public void EnsureSpecialisatiesExist_Should_Create_New_Entries_If_Not_Exist()
        {
            // Arrange
            using var context = new CompetentieAppFrontendContext(_options);
            var repository = new SpecialisatieRepository(context);

            // Act
            var result = repository.EnsureSpecialisatiesExist(new List<Specialisatie>
            {
                new Specialisatie
                {
                    SpecialisatieNaam = "Kaas snijden"
                }
            });

            // Assert
            Assert.IsTrue(result.Any(id => id == 5));
        }
    }
}