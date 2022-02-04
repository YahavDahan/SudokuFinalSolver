using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sudoku.Logic
{
    /// <summary>
    /// This class handles all general functions related to matrices
    /// </summary>
    public static class HandleMatrix
    {
        /// <summary>
        /// this function converts a matrix of numbers to a string
        /// </summary>
        /// <param name="matrix">the matrix we want to convert to string</param>
        /// <returns>the string that representing the integer matrix</returns>
        /// <example>
        /// <code>
        /// int[,] myMatrix = new int[,] {{ 1, 0, 0, 2 }, { 0, 3, 1, 0 }, { 0, 0, 0, 3 }, { 4, 2, 0, 0 }};
        /// Console.WriteLine(IntegerMatrixToString(myMatrix));
        /// </code>
        /// the return string: "1002031000034200"
        /// </example>
        public static string IntegerMatrixToString(int[,] matrix)
        {
            string strMatrix = "";
            for (int i = 0; i < matrix.GetLength(0); i++)
                for (int j = 0; j < matrix.GetLength(1); j++)
                    strMatrix += HandleString.ConvertIntegerAsNumberToCharType(matrix[i, j]);
            return strMatrix;
        }

        //public static int[,] StringToIntegerSquareMatrix(string stringToConvert, int numOfRows)
        //{
        //    int[,] mat = new int[numOfRows, numOfRows];
        //    for (int i = 0; i < numOfRows; i++)
        //        for (int j = 0; j < numOfRows; j++)
        //            mat[i, j] = HandleString.ConvertCharToIntegerTypeAsNumber(stringToConvert[i * numOfRows + j]);
        //    return mat;
        //}
    }
}
