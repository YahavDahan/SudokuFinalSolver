using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sudoku.Input_and_Output
{
    /// <summary>
    /// class that allows input and output operations to be performed through a text file
    /// </summary>
    /// <inheritdoc cref="IReadable"/>
    /// <inheritdoc cref="IPrintable"/>
    public class IOThroughTextFile : IReadable, IPrintable
    {
        /// <summary>
        /// the text file path where the sudoku board is located
        /// </summary>
        private string textFilePath;

        /// <summary>
        /// An object that allows the user to select a text file through the explorer
        /// </summary>
        private OpenFileDialog textOfd;

        /// <summary>
        /// Initializes the class properties for creating IO object through a thext file.
        /// </summary>
        public IOThroughTextFile()
        {
            this.textOfd = new OpenFileDialog();
            this.textOfd.InitialDirectory = "c:\\";
            this.textOfd.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            this.textFilePath = this.GetPath();
        }

        /// <summary>
        /// get path to text file from the user
        /// </summary>
        /// <returns>the path of the text file</returns>
        private string GetPath()
        {
            if (this.textOfd.ShowDialog() == DialogResult.OK)
                return this.textOfd.FileName;
            Console.WriteLine("You have to choose a text file path! ");
            return GetPath();
        }

        /// <summary>
        /// input sudoku board through a text file
        /// </summary>
        /// <returns>string that representing the sudoku board</returns>
        public string InputSudokuBoard()
        {
            string strBoard;
            try
            {
                strBoard = System.IO.File.ReadAllText(this.textFilePath);
                strBoard = strBoard.Replace("\n", "").Replace("\r", "");
            }
            catch (System.Security.SecurityException)
            {
                Console.WriteLine("cannot open file with this path, enter other path: ");
                this.textFilePath = this.GetPath();
                strBoard = InputSudokuBoard();
            }
            return strBoard;
        }

        /// <summary>
        /// output the sudoku board through a text file in the same location of the unsolved board
        /// </summary>
        /// <param name="boardToPrint">the object of the board we want to write to the new file</param>
        public void OutputSudokuBoard(Board boardToPrint)
        {
            Console.WriteLine("\nThe solved board was successfully written to the a file in the folder where the file with the unsolved board is located");
            string strBoard = Logic.HandleMatrix.IntegerMatrixToString(boardToPrint.BoardMatrix);
            string fileToWriteTheSolution = this.textFilePath.Replace(".txt", "Solution.txt");
            File.WriteAllText(fileToWriteTheSolution, strBoard);
        }
    }
}
