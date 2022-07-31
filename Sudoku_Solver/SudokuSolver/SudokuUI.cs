//-----------------------------------------------------------------------------------------------------
// <copyright file="SudokuUI.cs" company="Fh Wr.Neustadt">
//     Copyright by Christy Kariyampalli. All rights reserved
// </copyright>
// <summary>A class to show the Sudoku on the console.</summary>
// <author>Christy Kariyampalli</author>
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
    /// The sudoku user interface class is needed to draw/show the Sudoku on the console.
    /// </summary>
    public class SudokuUI
    {
        private ConsoleWriter consoleWriter;
        /// <summary>
        /// Initializes a new instance of the <see cref="SudokuUI"/> class.
        /// </summary>
        public SudokuUI(ConsoleWriter writer)
        {
            this.consoleWriter = writer;
        }

        /// <summary>
        /// The ShowSpaces-method shows the Sudoku between each updated value of a space.
        /// </summary>
        /// <param name="spaces">
        /// The Sudoku spaces that should be shown.
        /// </param>
        /// <param name="speed">
        /// The speed between each Sudoku update/ the speed to show the 
        /// Sudoku between each update in value of a space during the game.
        /// </param>
        public void ShowSpaces(ISpace[,] spaces, int speed)
        {
            if (spaces == null || spaces.Length < 81 || speed < 0 || speed > 5000)
            {
                throw new InvalidOperationException("space or speed had was wrong during writting of sudoku on the console");
            }
            ConsoleColor currentColor = ConsoleColor.White;
            int yCounter = 0;
            int xCounter = 0;

            for (int i = 0; i < spaces.Length; i++)
            {
                switch (spaces[yCounter, xCounter].KindType)
                {
                    case Kind.Reserved:
                        currentColor = ConsoleColor.DarkRed;
                        break;
                    case Kind.Usable:
                        currentColor = ConsoleColor.Gray;
                        break;
                }

                consoleWriter.Write($" {spaces[yCounter, xCounter].Value}", currentColor);
                xCounter++;
                if ((i + 1) % 9 == 0)
                {
                    yCounter++;
                    xCounter = 0;
                    consoleWriter.Write("\n", currentColor);
                }
            }

            Thread.Sleep(speed);
        }
    }
}
