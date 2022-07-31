using Microsoft.VisualStudio.TestTools.UnitTesting;
using SudokuSolver;
using System;

namespace TestPositionMover
{
    [TestClass]
    public class PositionMoverTest
    {
        PositionMover mover;
        public PositionMoverTest()
        {
            this.mover = new PositionMover();
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void TestValuesTooSmallMoveBackwards()
        {
            int x = -12;
            int y = -2;
            bool unsolvable = false;
            Direction direction = Direction.Backward;
            this.mover.MoveBackwards(ref y, ref x, ref unsolvable, ref direction);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void TestValuesTooBigMoveBackwards()
        {
            int x = 12;
            int y = 9;
            bool unsolvable = false;
            Direction direction = Direction.Backward;
            this.mover.MoveBackwards(ref y, ref x, ref unsolvable, ref direction);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void TestValuesTooSmallMoveForwards()
        {
            int x = -12;
            int y = -2;
            bool solved = false;
            Direction direction = Direction.Forward;
            this.mover.MoveForward(ref y, ref x, ref solved, ref direction);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void TestValuesTooBigMoveForwards()
        {
            int x = 12;
            int y = 9;
            bool solved = false;
            Direction direction = Direction.Forward;
            this.mover.MoveForward(ref y, ref x, ref solved, ref direction);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void TestRightValueButSodukuSolvedMoveForwards()
        {
            int x = 2;
            int y = 5;
            bool solved = true;
            Direction direction = Direction.Forward;
            this.mover.MoveForward(ref y, ref x, ref solved, ref direction);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void TestRightValueButSodukuUnsolvedMoveBackwards()
        {
            int x = 3;
            int y = 4;
            bool unsolvable = true;
            Direction direction = Direction.Backward;
            this.mover.MoveForward(ref y, ref x, ref unsolvable, ref direction);
        }
    }
}
