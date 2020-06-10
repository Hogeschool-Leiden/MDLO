using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Miffy.MicroServices.Events;
using ModuleDomainService.Domain.Events;
using ModuleDomainService.Infrastructure.DAL;

namespace ModuleDomainService.Infrastructure.Test.DAL
{
    [TestClass]
    public class EventStreamTest
    {
        [TestMethod]
        public void ToEvents_Should_Return_Instance_Of_Type_IEnumerable_With_Events()
        {
            // Arrange
            var eventStream = new EventStream("streamId", 1, new List<DomainEvent> {new ModuleGecreeerd()});

            // Act
            var result = eventStream.ToEvents;

            // Assert
            Assert.IsInstanceOfType(result, typeof(IEnumerable<Event>));
        }

        [TestMethod]
        public void Events_Should_Return_Instance_Of_Type_IEnumerable_With_DomainEvent()
        {
            // Arrange
            var eventStream = new EventStream("streamId", new List<Event>
            {
                Event.FromDomainEvent(new Stream("streamId", 1), new ModuleGecreeerd())
            });

            // Act
            var result = eventStream.Events;

            // Assert
            Assert.IsInstanceOfType(result, typeof(IEnumerable<DomainEvent>));
        }
    }
}