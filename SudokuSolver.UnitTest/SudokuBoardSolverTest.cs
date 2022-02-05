using Microsoft.VisualStudio.TestTools.UnitTesting;
using Sudoku;
using System;

namespace SudokuSolver.UnitTest
{
    [TestClass]
    public class SudokuBoardSolverTest
    {
        // Checking empty boards

        [TestMethod]
        public void Solver_Empty1x1_ReturnsTrue()
        {
            // Arrange - create board object
            Board sudokuBoard = new Board("0");

            // Act + Assert
            this.CheckIfCanSolveBoard(sudokuBoard);
        }

        [TestMethod]
        public void Solver_Empty4x4_ReturnsTrue()
        {
            // Arrange - create board object
            Board sudokuBoard = new Board("0000000000000000");

            // Act + Assert
            this.CheckIfCanSolveBoard(sudokuBoard);
        }

        [TestMethod]
        public void Solver_Empty9x9_ReturnsTrue()
        {
            // Arrange - create board object
            Board sudokuBoard = new Board("000000000000000000000000000000000000000000000000000000000000000000000000000000000");

            // Act + Assert
            this.CheckIfCanSolveBoard(sudokuBoard);
        }

        [TestMethod]
        public void Solver_Empty16x16_ReturnsTrue()
        {
            // Arrange - create board object
            Board sudokuBoard = new Board("0000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000");

            // Act + Assert
            this.CheckIfCanSolveBoard(sudokuBoard);
        }

        [TestMethod]
        public void Solver_Empty25x25_ReturnsTrue()
        {
            // Arrange - create board object
            Board sudokuBoard = new Board("0000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000");

            // Act + Assert
            this.CheckIfCanSolveBoard(sudokuBoard);
        }

        //---------------------------------------------------------------------------------------------------------
        // Checking full boards

        [TestMethod]
        public void Solver_Full9x9_ReturnsTrue()
        {
            // Arrange - create board object
            Board sudokuBoard = new Board("873415629924763851165928743238157964547396182691284537489672315752831496316549278");

            // Act + Assert
            this.CheckIfCanSolveBoard(sudokuBoard);
        }

        [TestMethod]
        public void Solver_Full16x16_ReturnsTrue()
        {
            // Arrange - create board object
            Board sudokuBoard = new Board("172:93;68>?54<@=>?5;=8:4<@931726=<84>1@5627;:?39@693<72?=1:4>85;<:=@1?32;4569>787368;4=9?<>@51:2;942:5<>78=136?@?1>5768@392:;4=<4@1<2:?396;>7=85:836591=@?<72;4>9>;=6<472538@:1?257?@;>81:4=<96354?13>9<:=628@;76=@74251>;89?3<:3;<98@6:571?=2>482:>?=7;43@<6591");

            // Act + Assert
            this.CheckIfCanSolveBoard(sudokuBoard);
        }

        //---------------------------------------------------------------------------------------------------------
        // solving bords

        [TestMethod]
        public void Solver_Board4x4_ReturnsTrue()
        {
            // Arrange - create board object
            Board sudokuBoard = new Board("1000020100000304");

            // Act + Assert
            this.CheckIfCanSolveBoard(sudokuBoard);
        }

        [TestMethod]
        public void Solver_EasyBoard9x9_ReturnsTrue()
        {
            // Arrange - create board object
            Board sudokuBoard = new Board("070963010008000700000704000830000049409000602750000081000408000005000400040312090");

            // Act + Assert
            this.CheckIfCanSolveBoard(sudokuBoard);
        }

        [TestMethod]
        public void Solver_HardBoard9x9_ReturnsTrue()
        {
            // Arrange - create board object
            Board sudokuBoard = new Board("000006000059000008200008000045000000003000000006003054000325006000000000000000000");

            // Act + Assert
            this.CheckIfCanSolveBoard(sudokuBoard);
        }

        [TestMethod]
        public void Solver_EasyBoard16x16_ReturnsTrue()
        {
            // Arrange - create board object
            Board sudokuBoard = new Board("00<00010020008000003?=<001:4500000@>;007500=?30020=706800?>0410;000000?>23000000<02;=90@:05>1?07>50000000000003600180002;0009=0000?:00014000@<004;000000000000?8107<240;=0?83:0500000063<:000000@09?0<200;70=5030031500?>0027;0000057>;00<13800000;000@004000900");

            // Act + Assert
            this.CheckIfCanSolveBoard(sudokuBoard);
        }

        [TestMethod]
        public void Solver_HardBoard16x16_ReturnsTrue()
        {
            // Arrange - create board object
            Board sudokuBoard = new Board("102000;680054<00>00;08:0<09007000<00000002700?090090070000:0>85;0:0@1002;40600080300000900000000;942050>00=030000000008@3920040000100:?39600000000060900@0<02;4>00000000200000102000@0>8100=<06054?10>0000600@0060@00250000000<000<00@0:0710=00400:>?00;43000501");

            // Act + Assert
            this.CheckIfCanSolveBoard(sudokuBoard);
        }

        //---------------------------------------------------------------------------------------------------------
        // unsolvable bords

        [TestMethod]
        public void Solver_UnsolvableBoard4x4_ReturnsFalse()
        {
            // Arrange - create board object
            Board sudokuBoard = new Board("1300000002030001");

            // Act + Assert
            this.CheckIfCannotSolveBoard(sudokuBoard);
        }

        [TestMethod]
        public void Solver_UnsolvableBoard9x9_ReturnsFalse()
        {
            // Arrange - create board object
            Board sudokuBoard = new Board("100000000000100000000000005000000100000000000000000000000000000000000010000000000");

            // Act + Assert
            this.CheckIfCannotSolveBoard(sudokuBoard);
        }

        [TestMethod]
        public void Solver_UnsolvableBoard16x16_ReturnsFalse()
        {
            // Arrange - create board object
            Board sudokuBoard = new Board("102300;680054<00>00;08:0<09007000<00000002700?090090070000:0>85;0:0@1002;40600080300000900000000;942050>00=030000000008@3920040000100:?39600000000060900@0<02;4>00000000200000102000@0>8100=<06054?10>0000600@0060@00250000000<000<00@0:0710=00400:>?00;43000501");

            // Act + Assert
            this.CheckIfCannotSolveBoard(sudokuBoard);
        }

        //---------------------------------------------------------------------------------------------------------

        private void CheckIfCanSolveBoard(Board boardToCheck)
        {
            // Act - try to solve the board
            bool isTheBoardSave = Sudoku.Logic.SudokuBoardSolver.Solver(boardToCheck);

            // Assert if the board is unsolvable
            Assert.IsTrue(isTheBoardSave);

            // Assert if the board result is incorrect (throws exception if cannot create board with the result)
            try
            {
                Board testBoard = new Board(boardToCheck.ToString());
            }
            catch
            {
                Assert.Fail();
            }
        }

        private void CheckIfCannotSolveBoard(Board boardToCheck)
        {
            // Act - try to solve the board
            bool boardSolution = Sudoku.Logic.SudokuBoardSolver.Solver(boardToCheck);

            // Assert if the board is unsolvable
            Assert.IsFalse(boardSolution);
        }
    }
}
