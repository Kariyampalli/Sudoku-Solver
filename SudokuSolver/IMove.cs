using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SudokuSolver
{
    public interface IMove
    {
        //Interface for what has to be done if moven to a specific direction

        void MoveForward(ref int yPosition, ref int xPosition, ref bool solved, ref Direction nextDirection);
        void MoveBackwards(ref int yPosition, ref int xPosition, ref bool unsolvable, ref Direction nextDirection);
    }
}
