using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sudoku.Exceptions
{
    /// <summary>
    /// exception class that occurs when location of number in the board is incorrect
    /// </summary>
    public class NumberLocationException : Exception
    {
        /// <summary>
        /// build the exception object with message
        /// </summary>
        /// <param name="message">The message for creating the exception</param>
        public NumberLocationException(string message)
        : base(message) { }
    }
}
