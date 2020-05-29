using System.Linq;
using CompetentieAppFrontend.Domain;

namespace CompetentieAppFrontend.Infrastructure.DAL
{
    public static class Seeding
    {
        public static void EnsureDataSeeded(this CompetentieAppFrontendContext context)
        {
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
                        SpecialisatieNaam = "Propedeuse"
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
                        Id = 1,
                        ArchitectuurLaagId = 1,
                        ActiviteitId = 1,
                        Niveau = 1
                    },
                    new BeheersingsNiveau
                    {
                        Id = 2,
                        ArchitectuurLaagId = 1,
                        ActiviteitId = 2,
                        Niveau = 1
                    },
                    new BeheersingsNiveau
                    {
                        Id = 3,
                        ArchitectuurLaagId = 1,
                        ActiviteitId = 3,
                        Niveau = 1
                    },
                    new BeheersingsNiveau
                    {
                        Id = 4,
                        ArchitectuurLaagId = 1,
                        ActiviteitId = 4,
                        Niveau = 1
                    },
                    new BeheersingsNiveau
                    {
                        Id = 5,
                        ArchitectuurLaagId = 1,
                        ActiviteitId = 5,
                        Niveau = 1
                    }
                });

            context.BeheersingsNiveaus
                .AddRange(new[]
                {
                    new BeheersingsNiveau
                    {
                        Id = 6,
                        ArchitectuurLaagId = 2,
                        ActiviteitId = 1,
                        Niveau = 1
                    },
                    new BeheersingsNiveau
                    {
                        Id = 7,
                        ArchitectuurLaagId = 2,
                        ActiviteitId = 2,
                        Niveau = 1
                    },
                    new BeheersingsNiveau
                    {
                        Id = 8,
                        ArchitectuurLaagId = 2,
                        ActiviteitId = 3,
                        Niveau = 1
                    },
                    new BeheersingsNiveau
                    {
                        Id = 9,
                        ArchitectuurLaagId = 2,
                        ActiviteitId = 4,
                        Niveau = 1
                    },
                    new BeheersingsNiveau
                    {
                        Id = 10, 
                        ArchitectuurLaagId = 2,
                        ActiviteitId = 5,
                        Niveau = 1
                    }
                });

            context.BeheersingsNiveaus
                .AddRange(new[]
                {
                    new BeheersingsNiveau
                    {
                        Id = 11,
                        ArchitectuurLaagId = 3,
                        ActiviteitId = 1,
                        Niveau = 1
                    },
                    new BeheersingsNiveau
                    {
                        Id = 12,
                        ArchitectuurLaagId = 3,
                        ActiviteitId = 2,
                        Niveau = 1
                    },
                    new BeheersingsNiveau
                    {
                        Id = 13,
                        ArchitectuurLaagId = 3,
                        ActiviteitId = 3,
                        Niveau = 1
                    },
                    new BeheersingsNiveau
                    {
                        Id = 14,
                        ArchitectuurLaagId = 3,
                        ActiviteitId = 4,
                        Niveau = 1
                    },
                    new BeheersingsNiveau
                    {
                        Id = 15,
                        ArchitectuurLaagId = 3,
                        ActiviteitId = 5,
                        Niveau = 1
                    }
                });

            context.BeheersingsNiveaus
                .AddRange(new[]
                {
                    new BeheersingsNiveau
                    {
                        Id = 16,
                        ArchitectuurLaagId = 4,
                        ActiviteitId = 1,
                        Niveau = 1
                    },
                    new BeheersingsNiveau
                    {
                        Id = 17,
                        ArchitectuurLaagId = 4,
                        ActiviteitId = 2,
                        Niveau = 1
                    },
                    new BeheersingsNiveau
                    {
                        Id = 18,
                        ArchitectuurLaagId = 4,
                        ActiviteitId = 3,
                        Niveau = 1
                    },
                    new BeheersingsNiveau
                    {
                        Id = 19,
                        ArchitectuurLaagId = 4,
                        ActiviteitId = 4,
                        Niveau = 1
                    },
                    new BeheersingsNiveau
                    {
                        Id = 20,
                        ArchitectuurLaagId = 4,
                        ActiviteitId = 5,
                        Niveau = 1
                    }
                });
            
            context.BeheersingsNiveaus
                .AddRange(new[]
                {
                    new BeheersingsNiveau
                    {
                        Id = 21,
                        ArchitectuurLaagId = 5,
                        ActiviteitId = 1,
                        Niveau = 1
                    },
                    new BeheersingsNiveau
                    {
                        Id = 22,
                        ArchitectuurLaagId = 5,
                        ActiviteitId = 2,
                        Niveau = 1
                    },
                    new BeheersingsNiveau
                    {
                        Id = 23,
                        ArchitectuurLaagId = 5,
                        ActiviteitId = 3,
                        Niveau = 1
                    },
                    new BeheersingsNiveau
                    {
                        Id = 24,
                        ArchitectuurLaagId = 5,
                        ActiviteitId = 4,
                        Niveau = 1
                    },
                    new BeheersingsNiveau
                    {
                        Id = 25,
                        ArchitectuurLaagId = 5,
                        ActiviteitId = 5,
                        Niveau = 1
                    }
                });
            
            context.BeheersingsNiveaus
                .AddRange(new[]
                {
                    new BeheersingsNiveau
                    {
                        Id = 26,
                        ArchitectuurLaagId = 1,
                        ActiviteitId = 1,
                        Niveau = 3
                    },
                    new BeheersingsNiveau
                    {
                        Id = 27,
                        ArchitectuurLaagId = 1,
                        ActiviteitId = 2,
                        Niveau = 3
                    },
                    new BeheersingsNiveau
                    {
                        Id = 28,
                        ArchitectuurLaagId = 1,
                        ActiviteitId = 3,
                        Niveau = 3
                    },
                    new BeheersingsNiveau
                    {
                        Id = 29,
                        ArchitectuurLaagId = 1,
                        ActiviteitId = 4,
                        Niveau = 3
                    },
                    new BeheersingsNiveau
                    {
                        Id = 30,
                        ArchitectuurLaagId = 1,
                        ActiviteitId = 5,
                        Niveau = 3
                    }
                });

            context.Modules
                .AddRange(new[]
                {
                    new Module
                    {
                        Id = 1,
                        ModuleCode = "IOPR",
                        ModuleNaam = "Object georienteerd programeren",
                        Studiepunten = 3
                    },
                    new Module
                    {
                        Id = 2,
                        ModuleCode = "IOPR2",
                        ModuleNaam = "Object georienteerd programeren 2",
                        Studiepunten = 3
                    },
                    new Module
                    {
                        Id = 3,
                        ModuleCode = "IUML",
                        ModuleNaam = "UML",
                        Studiepunten = 3
                    }
                });

            context.Studiefasen
                .AddRange(new[]
                {
                    new Studiefase
                    {
                        ModuleId = 1,
                        PeriodeId = 1,
                        SpecialisatieId = 1
                    },
                    new Studiefase
                    {
                        ModuleId = 2,
                        PeriodeId = 3,
                        SpecialisatieId = 1
                    },
                    new Studiefase
                    {
                        ModuleId = 3,
                        PeriodeId = 1,
                        SpecialisatieId = 1
                    }
                });

            context.Competenties
                .AddRange(new[]
                {
                    new Competentie
                    {
                        ModuleId = 1,
                        BeheersingsNiveauId = 1
                    },
                    new Competentie
                    {
                        ModuleId = 1,
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
                        ModuleId = 3,
                        BeheersingsNiveauId = 26
                    }
                });

            context.AddRange(new[]
            {
                new Eindeis
                {
                    Id = 1,
                    ModuleId = 1,
                    EindeisBeschrijving = "Deze module is erg moeilijk."
                },
                new Eindeis
                {
                    Id = 2,
                    ModuleId = 1,
                    EindeisBeschrijving = "Het is onmogelijk deze module te halen."
                }
            });

            context.SaveChanges();
        }
    }
}