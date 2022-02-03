using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sudoku.Input_and_Output
{
    public class IOThroughConsole : IReadable, IPrintable
    {
        public IOThroughConsole() { }

        public string InputSudokuBoard()
        {
            string strBoard;
            Console.WriteLine("Enter the string that representing the sudoku board: ");
            try
            {
                strBoard = Console.ReadLine();
            }
            catch (System.OverflowException)
            {
                Console.WriteLine("you didnt enter a board!");
                strBoard = InputSudokuBoard();
            }
            return strBoard;
        }

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
