using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sudoku.Input_and_Output
{
    interface IPrintable
    {
        /// <summary>
        /// Classes that can print a sudoku board implement this interface
        /// </summary>
        /// <param name="boardToPrint">the board object we want to print</param>
        void OutputSudokuBoard(Board boardToPrint);
    }
}
