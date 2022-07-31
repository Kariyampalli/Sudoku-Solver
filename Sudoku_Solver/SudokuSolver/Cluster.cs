//-----------------------------------------------------------------------------------------------------
// <copyright file="Cluster.cs" company="Fh Wr.Neustadt">
//     Copyright by Christy Kariyampalli. All rights reserved
// </copyright>
// <summary>A class to for cluster objects.</summary>
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
    /// The cluster class is class for each 3x3 cluster/group within the Sudoku (look up rules).
    /// </summary>
    public class Cluster
    {
        /// <summary>
        /// Id for the cluster.
        /// </summary>
        private int id;

        /// <summary>
        /// Initializes a new instance of the <see cref="Cluster"/> class.
        /// </summary>
        /// <param name="idNumber">
        /// The id for the cluster.
        /// </param>
        /// <param name="spaces">
        /// The spaces currently in the cluster.
        /// </param>
        public Cluster(int idNumber, ISpace[,] spaces)
        {
            this.id = idNumber;
            this.Spaces = spaces;
        }

        /// <summary>
        /// Gets or sets the spaces within the cluster.
        /// </summary>
        /// <value>
        /// An array of ISpace-objects.
        /// </value>
        public ISpace[,] Spaces { get; set; }

        /// <summary>
        /// Gets the id of the cluster.
        /// </summary>
        /// <value>
        /// Integer between 1-9.
        /// </value>
        public int ID
        {
            get
            {
                return this.id;
            }
        }
    }
}
