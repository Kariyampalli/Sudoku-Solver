//-----------------------------------------------------------------------------------------------------
// <copyright file="Direction.cs" company="Fh Wr.Neustadt">
//     Copyright by Christy Kariyampalli. All rights reserved
// </copyright>
// <summary>An enum to tell which direction to go next.</summary>
// <author>Christy Kariyampalli</author>
//-----------------------------------------------------------------------------------------------------
namespace SudokuSolver
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    /// Enum for the direction the Sudoku can move.
    /// </summary>
    public enum Direction
    {
        /// <summary>
        /// Forward (Look at next space infront of the current space if a valid value can be found).
        /// </summary>
        Forward,

        /// <summary>
        /// Backward (Look at next space behind of the current space if a valid value can be found).
        /// </summary>
        Backward
    }
}
