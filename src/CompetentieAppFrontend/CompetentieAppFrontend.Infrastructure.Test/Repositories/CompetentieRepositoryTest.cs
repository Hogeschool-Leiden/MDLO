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
    public class CompetentieRepositoryTest
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
        public void GetCompetentieByCriteria_Should_Return_Typeof_IList_Of_Competenties()
        {
            // Arrange
            using var context = new CompetentieAppFrontendContext(_options);
            var repository = new CompetentieRepository(context);

            // Act
            var result = repository.GetAllCompetentiesByCriteria(1, "Propedeuse");

            // Assert
            Assert.IsInstanceOfType(result, typeof(IList<Competentie>));
        }

        [DataTestMethod]
        [DataRow(1)]
        [DataRow(3)]
        public void GetCompetentiesByCriteria_Should_Return_Retrieve_Data_From_Database(int moduleId)
        {
            // Arrange
            using var context = new CompetentieAppFrontendContext(_options);
            var repository = new CompetentieRepository(context);

            // Act
            var result = repository.GetAllCompetentiesByCriteria(1, "Propedeuse");
            
            // Assert
            Assert.IsTrue(result.Any(competentie => competentie.ModuleId == moduleId));
        }

        [DataTestMethod]
        [DataRow(1)]
        [DataRow(2)]
        public void GetCompetentiesByCriteria_Should_Include_BeheersingsNiveau(int beheersingsNiveauId)
        {
            // Arrange
            using var context = new CompetentieAppFrontendContext(_options);
            var repository = new CompetentieRepository(context);

            // Act
            var result = repository.GetAllCompetentiesByCriteria(1, "Propedeuse");
            
            // Assert
            Assert.IsTrue(result.Any(competentie => competentie.BeheersingsNiveau.Id == beheersingsNiveauId));
        }

        [DataTestMethod]
        [DataRow("analyseren")]
        [DataRow("adviseren")]
        public void GetCompetentiesByCriteria_Should_Include_Activiteit(string activiteitNaam)
        {
            // Arrange
            using var context = new CompetentieAppFrontendContext(_options);
            var repository = new CompetentieRepository(context);

            // Act
            var result = repository.GetAllCompetentiesByCriteria(1, "Propedeuse");
            
            // Assert
            Assert.IsTrue(result.Any(competentie => competentie.BeheersingsNiveau.Activiteit.ActiviteitNaam == activiteitNaam));
        }
        
        [DataTestMethod]
        [DataRow("gebruikersinteractie")]
        public void GetCompetentiesByCriteria_Should_Include_ArchitectuurLaag(string architectuurLaagNaam)
        {
            // Arrange
            using var context = new CompetentieAppFrontendContext(_options);
            var repository = new CompetentieRepository(context);

            // Act
            var result = repository.GetAllCompetentiesByCriteria(1, "Propedeuse");
            
            // Assert
            Assert.IsTrue(result.Any(competentie => competentie.BeheersingsNiveau.ArchitectuurLaag.ArchitectuurLaagNaam == architectuurLaagNaam));
        }
        
        [DataTestMethod]
        [DataRow("IOPR")]
        [DataRow("IUML")]
        public void GetCompetentiesByCriteria_Should_Include_Module(string moduleCode)
        {
            // Arrange
            using var context = new CompetentieAppFrontendContext(_options);
            var repository = new CompetentieRepository(context);

            // Act
            var result = repository.GetAllCompetentiesByCriteria(1, "Propedeuse");
            
            // Assert
            Assert.IsTrue(result.Any(competentie => competentie.Module.ModuleCode == moduleCode));
        }

        [TestMethod]
        public void GetCompetentiesByCriteria_Should_Be_Filtered_By_Criteria()
        {
            // Arrange
            using var context = new CompetentieAppFrontendContext(_options);
            var repository = new CompetentieRepository(context);

            // Act
            var result = repository.GetAllCompetentiesByCriteria(5, "Forensische ICT");
            
            // Assert
            Assert.IsFalse(result.Any());
        }

        [TestMethod]
        public void GetCompetentiesByCriteria_Should_Include_Competenties_From_Previous_Perioden()
        {
            // Arrange
            using var context = new CompetentieAppFrontendContext(_options);
            var repository = new CompetentieRepository(context);

            // Act
            var result = repository.GetAllCompetentiesByCriteria(5, "Propedeuse");
            
            // Assert
            Assert.IsTrue(result.Any());
        }
    }
}