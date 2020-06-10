using CsvHelper.Configuration.Attributes;

namespace ModuleFrontend.Api.Utility
{
    public class ModuleFromCsv
    {
        [Name("Naam")]
        public string ModuleCode { get; set; }
        [Name("Omschrijving")]
        public string ModuleNaam { get; set; }
        [Name("EC")]
        public int Ec { get; set; }
        [Optional]
        [Name("Allen")]
        public string Allen { get; set; }
        [Name("FICT")]
        [Optional]
        public string FICT { get; set; }
        [Name("SE")]
        [Optional]
        public string SE { get; set; }
        [Name("IAT")]
        [Optional]
        public string IAT { get; set; }
        [Name("BDAM")]
        [Optional]
        public string BDAM { get; set; }
        [Name("Jaar")]
        [Optional]
        public int Jaar { get; set; }
        [Name("per1")]
        [Optional]
        public bool Periode1 { get; set; }
        [Name("per2")]
        [Optional]
        public bool Periode2 { get; set; }
        [Name("per3")]
        [Optional]
        public bool Periode3 { get; set; }
        [Name("per4")]
        [Optional]
        public bool Periode4 { get; set; }
        [Name("GI-BE")]
        [Optional]
        public string GIBE { get; set; }
        [Name("GI-AN")]
        [Optional]
        public string GIAN { get; set; }
        [Name("GI-AD")]
        [Optional]
        public string GIAD { get; set; }
        [Name("GI-ON")]
        [Optional]
        public string GION { get; set; }
        [Name("GI-RE")]
        [Optional]
        public string GIRE { get; set; }

        [Name("BP-BE")]
        [Optional]
        public string BPBE { get; set; }
        [Name("BP-AN")]
        [Optional]
        public string BPAN { get; set; }
        [Name("BP-AD")]
        [Optional]
        public string BPAD { get; set; }
        [Name("BP-ON")]
        [Optional]
        public string BPON { get; set; }
        [Name("BP-RE")]
        [Optional]
        public string BPRE { get; set; }

        [Name("IS-BE")]
        [Optional]
        public string ISBE { get; set; }
        [Name("IS-AN")]
        [Optional]
        public string ISAN { get; set; }
        [Name("IS-AD")]
        [Optional]
        public string ISAD { get; set; }
        [Name("IS-ON")]
        [Optional]
        public string ISON { get; set; }
        [Name("IS-RE")]
        [Optional]
        public string ISRE { get; set; }

        [Name("SW-BE")]
        [Optional]
        public string SWBE { get; set; }
        [Name("SW-AN")]
        [Optional]
        public string SWAN { get; set; }
        [Name("SW-AD")]
        [Optional]
        public string SWAD { get; set; }
        [Name("SW-ON")]
        [Optional]
        public string SWON { get; set; }
        [Name("SW-RE")]
        [Optional]
        public string SWRE { get; set; }

        [Name("HI-BE")]
        [Optional]
        public string HIBE { get; set; }
        [Name("HI-AN")]
        [Optional]
        public string HIAN { get; set; }
        [Name("HI-AD")]
        [Optional]
        public string HIAD { get; set; }
        [Name("HI-ON")]
        [Optional]
        public string HION { get; set; }
        [Name("HI-RE")]
        [Optional]
        public string HIRE { get; set; }
    }
}
