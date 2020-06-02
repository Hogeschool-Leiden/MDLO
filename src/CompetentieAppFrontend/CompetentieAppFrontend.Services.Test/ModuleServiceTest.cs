using System;
using System.Collections.Generic;
using System.Linq;
using CompetentieAppFrontend.Domain;
using CompetentieAppFrontend.Infrastructure.Repositories;
using Microsoft.Extensions.Logging;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace CompetentieAppFrontend.Services.Test
{
    [TestClass]
    public class ModuleServiceTest
    {
        private Mock<IMatrixService<int>> _niveauMatrixService;
        private Mock<IModuleRepository> _moduleRepositoryMock;
        private Mock<ILogger<EindcompetentieService>> _loggerMock;

        [TestInitialize]
        public void TestInitialize()
        {
            _niveauMatrixService = new Mock<IMatrixService<int>>();
            _moduleRepositoryMock = new Mock<IModuleRepository>();
            _loggerMock = new Mock<ILogger<EindcompetentieService>>();

            _moduleRepositoryMock
                .Setup(repository => repository.GetAllModules())
                .Returns(new List<Module>
                {
                    new Module
                    {
                        ModuleCode = "IOPR",
                        Studiefasen = new List<Studiefase>
                        {
                            new Studiefase
                            {
                                Specialisatie = new Specialisatie
                                {
                                    SpecialisatieNaam = "Propedeuse",
                                },
                                Periode = new Periode
                                {
                                    PeriodeNummer = 1
                                }
                            }
                        },
                        Eindeisen = new List<Eindeis>
                        {
                            new Eindeis
                            {
                                EindeisBeschrijving = "Weten wat een if statement is"
                            }
                        },
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
                                        ActiviteitNaam = "ontwikkelen"
                                    },
                                    Niveau = 1
                                }
                            }
                        },
                        Cohort = new Cohort
                        {
                            CohortNaam = "Studiejaar 2019/2020",
                            StartDatum = new DateTime(2019, 9, 3)
                        }
                    },
                    new Module
                    {
                        ModuleCode = "IOPR2",
                        Studiefasen = new List<Studiefase>
                        {
                            new Studiefase
                            {
                                Specialisatie = new Specialisatie
                                {
                                    SpecialisatieNaam = "Propedeuse",
                                },
                                Periode = new Periode
                                {
                                    PeriodeNummer = 3
                                }
                            }
                        },
                        Eindeisen = new List<Eindeis>
                        {
                            new Eindeis
                            {
                                EindeisBeschrijving = "OOP kunnen programeren"
                            }
                        },
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
                                        ActiviteitNaam = "ontwikkelen"
                                    },
                                    Niveau = 2
                                }
                            }
                        },
                        Cohort = new Cohort
                        {
                            CohortNaam = "Studiejaar 2019/2020",
                            StartDatum = new DateTime(2019, 9, 3)
                        }
                    }
                });

            _niveauMatrixService
                .Setup(service => service.CreateCompetentieMatrix(It.IsAny<IEnumerable<Competentie>>()))
                .Returns(new Matrix<int>(new List<string>(), new List<string>(), new List<Niveau> { }));
        }

        [TestMethod]
        public void GetAllModules_Should_Return_Typeof_IEnumerable_With_ModuleWithMatrix()
        {
            // Arrange
            var service = new ModuleService(
                _loggerMock.Object,
                _niveauMatrixService.Object,
                _moduleRepositoryMock.Object
            );

            // Act
            var result = service.GetAllModules();

            // Assert
            Assert.IsInstanceOfType(result, typeof(IEnumerable<ModuleView>));
        }

        [TestMethod]
        public void GetAllModules_Should_Call_GetAllModules_On_ModuleRepository()
        {
            // Arrange
            var service = new ModuleService(
                _loggerMock.Object,
                _niveauMatrixService.Object,
                _moduleRepositoryMock.Object
            );

            // Act
            var result = service.GetAllModules();

            // Assert
            _moduleRepositoryMock.Verify(repository => repository.GetAllModules());
        }

        [DataTestMethod]
        [DataRow("IOPR")]
        [DataRow("IOPR2")]
        public void GetAllModules_Should_Return_ModulesWithMatrix_From_Database_Data(string moduleCode)
        {
            // Arrange
            var service = new ModuleService(
                _loggerMock.Object,
                _niveauMatrixService.Object,
                _moduleRepositoryMock.Object
            );

            // Act
            var result = service.GetAllModules();

            // Assert
            Assert.IsTrue(result.Any(matrix => matrix.ModuleCode.Equals(moduleCode)));
        }

        [TestMethod]
        public void GetAllModules_Should_Return_ModulesWithMatrix_With_Specialisaties()
        {
            // Arrange
            var service = new ModuleService(
                _loggerMock.Object,
                _niveauMatrixService.Object,
                _moduleRepositoryMock.Object
            );

            // Act
            var result = service.GetAllModules();

            // Assert
            Assert.IsTrue(result.Any(matrix => matrix.Specialisaties.Contains("Propedeuse")));
        }

        [TestMethod]
        public void GetAllModules_Should_Return_ModulesWithMatrix_With_Perioden()
        {
            // Arrange
            var service = new ModuleService(
                _loggerMock.Object,
                _niveauMatrixService.Object,
                _moduleRepositoryMock.Object
            );

            // Act
            var result = service.GetAllModules();

            // Assert
            Assert.IsTrue(result.Any(matrix => matrix.Perioden.Contains(1)));
        }

        [TestMethod]
        public void GetAllModules_Should_Return_ModulesWithMatrix_With_Eindeisen()
        {
            // Arrange
            var service = new ModuleService(
                _loggerMock.Object,
                _niveauMatrixService.Object,
                _moduleRepositoryMock.Object
            );

            // Act
            var result = service.GetAllModules();

            // Assert
            Assert.IsTrue(result.Any(matrix => matrix.Eindeisen.Contains("Weten wat een if statement is")));
        }

        [TestMethod]
        public void GetAllModules_Should_Return_ModulesWithMatrix_With_Matrix()
        {
            // Arrange
            var moduleService = new ModuleService(
                _loggerMock.Object,
                _niveauMatrixService.Object,
                _moduleRepositoryMock.Object
            );

            // Act
            var result = moduleService.GetAllModules();

            // Assert
            Assert.IsFalse(result.Any(matrix => matrix.Matrix.Equals(null)));
        }

        [TestMethod]
        public void GetAllModules_Should_Have_CohortNaam()
        {
            // Arrange
            var moduleService = new ModuleService(
                _loggerMock.Object,
                _niveauMatrixService.Object,
                _moduleRepositoryMock.Object
            );

            // Act
            var result = moduleService.GetAllModules();

            // Assert
            Assert.IsTrue(result.All(view => view.CohortNaam.Equals("Studiejaar 2019/2020")));
        }
    }
}