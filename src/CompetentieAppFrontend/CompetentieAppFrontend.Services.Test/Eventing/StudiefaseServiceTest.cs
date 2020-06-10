using System.Collections.Generic;
using System.Linq;
using CompetentieAppFrontend.Domain;
using CompetentieAppFrontend.Infrastructure.Repositories;
using CompetentieAppFrontend.Services.Abstractions;
using CompetentieAppFrontend.Services.Commands;
using CompetentieAppFrontend.Services.Eventing;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace CompetentieAppFrontend.Services.Test.Eventing
{
    [TestClass]
    public class StudiefaseServiceTest
    {
        private Mock<ISpecialisatieRepository> _specialisatieRepositoryMock;
        private Mock<IStudiefaseRepository> _studiefaseRepositoryMock;
        private Mock<IPeriodeRepository> _periodeRepositoryMock;

        [TestInitialize]
        public void TestInitialize()
        {
            _specialisatieRepositoryMock = new Mock<ISpecialisatieRepository>();
            _studiefaseRepositoryMock = new Mock<IStudiefaseRepository>();
            _periodeRepositoryMock = new Mock<IPeriodeRepository>();

            _specialisatieRepositoryMock
                .Setup(repository => repository.EnsureSpecialisatiesExist(It.IsAny<IEnumerable<Specialisatie>>()))
                .Returns(new List<long> {1, 2});

            _periodeRepositoryMock
                .Setup(repository => repository.EnsurePeriodenExist(It.IsAny<IEnumerable<Periode>>()))
                .Returns(new List<long> {2, 3});
        }

        [TestMethod]
        public void CreateStudiefasen_Should_Call_CreateStudiefasen_On_StudiefaseRepository()
        {
            // Arrange
            var service = new StudiefaseService(
                _specialisatieRepositoryMock.Object,
                _studiefaseRepositoryMock.Object,
                _periodeRepositoryMock.Object
            );

            // Act
            service.CreateStudiefasen(new CreateStudiefasenCommand
            {
                VerplichtVoor = new List<Specialisatie>(),
                AanbevolenVoor = new List<Specialisatie>(),
                ModuleId = 1,
                PeriodenNummers = new List<int> {2, 3}
            });

            _studiefaseRepositoryMock.Verify(repository =>
                repository.CreateStudiefasen(It.IsAny<IEnumerable<Studiefase>>()));
        }

        [TestMethod]
        public void CreateStudiefasen_Should_Convert_Data_In_Studiefasen()
        {
            // Arrange
            IEnumerable<Studiefase> actual = new List<Studiefase>();
            _studiefaseRepositoryMock
                .Setup(repository => repository.CreateStudiefasen(It.IsAny<IEnumerable<Studiefase>>()))
                .Callback((IEnumerable<Studiefase> studiefasen) => { actual = studiefasen; });
            var service = new StudiefaseService(
                _specialisatieRepositoryMock.Object,
                _studiefaseRepositoryMock.Object,
                _periodeRepositoryMock.Object
            );

            // Act
            service.CreateStudiefasen(new CreateStudiefasenCommand
            {
                VerplichtVoor = new List<Specialisatie>(),
                AanbevolenVoor = new List<Specialisatie>(),
                ModuleId = 1,
                PeriodenNummers = new List<int> {2, 3}
            });

            // Assert
            Assert.IsTrue(actual.Any(studiefase => studiefase.PeriodeId == 3));
        }
    }
}