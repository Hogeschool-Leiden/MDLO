using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace ModuleFrontend.Api.Models
{
    [ExcludeFromCodeCoverage]
    public class Matrix
    {
        public List<string> xHeaders{ get; set; }
        public List<string> yHeaders { get; set; }
        public int[][] Cells { get; set; }
    }
}
