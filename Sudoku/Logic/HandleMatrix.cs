using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sudoku.Logic
{
    public static class HandleMatrix
    {
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
