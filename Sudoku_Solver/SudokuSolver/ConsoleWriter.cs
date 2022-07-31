using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SudokuSolver
{
    public class ConsoleWriter : IWriter
    {
        //This class writes the each output on the console with a specific color
        public void WriteLine(string output, ConsoleColor color)
        {
            if (string.IsNullOrEmpty(output) || string.IsNullOrWhiteSpace(output))
            {
                throw new ArgumentNullException("output for the console was null or empty");
            }
            Console.ForegroundColor = color;
            Console.WriteLine(output);
        }
        public void Write(string output, ConsoleColor color)
        {
            if ((string.IsNullOrEmpty(output) || string.IsNullOrWhiteSpace(output)) && output != "\n")
            {
                throw new ArgumentNullException("output for the console was null or empty");
            }
            Console.ForegroundColor = color;
            Console.Write(output);
        }
    }
}
