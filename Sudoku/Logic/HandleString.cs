using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sudoku.Logic
{
    /// <summary>
    /// This class handles all general functions related to strings
    /// </summary>
    public static class HandleString
    {
        /// <summary>
        /// this function convert character to number (integer)
        /// </summary>
        /// <param name="tavToConvert">the character we want to convert</param>
        /// <returns>The number after the conversion</returns>
        public static int ConvertCharToIntegerTypeAsNumber(char tavToConvert)
        {
            return (int)(tavToConvert - '0');
        }

        /// <summary>
        /// this function convert integer number to character type
        /// </summary>
        /// <param name="numberToConvert">the number we want to convert</param>
        /// <returns>The character after the conversion</returns>
        public static char ConvertIntegerAsNumberToCharType(int numberToConvert)
        {
            return (char)(numberToConvert + '0');
        }

        /// <summary>
        /// This function checks if the length of a string is valid to create a sudoku board
        /// </summary>
        /// <param name="strBoard">string that representing a sudoku board</param>
        /// <returns>true if the length is valid to create a sudoku board, otherwise returns false</returns>
        public static bool IsValidLengthToCreateSudokuBoard(string strBoard)
        {
            double sqrtOfStrBoardLength = Math.Sqrt(strBoard.Length);
            if (strBoard.Length > 4096 || sqrtOfStrBoardLength - Math.Floor(sqrtOfStrBoardLength) != 0 ||
                Math.Sqrt(sqrtOfStrBoardLength) - Math.Floor(Math.Sqrt(sqrtOfStrBoardLength)) != 0)
                return false;
            return true;
        }

        /// <summary>
        /// this fanction checks if all the charcters in string are representing number in the range of 0 to the parameter 'theNumberOfTheValidCharacters'
        /// </summary>
        /// <param name="strBoard">A string that we want to check its characters</param>
        /// <param name="theNumberOfTheValidCharacters">the maximum number that character can reoresent</param>
        /// <returns>true if all the caracters in the string are in the range</returns>
        public static bool AreAllTheCharactersAsciiCodeValid(string strBoard, int theNumberOfTheValidCharacters)
        {
            for (int i = 0; i < strBoard.Length; i++)
                if (strBoard[i] < '0' || strBoard[i] > ('0' + theNumberOfTheValidCharacters))
                    return false;
            return true;
        }
    }
}
