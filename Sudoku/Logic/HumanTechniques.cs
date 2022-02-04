using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sudoku.Logic
{
	/// <summary>
	/// this class handles all the human techniques for solving a sudoku board
	/// </summary>
	public static class HumanTechniques
	{
		/// <summary>
		/// Indicates the number of changes that made in the sudoku board as a result of the human techniques
		/// </summary>
		public static int countChangesInTheBoard = 0;

		/// <summary>
		/// indicates if the board is valid when trying to use the human techniques
		/// </summary>
		public static bool isBoardValid = true;

		/// <summary>
		/// This function operates human methods on the sudoku board
		/// </summary>
		/// <param name="boardToSolve">the board object we want to try the techniques on</param>
		/// <returns>the number of changes that have occurred in the board. if an error occurred during one of the techniques, returns -1</returns>
		public static int SolveWithHumanTechniques(Board boardToSolve)
		{
			HumanTechniques.countChangesInTheBoard = 0;
			HumanTechniques.isBoardValid = true;
			while (true)
			{
				bool nakedSingles = NakedSinglesTechnique(boardToSolve);  // O(n^2)
				bool hiddenSingles = HiddenSinglesTechnique(boardToSolve);  // O(n^3)
				bool nakedPair = NakedPairsTechnique(boardToSolve);  // O(n^4)
				if (!HumanTechniques.isBoardValid)
				{
					SudokuBoardSolver.RemoveValuesFromBoard(boardToSolve, countChangesInTheBoard);
					return -1;
				}
				if (!(hiddenSingles || nakedSingles || nakedPair))
					return HumanTechniques.countChangesInTheBoard;
			}
		}

		/// <summary>
		/// try the human technique that called "Naked Single" on every cell in the board
		/// </summary>
		/// <param name="board">the board we want to perform the technique on</param>
		/// <returns>true if the technique changed something in the board, otherwise return false</returns>
		private static bool NakedSinglesTechnique(Board board)
		{
			bool hasBoardChanged = false;
			for (int row = 0; row < board.GetSize(); row++)
				for (int col = 0; col < board.GetSize(); col++)
					if (board.BoardMatrix[row, col] == 0)
					{
						ulong maskOfThePossibleNumbers = CheckPossibleNumbersInCurrentIndex(board, row, col);
						if (maskOfThePossibleNumbers == 0)
						{
							// throw new Exceptions.UnsolvableBoardException(String.Format("No value can match the cell at location [{0}, {1}]", row, col));
							HumanTechniques.isBoardValid = false;
							return hasBoardChanged;
						}
						if (HandleBitwise.IsPowerOfTwo(maskOfThePossibleNumbers))
						{
							AddNewValueToTheBoard(board, maskOfThePossibleNumbers, row, col);
							hasBoardChanged = true;
						}
					}
			return hasBoardChanged;
		}

		/// <summary>
		/// try the human technique that called "Hidden Single" on every cell in the board
		/// </summary>
		/// <param name="board">the board we want to perform the technique on</param>
		/// <returns>true if the technique changed something in the board, otherwise return false</returns>
		private static bool HiddenSinglesTechnique(Board board)
		{
			bool hasBoardChanged = false;
			for (int row = 0; row < board.GetSize(); row++)
				for (int col = 0; col < board.GetSize(); col++)
					if (board.BoardMatrix[row, col] == 0)
					{
						ulong possibleNumbersOfAllTheCellsInTheCurrentBox = PossibleNumbersInCurrentBox(board, row, col);
						ulong notPossibleNumbersOfTheCurrentCell = board.RowsArr[row] | board.ColsArr[col]
							| board.BoxesArr[row - (row % board.GetSubSize()) + col / board.GetSubSize()];
						ulong maskOfThePossibleNumbers = (possibleNumbersOfAllTheCellsInTheCurrentBox | notPossibleNumbersOfTheCurrentCell) ^ (((ulong)1 << board.GetSize()) - 1);
						if (maskOfThePossibleNumbers != 0)
						{
							if (HandleBitwise.IsPowerOfTwo(maskOfThePossibleNumbers))
							{
								AddNewValueToTheBoard(board, maskOfThePossibleNumbers, row, col);
								hasBoardChanged = true;
							}
							else
							{
								// throw new Exceptions.UnsolvableBoardException(String.Format("more then one number must appear in location [{0}, {1}]", row, col));
								HumanTechniques.isBoardValid = false;
								return hasBoardChanged;
							}
						}
					}
			return hasBoardChanged;
		}

		/// <summary>
		/// this function finds all the possible numbers that can appear in the box (Except of the options of the current cell) of the row and column that obtained as a parameter.
		/// </summary>
		/// <param name="board">The board we want to find in the possible numbers that can appear in particular box</param>
		/// <param name="row">the row of the current cell</param>
		/// <param name="col">the column of the current cell</param>
		/// <returns>the mask of the pssible numbers in the current box except of the possibles of the current cell</returns>
		private static ulong PossibleNumbersInCurrentBox(Board board, int row, int col)
		{
			int boxNumber = board.GetBoxNumberByRowAndColumn(row, col);
			ulong resultOfAllThePossibleNumbersInTheCurrentBox = 0;
			for (int i = boxNumber / board.GetSubSize() * board.GetSubSize(); i < boxNumber / board.GetSubSize() * board.GetSubSize() + board.GetSubSize(); i++)
				for (int j = (boxNumber % board.GetSubSize()) * board.GetSubSize(); j < (boxNumber % board.GetSubSize()) * board.GetSubSize() + board.GetSubSize(); j++)
					if (board.BoardMatrix[i, j] == 0 && (i != row || j != col))
						resultOfAllThePossibleNumbersInTheCurrentBox |= CheckPossibleNumbersInCurrentIndex(board, i, j);
			return resultOfAllThePossibleNumbersInTheCurrentBox;
		}

		/// <summary>
		/// try the human technique that called "Naked Pairs" on every cell in the board
		/// </summary>
		/// <param name="board">the board we want to perform the technique on</param>
		/// <returns>true if the technique changed something in the board, otherwise return false</returns>
		private static bool NakedPairsTechnique(Board board)
		{
			bool hasBoardChanged = false;
			bool hasAChangeoccurredInRow = false, hasAChangeoccurredInColumn = false;
			for (int i = 0; i < board.GetSize(); i++)
			{
				ulong maskOfTheMissingNumbersInTheRow = board.RowsArr[i] ^ (((ulong)1 << board.GetSize()) - 1);
				if (HandleBitwise.CountOneBits(maskOfTheMissingNumbersInTheRow) >= 3)
					hasAChangeoccurredInRow = CheckNakedPairsInTheRows(board, i);
				ulong maskOfTheMissingNumbersInTheColumn = board.ColsArr[i] ^ (((ulong)1 << board.GetSize()) - 1);
				if (HandleBitwise.CountOneBits(maskOfTheMissingNumbersInTheColumn) >= 3)
					hasAChangeoccurredInColumn = CheckNakedPairsInTheColumns(board, i);
				if (hasAChangeoccurredInRow || hasAChangeoccurredInColumn)
					hasBoardChanged = true;
			}
			return hasBoardChanged;
		}

		/// <summary>
		/// this function try to use the technique that called "Naked Pairs" a single row
		/// </summary>
		/// <param name="board">the board we want to perform the technique on</param>
		/// <param name="rowNum">The row number on which we want to practice the technique</param>
		/// <returns>true if the technique changed something in the current row, otherwise return false</returns>
		private static bool CheckNakedPairsInTheRows(Board board, int rowNum)
		{
			bool hasBoardChanged = false, hasAChangeoccurredInRow = false, hasAChangeoccurredInBox = false;
			for (int col = 0; col < board.GetSize(); col++)
			{
				if (board.BoardMatrix[rowNum, col] != 0)
					continue;
				ulong maskOfPossibleNumbers = CheckPossibleNumbersInCurrentIndex(board, rowNum, col);
				if (HandleBitwise.CountOneBits(maskOfPossibleNumbers) == 2)
				{
					int boxNum = board.GetBoxNumberByRowAndColumn(rowNum, col);
					for (int i = col + 1; i < board.GetSize(); i++)
						if (board.BoardMatrix[rowNum, i] == 0)
							if (maskOfPossibleNumbers == CheckPossibleNumbersInCurrentIndex(board, rowNum, i))
							{
								if (boxNum == board.GetBoxNumberByRowAndColumn(rowNum, i))
									hasAChangeoccurredInBox = RemoveAllThePairsInTheBox(board, maskOfPossibleNumbers, boxNum, rowNum * board.GetSize() + col, rowNum * board.GetSize() + i);
								hasAChangeoccurredInRow = RemoveAllThePairsInTheRow(board, maskOfPossibleNumbers, rowNum, col, i);
								if (hasAChangeoccurredInRow || hasAChangeoccurredInBox)
									hasBoardChanged = true;
								break;
							}
				}
			}
			return hasBoardChanged;
		}

		/// <summary>
		/// the function remove all the appearances of the pair numbers in the row (except of the two cells that representing the pair) and checks if possible to add value to the board after removing the pair
		/// </summary>
		/// <param name="board">The board from which we want to remove the pairs</param>
		/// <param name="maskOfThePair">mask that representing the pair. for example, if the pair is the number 4 and 8, the mask will be: 10001000.</param>
		/// <param name="rowNum">The row number on which we want to remove all the pairs</param>
		/// <param name="theFirstColumnNumberOfThePairInTheRow">the column of the first pair in the row</param>
		/// <param name="theSecondColumnNumberOfThePairInTheRow">the column of the second pair in the row</param>
		/// <returns>true if the technique changed something in the current row, otherwise return false</returns>
		private static bool RemoveAllThePairsInTheRow(Board board, ulong maskOfThePair, int rowNum, int theFirstColumnNumberOfThePairInTheRow, int theSecondColumnNumberOfThePairInTheRow)
		{
			bool hasBoardChanged = false;
			for (int col = 0; col < board.GetSize(); col++)
				if (board.BoardMatrix[rowNum, col] == 0 && col != theFirstColumnNumberOfThePairInTheRow && col != theSecondColumnNumberOfThePairInTheRow)
					if (CheckIfCanAddValueInTheBoard(board, maskOfThePair, rowNum, col))
						hasBoardChanged = true;
			return hasBoardChanged;
		}

		/// <summary>
		/// this function try to use the technique that called "Naked Pairs" a single column
		/// </summary>
		/// <param name="board">the board we want to perform the technique on</param>
		/// <param name="colNum">The column number on which we want to practice the technique</param>
		/// <returns>true if the technique changed something in the current column, otherwise return false</returns>
		private static bool CheckNakedPairsInTheColumns(Board board, int colNum)
		{
			bool hasBoardChanged = false, hasAChangeoccurredInColumn = false, hasAChangeoccurredInBox = false; ;
			for (int row = 0; row < board.GetSize(); row++)
			{
				if (board.BoardMatrix[row, colNum] != 0)
					continue;
				ulong maskOfPossibleNumbers = CheckPossibleNumbersInCurrentIndex(board, row, colNum);
				if (HandleBitwise.CountOneBits(maskOfPossibleNumbers) == 2)
				{
					int boxNum = board.GetBoxNumberByRowAndColumn(row, colNum);
					for (int i = row + 1; i < board.GetSize(); i++)
						if (board.BoardMatrix[i, colNum] == 0)
							if (maskOfPossibleNumbers == CheckPossibleNumbersInCurrentIndex(board, i, colNum))
							{
								if (boxNum == board.GetBoxNumberByRowAndColumn(i, colNum))
									hasAChangeoccurredInBox = RemoveAllThePairsInTheBox(board, maskOfPossibleNumbers, boxNum, row * board.GetSize() + colNum, i * board.GetSize() + colNum);
								hasAChangeoccurredInColumn = RemoveAllThePairsInTheColumn(board, maskOfPossibleNumbers, colNum, row, i);
								if (hasAChangeoccurredInColumn || hasAChangeoccurredInBox)
									hasBoardChanged = true;
								break;
							}
				}
			}
			return hasBoardChanged;
		}

		/// <summary>
		/// the function remove all the appearances of the pair numbers in the column (except of the two cells that representing the pair) and checks if possible to add value to the board after removing the pair
		/// </summary>
		/// <param name="board">The board from which we want to remove the pairs</param>
		/// <param name="maskOfThePair">mask that representing the pair. for example, if the pair is the number 4 and 8, the mask will be: 10001000.</param>
		/// <param name="colNum">The column number on which we want to remove all the pairs</param>
		/// <param name="theFirstRowNumberOfThePairInTheColumn">the row of the first pair in the column</param>
		/// <param name="theSecondRowNumberOfThePairInTheColumn">the row of the second pair in the column</param>
		/// <returns>true if the technique changed something in the current column, otherwise return false</returns>
		private static bool RemoveAllThePairsInTheColumn(Board board, ulong maskOfThePair, int colNum, int theFirstRowNumberOfThePairInTheColumn, int theSecondRowNumberOfThePairInTheColumn)
		{
			bool hasBoardChanged = false;
			for (int row = 0; row < board.GetSize(); row++)
				if (board.BoardMatrix[row, colNum] == 0 && row != theFirstRowNumberOfThePairInTheColumn && row != theSecondRowNumberOfThePairInTheColumn)
					if (CheckIfCanAddValueInTheBoard(board, maskOfThePair, row, colNum))
						hasBoardChanged = true;
			return hasBoardChanged;
		}

		/// <summary>
		/// the function remove all the appearances of the pair numbers in the box (except of the two cells that representing the pair) and checks if possible to add value to the board after removing the pair
		/// </summary>
		/// <param name="board">The board from which we want to remove the pairs</param>
		/// <param name="maskOfThePair">mask that representing the pair. for example, if the pair is the number 4 and 8, the mask will be: 10001000.</param>
		/// <param name="boxNum">The box number on which we want to remove all the pairs</param>
		/// <param name="theFirstLocationOfThePairInTheBox">the location of the first pair in the box</param>
		/// <param name="theSecondLocationOfThePairInTheBox">the location of the second pair in the box</param>
		/// <returns>true if the technique changed something in the current box, otherwise return false</returns>
		private static bool RemoveAllThePairsInTheBox(Board board, ulong maskOfThePair, int boxNum, int theFirstLocationOfThePairInTheBox, int theSecondLocationOfThePairInTheBox)
		{
			bool hasBoardChanged = false;
			for (int row = boxNum / board.GetSubSize() * board.GetSubSize(); row < boxNum / board.GetSubSize() * board.GetSubSize() + board.GetSubSize(); row++)
				for (int col = (boxNum % board.GetSubSize()) * board.GetSubSize(); col < (boxNum % board.GetSubSize()) * board.GetSubSize() + board.GetSubSize(); col++)
					if (board.BoardMatrix[row, col] == 0 && (row * board.GetSize() + col) != theFirstLocationOfThePairInTheBox && (row * board.GetSize() + col) != theSecondLocationOfThePairInTheBox)
						if (CheckIfCanAddValueInTheBoard(board, maskOfThePair, row, col))
							hasBoardChanged = true;
			return hasBoardChanged;
		}

		/// <summary>
		/// the function checks if we can add number to the board after removing the possibilities of the pair from his possibilities.
		/// </summary>
		/// <param name="board">The board we want to check if it is possible to add a value to it</param>
		/// <param name="maskOfThePair">mask that representing the pair. for example, if the pair is the number 4 and 8, the mask will be: 10001000.</param>
		/// <param name="rowNumber">The number of the row we want to check if it possible to add a value</param>
		/// <param name="columnNumber">The number of the column we want to check if it possible to add a value</param>
		/// <returns>true if a value has been appended to the board, otherwise return false</returns>
		private static bool CheckIfCanAddValueInTheBoard(Board board, ulong maskOfThePair, int rowNumber, int columnNumber)
		{
			ulong maskOfThePossibleNumbers = CheckPossibleNumbersInCurrentIndex(board, rowNumber, columnNumber) & (maskOfThePair ^ (((ulong)1 << board.GetSize()) - 1));
			if (HandleBitwise.CountOneBits(maskOfThePossibleNumbers) == 0)
				HumanTechniques.isBoardValid = false;
				// throw new Exceptions.UnsolvableBoardException(String.Format("No value can match the cell at location [{0}, {1}]", rowNumber, columnNumber));
			if (HandleBitwise.CountOneBits(maskOfThePossibleNumbers) == 1)
			{
				AddNewValueToTheBoard(board, maskOfThePossibleNumbers, rowNumber, columnNumber);
				return true;
			}
			return false;
		}

		/// <summary>
		/// the function adds number to the board object, pushing his location to the stack (static property) and increases the changes counter in the board by one
		/// </summary>
		/// <param name="board">The object of the board to which we want to add the number</param>
		/// <param name="maskOfTheNumberToBeAddedToTheBoard">mask of the number we want to add to the board. for example, if the number we want to add is 7, his mask will be: 1000000.</param>
		/// <param name="row">The row number we want to add the number to</param>
		/// <param name="col">The column number we want to add the number to</param>
		private static void AddNewValueToTheBoard(Board board, ulong maskOfTheNumberToBeAddedToTheBoard, int row, int col)
		{
			board.UpdateValue(HandleBitwise.CreateNumberFromMask(maskOfTheNumberToBeAddedToTheBoard), maskOfTheNumberToBeAddedToTheBoard, row, col);
			SudokuBoardSolver.locationsOfBoardchangesStack.Push(row * board.GetSize() + col);
			HumanTechniques.countChangesInTheBoard++;
		}

		/// <summary>
		/// The function finds the possible numbers that can be put in a particular cell on the board
		/// </summary>
		/// <param name="board">A board that we want to find for one of the cells in it the possible numbers that can be put in it</param>
		/// <param name="row">the row of the cell we want to check</param>
		/// <param name="col">the column of the cell we want to check</param>
		/// <returns>the mask of the possibilities that can be insert in the current cell</returns>
		public static ulong CheckPossibleNumbersInCurrentIndex(Board board, int row, int col)
		{
			return (board.RowsArr[row] | board.ColsArr[col] | board.BoxesArr[board.GetBoxNumberByRowAndColumn(row, col)]) ^ (((ulong)1 << board.GetSize()) - 1);
		}
	}
}
