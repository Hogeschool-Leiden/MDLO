using CsvHelper;
using ModuleFrontend.Api.DAL;
using ModuleFrontend.Api.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;

namespace ModuleFrontend.Api.Utility
{
    public class CsvLoader
    {
        private readonly ModuleContext _context;
        public CsvLoader()
        {
           
        }

        public void LoadFromCsv(string filePath)
        {
            List<Module> modules = new List<Module>() { };
            using (var reader = new StreamReader(filePath))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                csv.Configuration.Delimiter = ";";
                csv.Configuration.BadDataFound = (context) => { Console.WriteLine($"Error:{context.CurrentIndex} "); };
                var records = csv.GetRecords<ModuleFromCsv>();

                foreach (var item in records)
                {
                    modules.Add(new Module() 
                    {
                        ModuleCode = item.ModuleCode,
                        ModuleNaam = item.ModuleNaam,
                        
                    });
                }
            }
        }
    }
}
