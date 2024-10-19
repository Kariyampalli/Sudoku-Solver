//-----------------------------------------------------------------------------------------------------
// <copyright file="Program.cs" company="Fh Wr.Neustadt">
//     Copyright by Christy Kariyampalli. All rights reserved
// </copyright>
// <summary>The Program class starts the program with the main method.</summary>
// <author>Christy Kariyamplli</author>
//-----------------------------------------------------------------------------------------------------
namespace SudokuSolver
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    /// The program class runs the program but doesn't actually start the game until the inputs have been verified.
    /// </summary>
    public class Program
    {

        /// <summary>
        /// The Main method start the program.
        /// </summary>
        /// <param name="args">
        /// Command line arguments received at the start of the program. In this case none.
        /// </param>
        public static void Main(string[] args)
        {
            RunProgram();
        }

        /// <summary>
        /// Calls the Sudoku run method to start the Sudoku and gives his constructors the objects he needs
        /// </summary>
        private static void RunProgram()
        {
            ConsoleWriter writer = new ConsoleWriter();
            PositionMover positionMover = new PositionMover();
            ClusterCreator creator = new ClusterCreator(writer);
            Sudoku sudoku = new Sudoku(writer, positionMover, creator);
            sudoku.Run();
        }
    }
}
