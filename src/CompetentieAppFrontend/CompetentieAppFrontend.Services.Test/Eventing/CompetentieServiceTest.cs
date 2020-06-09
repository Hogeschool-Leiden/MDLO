using System.Collections.Generic;
using System.Linq;
using CompetentieAppFrontend.Domain;
using CompetentieAppFrontend.Infrastructure.Repositories;
using CompetentieAppFrontend.Services.Commands;
using CompetentieAppFrontend.Services.Eventing;
using CompetentieAppFrontend.Services.Projections;
using CompetentieAppFrontend.Services.ViewModels;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace CompetentieAppFrontend.Services.Test.Eventing
{
    [TestClass]
    public class CompetentieServiceTest
    {
        private Mock<IBeheersingsNiveauRepository> _beheersingsNiveauRepositoryMock;
        private Mock<IArchitectuurLaagRepository> _architectuurLaagRepositoryMock;
        private Mock<ICompetentieRepository> _competentieRepositoryMock;
        private Mock<IActiviteitRepository> _activiteitRepositoryMock;

        [TestInitialize]
        public void TestInitialize()
        {
            _beheersingsNiveauRepositoryMock = new Mock<IBeheersingsNiveauRepository>();
            _architectuurLaagRepositoryMock = new Mock<IArchitectuurLaagRepository>();
            _competentieRepositoryMock = new Mock<ICompetentieRepository>();
            _activiteitRepositoryMock = new Mock<IActiviteitRepository>();

            _beheersingsNiveauRepositoryMock
                .Setup(repository =>
                    repository.EnsureBeheersingsNiveausExist(It.IsAny<IEnumerable<BeheersingsNiveau>>()))
                .Returns(new List<long> {1, 2});

            _architectuurLaagRepositoryMock
                .Setup(repository => repository.EnsureArchitectuurLaagExist(It.IsAny<string>()))
                .Returns(1);

            _activiteitRepositoryMock
                .Setup(repository => repository.EnsureActiviteitExist(It.IsAny<string>()))
                .Returns(1);
        }

        [TestMethod]
        public void CreateCompetenties_Should_CallEnsureBeheersingsNiveausExist()
        {
            // Arrange
            var competentieService = new CompetentieService(
                _architectuurLaagRepositoryMock.Object,
                _activiteitRepositoryMock.Object,
                _beheersingsNiveauRepositoryMock.Object,
                _competentieRepositoryMock.Object
            );

            // Act
            competentieService.CreateCompetenties(new CreateCompetentiesCommand
            {
                ModuleId = 1,
                Competenties = new Matrix<int>(
                    new List<string>
                    {
                        "software"
                    },
                    new List<string>
                    {
                        "analyseren"
                    },
                    new List<Niveau>
                    {
                        new Niveau("software", "analyseren", 3)
                    })
            });

            // Assert
            _beheersingsNiveauRepositoryMock.Verify(repository =>
                repository.EnsureBeheersingsNiveausExist(It.IsAny<IEnumerable<BeheersingsNiveau>>()));
        }

        [TestMethod]
        public void CreateCompetenties_Should_Extract_Competenties_From_Matrix()
        {
            // Arrange
            IEnumerable<BeheersingsNiveau> actual = new List<BeheersingsNiveau>();
            _beheersingsNiveauRepositoryMock
                .Setup(repository =>
                    repository.EnsureBeheersingsNiveausExist(It.IsAny<IEnumerable<BeheersingsNiveau>>()))
                .Callback((IEnumerable<BeheersingsNiveau> beheersingsNiveaus) => actual = beheersingsNiveaus)
                .Returns(new List<long> {1});
            var competentieService = new CompetentieService(
                _architectuurLaagRepositoryMock.Object,
                _activiteitRepositoryMock.Object,
                _beheersingsNiveauRepositoryMock.Object,
                _competentieRepositoryMock.Object
            );

            // Act
            competentieService.CreateCompetenties(new CreateCompetentiesCommand
            {
                ModuleId = 1,
                Competenties = new Matrix<int>(
                    new List<string>
                    {
                        "software"
                    },
                    new List<string>
                    {
                        "analyseren"
                    },
                    new List<Niveau>
                    {
                        new Niveau("software", "analyseren", 3)
                    })
            });

            // Assert
            Assert.IsTrue(actual.Any(niveau => niveau.ArchitectuurLaagId == 1));
        }

        [TestMethod]
        public void CreateCompetenties_Should_Call_EnsureArchitectuurLaagExist_On_ArchitectuurLaagRepository()
        {
            // Arrange
            var competentieService = new CompetentieService(
                _architectuurLaagRepositoryMock.Object,
                _activiteitRepositoryMock.Object,
                _beheersingsNiveauRepositoryMock.Object,
                _competentieRepositoryMock.Object
            );

            // Act
            competentieService.CreateCompetenties(new CreateCompetentiesCommand
            {
                ModuleId = 1,
                Competenties = new Matrix<int>(
                    new List<string>
                    {
                        "software"
                    },
                    new List<string>
                    {
                        "analyseren"
                    },
                    new List<Niveau>
                    {
                        new Niveau("software", "analyseren", 3)
                    })
            });

            // Assert
            _architectuurLaagRepositoryMock.Verify(repository => repository.EnsureArchitectuurLaagExist("software"));
        }

        [TestMethod]
        public void CreateCompetenties_Should_Call_EnsureActiviteitExist_On_ActiviteitRepository()
        {
            // Arrange
            var competentieService = new CompetentieService(
                _architectuurLaagRepositoryMock.Object,
                _activiteitRepositoryMock.Object,
                _beheersingsNiveauRepositoryMock.Object,
                _competentieRepositoryMock.Object
            );

            // Act
            competentieService.CreateCompetenties(new CreateCompetentiesCommand
            {
                ModuleId = 1,
                Competenties = new Matrix<int>(
                    new List<string>
                    {
                        "software"
                    },
                    new List<string>
                    {
                        "analyseren"
                    },
                    new List<Niveau>
                    {
                        new Niveau("software", "analyseren", 3)
                    })
            });

            // Assert
            _activiteitRepositoryMock.Verify(repository => repository.EnsureActiviteitExist("analyseren"));
        }
    }
}