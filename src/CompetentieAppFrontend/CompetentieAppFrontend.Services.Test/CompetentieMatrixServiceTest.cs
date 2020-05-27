using System.Collections.Generic;
using CompetentieAppFrontend.Domain;
using CompetentieAppFrontend.Infrastructure.Repositories;
using Microsoft.Extensions.Logging;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace CompetentieAppFrontend.Services.Test
{
    [TestClass]
    public class CompetentieMatrixServiceTest
    {
        private Mock<IArchitectuurLaagRepository> _architectuurRepositoryMock;
        private Mock<IActiviteitRepository> _activiteitRepositoryMock;
        private Mock<ILogger<CompetentieMatrixService>> _loggerMock;

        [TestInitialize]
        public void TestInitialize()
        {
            _architectuurRepositoryMock = new Mock<IArchitectuurLaagRepository>();
            _activiteitRepositoryMock = new Mock<IActiviteitRepository>();
            _loggerMock = new Mock<ILogger<CompetentieMatrixService>>();

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
            var service = new CompetentieMatrixService(_loggerMock.Object, _architectuurRepositoryMock.Object,
                _activiteitRepositoryMock.Object);

            // Act
            var result = service.CreateCompetentieMatrix(new Module
            {
                Competenties = new List<Competentie>
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
                }
            });

            // Assert
            Assert.IsInstanceOfType(result, typeof(CompetentieMatrix));
        }

        [TestMethod]
        public void CreateCompetentieMatrix_Should_Call_GetAllArchitectuurLaagNamen_On_ArchitectuurLaagRepository()
        {
            // Arrange
            var service = new CompetentieMatrixService(_loggerMock.Object, _architectuurRepositoryMock.Object,
                _activiteitRepositoryMock.Object);

            // Act
            var result = service.CreateCompetentieMatrix(new Module
            {
                Competenties = new List<Competentie>
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
                }
            });

            // Assert
            _architectuurRepositoryMock.Verify(repository => repository.GetAllArchitectuurLaagNamen());
        }

        [TestMethod]
        public void CreateCompetentieMatrix_Should_Call_GetAllActiviteitNamen_On_ActiviteitRepository()
        {
            // Arrange
            var service = new CompetentieMatrixService(_loggerMock.Object, _architectuurRepositoryMock.Object,
                _activiteitRepositoryMock.Object);

            // Act
            var result = service.CreateCompetentieMatrix(new Module
            {
                Competenties = new List<Competentie>
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
                }
            });

            // Assert
            _activiteitRepositoryMock.Verify(repository => repository.GetAllActiviteitNamen());
        }

        [TestMethod]
        public void CreateCompetentieMatrix_Should_Build_Correct_Matrix()
        {
            // Arrange
            var service = new CompetentieMatrixService(_loggerMock.Object, _architectuurRepositoryMock.Object,
                _activiteitRepositoryMock.Object);

            // Act
            var result = service.CreateCompetentieMatrix(new Module
            {
                Competenties = new List<Competentie>
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
                }
            });

            // Assert
            Assert.AreEqual(3, result.Matrix[0][0].Niveau);
        }
    }
}