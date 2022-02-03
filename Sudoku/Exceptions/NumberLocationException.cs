using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sudoku.Exceptions
{
    public class NumberLocationException : Exception
    {
        public NumberLocationException(string message)
        : base(message) { }
    }
}
