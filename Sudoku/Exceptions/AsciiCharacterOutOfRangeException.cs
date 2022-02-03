using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sudoku.Exceptions
{
    public class AsciiCharacterOutOfRangeException : Exception
    {
        public AsciiCharacterOutOfRangeException(string message)
        : base(message) { }

        //public override string ToString()
        //{
        //    return Message;
        //}
    }
}
