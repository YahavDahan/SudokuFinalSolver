using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sudoku.Input_and_Output
{
    public class MainBoardIO
    {
        private IReadable inputObj;
        private IPrintable outputObj;

        public MainBoardIO()
        {
            int number = this.GetNumberToIdentifyTheBoardInputWay();
            switch (number)
            {
                case 1:
                    this.inputObj = new IOThroughTextFile();
                    this.outputObj = (IOThroughTextFile)this.inputObj;
                    break;
                case 2:
                    this.inputObj = new IOThroughConsole();
                    this.outputObj = (IOThroughConsole)this.inputObj;
                    break;
            }
        }

        private int GetNumberToIdentifyTheBoardInputWay()
        {
            Console.WriteLine("Do you want to insert a sudoku board through a text file or through the console?");
            Console.Write("Enter 1 to insert the board through a text file and 2 to insert the board through the console:  ");
            int theChosenNumber = this.InputNumber();
            while (theChosenNumber != 1 && theChosenNumber != 2)
            {
                Console.Write("You have to choose the number 1 or 2:  ");
                theChosenNumber = this.InputNumber();
            }
            return theChosenNumber;
        }

        private int InputNumber()
        {
            int theChosenNumber;
            try
            {
                theChosenNumber = int.Parse(Console.ReadLine());
            }
            catch (Exception e) when (e is System.FormatException || e is System.OverflowException)
            {
                theChosenNumber = -1;
            }
            return theChosenNumber;
        }

        public string InputStringBoard()
        {
            return this.inputObj.InputSudokuBoard();
        }

        public void OutputSudokuBoard(Board boardToPrint)
        {
            this.outputObj.OutputSudokuBoard(boardToPrint);
        }
    }
}
