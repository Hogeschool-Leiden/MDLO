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
    public class ModuleRepositoryTest
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
        public void GetAllModules_Should_Return_Typeof_IList_Of_Modules()
        {
            // Arrange
            var context = new CompetentieAppFrontendContext(_options);
            var repository = new ModuleRepository(context);

            // Act
            var result = repository.GetAllModules();

            // Assert
            Assert.IsInstanceOfType(result, typeof(IList<Module>));
        }

        [DataTestMethod]
        [DataRow("IOPR")]
        [DataRow("IOPR2")]
        public void GetAllModules_Should_Be_Retrieved_From_Database(string moduleCode)
        {
            // Arrange
            var context = new CompetentieAppFrontendContext(_options);
            var repository = new ModuleRepository(context);

            // Act
            var result = repository.GetAllModules();

            // Assert
            Assert.IsTrue(result.Any(module => module.ModuleCode.Equals(moduleCode)));
        }

        [TestMethod]
        public void GetAllModules_Should_Include_Competenties()
        {
            // Arrange
            var context = new CompetentieAppFrontendContext(_options);
            var repository = new ModuleRepository(context);

            // Act
            var result = repository.GetAllModules().First();

            // Assert
            Assert.IsNotNull(result.Competenties);
        }

        [TestMethod]
        public void GetAllModules_ShouldInclude_BeheersingsNiveaus()
        {
            // Arrange
            var context = new CompetentieAppFrontendContext(_options);
            var repository = new ModuleRepository(context);

            // Act
            var result = repository.GetAllModules().First();

            // Assert
            Assert.IsTrue(result.Competenties.Any(competentie => competentie.BeheersingsNiveau.Niveau.Equals(1)));
        }

        [TestMethod]
        public void GetAllModules_Should_Include_ArchitectuurLagen()
        {
            // Arrange
            var context = new CompetentieAppFrontendContext(_options);
            var repository = new ModuleRepository(context);

            // Act
            var result = repository.GetAllModules().First();

            // Assert
            Assert.IsTrue(result.Competenties.Any(competentie =>
                competentie.BeheersingsNiveau.ArchitectuurLaag.ArchitectuurLaagNaam.Equals("gebruikersinteractie")));
        }

        [TestMethod]
        public void GetAllModules_Should_Include_Activiteiten()
        {
            // Arrange
            var context = new CompetentieAppFrontendContext(_options);
            var repository = new ModuleRepository(context);

            // Act
            var result = repository.GetAllModules().First();

            // Assert
            Assert.IsTrue(result.Competenties.Any(competentie =>
                competentie.BeheersingsNiveau.Activiteit.ActiviteitNaam.Equals("analyseren")));
        }

        [TestMethod]
        public void GetAllModules_Should_Include_Specialisaties()
        {
            // Arrange
            var context = new CompetentieAppFrontendContext(_options);
            var repository = new ModuleRepository(context);

            // Act
            var result = repository.GetAllModules().First();

            // Assert
            Assert.IsTrue(result.Studiefasen.Any(studiefase =>
                studiefase.Specialisatie.SpecialisatieNaam.Equals("Propedeuse")));
        }

        [TestMethod]
        public void GetAllModules_Should_Include_Perioden()
        {
            // Arrange
            var context = new CompetentieAppFrontendContext(_options);
            var repository = new ModuleRepository(context);

            // Act
            var result = repository.GetAllModules().First();

            // Assert
            Assert.IsTrue(result.Studiefasen.Any(studiefase =>
                studiefase.Periode.PeriodeNummer == 1));
        }

        [TestMethod]
        public void GetAllModules_Should_Include_Eindeisen()
        {
            // Arrange
            var context = new CompetentieAppFrontendContext(_options);
            var repository = new ModuleRepository(context);

            // Act
            var result = repository.GetAllModules().First();

            // Assert
            Assert.IsTrue(result.Eindeisen.Any(eindeis => eindeis.EindeisBeschrijving.Equals("Deze module is erg moeilijk.")));
        }

        [TestMethod]
        public void GetAllModules_Should_Include_Cohort()
        {
            // Arrange
            var context = new CompetentieAppFrontendContext(_options);
            var repository = new ModuleRepository(context);

            // Act
            var result = repository.GetAllModules().First();

            // Assert
            Assert.AreEqual("2018-2019",result.Cohort.CohortNaam);
        }
        
        [TestMethod]
        public void GetAllModules_Should_Include_AuditLogEntries()
        {
            // Arrange
            var context = new CompetentieAppFrontendContext(_options);
            var repository = new ModuleRepository(context);

            // Act
            var result = repository.GetAllModules().First();

            // Assert
            Assert.IsTrue(result.AuditLogEntries.Any(entry => entry.Omschrijving == "Henk creeerde dit"));
        }

        [TestMethod]
        public void CreateModule_Should_Save_Entry_To_Database()
        {
            // Arrange
            var context = new CompetentieAppFrontendContext(_options);
            var repository = new ModuleRepository(context);
            
            // Act
            var result = repository.CreateModule(new Module
            {
                ModuleCode = "ITEST",
                ModuleNaam = "Test Driven development",
                CohortId = 1,
                Studiepunten = 4
            });
            
            // Assert
            Assert.IsTrue(context.Modules.Any(module => module.ModuleCode == "ITEST"));
        }
    }
}