using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sudoku.Exceptions
{
    /// <summary>
    /// exception class that occurs when the board is unsolvable
    /// </summary>
    public class UnsolvableBoardException : Exception
    {
        /// <summary>
        /// build the exception object with message
        /// </summary>
        /// <param name="message">The message for creating the exception</param>
        public UnsolvableBoardException(string message)
        : base(message) { }
    }
}
