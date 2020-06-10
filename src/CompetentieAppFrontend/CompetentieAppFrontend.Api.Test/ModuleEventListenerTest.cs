using System.Reflection;
using CompetentieAppFrontend.Api.EventListeners;
using CompetentieAppFrontend.Constants;
using CompetentieAppFrontend.Services.Abstractions;
using CompetentieAppFrontend.Services.Events;
using Microsoft.Extensions.Logging;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Miffy.MicroServices.Events;
using Moq;

namespace CompetentieAppFrontend.Api.Test
{
    [TestClass]
    public class ModuleEventListenerTest
    {
        private Mock<IModuleEventsDeserializer> _moduleEventsDeserializer;
        private Mock<ILogger<ModuleEventListener>> _loggerMock;

        [TestInitialize]
        public void TestInitialize()
        {
            _moduleEventsDeserializer = new Mock<IModuleEventsDeserializer>();
            _loggerMock = new Mock<ILogger<ModuleEventListener>>();
        }

        [TestMethod]
        public void ModuleGecreeerd_Should_CreateModule_On_ModuleEventsDeserializer()
        {
            // Arrange
            var eventListener = new ModuleEventListener(_moduleEventsDeserializer.Object, _loggerMock.Object);

            // Act
            eventListener.ModuleGecreeerd(new ModuleGecreeerd());

            // Assert
            _moduleEventsDeserializer.Verify(deserializer => deserializer.CreateModule(It.IsAny<ModuleGecreeerd>()));
        }

        [TestMethod]
        public void ModuleGecreeerd_Should_Have_EventListenerAttribute()
        {
            // Arrange
            var eventListener = new ModuleEventListener(_moduleEventsDeserializer.Object, _loggerMock.Object);

            // Act
            var result = eventListener.GetType().GetMethod(nameof(eventListener.ModuleGecreeerd))
                ?.GetCustomAttribute<EventListenerAttribute>();

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void ModuleGecreeerd_Should_Have_TopicAttribute()
        {
            // Arrange
            var eventListener = new ModuleEventListener(_moduleEventsDeserializer.Object, _loggerMock.Object);

            // Act
            var result = eventListener.GetType().GetMethod(nameof(eventListener.ModuleGecreeerd))
                ?.GetCustomAttribute<TopicAttribute>();

            // Assert
            Assert.IsNotNull(result);
        }
        
        [TestMethod]
        public void ModuleGecreeerd_Should_Have_TopicAttribute_With_TopicPattern_Of_ModuleGecreeerd()
        {
            // Arrange
            var eventListener = new ModuleEventListener(_moduleEventsDeserializer.Object, _loggerMock.Object);

            // Act
            var result = eventListener.GetType().GetMethod(nameof(eventListener.ModuleGecreeerd))
                ?.GetCustomAttribute<TopicAttribute>()?.TopicPattern;

            // Assert
            Assert.AreEqual(Topics.ModuleGecreeerd, result);
        }
    }
}