using System.Collections.Generic;
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
                    Perioden = new List<int>(){ 1, 3}
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
                    Perioden = new List<int>(){ 1, 3}
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
                    Perioden = new List<int>(){ 1, 3}
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
                    Perioden = new List<int>(){ 1, 3}
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
    }
}
