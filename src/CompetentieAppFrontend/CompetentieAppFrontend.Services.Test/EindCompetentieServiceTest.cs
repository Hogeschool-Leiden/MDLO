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
        private Mock<IMatrixService<Eindniveau>> _competentieMatrixService;
        private Mock<ICompetentieRepository> _competentieRepositoryMock;
        private Mock<ILogger<EindcompetentieService>> _loggerMock;

        [TestInitialize]
        public void TestInitialize()
        {
            _competentieMatrixService = new Mock<IMatrixService<Eindniveau>>();
            _competentieRepositoryMock = new Mock<ICompetentieRepository>();
            _loggerMock = new Mock<ILogger<EindcompetentieService>>();

            _competentieRepositoryMock
                .Setup(repository => repository.GetAllCompetentiesByCriteria(It.IsAny<int>(), It.IsAny<string>()))
                .Returns(new List<Competentie>());

            _competentieMatrixService
                .Setup(service => service.CreateCompetentieMatrix(It.IsAny<IEnumerable<Competentie>>()))
                .Returns(new Matrix<Eindniveau>(new List<string>(), new List<string>(), new List<Eindcompetentie>()));
        }

        [DataTestMethod]
        [DataRow(1, "Interactie technologie")]
        [DataRow(2, "Software engineering")]
        [DataRow(3, "Business data management")]
        [DataRow(5, "Forensische ict")]
        [DataRow(7, "Interactie technologie")]
        public void GetEindCompetentieMatrix_Should_Return_Typeof_CompetentieMatrix(int periodeNummer,
            string specialisatieNaam)
        {
            // Arrange
            var eindCompetentieMatrixService = new EindcompetentieService(
                _loggerMock.Object,
                _competentieRepositoryMock.Object,
                _competentieMatrixService.Object
            );

            // Act
            var result =
                eindCompetentieMatrixService.GetEindcompetentieMatrixByCriteria(periodeNummer, specialisatieNaam);

            // Assert
            Assert.IsInstanceOfType(result, typeof(Matrix<Eindniveau>));
        }

        [DataTestMethod]
        [DataRow(1, "Interactie technologie")]
        [DataRow(2, "Software engineering")]
        [DataRow(3, "Business data management")]
        [DataRow(5, "Forensische ict")]
        [DataRow(7, "Interactie technologie")]
        public void GetEindCompetentieMatrix_Should_Call_GetAllCompetentiesByCriteria_On_IEindCompetentieRepository(
            int periodeNummer, string specialisatieNaam)
        {
            // Arrange
            var eindCompetentieMatrixService = new EindcompetentieService(
                _loggerMock.Object,
                _competentieRepositoryMock.Object,
                _competentieMatrixService.Object
            );

            // Act
            var result =
                eindCompetentieMatrixService.GetEindcompetentieMatrixByCriteria(periodeNummer, specialisatieNaam);

            // Assert
            _competentieRepositoryMock.Verify(repository =>
                repository.GetAllCompetentiesByCriteria(periodeNummer, specialisatieNaam));
        }
    }
}