using System.Collections.Generic;
using System.Linq;
using CompetentieAppFrontend.Domain;
using CompetentieAppFrontend.Infrastructure.DAL;
using CompetentieAppFrontend.Infrastructure.Repositories;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;

namespace CompetentieAppFrontend.Infrastructure.Test
{
    [TestClass]
    public class MatrixRepositoryTest
    {
        private const string DATA_SOURCE = "DataSource=:memory:";
        private static SqliteConnection _connection;
        private static DbContextOptions<CompetentieAppFrontendContext> _options;

        [ClassInitialize]
        public static void ClassInitialize(TestContext tc)
        {
            _connection = new SqliteConnection(DATA_SOURCE);
            _connection.Open();
            _options = new DbContextOptionsBuilder<CompetentieAppFrontendContext>()
                .UseSqlite(_connection).Options;

            using var context = new CompetentieAppFrontendContext(_options);
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
            using var context = new CompetentieAppFrontendContext(_options);
            context.Set<Module>().RemoveRange(context.Set<Module>());
            context.SaveChanges();
            LoadData();
        }

        [TestMethod]
        public void GetCompetentieMatrix_Should_Return_Typeof_IEnumerable_Of_Competentie()
        {
            // Arrange
            using var context = new CompetentieAppFrontendContext(_options);
            var repository = new MatrixRepository(context);

            // Act
            var result = repository.GetCompetentieMatrix(1, "Properdeuse");

            var stuff = result.ToList();

            // Assert
            Assert.IsInstanceOfType(result, typeof(IEnumerable<MatrixCell>));
        }

