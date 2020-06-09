using System;
using System.Linq;

namespace ModuleDomainService.Domain.Extensions
{
    internal static class Array2DExtensions
    {
        internal static T[][] ToJaggedArray<T>(this T[,] twoDimensionalArray)
        {
            var rowsFirstIndex = twoDimensionalArray.GetLowerBound(0);
            var rowsLastIndex = twoDimensionalArray.GetUpperBound(0);
            var numberOfRows = rowsLastIndex + 1;

            var columnsFirstIndex = twoDimensionalArray.GetLowerBound(1);
            var columnsLastIndex = twoDimensionalArray.GetUpperBound(1);
            var numberOfColumns = columnsLastIndex + 1;

            var jaggedArray = new T[numberOfRows][];
            for (var i = rowsFirstIndex; i <= rowsLastIndex; i++)
            {
                jaggedArray[i] = new T[numberOfColumns];

                for (var j = columnsFirstIndex; j <= columnsLastIndex; j++)
                {
                    jaggedArray[i][j] = twoDimensionalArray[i, j];
                }
            }

            return jaggedArray;
        }

        internal static T[,] FromJaggedArray<T>(this T[][] jaggedArray)
        {
            try
            {
                var FirstDim = jaggedArray.Length;
                var SecondDim = jaggedArray.GroupBy(row => row.Length).Single().Key; // throws InvalidOperationException if source is not rectangular

                var result = new T[FirstDim, SecondDim];
                for (var i = 0; i < FirstDim; ++i)
                for (var j = 0; j < SecondDim; ++j)
                    result[i, j] = jaggedArray[i][j];

                return result;
            }
            catch (InvalidOperationException)
            {
                throw new InvalidOperationException("The given jagged array is not rectangular.");
            } 
        }
    }
}