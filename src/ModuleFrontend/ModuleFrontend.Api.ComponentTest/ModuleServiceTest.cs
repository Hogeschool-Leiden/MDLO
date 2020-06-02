using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ModuleFrontend.Api.DAL;
using ModuleFrontend.Api.Exceptions;
using ModuleFrontend.Api.Models;
using ModuleFrontend.Api.Services;
using ModuleFrontend.Api.ViewModels;
using System;
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
                new Module { ModuleNaam = "naam1", ModuleCode = "icommh", AantalEc = 3 },
                new Module { ModuleNaam = "naam2", ModuleCode = "iitorg", AantalEc = 6 },
                new Module { ModuleNaam = "naam3", ModuleCode = "iad1", AantalEc = 7 },
                new Module { ModuleNaam = "naam4", ModuleCode = "iwis", AantalEc = 1 }
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

        [TestMethod]
        public void TestIfAddModuleMakesCountGoUpOne()
        {
            // Arrange
            using var context = new ModuleContext(_options);
            IModuleService service = new ModuleService(context);

            // Act
            var moduleCountBefore = context.Modules.Count();
            var mod = new ModuleViewModel()
            {
                ModuleNaam = "naampie",
                ModuleCode = "code123",
                AantalEc = 2,
                Studiejaar = "Jaar 4",
                Moduleleider = new ModuleleiderViewModel() { Email = "nmfuashf@xdd.com", Naam = "Harry", Telefoonnummer = "0682377382" },
                Studiefase = new StudiefaseViewModel() { Fase = "Propedeuse", Periode = new PeriodeViewModel() { PeriodeNummer = 4 } },
                VerplichtVoor = new List<SpecialisatieViewModel>() { },
                AanbevolenVoor = new List<SpecialisatieViewModel>() { },
                BeschrijvingLeerdoelen = "Leerdoelen",
                InhoudelijkeBeschrijving = "Inhoud",
                Eindeisen = "Eindeisen",
                ContacturenWerkvormen = "contacturen",
                Toetsvorm = "rond",
                VoorwaardenVoldoende = "voorwaarden",
                LetOp = "pas op hoor!!1!",
                Summatief = true,
                Formatief = false,
                Kwalitatief = true,
                Kwantitatief = true,
                Examinatoren = "Bas"
                
            };
            service.AddModule(mod);

            // Assert 
            Assert.AreEqual(moduleCountBefore + 1, context.Modules.Count());
        }

        [TestMethod]
        public void TestIfAfterAddModuleCanLookUpTheModuleByModuleCode()
        {
            // Arrange
            using var context = new ModuleContext(_options);
            IModuleService service = new ModuleService(context);

            // Act
            var moduleCountBefore = context.Modules.Count();
            var mod = new ModuleViewModel()
            {
                ModuleNaam = "naampie",
                ModuleCode = "code123",
                AantalEc = 2,
                Studiejaar = "Jaar 4",
                Moduleleider = new ModuleleiderViewModel() { Email = "nmfuashf@xdd.com", Naam = "Harry", Telefoonnummer = "0682377382" },
                Studiefase = new StudiefaseViewModel() { Fase = "Propedeuse", Periode = new PeriodeViewModel() { PeriodeNummer = 4 } },
                VerplichtVoor = new List<SpecialisatieViewModel>() { },
                AanbevolenVoor = new List<SpecialisatieViewModel>() { },
                BeschrijvingLeerdoelen = "Leerdoelen",
                InhoudelijkeBeschrijving = "Inhoud",
                Eindeisen = "Eindeisen",
                ContacturenWerkvormen = "contacturen",
                Toetsvorm = "rond",
                VoorwaardenVoldoende = "voorwaarden",
                LetOp = "pas op hoor!!1!",
                Summatief = true,
                Formatief = false,
                Kwalitatief = true,
                Kwantitatief = true,
                Examinatoren = "Bas"

            };
            service.AddModule(mod);
            var retrievedModule = service.GetByModuleCode("code123");
            // Assert 
            Assert.AreEqual("naampie", retrievedModule.ModuleNaam);
        }

        [TestMethod]
        public void TestIfAddModuleFailsWhenDuplicateModuleCode()
        {
            // Arrange
            using var context = new ModuleContext(_options);
            IModuleService service = new ModuleService(context);

            // Act
            var moduleCountBefore = context.Modules.Count();
            var mod1 = new ModuleViewModel()
            {
                ModuleNaam = "naampie",
                ModuleCode = "code1234",
                AantalEc = 2,
                Studiejaar = "Jaar 4",
                Moduleleider = new ModuleleiderViewModel() { Email = "nmfuashf@xdd.com", Naam = "Harry", Telefoonnummer = "0682377382" },
                Studiefase = new StudiefaseViewModel() { Fase = "Propedeuse", Periode = new PeriodeViewModel() { PeriodeNummer = 4 } },
                VerplichtVoor = new List<SpecialisatieViewModel>() { },
                AanbevolenVoor = new List<SpecialisatieViewModel>() { },
                BeschrijvingLeerdoelen = "Leerdoelen",
                InhoudelijkeBeschrijving = "Inhoud",
                Eindeisen = "Eindeisen",
                ContacturenWerkvormen = "contacturen",
                Toetsvorm = "rond",
                VoorwaardenVoldoende = "voorwaarden",
                LetOp = "pas op hoor!!1!",
                Summatief = true,
                Formatief = false,
                Kwalitatief = true,
                Kwantitatief = true,
                Examinatoren = "Bas"

            };
            service.AddModule(mod1);

            var mod2 = new ModuleViewModel()
            {
                ModuleNaam = "AnderNaampieZelfdeCode",
                ModuleCode = "code1234",
                AantalEc = 2,
                Studiejaar = "Jaar 4",
                Moduleleider = new ModuleleiderViewModel() { Email = "nmfuashf@xdd.com", Naam = "Harry", Telefoonnummer = "0682377382" },
                Studiefase = new StudiefaseViewModel() { Fase = "Propedeuse", Periode = new PeriodeViewModel() { PeriodeNummer = 4 } },
                VerplichtVoor = new List<SpecialisatieViewModel>() { },
                AanbevolenVoor = new List<SpecialisatieViewModel>() { },
                BeschrijvingLeerdoelen = "Leerdoelen",
                InhoudelijkeBeschrijving = "Inhoud",
                Eindeisen = "Eindeisen",
                ContacturenWerkvormen = "contacturen",
                Toetsvorm = "rond",
                VoorwaardenVoldoende = "voorwaarden",
                LetOp = "pas op hoor!!1!",
                Summatief = true,
                Formatief = false,
                Kwalitatief = true,
                Kwantitatief = true,
                Examinatoren = "Bas"

            };

            // Assert 
            Assert.ThrowsException<AlreadyExistsException>(() =>
           {
               service.AddModule(mod2);
           });
        }
    }
}
