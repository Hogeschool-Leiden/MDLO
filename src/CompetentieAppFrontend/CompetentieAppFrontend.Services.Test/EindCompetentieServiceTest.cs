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
        private Mock<IMatrixService<Eindniveau>> _eindcompetentieMatrixService;
        private Mock<ICompetentieRepository> _competentieRepositoryMock;
        private Mock<ILogger<EindcompetentieService>> _loggerMock;

        [TestInitialize]
        public void TestInitialize()
        {
            _eindcompetentieMatrixService = new Mock<IMatrixService<Eindniveau>>();
            _competentieRepositoryMock = new Mock<ICompetentieRepository>();
            _loggerMock = new Mock<ILogger<EindcompetentieService>>();

            _competentieRepositoryMock
                .Setup(repository => repository.GetAllCompetentiesByCriteria(It.IsAny<ICompetentieRepository.Criteria>()))
                .Returns(new List<Competentie>());

            _eindcompetentieMatrixService
                .Setup(service => service.CreateCompetentieMatrix(It.IsAny<IEnumerable<Competentie>>()))
                .Returns(new Matrix<Eindniveau>(new List<string>(), new List<string>(), new List<Eindcompetentie>()));
        }

        [DataTestMethod]
        [DataRow(1, "Interactie technologie", "2018/2019")]
        [DataRow(2, "Software engineering", "2018/2019")]
        [DataRow(3, "Business data management", "2019/2020")]
        [DataRow(5, "Forensische ict", "2021/2022")]
        [DataRow(7, "Interactie technologie", "2020/2021")]
        public void GetEindCompetentieMatrix_Should_Return_Typeof_CompetentieMatrix(int periodeNummer,
            string specialisatieNaam, string cohortNaam)
        {
            // Arrange
            var eindCompetentieMatrixService = new EindcompetentieService(
                _loggerMock.Object,
                _competentieRepositoryMock.Object,
                _eindcompetentieMatrixService.Object
            );

            // Act
            var result =
                eindCompetentieMatrixService.GetEindcompetentieMatrixByCriteria(new ICompetentieRepository.Criteria
                {
                    PeriodeNummer = periodeNummer,
                    SpecialisatieNaam = specialisatieNaam,
                    CohortNaam = cohortNaam
                });

            // Assert
            Assert.IsInstanceOfType(result, typeof(Matrix<Eindniveau>));
        }

        [DataTestMethod]
        [DataRow(1, "Interactie technologie", "2018/2019")]
        [DataRow(2, "Software engineering", "2018/2019")]
        [DataRow(3, "Business data management", "2019/2020")]
        [DataRow(5, "Forensische ict", "2021/2022")]
        [DataRow(7, "Interactie technologie", "2020/2021")]
        public void GetEindCompetentieMatrix_Should_Call_GetAllCompetentiesByCriteria_On_IEindCompetentieRepository(
            int periodeNummer, string specialisatieNaam, string cohortNaam)
        {
            // Arrange
            var eindCompetentieMatrixService = new EindcompetentieService(
                _loggerMock.Object,
                _competentieRepositoryMock.Object,
                _eindcompetentieMatrixService.Object
            );

            // Act
            var result =
                eindCompetentieMatrixService.GetEindcompetentieMatrixByCriteria(new ICompetentieRepository.Criteria
                {
                    PeriodeNummer = periodeNummer,
                    SpecialisatieNaam = specialisatieNaam,
                    CohortNaam = cohortNaam
                });

            // Assert
            _competentieRepositoryMock.Verify(repository =>
                repository.GetAllCompetentiesByCriteria(It.IsAny<ICompetentieRepository.Criteria>()));
        }
    }
}