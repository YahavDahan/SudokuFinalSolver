using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sudoku.Exceptions
{
    /// <summary>
    /// exception class that occurs when the board cannot contain particular ascii character
    /// </summary>
    public class AsciiCharacterOutOfRangeException : Exception
    {
        /// <summary>
        /// build the exception object with message
        /// </summary>
        /// <param name="message">The message for creating the exception</param>
        public AsciiCharacterOutOfRangeException(string message)
        : base(message) { }

        //public override string ToString()
        //{
        //    return Message;
        //}
    }
}
