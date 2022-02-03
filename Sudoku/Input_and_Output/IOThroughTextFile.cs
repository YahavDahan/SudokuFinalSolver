using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sudoku.Input_and_Output
{
    public class IOThroughTextFile : IReadable, IPrintable
    {
        private string textFilePath;

        private OpenFileDialog textOfd;

        public IOThroughTextFile()
        {
            this.textOfd = new OpenFileDialog();
            this.textOfd.InitialDirectory = "c:\\";
            this.textOfd.Filter = "txt files (.txt)|.txt| All files(.)|.";
            this.textFilePath = this.GetPath();
        }

        private string GetPath()
        {
            if (this.textOfd.ShowDialog() == DialogResult.OK)
                return this.textOfd.FileName;
            Console.WriteLine("You have to choose a text file path! ");
            return GetPath();
        }

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

        public void OutputSudokuBoard(Board boardToPrint)
        {
            string strBoard = Logic.HandleMatrix.IntegerMatrixToString(boardToPrint.BoardMatrix);
            string fileToWriteTheSolution = this.textFilePath.Replace(".txt", "Solution.txt");
            File.WriteAllText(fileToWriteTheSolution, strBoard);
        }
    }
}
