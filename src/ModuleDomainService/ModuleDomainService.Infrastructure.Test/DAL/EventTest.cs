using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ModuleDomainService.Domain;
using ModuleDomainService.Domain.Events;
using ModuleDomainService.Infrastructure.DAL;

namespace ModuleDomainService.Infrastructure.Test.DAL
{
    [TestClass]
    public class EventTest
    {
        [TestMethod]
        public void FromDomainEvent_Should_Have_A_Id_From_Stream()
        {
            // Arrange
            var stream = new Stream("streamId", 1);
            var domainEvent = new ModuleGecreeerd();

            // Act
            var result = Event.FromDomainEvent(stream, domainEvent);

            // Assert
            Assert.AreEqual("streamId:1:ModuleGecreeerd", result.Id);
        }

        [TestMethod]
        public void FromDomainEvent_Should_Have_A_Version_From_Stream()
        {
            // Arrange
            var stream = new Stream("streamId", 1);
            var domainEvent = new ModuleGecreeerd();

            // Act
            var result = Event.FromDomainEvent(stream, domainEvent);

            // Assert
            Assert.AreEqual(1, result.Stream.Version);
        }

        [TestMethod]
        public void FromDomainEvent_Should_Have_A_Json_Object_Of_DomainEvent()
        {
            // Arrange
            var stream = new Stream("streamId", 1);
            var domainEvent = new ModuleGecreeerd();

            // Act
            var result = Event.FromDomainEvent(stream, domainEvent);

            // Assert
            Assert.AreEqual("ModuleGecreeerd", result.Type);
        }

        [TestMethod]
        public void ToDomainEvent_Should_Return_Instanceof_Type_ModuleGecreeerd()
        {
            // Arrange
            var stream = new Stream("streamId", 1);
            var domainEvent = new ModuleGecreeerd
            {
                ModuleCode = "IOPR",
                ModuleNaam = "Object oriented programming",
                AantalEc = 3,
                Cohort = "2019/2020",
                VerplichtVoor = new List<Specialisatie>(),
                AanbevolenVoor = new List<Specialisatie>(),
                Competenties = new Matrix
                {
                    XHeaders = new List<string> {"software"},
                    YHeaders = new List<string> {"analyseren"},
                    Cells = new int[][] {new[] {1}}
                },
                Studiefase = new Studiefase("", new List<int> {1, 2}),
                Eindeisen = new List<string> {"Test", "Test"}
            };

            // Act
            var result = Event.FromDomainEvent(stream, domainEvent).ToDomainEvent();

            // Assert
            Assert.IsInstanceOfType(result, typeof(ModuleGecreeerd));
        }
    }
}