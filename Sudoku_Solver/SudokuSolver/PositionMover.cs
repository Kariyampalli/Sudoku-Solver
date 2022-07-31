using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SudokuSolver
{
    public class PositionMover : IMove
    {
        public PositionMover()
        {

        }
        /// <summary>
        /// The MoveForward-method is used to go to the next space (forward) if there is one.
        /// If there isn't one, it means its on the last available space (which has the right value)/the game has been solved.
        /// </summary>
        /// <param name="yPosition">
        /// Referencing the current y-position of the space in the Sudoku game that needs to find a right value.
        /// </param>
        /// <param name="xPosition">
        /// Referencing the current x-position of the space in the Sudoku game that needs to find a right value.
        /// </param>
        public void MoveForward(ref int yPosition, ref int xPosition, ref bool solved, ref Direction nextDirection)
        {
            if (xPosition < 0 || yPosition < 0 || xPosition > 8 || yPosition > 8 || solved)
            {
                throw new InvalidOperationException("Either xPosition and/or yPosition value is either too small or too big!!\nOr Sudoku tried to look into the space infront the current one even though Sudoku has already been solved!");
            }
            if (yPosition == 8 && xPosition == 8)
            {
                solved = true;
            }
            else
            {
                if (xPosition == 8)
                {
                    yPosition++;
                    xPosition = 0;
                }
                else
                {
                    xPosition++;
                }

                nextDirection = Direction.Forward;
            }
        }

        /// <summary>
        /// The MoveBackwards-method is used to go to the next space (backwards) if there is one.
        /// If there isn't one, it means its on the first available space (which didn't find the right value of)/the game can't be solved.
        /// </summary>
        /// <param name="yPosition">
        ///  Referencing the current y-position of the space in the Sudoku game that needs to find a right value.
        /// </param>
        /// <param name="xPosition">
        ///  Referencing the current x-position of the space in the Sudoku game that needs to find a right value.
        /// </param>
        public void MoveBackwards(ref int yPosition, ref int xPosition, ref bool unsolvable, ref Direction nextDirection)
        {


            if (xPosition < 0 || yPosition < 0 || xPosition > 8 || yPosition > 8 || unsolvable)
            {
                throw new InvalidOperationException("Either xPosition and/or yPosition value is either too small or too big!\nOr Sudoku tried to look into the space behind the current one even though Sudoku is already unsolvable!");
            }
            if (xPosition == 0 && yPosition - 1 >= 0)
            {
                yPosition--;
                xPosition = 8;
            }
            else if (yPosition == 0 && xPosition == 0)
            {
                unsolvable = true;
            }
            else
            {
                xPosition--;
            }

            nextDirection = Direction.Backward;
        }
    }
}
