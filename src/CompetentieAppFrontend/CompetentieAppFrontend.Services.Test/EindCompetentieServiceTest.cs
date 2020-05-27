using System.Collections.Generic;
using CompetentieAppFrontend.Domain;
using CompetentieAppFrontend.Infrastructure.Repositories;
using Microsoft.Extensions.Logging;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace CompetentieAppFrontend.Services.Test
{
    [TestClass]
    public class EindCompetentieServiceTest
    {
        private Mock<IArchitectuurLaagRepository> _architectuurLaagRepositoryMock;
        private Mock<IActiviteitRepository> _activiteitRepositoryMock;
        private Mock<IEindCompetentieRepository> _eindCompetentieRepositoryMock;
        private Mock<ILogger<EindCompetentieService>> _loggerMock;

        [TestInitialize]
        public void TestInitialize()
        {
            _architectuurLaagRepositoryMock = new Mock<IArchitectuurLaagRepository>();
            _activiteitRepositoryMock = new Mock<IActiviteitRepository>();
            _eindCompetentieRepositoryMock = new Mock<IEindCompetentieRepository>();
            _loggerMock = new Mock<ILogger<EindCompetentieService>>();

            _architectuurLaagRepositoryMock
                .Setup(repository => repository.GetAllArchitectuurLaagNamen())
                .Returns(new List<string>());
            _activiteitRepositoryMock
                .Setup(repository => repository.GetAllActiviteitNamen())
                .Returns(new List<string>());
            _eindCompetentieRepositoryMock
                .Setup(repository => repository.GetEindCompetenties(It.IsAny<int>(), It.IsAny<string>()))
                .Returns(new List<EindCompetentie>());
        }

        [DataTestMethod]
        [DataRow(1, "Interactie technologie")]
        [DataRow(2, "Software engineering")]
        [DataRow(3, "Business data management")]
        [DataRow(5, "Forensische ict")]
        [DataRow(7, "Interactie technologie")]
        public void GetEindCompetentieMatrix_Should_Return_Typeof_CompetentieMatrix(int periodeNummer, string specialisatieNaam)
        {
            // Arrange
            var eindCompetentieMatrixService = new EindCompetentieService(_loggerMock.Object,
                _eindCompetentieRepositoryMock.Object, _architectuurLaagRepositoryMock.Object,
                _activiteitRepositoryMock.Object);

            // Act
            var result = eindCompetentieMatrixService.GetEindCompetentieMatrix(periodeNummer, specialisatieNaam);

            // Assert
            Assert.IsInstanceOfType(result, typeof(CompetentieMatrix));
        }

        [DataTestMethod]
        [DataRow(1, "Interactie technologie")]
        [DataRow(2, "Software engineering")]
        [DataRow(3, "Business data management")]
        [DataRow(5, "Forensische ict")]
        [DataRow(7, "Interactie technologie")]
        public void GetEindCompetentieMatrix_Should_Call_GetArchitectuurLaagNamen_On_IArchitectuurLaagRepository(int periodeNummer, string specialisatieNaam)
        {
            // Arrange
            var eindCompetentieMatrixService = new EindCompetentieService(_loggerMock.Object,
                _eindCompetentieRepositoryMock.Object, _architectuurLaagRepositoryMock.Object,
                _activiteitRepositoryMock.Object);
            
            // Act
            var result = eindCompetentieMatrixService.GetEindCompetentieMatrix(periodeNummer, specialisatieNaam);
            
            // Assert
            _architectuurLaagRepositoryMock.Verify(repository => repository.GetAllArchitectuurLaagNamen());
        }

        [DataTestMethod]
        [DataRow(1, "Interactie technologie")]
        [DataRow(2, "Software engineering")]
        [DataRow(3, "Business data management")]
        [DataRow(5, "Forensische ict")]
        [DataRow(7, "Interactie technologie")]
        public void GetEindCompetentieMatrix_Should_Call_GetActiviteitNamen_On_IActiviteitRepository(int periodeNummer, string specialisatieNaam)
        {
            // Arrange
            var eindCompetentieMatrixService = new EindCompetentieService(_loggerMock.Object,
                _eindCompetentieRepositoryMock.Object, _architectuurLaagRepositoryMock.Object,
                _activiteitRepositoryMock.Object);
            
            // Act
            var result = eindCompetentieMatrixService.GetEindCompetentieMatrix(periodeNummer, specialisatieNaam);
            
            
            // Assert
            _activiteitRepositoryMock.Verify(repository => repository.GetAllActiviteitNamen());
        }

        [DataTestMethod]
        [DataRow(1, "Interactie technologie")]
        [DataRow(2, "Software engineering")]
        [DataRow(3, "Business data management")]
        [DataRow(5, "Forensische ict")]
        [DataRow(7, "Interactie technologie")]
        public void GetEindCompetentieMatrix_Should_Call_GetEindCompetenties_On_IEindCompetentieRepository(int periodeNummer, string specialisatieNaam)
        {
            // Arrange
            var eindCompetentieMatrixService = new EindCompetentieService(_loggerMock.Object,
                _eindCompetentieRepositoryMock.Object, _architectuurLaagRepositoryMock.Object,
                _activiteitRepositoryMock.Object);
            
            // Act
            var result = eindCompetentieMatrixService.GetEindCompetentieMatrix(periodeNummer, specialisatieNaam);
            
            // Assert
            _eindCompetentieRepositoryMock.Verify(repository => repository.GetEindCompetenties(periodeNummer, specialisatieNaam));
        }
    }
}