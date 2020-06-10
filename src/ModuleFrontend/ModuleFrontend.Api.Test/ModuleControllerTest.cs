using System.Collections.Generic;
using System.IO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Miffy;
using ModuleFrontend.Api.Commands;
using ModuleFrontend.Api.Controllers;
using ModuleFrontend.Api.Models;
using ModuleFrontend.Api.Services;
using ModuleFrontend.Api.Utility;
using ModuleFrontend.Api.ViewModels;
using Moq;


namespace ModuleFrontend.Api.Test
{
    [TestClass]
    public class ModuleControllerTest
    {
        private static string file2 = "TestData/testdata2.csv";
        [TestMethod]
        public void PostModule_TestIfFaultyViewModelReturns400()
        {
            // Arrange
            Mock<ICsvLoader> csvMock = new Mock<ICsvLoader>(MockBehavior.Loose);
            Mock<IModuleService> service = new Mock<IModuleService>(MockBehavior.Loose);
            ModuleController sut = new ModuleController(service.Object, csvMock.Object);
            sut.ModelState.AddModelError("FaultyModel", "A faulty model has been sent");
            
            // Act
            var result = sut.PostModule(new ModuleViewModel());
            
            // Assert
            Assert.IsInstanceOfType(result, typeof(BadRequestObjectResult));
        }

        [TestMethod]
        public void PostModule_TestIfViewModelWith0VerplichtVoorReturnsVerplichtVoorError()
        {
            // Arrange
            Mock<ICsvLoader> csvMock = new Mock<ICsvLoader>(MockBehavior.Loose);
            Mock<IModuleService> service = new Mock<IModuleService>(MockBehavior.Loose);
            ModuleController sut = new ModuleController(service.Object, csvMock.Object);
            
            // Act
            ModuleViewModel model = new ModuleViewModel()
            {
                Cohort = "2017/2018",
                Competenties = new Matrix(),
                Eindeisen = new List<string>(){"Eindeis1", "Eindeis2"},
                Moduleleider = new Moduleleider()
                {
                    Email = "dirkjan@hotmail.com",
                    Naam = "dirk-jan",
                    Telefoonnummer = "06742136491"
                },
                Studiefase = new Studiefase()
                {
                    Fase = "Propedeuse",
                    Periode = new List<int>(){ 1, 3}
                },
                Studiejaar = "Jaar 3",
                AanbevolenVoor = new List<Specialisatie>(){ new Specialisatie()
                {
                    Code = "SE",
                    Naam = "Software Engineering"
                }},
                AantalEc = 3,
                ModuleCode = "iad1",
                ModuleNaam = "Algoritmen en Datastructuren 1",
                VerplichtVoor = new List<Specialisatie>(){}
            };
            var result = sut.PostModule(model);
            
            // Assert
            Assert.IsInstanceOfType(result, typeof(BadRequestObjectResult));
            var objectResult = (BadRequestObjectResult) result;
            Assert.AreEqual("Een module moest minstens voor één specialisatie verplicht zijn.",objectResult.Value);
        }

