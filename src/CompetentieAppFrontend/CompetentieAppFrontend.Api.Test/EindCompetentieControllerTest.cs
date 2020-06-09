using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using CompetentieAppFrontend.Api.Controllers;
using CompetentieAppFrontend.Infrastructure.Repositories;
using CompetentieAppFrontend.Services;
using CompetentieAppFrontend.Services.Projections;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace CompetentieAppFrontend.Api.Test
{
    [TestClass]
    public class EindCompetentieControllerTest
    {
        private Mock<IEindcompetentieService> _eindCompetentieService;
        private Mock<ILogger<EindCompetentieController>> _loggerMock;

        [TestInitialize]
        public void TestInitialize()
        {
            _eindCompetentieService = new Mock<IEindcompetentieService>();
            _loggerMock = new Mock<ILogger<EindCompetentieController>>();

            _eindCompetentieService
                .Setup(service => service.GetEindcompetentieMatrixByCriteria(It.IsAny<ICompetentieRepository.Criteria>()))
                .Returns(new Matrix<Eindniveau>(new List<string>(), new List<string>(),
                    new List<IMatrixable<Eindniveau>>()));
        }

        [TestMethod]
        public void Should_Have_ApiControllerAttribute()
        {
            // Arrange
            var controller = new EindCompetentieController(_loggerMock.Object, _eindCompetentieService.Object);

            // Act
            var result = controller.GetType().GetCustomAttribute<ApiControllerAttribute>();

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void Should_Have_RouteAttribute()
        {
            // Arrange
            var controller = new EindCompetentieController(_loggerMock.Object, _eindCompetentieService.Object);

            // Act
            var result = controller.GetType().GetCustomAttribute<RouteAttribute>();

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void Should_Have_RouteAttribute_With_Template_Of_Eindcompetentie()
        {
            // Arrange
            var controller = new EindCompetentieController(_loggerMock.Object, _eindCompetentieService.Object);

            // Act
            var result = controller.GetType().GetCustomAttribute<RouteAttribute>()?.Template;

            // Assert
            Assert.AreEqual("api/eindcompetentie", result);
        }

        [TestMethod]
        public void GetCompetentieMatrix_Should_Return_Typeof_Matrix_Eindniveau()
        {
            // Arrange
            var controller = new EindCompetentieController(_loggerMock.Object, _eindCompetentieService.Object);

            // Act
            var result = controller.GetCompetentieMatrix("Propedeuse", 1, "2019/2020");

            // Assert
            Assert.IsInstanceOfType(result, typeof(Matrix<Eindniveau>));
        }

        [TestMethod]
        public void GetCompetentieMatrix_Should_Have_HttpGetAttribute()
        {
            // Arrange
            var controller = new EindCompetentieController(_loggerMock.Object, _eindCompetentieService.Object);

            // Act
            var result = controller.GetType().GetMethod(nameof(controller.GetCompetentieMatrix))
                ?.GetCustomAttribute<HttpGetAttribute>();

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void GetCompetentieMatrix_Should_Have_RouteAttribute()
        {
            // Arrange
            var controller = new EindCompetentieController(_loggerMock.Object, _eindCompetentieService.Object);

            // Act
            var result = controller.GetType().GetMethod(nameof(controller.GetCompetentieMatrix))
                ?.GetCustomAttribute<RouteAttribute>();

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void
            GetCompetentieMatrix_Should_Have_RouteAttribute_With_Template_Of_PeriodeNummer_And_SpecialisatieNaam()
        {
            // Arrange
            var controller = new EindCompetentieController(_loggerMock.Object, _eindCompetentieService.Object);

            // Act
            var result = controller
                .GetType()
                .GetMethod(nameof(controller.GetCompetentieMatrix))
                ?.GetCustomAttribute<RouteAttribute>()
                ?.Template;

            // Assert
            Assert.AreEqual("{specialisatieNaam}/{periodeNummer}/{cohortNaam}", result);
        }

        [DataTestMethod]
        [DataRow(0)]
        [DataRow(1)]
        public void GetCompetentieMatrix_Should_Have_FromRouteAttribute(int parameterIndex)
        {
            // Arrange
            var controller = new EindCompetentieController(_loggerMock.Object, _eindCompetentieService.Object);

            // Act
            var result = controller
                .GetType()
                .GetMethod(nameof(controller.GetCompetentieMatrix))
                ?.GetParameters()[parameterIndex]
                .GetCustomAttribute<FromRouteAttribute>();

            // Assert
            Assert.IsNotNull(result);
        }

        [DataTestMethod]
        [DataRow("Propedeuse", 1)]
        [DataRow("Propedeuse", 2)]
        [DataRow("Forensische ICT", 3)]
        [DataRow("Big data management", 5)]
        [DataRow("Software enginering", 6)]
        public void GetCompetentieMatrix_Should_Call_GetEindcompetentieMatrixByCriteria_On_EindcompetentieService(
            string specialisatieNaam, int periodeNummer)
        {
            // Arrange
            var controller = new EindCompetentieController(_loggerMock.Object, _eindCompetentieService.Object);

            // Act
            var result = controller.GetCompetentieMatrix(specialisatieNaam, periodeNummer, "2019/2020");

            // Assert
            _eindCompetentieService.Verify(service =>
                service.GetEindcompetentieMatrixByCriteria(It.IsAny<ICompetentieRepository.Criteria>()));
        }
    }
}