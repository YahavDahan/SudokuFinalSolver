using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sudoku.Logic
{
    /// <summary>
    /// This class is responsible for solving sudoku board of all sizes
    /// </summary>
    public static class SudokuBoardSolver
    {
        /// <summary>
        /// stack for saving the location of the changed data in the sudoku board during the backtracking function
        /// </summary>
        public static Stack<int> locationsOfBoardchangesStack = new Stack<int>();

        /// <summary>
        /// This function is responsible for solving the sudoku board and emptying the stack at the end of the solution in preparation for the next solving.
        /// </summary>
        /// <param name="sudokuBoardToSolve">the sudoku board object we want to solve</param>
        /// <returns>true if the board solved, if the board cannot be solved return false</returns>
        public static bool Solver(Board sudokuBoardToSolve)
        {
            bool isTheSudokuBoardResolved = BacktrackingSolver(sudokuBoardToSolve);
            // clear the stack in preparation for the next board
            locationsOfBoardchangesStack.Clear();
            return isTheSudokuBoardResolved;
        }

        /// <summary>
        /// this recursive function using backtracking with human techniques to solve the sudoku board
        /// </summary>
        /// <param name="sudokuBoardToSolve">the sudoku board object we want to solve</param>
        /// <returns>true if the board if solved, otherwise returns false</returns>
        private static bool BacktrackingSolver(Board sudokuBoardToSolve)
        {
            // try to use human techniques to solve the board. in case the board is unsolvable, returns false
            int countNumOfChanges = HumanTechniques.SolveWithHumanTechniques(sudokuBoardToSolve);
            if (countNumOfChanges == -1)
                return false;

            // find the cell with the minimum number of options for inserting. if the board is full, returns true
            int locationOfTheCellWithTheMinimumNumberOfLegalOptions = FindMinimumLocation(sudokuBoardToSolve);
            if (locationOfTheCellWithTheMinimumNumberOfLegalOptions == -1)
                return true;
            int row = locationOfTheCellWithTheMinimumNumberOfLegalOptions / sudokuBoardToSolve.GetSize();
            int col = locationOfTheCellWithTheMinimumNumberOfLegalOptions % sudokuBoardToSolve.GetSize();

            // Trying to guess a valid number in the location of the minimum cell and calling the BacktrackingSolver function again.
            // If the guess was not correct, the function try to guess a new number until the legal numbers for the guess are over.
            for (int i = 1; i < sudokuBoardToSolve.GetSize() + 1; i++)
            {
                ulong maskOfTheNumber = HandleBitwise.CreateMaskFromNumber(i);
                if (sudokuBoardToSolve.IsNumberValidInThisLocation(maskOfTheNumber, row, col))
                {
                    sudokuBoardToSolve.UpdateValue(i, maskOfTheNumber, row, col);
                    if (BacktrackingSolver(sudokuBoardToSolve))
                        return true;
                    sudokuBoardToSolve.RemoveValue(maskOfTheNumber, row, col);
                }
            }

            // Removes the human techniques previously performed from the board and return false
            RemoveValuesFromBoard(sudokuBoardToSolve, countNumOfChanges);
            return false;
        }

        /// <summary>
        /// this function counts the legal possible numbers to put in particular location.
        /// Time complexity: O(1)
        /// </summary>
        /// <param name="board">A board that we want to find for one of the cells in it the number of possible options that can be put in it</param>
        /// <param name="row">the row of the cell we want to check</param>
        /// <param name="col">the column of the cell we want to check</param>
        /// <returns>the number of possible number in the current location</returns>
        public static int CountLegalNumbersInCurrentIndex(Board board, int row, int col)
        {
            ulong theValidNumbersInTheCurrentIndex = HumanTechniques.CheckPossibleNumbersInCurrentIndex(board, row, col);
            return HandleBitwise.CountOneBits(theValidNumbersInTheCurrentIndex);
        }

        /// <summary>
        /// this function finds the empty cell with the minimum amount of possibe numbers to put in it
        /// </summary>
        /// <param name="board">The board where the cell is searched</param>
        /// <returns>the location of the empty cell with the minimum possible option to put in it. if the board is full, return -1</returns>
        /// <example>
        /// for 9x9 board:
        /// if the cell was found in row number 5 and column number 7, 52 will be the returned location
        /// 5 * 9 + 7 = 52   (rowNum * boardSize + colNum)
        /// </example>
        public static int FindMinimumLocation(Board board)
        {
            int theMinimumNumberOfLegalOptions = board.GetSize(), locationOfTheCellWithTheMinimumNumberOfLegalOptions = -1;
            int row, col;
            for (row = 0; row < board.GetSize(); row++)
            {
                if (board.RowsArr[row] == (((ulong)1 << board.GetSize()) - 1))
                    continue;
                for (col = 0; col < board.GetSize(); col++)
                {
                    if (board.BoardMatrix[row, col] == 0)
                    {
                        int theNumberOfLegalOptionsOfTheCurrentCell = CountLegalNumbersInCurrentIndex(board, row, col);
                        if (theNumberOfLegalOptionsOfTheCurrentCell == 0)
                            return row * board.GetSize() + col;
                        if (theNumberOfLegalOptionsOfTheCurrentCell <= theMinimumNumberOfLegalOptions)
                        {
                            theMinimumNumberOfLegalOptions = theNumberOfLegalOptionsOfTheCurrentCell;
                            locationOfTheCellWithTheMinimumNumberOfLegalOptions = row * board.GetSize() + col;
                        }
                    }
                }
            }
            return locationOfTheCellWithTheMinimumNumberOfLegalOptions;
        }

        /// <summary>
        /// the function removes numbers from the board - pulls their location out of the stack (static property) and remove them from the board object.
        /// </summary>
        /// <param name="board">The object of the board from which we want to remove the values</param>
        /// <param name="numberOfValuesToRemove">the amount of numbers we want to remove from the board</param>
        public static void RemoveValuesFromBoard(Board board, int numberOfValuesToRemove)
        {
            for (int i = 1; i <= numberOfValuesToRemove; i++)
            {
                int locationToRemove = SudokuBoardSolver.locationsOfBoardchangesStack.Pop();
                int row = locationToRemove / board.GetSize();
                int col = locationToRemove % board.GetSize();
                ulong maskOfTheValueToRemove = HandleBitwise.CreateMaskFromNumber(board.BoardMatrix[row, col]);
                board.RemoveValue(maskOfTheValueToRemove, row, col);
            }
        }
    }
}
