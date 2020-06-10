using System.Collections.Generic;
using CompetentieAppFrontend.Domain;
using CompetentieAppFrontend.Infrastructure.Repositories;
using CompetentieAppFrontend.Services.Projections;
using CompetentieAppFrontend.Services.ViewModels;
using Microsoft.Extensions.Logging;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace CompetentieAppFrontend.Services.Test.Projections
{
    [TestClass]
    public class NiveauMatrixServiceTest
    {
        private readonly List<Competentie> _competenties = new List<Competentie>
        {
            new Competentie
            {
                BeheersingsNiveau = new BeheersingsNiveau
                {
                    ArchitectuurLaag = new ArchitectuurLaag
                    {
                        ArchitectuurLaagNaam = "Software engineering"
                    },
                    Activiteit = new Activiteit
                    {
                        ActiviteitNaam = "ontwerpen"
                    },
                    Niveau = 3
                }
            }
        };

        private Mock<IArchitectuurLaagRepository> _architectuurRepositoryMock;
        private Mock<IActiviteitRepository> _activiteitRepositoryMock;
        private Mock<ILogger<NiveauMatrixService>> _loggerMock;

        [TestInitialize]
        public void TestInitialize()
        {
            _architectuurRepositoryMock = new Mock<IArchitectuurLaagRepository>();
            _activiteitRepositoryMock = new Mock<IActiviteitRepository>();
            _loggerMock = new Mock<ILogger<NiveauMatrixService>>();

            _architectuurRepositoryMock
                .Setup(repository => repository.GetAllArchitectuurLaagNamen())
                .Returns(new List<string> {"Software engineering"});

            _activiteitRepositoryMock
                .Setup(repository => repository.GetAllActiviteitNamen())
                .Returns(new List<string> {"ontwerpen"});
        }

        [TestMethod]
        public void CreateCompetentieMatrix_Should_Return_Typeof_CompetentieMatrix()
        {
            // Arrange
            var service = new NiveauMatrixService(
                _loggerMock.Object,
                _architectuurRepositoryMock.Object,
                _activiteitRepositoryMock.Object
            );

            // Act
            var result = service.CreateCompetentieMatrix(_competenties);

            // Assert
            Assert.IsInstanceOfType(result, typeof(Matrix<int>));
        }

        [TestMethod]
        public void CreateCompetentieMatrix_Should_Call_GetAllArchitectuurLaagNamen_On_ArchitectuurLaagRepository()
        {
            // Arrange
            var service = new NiveauMatrixService(
                _loggerMock.Object,
                _architectuurRepositoryMock.Object,
                _activiteitRepositoryMock.Object
            );

            // Act
            var result = service.CreateCompetentieMatrix(_competenties);

            // Assert
            _architectuurRepositoryMock.Verify(repository => repository.GetAllArchitectuurLaagNamen());
        }

        [TestMethod]
        public void CreateCompetentieMatrix_Should_Call_GetAllActiviteitNamen_On_ActiviteitRepository()
        {
            // Arrange
            var service = new NiveauMatrixService(
                _loggerMock.Object,
                _architectuurRepositoryMock.Object,
                _activiteitRepositoryMock.Object
            );

            // Act
            var result = service.CreateCompetentieMatrix(_competenties);

            // Assert
            _activiteitRepositoryMock.Verify(repository => repository.GetAllActiviteitNamen());
        }

        [TestMethod]
        public void CreateCompetentieMatrix_Should_Build_Correct_Matrix()
        {
            // Arrange
            var service = new NiveauMatrixService(
                _loggerMock.Object,
                _architectuurRepositoryMock.Object,
                _activiteitRepositoryMock.Object
            );

            // Act
            var result = service.CreateCompetentieMatrix(_competenties);

            // Assert
            Assert.AreEqual(3, result.Cells[0][0].Value);
        }
    }
}