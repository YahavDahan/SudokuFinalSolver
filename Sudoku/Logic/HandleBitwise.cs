using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sudoku.Logic
{
    /// <summary>
    /// This class handles all general functions related to bitwise
    /// </summary>
    public static class HandleBitwise
    {
        private static int[] BitsSetTable256;

        /// <summary>
        /// Initializes the static property of the class so that each cell in the array contains the number of one bits in its index.
        /// for example, index number 11 will contain the value 3 (1011 - 3 bits are on)
        /// </summary>
        static HandleBitwise()
        {
            BitsSetTable256 = new int[256];
            BitsSetTable256[0] = 0;
            for (int i = 0; i < 256; i++)
            {
                BitsSetTable256[i] = (i & 1) + BitsSetTable256[i / 2];
            }
        }

        /// <summary>
        /// the function count the one bits in ulong number.
        /// Time complexity: O(1)
        /// </summary>
        /// <param name="number">The number we want to count its one bits</param>
        /// <returns>the amount of one bits in the number</returns>
        public static int CountOneBits(ulong number)
        {
            return BitsSetTable256[number & 0xff]
                + BitsSetTable256[(number >> 8) & 0xff]
                + BitsSetTable256[(number >> 16) & 0xff]
                + BitsSetTable256[(number >> 24) & 0xff]
                + BitsSetTable256[(number >> 32) & 0xff]
                + BitsSetTable256[(number >> 40) & 0xff]
                + BitsSetTable256[(number >> 48) & 0xff]
                + BitsSetTable256[number >> 56];
        }

        /// <summary>
        /// checks if number is power of 2 (only one bit is on)
        /// Time complexity: O(1)
        /// </summary>
        /// <param name="number">the number we want to check if its power of two</param>
        /// <returns>true if only one bit of the number is on, otherwise returns false</returns>
        public static bool IsPowerOfTwo(ulong number)
        {
            return (number != 0) && ((number & (number - 1)) == 0);
        }

        /// <summary>
        /// the function creates ulong mask from integer number
        /// Time complexity: O(1)
        /// </summary>
        /// <param name="numberForCreatingMask">the number we want to convert to mask</param>
        /// <returns>the mask that the number represents</returns>
        /// <example>
        /// if number = 4  ,  the result will be -> 1000
        /// if number = 7  ,  the result will be -> 1000000
        /// </example>
        public static ulong CreateMaskFromNumber(int numberForCreatingMask)
        {
            if (numberForCreatingMask == 0)
                return 0;
            ulong mask = 1;
            mask <<= (numberForCreatingMask - 1);
            return mask;
        }

        /// <summary>
        /// the function creates number from ulong mask
        /// </summary>
        /// <param name="maskForCreatingNumber">mask of a number (only one bit is on)</param>
        /// <returns>the number that the mask represents</returns>
        /// <example>
        /// if mask = 10000  ,  the result will be -> 5
        /// if mask = 100000000  ,  the result will be -> 9
        /// </example>
        public static int CreateNumberFromMask(ulong maskForCreatingNumber)
        {
            return Log2ToNumber(maskForCreatingNumber) + 1;
        }

        /// <summary>
        /// Checks the log2 mathematical operation of a number
        /// </summary>
        /// <param name="number">A number we want to calculate its log2</param>
        /// <returns>the result of log2 of the number</returns>
        /// <example><code>
        /// ulong num = 16;
        /// Console.WriteLine(Log2ToNumber(num));
        /// </code>
        /// the result will be: 4
        /// </example>
        public static int Log2ToNumber(ulong number)
        {
            return (number > 1) ? 1 + Log2ToNumber(number / 2) : 0;
        }
    }
}
