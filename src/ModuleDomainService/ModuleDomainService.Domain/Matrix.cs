using System.Collections.Generic;

namespace ModuleDomainService.Domain
{
    public class Matrix
    {
        public List<string> xHeaders{ get; set; }
        public List<string> yHeaders { get; set; }
        public int[][] Cells { get; set; }
    }
}
