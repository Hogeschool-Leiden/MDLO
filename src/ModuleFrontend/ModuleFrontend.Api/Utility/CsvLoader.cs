using CsvHelper;
using ModuleFrontend.Api.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;

namespace ModuleFrontend.Api.Utility
{
    public class CsvLoader : ICsvLoader
    {
        public CsvLoader()
        {
        }

        public IEnumerable<Module> ReadFromStream(Stream stream)
        {
            List<Module> modules = new List<Module>();
            using (var reader = new StreamReader(stream))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                csv.Configuration.Delimiter = ";";
                csv.Configuration.BadDataFound = (context) => { Console.WriteLine($"Error:{context.CurrentIndex} "); };
                var records = csv.GetRecords<ModuleFromCsv>();
                
                foreach (var item in records)
                {
                    var periodes = new List<int>();
                    var fase = "Propedeuse";
                    var verplichtVoor = new List<Specialisatie>();

                    if (item.Allen.ToLower() == "v")
                    {
                        verplichtVoor.Add(new Specialisatie(){Code = "SE", Naam= "Software Engineering"});
                        verplichtVoor.Add(new Specialisatie(){Code = "FICT", Naam= "Forensiche ICT"});
                        verplichtVoor.Add(new Specialisatie(){Code = "IAT", Naam= "Interactie Technologie"});
                        verplichtVoor.Add(new Specialisatie(){Code = "BDAM", Naam= "Business Data Management"});
                    }

                    if (item.Allen.ToLower() == "k")
                    {
                        verplichtVoor.Add(new Specialisatie(){Code = "K", Naam= "Keuzevak"});
                    }

                    if (item.SE.ToLower() == "v")
                    {
                        verplichtVoor.Add(new Specialisatie(){Code = "SE", Naam= "Software Engineering"});
                    }

                    if (item.FICT.ToLower() == "v")
                    {
                        verplichtVoor.Add(new Specialisatie(){Code = "FICT", Naam= "Forensiche ICT"});
                    }

                    if (item.IAT.ToLower() == "v")
                    {
                        verplichtVoor.Add(new Specialisatie(){Code = "IAT", Naam= "Interactie Technologie"});
                    }

                    if (item.BDAM.ToLower() == "v")
                    {
                        verplichtVoor.Add(new Specialisatie(){Code = "BDAM", Naam= "Business Data Management"});
                    }
                    
                    if (item.Jaar != 1)
                    {
                        fase = "Hoofdfase";
                    }

                    if (item.Periode1)
                    {
                        periodes.Add(1);
                    }
                    if (item.Periode2)
                    {
                        periodes.Add(2);
                    }
                    if (item.Periode3)
                    {
                        periodes.Add(3);
                    }
                    if (item.Periode4)
                    {
                        periodes.Add(4);
                    }
                    Matrix mtx = new Matrix();
                    mtx.xHeaders = new List<string>()
                    {
                        "gebruikersinteractie", "organisatieprocessen", "infrastructuur", "software",
                        "hardware interfacing"
                    };
                    mtx.yHeaders = new List<string>()
                        {"analyseren", "adviseren", "ontwerpen", "realiseren", "manage&control"};
                    mtx.Cells = new int[5][];
                    for (int i = 0; i < mtx.Cells.Length; i++)
                    {
                        mtx.Cells[i] = new int[5];
                    }
                    mtx.Cells[0][0] = convertToInt(item.GIAN);
                    mtx.Cells[0][1] = convertToInt(item.GIAD);
                    mtx.Cells[0][2] = convertToInt(item.GION);
                    mtx.Cells[0][3] = convertToInt(item.GIRE);
                    mtx.Cells[0][4] = convertToInt(item.GIBE);

                    mtx.Cells[1][0] = convertToInt(item.BPAN);
                    mtx.Cells[1][1] = convertToInt(item.BPAD);
                    mtx.Cells[1][2] = convertToInt(item.BPON);
                    mtx.Cells[1][3] = convertToInt(item.BPRE);
                    mtx.Cells[1][4] = convertToInt(item.BPBE);

                    mtx.Cells[2][0] = convertToInt(item.ISAN);
                    mtx.Cells[2][1] = convertToInt(item.ISAD);
                    mtx.Cells[2][2] = convertToInt(item.ISON);
                    mtx.Cells[2][3] = convertToInt(item.ISRE);
                    mtx.Cells[2][4] = convertToInt(item.ISBE);

                    mtx.Cells[3][0] = convertToInt(item.SWAN);
                    mtx.Cells[3][1] = convertToInt(item.SWAD);
                    mtx.Cells[3][2] = convertToInt(item.SWON);
                    mtx.Cells[3][3] = convertToInt(item.SWRE);
                    mtx.Cells[3][4] = convertToInt(item.SWBE);

                    mtx.Cells[4][0] = convertToInt(item.HIAN);
                    mtx.Cells[4][1] = convertToInt(item.HIAD);
                    mtx.Cells[4][2] = convertToInt(item.HION);
                    mtx.Cells[4][3] = convertToInt(item.HIRE);
                    mtx.Cells[4][4] = convertToInt(item.HIBE);

                    Module module = new Module()
                    {
                        ModuleCode = item.ModuleCode,
                        ModuleNaam = item.ModuleNaam,
                        AantalEc = item.Ec,
                        Studiejaar = $"{item.Jaar}",
                        Studiefase = new Studiefase(){Fase = fase, Perioden = periodes},
                        VerplichtVoor = verplichtVoor,
                        Competenties = mtx
                    };
                    modules.Add(module);
                }
            }
            return modules;
        }

        private int convertToInt(string item)
        {
            if (String.IsNullOrEmpty(item))
            {
                return 0;
            }

            return Convert.ToInt32(item);
        }
    }
}
