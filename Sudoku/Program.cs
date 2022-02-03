﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sudoku
{
    class Program
    {
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

        static void Main(string[] args)
        {
            // The program begins here.
            // An endless call is made to a function that represents a single sudoku game
            while (true)
                SudokuGame();
        }
    }
}

// שמות משמעותיים
// הערות (לראות שאין בעברית) + לרשום על כל פונקציה סיבוכיות זמן ריצה
// הרשאות גישה לפונקציות האם כל הפעולות הסטטיות הן פבליק?  מה המשמעות של פעולה פריבט סטטיק?
// טסטים
// לחבר פרויקט לגיט
// לבדוק שאין חזרות על קטעי קוד
// לטבל בקליטות של אנטר
// האם יש מחרוזות בקונסול שיכולות להקריס
// כל ההדפסות יקרו רק במיין בורד איי או
