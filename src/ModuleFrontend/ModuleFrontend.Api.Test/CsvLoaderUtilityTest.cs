using System.Collections.Generic;
using System.IO;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ModuleFrontend.Api.Models;
using ModuleFrontend.Api.Utility;

namespace ModuleFrontend.Api.Test
{
    [TestClass]
    public class CsvLoaderUtilityTest
    {
        private static string file1 = "TestData/testdata1.csv";
        private static string file2 = "TestData/testdata2.csv";
        private static string file3 = "TestData/testdata3.csv";
        [TestMethod]
        public void File1Creates7Rows()
        {
            ICsvLoader loader = new CsvLoader();
            using (FileStream fs = File.OpenRead(file1))
            {
                IEnumerable<Module> results = loader.ReadFromStream(fs);
                Assert.AreEqual(7, results.Count());
            }
        }
        [TestMethod]
        public void All7RowsHaveCorrectNames()
        {
            ICsvLoader loader = new CsvLoader();
            using (FileStream fs = File.OpenRead(file1))
            {
                IEnumerable<Module> results = loader.ReadFromStream(fs);
                Assert.IsTrue(results.Any(m => m.ModuleCode=="iarch"));
                Assert.IsTrue(results.Any(m => m.ModuleCode=="ibdw"));
                Assert.IsTrue(results.Any(m => m.ModuleCode=="ibk5"));
                Assert.IsTrue(results.Any(m => m.ModuleCode=="icomas"));
                Assert.IsTrue(results.Any(m => m.ModuleCode=="icommha"));
                Assert.IsTrue(results.Any(m => m.ModuleCode=="icommpr"));
                Assert.IsTrue(results.Any(m => m.ModuleCode=="icpt"));

            }
        }
        
        [TestMethod]
        public void iarchIsVerplichtVoorAlleSpecialisaties()
        {
            ICsvLoader loader = new CsvLoader();
            using (FileStream fs = File.OpenRead(file1))
            {
                IEnumerable<Module> results = loader.ReadFromStream(fs);
                Assert.IsTrue(results.Any(m => m.ModuleCode=="iarch"));
                var verplichtVoor = results.Where(m => m.ModuleCode == "iarch").First().VerplichtVoor;
                Assert.IsTrue(verplichtVoor.Any(m => m.Code == "SE"));
                Assert.IsTrue(verplichtVoor.Any(m => m.Code == "FICT"));
                Assert.IsTrue(verplichtVoor.Any(m => m.Code == "BDAM"));
                Assert.IsTrue(verplichtVoor.Any(m => m.Code == "IAT"));
            }
        }
        [TestMethod]
        public void File2Creates3Rows()
        {
            ICsvLoader loader = new CsvLoader();
            using (FileStream fs = File.OpenRead(file2))
            {
                IEnumerable<Module> results = loader.ReadFromStream(fs);
                Assert.AreEqual(3, results.Count());
            }
        }
        [TestMethod]
        public void File3Creates4Rows()
        {
            ICsvLoader loader = new CsvLoader();
            using (FileStream fs = File.OpenRead(file3))
            {
                IEnumerable<Module> results = loader.ReadFromStream(fs);
                Assert.AreEqual(2, results.Count());
            }
        }
    }
}