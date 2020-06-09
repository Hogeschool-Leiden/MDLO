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
    public class StudiefaseRepositoryTest
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
        public void CreateStudiefasen_Should_Save_New_Entries_To_Database()
        {
            // Arrange
            using var context = new CompetentieAppFrontendContext(_options);
            var repository = new StudiefaseRepository(context);

            // Act
            repository.CreateStudiefasen(new List<Studiefase>
            {
                new Studiefase
                {
                    ModuleId = 1,
                    SpecialisatieId = 4,
                    PeriodeId = 1
                }
            });

            // Assert
            var result = context.Modules.Include(module => module.Studiefasen)
                .ThenInclude(studiefase => studiefase.Specialisatie).First(module => module.Id == 1);
            Assert.IsTrue(result.Studiefasen.Any(studiefase =>
                studiefase.Specialisatie.SpecialisatieNaam == "Forensische ICT"));
        }
    }
}