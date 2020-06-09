using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Miffy.MicroServices.Commands;
using ModuleFrontend.Api.Commands;
using ModuleFrontend.Api.Models;
using ModuleFrontend.Api.Services;
using ModuleFrontend.Api.ViewModels;
using Moq;

namespace ModuleFrontend.Api.Test
{
    [TestClass]
    public class ModuleServiceTest
    {
        [TestMethod]
        public void SendCreeerModuleCommand_TestIfPublishAsyncGetsCalled()
        {
            // Arrange
            Mock<ICommandPublisher> mock = new Mock<ICommandPublisher>(MockBehavior.Strict);
            mock.Setup(publisher => publisher.PublishAsync<CreeerModuleCommandResponse>(It.IsAny<CreeerModuleCommand>())).Returns(Task.FromResult(new CreeerModuleCommandResponse(){Message = "Module toegevoegd", StatusCode = 200}));
            IModuleService sut = new ModuleService(mock.Object);
            ModuleViewModel correctModel = new ModuleViewModel()
            {
                Cohort = "2017/2018",
                Competenties = new Matrix(),
                Eindeisen = new List<string>(){"Eindeis1", "Eindeis2"},
                Moduleleider = new ModuleleiderViewModel()
                {
                    Email = "dirkjan@hotmail.com",
                    Naam = "dirk-jan",
                    Telefoonnummer = "06742136491"
                },
                Studiefase = new StudiefaseViewModel()
                {
                    Fase = "Propedeuse",
                    Periode = new List<int>(){ 1, 3}
                },
                Studiejaar = "Jaar 3",
                AanbevolenVoor = new List<SpecialisatieViewModel>(){ new SpecialisatieViewModel()
                {
                    Code = "SE",
                    Naam = "Software Engineering"
                }},
                AantalEc = 3,
                ModuleCode = "iad1",
                ModuleNaam = "Algoritmen en Datastructuren 1",
                VerplichtVoor = new List<SpecialisatieViewModel>(){ new SpecialisatieViewModel(){Code = "SE", Naam = "Software Engineering"}}
            };
            
            // Act
            var result = sut.SendCreeerModuleCommand(correctModel);
            
            // Assert
            mock.Verify(publisher => publisher.PublishAsync<CreeerModuleCommandResponse>(It.IsAny<CreeerModuleCommand>()));
        }
    }
}