        [TestMethod]
        public void PostModule_TestIfCommandReturnsCode400BadRequestIfCommandResponseIs400()
        {
            // Arrange
            Mock<ICsvLoader> csvMock = new Mock<ICsvLoader>(MockBehavior.Loose);
            Mock<IModuleService> service = new Mock<IModuleService>(MockBehavior.Loose);
            service.Setup(s => s.SendCreeerModuleCommand(It.IsAny<Module>()))
                .Returns(new CreeerModuleCommandResponse() {StatusCode = 400, Message = "Combinatie van modulecode en cohort bestaat al"});
            ModuleController sut = new ModuleController(service.Object, csvMock.Object);
            ModuleViewModel correctModel = new ModuleViewModel()
            {
                Cohort = "2017/2018",
                Competenties = new Matrix(),
                Eindeisen = new List<string>(){"Eindeis1", "Eindeis2"},
                Moduleleider = new Moduleleider()
                {
                    Email = "dirkjan@hotmail.com",
                    Naam = "dirk-jan",
                    Telefoonnummer = "06742136491"
                },
                Studiefase = new Studiefase()
                {
                    Fase = "Propedeuse",
                    Periode = new List<int>(){ 1, 3}
                },
                Studiejaar = "Jaar 3",
                AanbevolenVoor = new List<Specialisatie>(){ new Specialisatie()
                {
                    Code = "SE",
                    Naam = "Software Engineering"
                }},
                AantalEc = 3,
                ModuleCode = "iad1",
                ModuleNaam = "Algoritmen en Datastructuren 1",
                VerplichtVoor = new List<Specialisatie>(){ new Specialisatie(){Code = "SE", Naam = "Software Engineering"}}
            };
            // Act
            var result = sut.PostModule(correctModel);
            
            
            // Assert
            Assert.IsInstanceOfType(result, typeof(BadRequestObjectResult));
            var objectResult = (BadRequestObjectResult) result;
            Assert.AreEqual("De combinatie van modulecode en cohort bestaat al.", objectResult.Value);
        }

        [TestMethod]
        public void PostModule_TestIfEverythingGoesAlrightReturns200()
        {
            // Arrange
            Mock<ICsvLoader> csvMock = new Mock<ICsvLoader>(MockBehavior.Loose);
            Mock<IModuleService> service = new Mock<IModuleService>(MockBehavior.Loose);
            service.Setup(s => s.SendCreeerModuleCommand(It.IsAny<Module>()))
                .Returns(new CreeerModuleCommandResponse() {StatusCode = 200, Message = "Module met modulecode iad1 aangemaakt."});
            ModuleController sut = new ModuleController(service.Object, csvMock.Object);
            ModuleViewModel correctModel = new ModuleViewModel()
            {
                Cohort = "2017/2018",
                Competenties = new Matrix(),
                Eindeisen = new List<string>(){"Eindeis1", "Eindeis2"},
                Moduleleider = new Moduleleider()
                {
                    Email = "dirkjan@hotmail.com",
                    Naam = "dirk-jan",
                    Telefoonnummer = "06742136491"
                },
                Studiefase = new Studiefase()
                {
                    Fase = "Propedeuse",
                    Periode = new List<int>(){ 1, 3}
                },
                Studiejaar = "Jaar 3",
                AanbevolenVoor = new List<Specialisatie>(){ new Specialisatie()
                {
                    Code = "SE",
                    Naam = "Software Engineering"
                }},
                AantalEc = 3,
                ModuleCode = "iad1",
                ModuleNaam = "Algoritmen en Datastructuren 1",
                VerplichtVoor = new List<Specialisatie>(){ new Specialisatie(){Code = "SE", Naam = "Software Engineering"}}
            };
            
            // Act
            var result = sut.PostModule(correctModel);
            
            // Assert
            Assert.IsInstanceOfType(result, typeof(OkObjectResult));
            var objectResult = (OkObjectResult) result;
            Assert.AreEqual("Module met modulecode iad1 aangemaakt.", objectResult.Value);
        }

