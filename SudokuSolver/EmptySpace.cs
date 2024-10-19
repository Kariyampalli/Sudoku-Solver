//-----------------------------------------------------------------------------------------------------
// <copyright file="EmptySpace.cs" company="Fh Wr.Neustadt">
//     Copyright by Christy Kariyampalli. All rights reserved
// </copyright>
// <summary>A class for the space objects that have modifiable values.</summary>
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
    /// The EmptySpace-class is needed for the empty spaces at beginning/editable spaces during the game.
    /// </summary>
    public class EmptySpace : ISpace
    {
        /// <summary>
        /// Y-position for the space.
        /// </summary>
        private int yPosition;

        /// <summary>
        /// X-position for the space.
        /// </summary>
        private int xPosition;

        /// <summary>
        /// Initializes a new instance of the <see cref="EmptySpace"/> class.
        /// </summary>
        /// <param name="receivedValue">
        /// The value for the space.
        /// </param>
        /// <param name="yPosititon">
        /// The y-position for the space.
        /// </param>
        /// <param name="xPosititon">
        /// The x-position for the space.
        /// </param>
        public EmptySpace(int receivedValue, int yPosititon, int xPosititon)
        {
            this.Value = receivedValue;
            this.yPosition = yPosititon;
            this.xPosition = xPosititon;
        }

        /// <summary>
        /// Gets or sets the value the space is currently holding within the Sudoku.
        /// </summary>
        /// <value>
        /// Integer between 0-9.
        /// </value>
        public int Value { get; set; }

        /// <summary>
        /// Gets the y-coordinate/position of a space within the Sudoku.
        /// </summary>
        /// <value>
        /// Integer between 0-8.
        /// </value>
        public int YPosition
        {
            get
            {
                return this.yPosition;
            }
        }

        /// <summary>
        /// Gets the x-coordinate/position of a space within the Sudoku.
        /// </summary>
        /// <value>
        /// Integer between 0-8.
        /// </value>
        public int XPosition
        {
            get
            {
                return this.xPosition;
            }
        }

        /// <summary>
        /// Gets the type of the space.
        /// Usable: editable.
        /// </summary>
        /// <value>
        /// Kind enum.
        /// </value>
        public Kind KindType
        {
            get
            {
                return Kind.Usable;
            }
        }

        /// <summary>
        /// Gets or sets the id of the cluster the space is in.
        /// </summary>
        /// <value>
        /// Integer between 1-9.
        /// </value>
        public int ClusterId { get; set; }
    }
}
