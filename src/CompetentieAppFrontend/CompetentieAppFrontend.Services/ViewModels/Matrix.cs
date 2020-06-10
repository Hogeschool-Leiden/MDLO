using System.Collections.Generic;
using CompetentieAppFrontend.Services.Abstractions;
using CompetentieAppFrontend.Services.Projections;

namespace CompetentieAppFrontend.Services.ViewModels
{
    public class Matrix<TValue>
    {
        public Matrix()
        {
            XHeaders = new List<string>();
            YHeaders = new List<string>();
            Cells = new Cell<TValue>[0][];
        }

        private Matrix(int xHeaderCount, int yHeaderCount)
        {
            Cells = new Cell<TValue>[xHeaderCount, yHeaderCount].ToJaggedArray();
        }

        private Matrix(IList<string> xHeaders, IList<string> yHeaders) : this(
            xHeaders.Count,
            yHeaders.Count)
        {
            XHeaders = xHeaders;
            YHeaders = yHeaders;
        }

        public Matrix(IList<string> xHeaders,
            IList<string> yHeaders,
            IEnumerable<IMatrixable<TValue>> items) :
            this(xHeaders, yHeaders)
        {
            foreach (var item in items)
            {
                var xHeaderIndex = XHeaders.IndexOf(item.XHeader);
                var yHeaderIndex = YHeaders.IndexOf(item.YHeader);
                Cells[xHeaderIndex][yHeaderIndex] = new Cell<TValue>(item.Value);
            }
        }

        public IList<string> XHeaders { get; set; }

        public IList<string> YHeaders { get; set; }

        public Cell<TValue>[][] Cells { get; set; }

        public TValue ValueAt(string xHeader, string yHeader) =>
            Cells[XHeaders.IndexOf(xHeader)][YHeaders.IndexOf(yHeader)].Value;
    }
}