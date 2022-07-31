using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SudokuSolver
{
    public interface IWriter
    {
        //Interface for how and what should be shown on the console

        void Write(string output, ConsoleColor color);
        void WriteLine(string output, ConsoleColor color);
    }
}
