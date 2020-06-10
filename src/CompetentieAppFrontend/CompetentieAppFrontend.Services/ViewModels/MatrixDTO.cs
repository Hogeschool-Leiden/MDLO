using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using CompetentieAppFrontend.Services.Projections;

namespace CompetentieAppFrontend.Services.ViewModels
{
    [ExcludeFromCodeCoverage]
    public class MatrixDTO
    {
        public IEnumerable<string> XHeaders { get; set; }
        public IEnumerable<string> YHeaders { get; set; }
        public int[][] Cells { get; set; }

        public Cell<int>[][] ConvertToCells()
        {
            var cells = new Cell<int>[XHeaders.Count()][];
            for (var i = 0; i < XHeaders.Count(); i++)
            {
                cells[i] = new Cell<int>[YHeaders.Count()];
                for (var j = 0; j < YHeaders.Count(); j++)
                {
                    cells[i][j] = new Cell<int>(Cells[i][j]);
                }
            }

            return cells;
        }

        public Matrix<int> ToMatrix()
        {
            return new Matrix<int>
            {
                XHeaders = XHeaders.ToList(),
                YHeaders = YHeaders.ToList(),
                Cells = ConvertToCells()
            };
        }
    }
}