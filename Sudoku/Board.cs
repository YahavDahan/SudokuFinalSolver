using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sudoku
{
    /// <summary>
    /// A class that representing an object of a sudoku board of all sizes
    /// </summary>
    public class Board
    {
        /// <summary>
        /// matrix of integers that representing the numbers in the sudoku board
        /// </summary>
        private int[,] boardMatrix;

        /// <summary>
        /// the number of rows in the board
        /// </summary>
        private int size;

        /// <summary>
        /// the number of boxes in a row. for example, for 16x16 board, the property will contain the number 4.
        /// </summary>
        private int subSize;

        /// <summary>
        /// an ulong array that representing the rows in the board.
        /// every cell in the array will contain a number that representing one of the rows on the board (bitboard of the numbers that in the row).
        /// for example, if the first row in the board is: 0 0 1 6 5 0 0 8 0 , the first cell in the array will contain the number: 10110001
        /// </summary>
        private ulong[] rowsArr;

        /// <summary>
        /// an ulong array that representing the columns in the board.
        /// every cell in the array will contain a number that representing one of the columns on the board (bitboard of the numbers that in the column).
        /// for example, if the first column in the board is: 0 0 2 8 4 0 0 0 5 , the first cell in the array will contain the number: 10011010
        /// </summary>
        private ulong[] colsArr;

        /// <summary>
        /// an ulong array that representing the boxes in the board.
        /// every cell in the array will contain a number that representing one of the boxes on the board (bitboard of the numbers that in the box).
        /// for example, if the first box in the board is: 7 0 1 6 5 0 9 8 3 , the first cell in the array will contain the number: 111110101
        /// </summary>
        private ulong[] boxesArr;

        /// <summary>
        /// Creates the board object and initializes the board properties dynamically according to the board string obtained as a parameter.
        /// </summary>
        /// <param name="strBoard">string that representing the sudoku board</param>
        /// <exception cref="System.ArgumentOutOfRangeException">thrown when the length of the string parameter is incorrect for creating a sudoku board</exception>
        /// <exception cref="Exceptions.AsciiCharacterOutOfRangeException">thrown when one of the characters is invalid for creating a board</exception>
        /// <exception cref="Exceptions.NumberLocationException">thrown when the character in particular location of the string is invalid in this location</exception>
        public Board(string strBoard)
        {
            // if the sqrt of the string length is bigger then 64 (the number of bits in ulong type)
            // or the string's length is invalid
            if (!Logic.HandleString.IsValidLengthToCreateSudokuBoard(strBoard))
                throw new System.ArgumentOutOfRangeException("The string length is incorrect for creating a sudoku board");
            this.size = (int)(Math.Sqrt(strBoard.Length));
            this.subSize = (int)(Math.Sqrt(this.size));
            if (!Logic.HandleString.AreAllTheCharactersAsciiCodeValid(strBoard, this.size))
                throw new Exceptions.AsciiCharacterOutOfRangeException(String.Format("One of the characters is invalid to create a {0}X{0} board", this.size));
            this.boardMatrix = new int[this.size, this.size];
            this.rowsArr = new ulong[this.size];
            this.colsArr = new ulong[this.size];
            this.boxesArr = new ulong[this.size];
            for (int i = 0; i < this.size; i++)
            {
                for (int j = 0; j < this.size; j++)
                {
                    int numberToSave = Logic.HandleString.ConvertCharToIntegerTypeAsNumber(strBoard[i * this.size + j]);
                    ulong maskOfTheNumber = Logic.HandleBitwise.CreateMaskFromNumber(numberToSave);
                    if (numberToSave != 0 && !IsNumberValidInThisLocation(maskOfTheNumber, i, j))
                        throw new Exceptions.NumberLocationException(String.Format("The character in location {0} in the string is invalid in this location", (i * this.size + j)));
                    UpdateValue(numberToSave, maskOfTheNumber, i, j);
                }
            }
        }

        /// <summary>
        /// The function checks if number in particular location is valid in this location
        /// </summary>
        /// <param name="maskOfTheNumberForChecking">mask that representing the number we want to check if valid in this location. for example, if the number is 5, his mask will be 10000</param>
        /// <param name="row">The row where we want to check the validation</param>
        /// <param name="col">The column where we want to check the validation</param>
        /// <returns>the function returns true if the number is valid in this location, otherwise returns false</returns>
        public bool IsNumberValidInThisLocation(ulong maskOfTheNumberForChecking, int row, int col)
        {
            if ((maskOfTheNumberForChecking & this.rowsArr[row]) != 0)
                return false;
            if ((maskOfTheNumberForChecking & this.colsArr[col]) != 0)
                return false;
            if ((maskOfTheNumberForChecking & this.boxesArr[row - (row % this.subSize) + col / this.subSize]) != 0)
                return false;
            return true;
        }

        /// <summary>
        /// The function updates a value at a particular location in the board
        /// </summary>
        /// <param name="valueForUpdate">the new number we want to append to the board</param>
        /// <param name="maskOfTheValueForUpdate">the mask of the number we want to add to the board. for example, if the number is 7, the mask will be 1000000</param>
        /// <param name="row">The row to which we want to add the number</param>
        /// <param name="col">The column to which we want to add the number</param>
        public void UpdateValue(int valueForUpdate, ulong maskOfTheValueForUpdate, int row, int col)
        {
            this.boardMatrix[row, col] = valueForUpdate;
            this.rowsArr[row] |= maskOfTheValueForUpdate;
            this.colsArr[col] |= maskOfTheValueForUpdate;
            this.boxesArr[GetBoxNumberByRowAndColumn(row, col)] |= maskOfTheValueForUpdate;
        }

        /// <summary>
        /// The function removes a value at a particular location in the board
        /// </summary>
        /// <param name="maskOfTheValueToRemove">the mask of the number we want to remove from the board. for example, if the number we want to remove is 5, the mask will be 10000</param>
        /// <param name="row">The row where we want to remove the number</param>
        /// <param name="col">The column where we want to remove the number</param>
        public void RemoveValue(ulong maskOfTheValueToRemove, int row, int col)
        {
            this.boardMatrix[row, col] = 0;
            maskOfTheValueToRemove ^= (((ulong)1 << this.size) - 1);
            this.rowsArr[row] &= maskOfTheValueToRemove;
            this.colsArr[col] &= maskOfTheValueToRemove;
            this.boxesArr[GetBoxNumberByRowAndColumn(row, col)] &= maskOfTheValueToRemove;
        }

        /// <value>Property <c>RowsArr</c> represents the rows bitboard array</value>
        public ulong[] RowsArr
        {
            get { return this.rowsArr; }
            set { this.rowsArr = value; }
        }

        /// <value>Property <c>ColsArr</c> represents the columns bitboard array</value>
        public ulong[] ColsArr
        {
            get { return this.colsArr; }
            set { this.colsArr = value; }
        }

        /// <value>Property <c>BoxesArr</c> represents the Boxes bitboard array</value>
        public ulong[] BoxesArr
        {
            get { return this.boxesArr; }
            set { this.boxesArr = value; }
        }

        /// <summary>
        /// the function finds the box number of any location on the board
        /// </summary>
        /// <param name="rowNumber">The row where we want to find the box number</param>
        /// <param name="columnNumber">The column where we want to find the box number</param>
        /// <returns>returns the position of the box in the board</returns>
        public int GetBoxNumberByRowAndColumn(int rowNumber, int columnNumber)
        {
            return (rowNumber / this.subSize * this.subSize) + (columnNumber / this.subSize);
        }

        /// <value>Property <c>BoardMatrix</c> represents the integer board matrix</value>
        public int[,] BoardMatrix
        {
            get { return this.boardMatrix; }
            set { this.boardMatrix = value; }
        }

        /// <returns>the size of the board (the number of rows in the board)</returns>
        public int GetSize()
        {
            return this.size;
        }

        /// <returns>the subsize of the board - number of boxes in row (the square root of the number of rows in the board)</returns>
        public int GetSubSize()
        {
            return this.subSize;
        }

        public override string ToString()
        {
            return Logic.HandleMatrix.IntegerMatrixToString(this.boardMatrix);
        }
    }
}
