using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sudoku.Input_and_Output
{
    /// <summary>
    /// The class manages all input and output from the user
    /// </summary>
    public class MainBoardIO
    {
        /// <summary>
        /// A property that contains the object through which a board can be received
        /// </summary>
        private IReadable inputObj;

        /// <summary>
        /// A property that contains the object to which a board can be printed
        /// </summary>
        private IPrintable outputObj;

        /// <summary>
        /// Produces an object that initializes the properties and determines through which class the board will be absorbed and printed
        /// </summary>
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

        /// <summary>
        /// The function asks the user how he wants to receive the board
        /// </summary>
        /// <returns>the number 1 if the user want to receive the board through a text file and the number 2 if the user want to receive the board through the console</returns>
        private int GetNumberToIdentifyTheBoardInputWay()
        {
            Console.WriteLine("Do you want to insert a sudoku board through a text file or through the console?");
            Console.Write("Enter 1 to insert the board through a text file and 2 to insert the board through the console:  ");
            int theChosenNumber = InputPossitiveNumber();
            while (theChosenNumber != 1 && theChosenNumber != 2)
            {
                Console.Write("You have to choose the number 1 or 2:  ");
                theChosenNumber = InputPossitiveNumber();
            }
            return theChosenNumber;
        }

        /// <summary>
        /// the function receive a possitive number from the user
        /// </summary>
        /// <returns>return a possitive number or -1 if an exception occurred</returns>
        public static int InputPossitiveNumber()
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

        /// <summary>
        /// The function performs the reception of the board through the class defined in the property - inputObj
        /// </summary>
        /// <returns>return a string that representing a sudoku board</returns>
        public string InputStringBoard()
        {
            return this.inputObj.InputSudokuBoard();
        }

        /// <summary>
        /// The function performs the printing of the board through the class defined in the property - outputObj
        /// </summary>
        /// <param name="boardToPrint">the board object we wan to print</param>
        public void OutputSudokuBoard(Board boardToPrint)
        {
            this.outputObj.OutputSudokuBoard(boardToPrint);
        }
    }
}
