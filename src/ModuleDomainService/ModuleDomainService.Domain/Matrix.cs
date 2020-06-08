using System;
using System.Collections.Generic;
using System.Linq;
using ModuleDomainService.Domain.Extensions;

namespace ModuleDomainService.Domain
{
    public readonly struct Matrix : IEquatable<Matrix>
    {
        private readonly int[,] _adjacencyMatrix;

        public Matrix(IReadOnlyCollection<string> rows, IReadOnlyCollection<string> columns)
        {
            Rows = rows;
            Columns = columns;
            _adjacencyMatrix = new int[rows.Count, columns.Count];
        }

        public IEnumerable<string> Rows { get; }

        public IEnumerable<string> Columns { get; }

        public int[][] AdjacencyMatrix
        {
            get => _adjacencyMatrix.ToJaggedArray();
            set => value.FromJaggedArray();
        }

        public bool Equals(Matrix other)
        {
            for (var rowIndex = 0; rowIndex < Rows.Count(); rowIndex++)
            {
                for (var columnIndex = 0; columnIndex < Columns.Count(); columnIndex++)
                {
                    if (_adjacencyMatrix[rowIndex, columnIndex] != other._adjacencyMatrix[rowIndex, columnIndex])
                        return false;
                }
            }

            return Rows.All(row => other.Rows.Contains(row)) && Columns.All(column => other.Columns.Contains(column));
        }

        public override bool Equals(object obj) => obj is Matrix other && Equals(other);

        public override int GetHashCode() => HashCode.Combine(Rows, Columns, _adjacencyMatrix);

        public static bool operator ==(Matrix @this, Matrix other) => @this.Equals(other);

        public static bool operator !=(Matrix @this, Matrix other) => !@this.Equals(other);
    }
}