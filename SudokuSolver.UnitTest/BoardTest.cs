using Microsoft.VisualStudio.TestTools.UnitTesting;
using Sudoku;
using System;
using System.Collections.Generic;
using System.Text;

namespace SudokuSolver.UnitTest
{
    [TestClass]
    public class BoardTest
    {
        // try to create valid boards with different sizes

        [TestMethod]
        public void Board_Create9x9ValidBoard_ReturnsTrue()
        {
            // Arrange + Act + Assert
            try
            {
                Board sudokuBoard = new Board("040623000032080004190704000003000000000008009009000801000070410200090070000000005");
            }
            catch (Exception)
            {
                Assert.Fail();
            }
        }

        [TestMethod]
        public void Board_Create16x16ValidBoard_ReturnsTrue()
        {
            // Arrange + Act + Arrest
            try
            {
                Board sudokuBoard = new Board("00000000050000000000000000000000000000000000003000000000000000000000000000000000000000000000000000000000000602000000000000000000000000000000000000000000000000007000000000>00000005000000300000030=0000000000000000000000000000000000000000000000007000000000000");
            }
            catch (Exception)
            {
                Assert.Fail();
            }
        }


        // ------------------------------------------------------------------------------------------
        // Check boards that can not be created

        [TestMethod]
        public void Board_EmptyBoard_ReturnsFalse()
        {
            // Arrange + Act + Assert  - try to create board object with invalid length
            // If an exception of an incorrect length occurs then the test is correct.
            string strBoard = "";
            Board board;
            Assert.ThrowsException<System.ArgumentOutOfRangeException>(() => board = new Board(strBoard));
        }

        [TestMethod]
        public void Board_InvalidStringLengthToCreateBoard_ReturnsFalse()
        {
            // Arrange + Act + Assert  - try to create board object with invalid length
            // If an exception of an incorrect length occurs then the test is correct.
            string strBoard = "07096301000800070000070400083000004940900060275000008100040800400040312090";
            Board board;
            Assert.ThrowsException<System.ArgumentOutOfRangeException>(() => board = new Board(strBoard));
        }

        [TestMethod]
        public void Board_InvalidCharacterToCreateBoard_ReturnsFalse()
        {
            // Arrange + Act + Assert  - try to create board object with invalid length
            // If an exception of an incorrect ascii character occurs then the test is correct.
            string strBoard = "1000020109000304";
            Board board;
            Assert.ThrowsException<Sudoku.Exceptions.AsciiCharacterOutOfRangeException>(() => board = new Board(strBoard));
        }

        [TestMethod]
        public void Board_InvalidNumberLocationToCreateBoard_ReturnsFalse()
        {
            // Arrange + Act + Assert  - try to create board object with invalid length
            // If an exception of an incorrect number location occurs then the test is correct.
            string strBoard = "0011000000000000";
            Board board;
            Assert.ThrowsException<Sudoku.Exceptions.NumberLocationException>(() => board = new Board(strBoard));
        }
    }
}
