using System.Collections.Generic;
using System.Linq;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Miffy.MicroServices.Events;
using ModuleDomainService.Domain;
using ModuleDomainService.Domain.Events;
using ModuleDomainService.Infrastructure.DAL;

namespace ModuleDomainService.Infrastructure.Test.DAL
{
    [TestClass]
    public class SQLEventStoreTest
    {
        private const string DATA_SOURCE = "DataSource=:memory:";
        private static SqliteConnection _connection;
        private static DbContextOptions<ModuleDomainServiceContext> _options;

        [TestInitialize]
        public void TestInitialize()
        {
            _connection = new SqliteConnection(DATA_SOURCE);
            _connection.Open();
            _options = new DbContextOptionsBuilder<ModuleDomainServiceContext>()
                .UseSqlite(_connection).Options;
            using var context = new ModuleDomainServiceContext(_options);
            context.Database.EnsureCreated();
        }

        [TestCleanup]
        public void TestCleanUp()
        {
            using var context = new ModuleDomainServiceContext(_options);
            context.Database.EnsureDeleted();
            _connection.Close();
        }

        [TestMethod]
        public void AppendToStream_Should_Append_Event_To_Stream()
        {
            // Assert
            var context = new ModuleDomainServiceContext(_options);
            var eventStore = new SQLEventStore(context);
            
            // Act
            eventStore.AppendToStream(new EventStream("uniqueId", 0, new List<DomainEvent>
            {
                new ModuleGecreeerd
                {
                    ModuleCode = "IOPR",
                    ModuleNaam = "Object georienteerd programeren",
                    AantalEc = 3,
                    Cohort = new Cohort()
                }
            }));

            // Assert
            Assert.IsTrue(context.Events.Any(@event => @event.Stream.Id.Equals("uniqueId")));
        }
    }
}