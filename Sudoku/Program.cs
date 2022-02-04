using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sudoku
{
    class Program
    {
        /// <summary>
        /// The function creates a sudoku board from a string
        /// </summary>
        /// <param name="strBoard">string that representing the sudoku board</param>
        /// <returns>Return Board object If a sudoku board can be created from the resulting string, Otherwise NULL is returned</returns>
        public static Board CreateNewBoard(string strBoard)
        {
            Board sudokuBoard = null;
            try
            {
                sudokuBoard = new Board(strBoard);
            }
            catch (Exception e) when (e is System.ArgumentOutOfRangeException || e is Exceptions.AsciiCharacterOutOfRangeException || e is Exceptions.NumberLocationException)
            {
                Console.WriteLine("The inserted string is invalid to create a sudoku board.");
                Console.WriteLine("reason:  " + e.Message + "\nplease enter new board. \n\n");
            }
            return sudokuBoard;
        }

        /// <summary>
        /// A function that representing one complete sudoku game.
        /// A sudoku board is absorbed, constructed, solved and finally printed
        /// </summary>
        public static void SudokuGame()
        {
            Board sudokuBoard;
            Input_and_Output.MainBoardIO inputOutputObj;
            do
            {
                inputOutputObj = new Input_and_Output.MainBoardIO();
                string strBoard = inputOutputObj.InputStringBoard();
                sudokuBoard = CreateNewBoard(strBoard);
            } while (sudokuBoard == null);
            TimeSpan theTimeBeforeTheSolving = DateTime.Now.TimeOfDay;
            if (Logic.SudokuBoardSolver.Solver(sudokuBoard))
            {
                TimeSpan theTimeAfterTheSolving = DateTime.Now.TimeOfDay;
                inputOutputObj.OutputSudokuBoard(sudokuBoard);
                Console.WriteLine(String.Format("The time it took to solve the sudoku board:  {0} \n\n", theTimeAfterTheSolving - theTimeBeforeTheSolving));
            }
            else
                Console.WriteLine("The inserted board is unsolvable \n\n");
        }

        /// <summary>
        /// The program begins here.
        /// An endless call is made to a function that represents a single sudoku game
        /// </summary>
        /// <param name="args"></param>
        [STAThread]
        static void Main(string[] args)
        {
            while (true)
                SudokuGame();
        }
    }
}
