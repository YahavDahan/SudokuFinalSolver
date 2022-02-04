using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sudoku.Input_and_Output
{
    /// <summary>
    /// class that allows input and output operations to be performed through the console
    /// </summary>
    /// <inheritdoc cref="IReadable"/>
    /// <inheritdoc cref="IPrintable"/>
    public class IOThroughConsole : IReadable, IPrintable
    {
        /// <summary>
        /// empty constructor for creating IO object through the console
        /// </summary>
        public IOThroughConsole() { }

        /// <summary>
        /// input sudoku board through the console
        /// </summary>
        /// <returns>string that representing the sudoku board</returns>
        public string InputSudokuBoard()
        {
            string strBoard;
            Console.WriteLine("Enter the string that representing the sudoku board: ");
            try
            {
                Console.SetIn(new System.IO.StreamReader(Console.OpenStandardInput(8192)));
                strBoard = Console.ReadLine();
            }
            catch (System.OverflowException)
            {
                Console.WriteLine("you didnt enter a board!");
                strBoard = InputSudokuBoard();
            }
            return strBoard;
        }

        /// <summary>
        /// output the sudoku board through the console
        /// </summary>
        /// <param name="boardToPrint">the object of the board we want to print to the user</param>
        public void OutputSudokuBoard(Board boardToPrint)
        {
            Console.WriteLine("The sudoku board after solving:");
            for (int i = 0; i < boardToPrint.GetSize(); i++)
                Console.Write("_____");
            Console.WriteLine();
            for (int i = 0; i < boardToPrint.GetSize(); i++)
            {
                Console.Write('|');
                for (int j = 0; j < boardToPrint.GetSize(); j++)
                    Console.Write(String.Format(" {0,2} |", boardToPrint.BoardMatrix[i, j]));
                Console.Write("\n|");
                for (int j = 0; j < boardToPrint.GetSize(); j++)
                    Console.Write("____|");
                Console.WriteLine();
            }
            Console.WriteLine();
        }
    }
}
