using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sudoku.Input_and_Output
{
    interface IReadable
    {
        /// <summary>
        /// Classes that can input a sudoku board implement this interface
        /// </summary>
        /// <returns>string that representing the sudoku board</returns>
        string InputSudokuBoard();
    }
}
