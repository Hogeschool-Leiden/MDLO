using System.Collections.Generic;

namespace ModuleDomainService.Domain
{
    public class Matrix
    {
        public List<string> XHeaders{ get; set; }
        public List<string> YHeaders { get; set; }
        public int[][] Cells { get; set; }
    }
}
