//-----------------------------------------------------------------------------------------------------
// <copyright file="ISpace.cs" company="Fh Wr.Neustadt">
//     Copyright by Christy Kariyampalli. All rights reserved
// </copyright>
// <summary>An interface for spaces</summary>
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
    /// Interface for the different types of Spaces.
    /// </summary>
    public interface ISpace
    {
        /// <summary>
        /// Gets or sets the value the space is currently holding within the Sudoku.
        /// </summary>
        /// <value>
        /// Integer between 0-9.
        /// </value>
        int Value { get; set; }

        /// <summary>
        /// Gets the y-coordinate/position of a space within the Sudoku.
        /// </summary>
        /// <value>
        /// Integer between 0-8.
        /// </value>
        int YPosition { get; }

        /// <summary>
        /// Gets the x-coordinate/position of a space within the Sudoku.
        /// </summary>
        /// <value>
        /// Integer between 0-8.
        /// </value>
        int XPosition { get; }

        /// <summary>
        /// Gets the type of the space
        /// Reserved: not editable
        /// Usable: editable.
        /// </summary>
        /// <value>
        /// Kind enum.
        /// </value>
        Kind KindType { get; }

        /// <summary>
        /// Gets or sets the id of the cluster the space is in.
        /// </summary>
        /// <value>
        /// Integer between 1-9.
        /// </value>
        int ClusterId { get; set; }
    }
}