        [TestMethod]
        public void PostModule_TestIfStatus500IsReturnedIfDestinationQueueExceptionHappens()
        {
            // Arrange
            Mock<ICsvLoader> csvMock = new Mock<ICsvLoader>(MockBehavior.Loose);
            Mock<IModuleService> service = new Mock<IModuleService>(MockBehavior.Loose);
            service.Setup(s => s.SendCreeerModuleCommand(It.IsAny<Module>())).Throws(new DestinationQueueException("No response from service/Couldnt serialize/deserialize input/response"));
            ModuleController sut = new ModuleController(service.Object, csvMock.Object);
            ModuleViewModel correctModel = new ModuleViewModel()
            {
                Cohort = "2017/2018",
                Competenties = new Matrix(),
                Eindeisen = new List<string>(){"Eindeis1", "Eindeis2"},
                Moduleleider = new Moduleleider()
                {
                    Email = "dirkjan@hotmail.com",
                    Naam = "dirk-jan",
                    Telefoonnummer = "06742136491"
                },
                Studiefase = new Studiefase()
                {
                    Fase = "Propedeuse",
                    Periode = new List<int>(){ 1, 3}
                },
                Studiejaar = "Jaar 3",
                AanbevolenVoor = new List<Specialisatie>(){ new Specialisatie()
                {
                    Code = "SE",
                    Naam = "Software Engineering"
                }},
                AantalEc = 3,
                ModuleCode = "iad1",
                ModuleNaam = "Algoritmen en Datastructuren 1",
                VerplichtVoor = new List<Specialisatie>(){ new Specialisatie(){Code = "SE", Naam = "Software Engineering"}}
            };
            
            // Act
            var result = sut.PostModule(correctModel);
            
            // Assert
            Assert.IsInstanceOfType(result, typeof(ObjectResult));
            var objectResult = (ObjectResult) result;
            Assert.AreEqual(500, objectResult.StatusCode);
            Assert.AreEqual("Er is een fout op de server opgetreden. Probeer het later opnieuw.", objectResult.Value);
            
        }

        [TestMethod]
        public void PostCsv_ShouldReturnBadRequestIfModelErrors()
        {
            // Arrange
            Mock<ICsvLoader> csvMock = new Mock<ICsvLoader>(MockBehavior.Loose);
            Mock<IModuleService> service = new Mock<IModuleService>(MockBehavior.Loose);
            ModuleController sut = new ModuleController(service.Object, csvMock.Object);
            Mock<IFormFile> formFileMock = new Mock<IFormFile>();
            
            using (FileStream fs = File.OpenRead(file2))
                
            formFileMock.Setup(file => file.OpenReadStream()).Returns(fs);
            CsvInlaadFormViewModel model = new CsvInlaadFormViewModel(){Cohort = "2017/2018", File = formFileMock.Object};
            
            // Act
            sut.ModelState.AddModelError("Een error","Oh neeeeee");
            var result = sut.PostCsvFile(model);
            
            // Assert
            Assert.IsInstanceOfType(result, typeof(BadRequestResult));
        }
        
        [TestMethod]
        public void PostCsv_ShouldCallOpenReadStreamOnce()
        {
            // Arrange
            Mock<ICsvLoader> csvMock = new Mock<ICsvLoader>(MockBehavior.Loose);
            Mock<IModuleService> service = new Mock<IModuleService>(MockBehavior.Loose);
            ModuleController sut = new ModuleController(service.Object, csvMock.Object);
            Mock<IFormFile> formFileMock = new Mock<IFormFile>();
            
            using (FileStream fs = File.OpenRead(file2))
                formFileMock.Setup(file => file.OpenReadStream()).Returns(fs);
            
            CsvInlaadFormViewModel model = new CsvInlaadFormViewModel(){Cohort = "2017/2018", File = formFileMock.Object};
            
            // Act
            var result = sut.PostCsvFile(model);
            
            // Assert
            formFileMock.Verify(file => file.OpenReadStream(), Times.Once);
        }
        
        // [TestMethod]
        // public void PostCsv_ShouldCallServiceSendCreeerModuleCommand3Times()
        // {
        //     // Arrange
        //     ICsvLoader loader = new CsvLoader();
        //     Mock<IModuleService> service = new Mock<IModuleService>(MockBehavior.Loose);
        //     service.Setup(s => s.SendCreeerModuleCommand(It.IsAny<Module>()));
        //     ModuleController sut = new ModuleController(service.Object, loader);
        //     Mock<IFormFile> formFileMock = new Mock<IFormFile>();
        //
        //     using (FileStream fs = File.OpenRead(file2))
        //     {
        //         formFileMock.Setup(file => file.OpenReadStream()).Returns(fs);
        //
        //         CsvInlaadFormViewModel model = new CsvInlaadFormViewModel()
        //             {Cohort = "2017/2018", File = formFileMock.Object};
        //
        //         // Act
        //         var result = sut.PostCsvFile(model);
        //
        //         // Assert
        //         service.Verify(service => service.SendCreeerModuleCommand(It.IsAny<Module>()), Times.Exactly(3));
        //     }
        // }
        
