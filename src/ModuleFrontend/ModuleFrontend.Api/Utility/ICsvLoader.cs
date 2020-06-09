using System.Collections.Generic;
using System.IO;
using ModuleFrontend.Api.Models;

namespace ModuleFrontend.Api.Utility
{
    public interface ICsvLoader
    {
        public IEnumerable<Module> ReadFromStream(Stream stream);
    }
}