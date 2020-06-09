using System;
using System.Collections.Generic;
using System.Linq;
using ModuleDomainService.Domain.Extensions;

namespace ModuleDomainService.Domain
{
    public class Matrix : IEquatable<Matrix>
    {
        private int[,] _adjacencyMatrix;

        public IEnumerable<string> Rows { get; set; }
        public IEnumerable<string> Columns { get; set; }

        public int[][] AdjacencyMatrix
        {
            get => _adjacencyMatrix.ToJaggedArray();
            set => _adjacencyMatrix = value.FromJaggedArray();
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