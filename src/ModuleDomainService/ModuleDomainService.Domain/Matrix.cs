using System.Collections.Generic;

namespace ModuleDomainService.Domain
{
    public class Matrix
    {
        public IEnumerable<string> Rows { get; set; }
        public IEnumerable<string> Columns { get; set; }
        public int[][] AdjacencyMatrix { get; set; }
    }
}