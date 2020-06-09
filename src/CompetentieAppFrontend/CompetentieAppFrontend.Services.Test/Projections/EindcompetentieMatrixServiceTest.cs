using System.Collections.Generic;
using System.Linq;
using CompetentieAppFrontend.Domain;
using CompetentieAppFrontend.Infrastructure.Repositories;
using CompetentieAppFrontend.Services.Projections;
using Microsoft.Extensions.Logging;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace CompetentieAppFrontend.Services.Test.Projections
{
    [TestClass]
    public class EindcompetentieMatrixServiceTest
    {
        private Mock<IArchitectuurLaagRepository> _architectuurLaagRepositoryMock;
        private Mock<IActiviteitRepository> _activiteitRepositoryMock;
        private Mock<ILogger<EindcompetentieMatrixService>> _loggerMock;

        [TestInitialize]
        public void TestInitialize()
        {
            _architectuurLaagRepositoryMock = new Mock<IArchitectuurLaagRepository>();
            _activiteitRepositoryMock = new Mock<IActiviteitRepository>();
            _loggerMock = new Mock<ILogger<EindcompetentieMatrixService>>();

            _architectuurLaagRepositoryMock
                .Setup(repository => repository.GetAllArchitectuurLaagNamen())
                .Returns(new List<string>{"software engineering"});
            _activiteitRepositoryMock
                .Setup(repository => repository.GetAllActiviteitNamen())
                .Returns(new List<string>{"beheren"});
        }

        [TestMethod]
        public void CreateCompetentieMatrix_Should_Return_Typeof_Matrix_With_Eindniveau()
        {
            // Arrange
            var service = new EindcompetentieMatrixService(
                _loggerMock.Object,
                _architectuurLaagRepositoryMock.Object,
                _activiteitRepositoryMock.Object
            );
            
            // Act
            var result = service.CreateCompetentieMatrix(new List<Competentie>());

            // Assert
            Assert.IsInstanceOfType(result, typeof(Matrix<Eindniveau>));
        }

        [TestMethod]
        public void CreateCompetentieMatrix_Should_Call_GetAllArchitectuurLaagNamen_On_ArchitectuurLaagRepository()
        {
            // Arrange
            var service = new EindcompetentieMatrixService(
                _loggerMock.Object,
                _architectuurLaagRepositoryMock.Object,
                _activiteitRepositoryMock.Object
            );
            
            // Act
            var result = service.CreateCompetentieMatrix(new List<Competentie>());

            // Assert
            _architectuurLaagRepositoryMock.Verify(repository => repository.GetAllArchitectuurLaagNamen());
        }

        [TestMethod]
        public void CreateCompetentieMatrix_Should_Call_GetAllActiviteitNamen_On_ActiviteitRepository()
        {
            // Arrange
            var service = new EindcompetentieMatrixService(
                _loggerMock.Object,
                _architectuurLaagRepositoryMock.Object,
                _activiteitRepositoryMock.Object
            );
            
            // Act
            var result = service.CreateCompetentieMatrix(new List<Competentie>());

            // Assert
            _architectuurLaagRepositoryMock.Verify(repository => repository.GetAllArchitectuurLaagNamen());
        }

        [TestMethod]
        public void CreateCompetentieMatrix_Should_Map_Niveaus_To_Matrix()
        {
            // Arrange
            var service = new EindcompetentieMatrixService(
                _loggerMock.Object,
                _architectuurLaagRepositoryMock.Object,
                _activiteitRepositoryMock.Object
            );
            
            // Act
            var result = service.CreateCompetentieMatrix(new List<Competentie>
            {
                new Competentie
                {
                    BeheersingsNiveau = new BeheersingsNiveau
                    {
                        ArchitectuurLaag = new ArchitectuurLaag
                        {
                            ArchitectuurLaagNaam = "software engineering"
                        },
                        Activiteit = new Activiteit
                        {
                            ActiviteitNaam = "beheren"
                        },
                        Niveau = 1,
                    },
                    Module = new Module
                    {
                        ModuleCode = "IOPR2"
                    }
                }
            });

            // Assert
            Assert.IsTrue(result.Cells[0][0].Value.Niveau == 1);
        }
        
        [TestMethod]
        public void CreateCompetentieMatrix_Should_Group_Modules_To_Matrix()
        {
            // Arrange
            var service = new EindcompetentieMatrixService(
                _loggerMock.Object,
                _architectuurLaagRepositoryMock.Object,
                _activiteitRepositoryMock.Object
            );
            
            // Act
            var result = service.CreateCompetentieMatrix(new List<Competentie>
            {
                new Competentie
                {
                    BeheersingsNiveau = new BeheersingsNiveau
                    {
                        ArchitectuurLaag = new ArchitectuurLaag
                        {
                            ArchitectuurLaagNaam = "software engineering"
                        },
                        Activiteit = new Activiteit
                        {
                            ActiviteitNaam = "beheren"
                        },
                        Niveau = 1,
                    },
                    Module = new Module
                    {
                        ModuleCode = "IOPR2"
                    }
                }
            });

            // Assert
            Assert.IsTrue(result.Cells[0][0].Value.Modules.Contains("IOPR2"));
        }

        [TestMethod]
        public void GetCompetentieMatrix_Should_Use_Highest_Niveau_For_Matrix()
        {
            // Arrange
            var service = new EindcompetentieMatrixService(
                _loggerMock.Object,
                _architectuurLaagRepositoryMock.Object,
                _activiteitRepositoryMock.Object
            );
            
            // Act
            var result = service.CreateCompetentieMatrix(new List<Competentie>
            {
                new Competentie
                {
                    BeheersingsNiveau = new BeheersingsNiveau
                    {
                        ArchitectuurLaag = new ArchitectuurLaag
                        {
                            ArchitectuurLaagNaam = "software engineering"
                        },
                        Activiteit = new Activiteit
                        {
                            ActiviteitNaam = "beheren"
                        },
                        Niveau = 1,
                    },
                    Module = new Module
                    {
                        ModuleCode = "IOPR2"
                    }
                },
                new Competentie
                {
                    BeheersingsNiveau = new BeheersingsNiveau
                    {
                        ArchitectuurLaag = new ArchitectuurLaag
                        {
                            ArchitectuurLaagNaam = "software engineering"
                        },
                        Activiteit = new Activiteit
                        {
                            ActiviteitNaam = "beheren"
                        },
                        Niveau = 3,
                    },
                    Module = new Module
                    {
                        ModuleCode = "IUML"
                    }
                }
            });

            // Assert
            Assert.IsTrue(result.Cells[0][0].Value.Niveau == 3);
        }

        [DataTestMethod]
        [DataRow("IOPR2")]
        [DataRow("IUML")]
        public void GetCompetentieMatrix_Should_Have_All_Corresponding_Modules_Grouped(string moduleCode)
        {
            // Arrange
            var service = new EindcompetentieMatrixService(
                _loggerMock.Object,
                _architectuurLaagRepositoryMock.Object,
                _activiteitRepositoryMock.Object
            );
            
            // Act
            var result = service.CreateCompetentieMatrix(new List<Competentie>
            {
                new Competentie
                {
                    BeheersingsNiveau = new BeheersingsNiveau
                    {
                        ArchitectuurLaag = new ArchitectuurLaag
                        {
                            ArchitectuurLaagNaam = "software engineering"
                        },
                        Activiteit = new Activiteit
                        {
                            ActiviteitNaam = "beheren"
                        },
                        Niveau = 1,
                    },
                    Module = new Module
                    {
                        ModuleCode = "IOPR2"
                    }
                },
                new Competentie
                {
                    BeheersingsNiveau = new BeheersingsNiveau
                    {
                        ArchitectuurLaag = new ArchitectuurLaag
                        {
                            ArchitectuurLaagNaam = "software engineering"
                        },
                        Activiteit = new Activiteit
                        {
                            ActiviteitNaam = "beheren"
                        },
                        Niveau = 3,
                    },
                    Module = new Module
                    {
                        ModuleCode = "IUML"
                    }
                }
            });

            // Assert
            Assert.IsTrue(result.Cells[0][0].Value.Modules.Contains(moduleCode));
        }
    }
}