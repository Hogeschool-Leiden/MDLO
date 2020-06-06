using System;
using System.Collections.Generic;

namespace ModuleDomainService.Domain
{
    public readonly struct Matrix : IEquatable<Matrix>
    {
        private readonly IEnumerable<string> _rows;
        private readonly IEnumerable<string> _columns;
        private readonly int[,] _adjacencyMatrix;

        public Matrix(IReadOnlyCollection<string> rows, IReadOnlyCollection<string> columns)
        {
            _rows = rows;
            _columns = columns;
            _adjacencyMatrix = new int[rows.Count, columns.Count];
        }

        public bool Equals(Matrix other)
        {
            throw new NotImplementedException();
        }

        public override bool Equals(object obj)
        {
            return obj is Matrix other && Equals(other);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(_rows, _columns, _adjacencyMatrix);
        }

        public static bool operator ==(Matrix @this, Matrix other)
        {
            return @this.Equals(other);
        }

        public static bool operator !=(Matrix @this, Matrix other)
        {
            return !@this.Equals(other);
        }
    }
}