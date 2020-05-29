using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ModuleFrontend.Api.DAL;
using ModuleFrontend.Api.Models;
using ModuleFrontend.Api.Services;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace ModuleFrontend.Api.ComponentTest
{
    [TestClass]
    public class ModuleServiceTest
    {
        private const string DATA_SOURCE = "DataSource=:memory:";
        private static SqliteConnection _connection;
        private static DbContextOptions<ModuleContext> _options;

        [ClassInitialize]
        public static void ClassInitialize(TestContext tc)
        {
            _connection = new SqliteConnection(DATA_SOURCE);
            _connection.Open();
            _options = new DbContextOptionsBuilder<ModuleContext>().UseSqlite(_connection).Options;

            using var context = new ModuleContext(_options);
            context.Database.EnsureCreated();
        }

        [ClassCleanup]
        public static void ClassCleanup()
        {
            _connection.Close();
        }

        [TestInitialize]
        public void TestInitialize()
        {
            using var context = new ModuleContext(_options);
            context.Set<Module>().RemoveRange(context.Set<Module>());
            context.SaveChanges();
            LoadData();
        }

        private void LoadData()
        {
            using var context = new ModuleContext(_options);
            IEnumerable<Module> modules = new List<Module>() { 
                new Module { ModuleCode = "icommh", AantalEc = 3 }, 
                new Module { ModuleCode = "iitorg", AantalEc = 6 }, 
                new Module { ModuleCode = "iad1", AantalEc = 7 }, 
                new Module { ModuleCode = "iwis", AantalEc = 1 } 
            };
            context.Modules.AddRange(modules);
            context.SaveChanges();
        }

        [TestMethod]
        public void TestIfGetModuleReturnsModuleWithCorrectModulecode()
        {
            // Arrange
            using var context = new ModuleContext(_options);
            IModuleService service = new ModuleService(context);

            // Act
            var module = service.GetByModuleCode("icommh");

            // Assert 
            Assert.AreEqual("icommh", module.ModuleCode);
        }

        [TestMethod]
        public void TestIfGetModuleReturnsNullWhenCanNotFind()
        {
            // Arrange
            using var context = new ModuleContext(_options);
            IModuleService service = new ModuleService(context);

            // Act
            var module = service.GetByModuleCode("notexistingModuleCode");

            // Assert 
            Assert.AreEqual(null, module);
        }

        [TestMethod]
        public void TestIfGetAllModulesReturnsAllRecords()
        {
            // Arrange
            using var context = new ModuleContext(_options);
            IModuleService service = new ModuleService(context);

            // Act
            var modules = service.GetAllModules();

            // Assert 
            Assert.AreEqual(4, modules.Count());
        }
    }
}