        private static void LoadData()
        {
            using var context = new CompetentieAppFrontendContext(_options);

            context.Activiteiten
                .AddRange(new[]
                {
                    new Activiteit
                    {
                        Id = 1,
                        ActiviteitNaam = "analyseren"
                    },
                    new Activiteit
                    {
                        Id = 2,
                        ActiviteitNaam = "adviseren"
                    },
                    new Activiteit
                    {
                        Id = 3,
                        ActiviteitNaam = "ontwerpen"
                    },
                    new Activiteit
                    {
                        Id = 4,
                        ActiviteitNaam = "realiseren"
                    },
                    new Activiteit
                    {
                        Id = 5,
                        ActiviteitNaam = "manage & control"
                    }
                });

            context.ArchitectuurLagen
                .AddRange(new[]
                {
                    new ArchitectuurLaag
                    {
                        Id = 1,
                        ArchitectuurLaagNaam = "gebruikersinteractie"
                    },
                    new ArchitectuurLaag
                    {
                        Id = 2,
                        ArchitectuurLaagNaam = "organisatieprocessen"
                    },
                    new ArchitectuurLaag
                    {
                        Id = 3,
                        ArchitectuurLaagNaam = "infrastructuur"
                    },
                    new ArchitectuurLaag
                    {
                        Id = 4,
                        ArchitectuurLaagNaam = "software"
                    },
                    new ArchitectuurLaag
                    {
                        Id = 5,
                        ArchitectuurLaagNaam = "hardware interfacing"
                    }
                });

            context.Specialisaties
                .AddRange(new[]
                {
                    new Specialisatie
                    {
                        Id = 1,
                        SpecialisatieNaam = "Properdeuse"
                    },
                    new Specialisatie
                    {
                        Id = 2,
                        SpecialisatieNaam = "Interactie technologie"
                    },
                    new Specialisatie
                    {
                        Id = 3,
                        SpecialisatieNaam = "Software engineering"
                    },
                    new Specialisatie
                    {
                        Id = 4,
                        SpecialisatieNaam = "Forensische ICT"
                    }
                });

            context.Perioden
                .AddRange(new[]
                {
                    new Periode
                    {
                        Id = 1,
                        PeriodeNummer = 1
                    },
                    new Periode
                    {
                        Id = 2,
                        PeriodeNummer = 2
                    },
                    new Periode
                    {
                        Id = 3,
                        PeriodeNummer = 3
                    },
                    new Periode
                    {
                        Id = 4,
                        PeriodeNummer = 4
                    }
                });

            context.BeheersingsNiveaus
                .AddRange(new[]
                {
                    new BeheersingsNiveau
                    {
                        ArchitectuurLaagId = 1,
                        ActiviteitId = 1,
                        Niveau = 0
                    },
                    new BeheersingsNiveau
                    {
                        ArchitectuurLaagId = 1,
                        ActiviteitId = 2,
                        Niveau = 0
                    },
                    new BeheersingsNiveau
                    {
                        ArchitectuurLaagId = 1,
                        ActiviteitId = 3,
                        Niveau = 0
                    },
                    new BeheersingsNiveau
                    {
                        ArchitectuurLaagId = 1,
                        ActiviteitId = 4,
                        Niveau = 0
                    },
                    new BeheersingsNiveau
                    {
                        ArchitectuurLaagId = 1,
                        ActiviteitId = 5,
                        Niveau = 0
                    }
                });

            context.BeheersingsNiveaus
                .AddRange(new[]
                {
                    new BeheersingsNiveau
                    {
                        ArchitectuurLaagId = 2,
                        ActiviteitId = 1,
                        Niveau = 0
                    },
                    new BeheersingsNiveau
                    {
                        ArchitectuurLaagId = 2,
                        ActiviteitId = 2,
                        Niveau = 0
                    },
                    new BeheersingsNiveau
                    {
                        ArchitectuurLaagId = 2,
                        ActiviteitId = 3,
                        Niveau = 0
                    },
                    new BeheersingsNiveau
                    {
                        ArchitectuurLaagId = 2,
                        ActiviteitId = 4,
                        Niveau = 0
                    },
                    new BeheersingsNiveau
                    {
                        ArchitectuurLaagId = 2,
                        ActiviteitId = 5,
                        Niveau = 0
                    }
                });

            context.BeheersingsNiveaus
                .AddRange(new[]
                {
                    new BeheersingsNiveau
                    {
                        ArchitectuurLaagId = 3,
                        ActiviteitId = 1,
                        Niveau = 0
                    },
                    new BeheersingsNiveau
                    {
                        ArchitectuurLaagId = 3,
                        ActiviteitId = 2,
                        Niveau = 0
                    },
                    new BeheersingsNiveau
                    {
                        ArchitectuurLaagId = 3,
                        ActiviteitId = 3,
                        Niveau = 0
                    },
                    new BeheersingsNiveau
                    {
                        ArchitectuurLaagId = 3,
                        ActiviteitId = 4,
                        Niveau = 0
                    },
                    new BeheersingsNiveau
                    {
                        ArchitectuurLaagId = 3,
                        ActiviteitId = 5,
                        Niveau = 0
                    }
                });

            context.BeheersingsNiveaus
                .AddRange(new[]
                {
                    new BeheersingsNiveau
                    {
                        ArchitectuurLaagId = 4,
                        ActiviteitId = 1,
                        Niveau = 0
                    },
                    new BeheersingsNiveau
                    {
                        ArchitectuurLaagId = 4,
                        ActiviteitId = 2,
                        Niveau = 0
                    },
                    new BeheersingsNiveau
                    {
                        ArchitectuurLaagId = 4,
                        ActiviteitId = 3,
                        Niveau = 0
                    },
                    new BeheersingsNiveau
                    {
                        ArchitectuurLaagId = 4,
                        ActiviteitId = 4,
                        Niveau = 0
                    },
                    new BeheersingsNiveau
                    {
                        ArchitectuurLaagId = 4,
                        ActiviteitId = 5,
                        Niveau = 0
                    }
                });

            context.BeheersingsNiveaus
                .AddRange(new[]
                {
                    new BeheersingsNiveau
                    {
                        ArchitectuurLaagId = 5,
                        ActiviteitId = 1,
                        Niveau = 0
                    },
                    new BeheersingsNiveau
                    {
                        ArchitectuurLaagId = 5,
                        ActiviteitId = 2,
                        Niveau = 0
                    },
                    new BeheersingsNiveau
                    {
                        ArchitectuurLaagId = 5,
                        ActiviteitId = 3,
                        Niveau = 0
                    },
                    new BeheersingsNiveau
                    {
                        ArchitectuurLaagId = 5,
                        ActiviteitId = 4,
                        Niveau = 0
                    },
                    new BeheersingsNiveau
                    {
                        ArchitectuurLaagId = 5,
                        ActiviteitId = 5,
                        Niveau = 0
                    }
                });

            context.Modules
                .AddRange(new[]
                {
                    new Module
                    {
                        Id = 1,
                        ModuleCode = "IPRWC",
                        ModuleNaam = "Programeren in de webcontext",
                        Studiepunten = 3
                    },
                    new Module
                    {
                        Id = 2,
                        ModuleCode = "IOOPR",
                        ModuleNaam = "Object georienteerd programeren",
                        Studiepunten = 3
                    }
                });

            context.Studiefasen
                .AddRange(new[]
                {
                    new Studiefase
                    {
                        ModuleId = 1,
                        PeriodeId = 2,
                        SpecialisatieId = 3
                    },
                    new Studiefase
                    {
                        ModuleId = 2,
                        PeriodeId = 1,
                        SpecialisatieId = 1
                    }
                });

            context.Competenties
                .AddRange(new[]
                {
                    new Competentie
                    {
                        ModuleId = 2,
                        BeheersingsNiveauId = 1
                    },
                    new Competentie
                    {
                        ModuleId = 2,
                        BeheersingsNiveauId = 2
                    },
                    new Competentie
                    {
                        ModuleId = 2,
                        BeheersingsNiveauId = 3
                    },
                    new Competentie
                    {
                        ModuleId = 2,
                        BeheersingsNiveauId = 4
                    },
                    new Competentie
                    {
                        ModuleId = 2,
                        BeheersingsNiveauId = 5
                    },
                });

            context.SaveChanges();
        }
    }
}