using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sudoku.Input_and_Output
{
    public class IOThroughTextFile : IReadable, IPrintable
    {
        private string textFilePath;

        public IOThroughTextFile()
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "txt files (.txt)|.txt| All files(.)|.";
            if (ofd.ShowDialog() == DialogResult.OK)
                this.textFilePath = ofd.FileName;
            //Console.WriteLine("Enter the text file path: ");
            //string filePath = Console.ReadLine();
            //while (!filePath.EndsWith(".txt"))
            //{
            //    Console.WriteLine("Enter the path to text file with the string that representing the sudoku board: ");
            //    filePath = Console.ReadLine();
            //}
        }

        public string InputSudokuBoard()
        {
            string strBoard;
            try
            {
                strBoard = System.IO.File.ReadAllText(this.textFilePath);
                strBoard = strBoard.Replace("\n", "").Replace("\r", "");
            }
            // catch (Exception e) when (e is System.IO.FileNotFoundException || e is System.IO.PathTooLongException || e is System.Security.SecurityException)
            catch (System.Security.SecurityException)
            {
                Console.WriteLine("cannot open file with this path, enter other path: ");
                OpenFileDialog ofd = new OpenFileDialog();
                ofd.Filter = "txt files (.txt)|.txt| All files(.)|.";
                if (ofd.ShowDialog() == DialogResult.OK)
                    this.textFilePath = ofd.FileName;
                strBoard = InputSudokuBoard();
            }
            return strBoard;
        }

        public async void OutputSudokuBoard(Board boardToPrint)
        {
            // string guarnteedWritePath = System.Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData);
            // string filePath = Path.Combine(guarnteedWritePath, "solution.txt");
            string strBoard = Logic.HandleMatrix.IntegerMatrixToString(boardToPrint.BoardMatrix);
            string fileToWriteTheSolution = this.textFilePath.Remove(this.textFilePath.Length - 4) + "Solution.txt";
            await File.WriteAllTextAsync(fileToWriteTheSolution, strBoard);
        }
    }
}
