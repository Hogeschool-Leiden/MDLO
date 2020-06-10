using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ModuleDomainService.Infrastructure.DAL;

namespace ModuleDomainService.Infrastructure.Test.DAL
{
    [TestClass]
    public class IEnumerableExtensionsTest
    {
        [TestMethod]
        public void Empty_IEnumerable_Returns_Zero()
        {
            var events = new List<Event>();

            var version = IEnumerableExtensions.Version(events);
            
            Assert.AreEqual(0, version);
        }

        [TestMethod]
        public void Null_Object_Should_Return_Zero()
        {
            var version = IEnumerableExtensions.Version(null);
            
            Assert.AreEqual(0, version);
        }
    }
}