using System.Collections.Generic;

namespace CompetentieAppFrontend.Services
{
    public class Matrix<TValue>
    {
        private readonly Cell<TValue>[,] _cells;

        private Matrix(int xHeaderCount, int yHeaderCount)
        {
            _cells = new Cell<TValue>[xHeaderCount, yHeaderCount];
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
                _cells[xHeaderIndex, yHeaderIndex] = new Cell<TValue>(item.Value);
            }
        }

        public IList<string> XHeaders { get; }

        public IList<string> YHeaders { get; }

        public Cell<TValue>[][] Cells => _cells.ToJaggedArray();
    }
}