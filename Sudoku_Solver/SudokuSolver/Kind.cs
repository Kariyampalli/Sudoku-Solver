//-----------------------------------------------------------------------------------------------------
// <copyright file="Kind.cs" company="Fh Wr.Neustadt">
//     Copyright by Christy Kariyampalli. All rights reserved
// </copyright>
// <summary>An enum to differenciate between reserved and usable spaces.</summary>
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
    /// Enum for the types of spaces.
    /// </summary>
    public enum Kind
    {
        /// <summary>
        /// Reserved (not editable).
        /// </summary>
        Reserved,

        /// <summary>
        /// Usable (editable).
        /// </summary>
        Usable
    }
}