        [TestMethod]
        public void PostCsv_ShouldCallServiceSendCreeerModuleCommand1Times()
        {
            // Arrange
            ICsvLoader loader = new CsvLoader();
            Mock<IModuleService> service = new Mock<IModuleService>(MockBehavior.Loose);
            service.Setup(s => s.SendCreeerModuleCommand(It.IsAny<Module>())).Returns(new CreeerModuleCommandResponse(){Message = "xd", StatusCode = 200});
            ModuleController sut = new ModuleController(service.Object, loader);
            Mock<IFormFile> formFileMock = new Mock<IFormFile>();
        
            using (FileStream fs = File.OpenRead(file2))
            {
                formFileMock.Setup(file => file.OpenReadStream()).Returns(fs);
        
                CsvInlaadFormViewModel model = new CsvInlaadFormViewModel()
                    {Cohort = "2017/2018", File = formFileMock.Object};
        
                // Act
                var result = sut.PostCsvFile(model);
        
                // Assert
                service.Verify(service => service.SendCreeerModuleCommand(It.IsAny<Module>()), Times.Exactly(1));
            }
        }
        
        [TestMethod]
        public void PostCsv_ShouldReturn200IfSuccesful()
        {
            // Arrange
            ICsvLoader loader = new CsvLoader();
            Mock<IModuleService> service = new Mock<IModuleService>(MockBehavior.Loose);
            service.Setup(s => s.SendCreeerModuleCommand(It.IsAny<Module>())).Returns(new CreeerModuleCommandResponse(){Message = "xd", StatusCode = 200});
            ModuleController sut = new ModuleController(service.Object, loader);
            Mock<IFormFile> formFileMock = new Mock<IFormFile>();
        
            using (FileStream fs = File.OpenRead(file2))
            {
                formFileMock.Setup(file => file.OpenReadStream()).Returns(fs);
        
                CsvInlaadFormViewModel model = new CsvInlaadFormViewModel()
                    {Cohort = "2017/2018", File = formFileMock.Object};
        
                // Act
                var result = sut.PostCsvFile(model);
        
                // Assert
                Assert.IsInstanceOfType(result, typeof(OkObjectResult));
            }
        }
        
        [TestMethod]
        public void PostCsv_ShouldReturn500IfDestinationQueueException()
        {
            // Arrange
            ICsvLoader loader = new CsvLoader();
            Mock<IModuleService> service = new Mock<IModuleService>(MockBehavior.Loose);
            service.Setup(s => s.SendCreeerModuleCommand(It.IsAny<Module>()))
                .Throws(new DestinationQueueException("Oh oh!"));
            ModuleController sut = new ModuleController(service.Object, loader);
            Mock<IFormFile> formFileMock = new Mock<IFormFile>();
        
            using (FileStream fs = File.OpenRead(file2))
            {
                formFileMock.Setup(file => file.OpenReadStream()).Returns(fs);
        
                CsvInlaadFormViewModel model = new CsvInlaadFormViewModel()
                    {Cohort = "2017/2018", File = formFileMock.Object};
        
                // Act
                var result = sut.PostCsvFile(model);
        
                // Assert
                Assert.IsInstanceOfType(result, typeof(ObjectResult));
                var resultObject= (ObjectResult) result;
                Assert.AreEqual("Er is iets foutgegaan bij het versturen van de modules naar de server.", resultObject.Value);
                Assert.AreEqual(500, resultObject.StatusCode);
            }
        }
    }
}
