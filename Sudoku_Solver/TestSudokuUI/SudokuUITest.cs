using Microsoft.VisualStudio.TestTools.UnitTesting;
using SudokuSolver;
using System;

namespace TestSudokuUI
{
    [TestClass]
    public class SudokuUITest
    {
        ISpace[,] spaces;
        Check check = new Check(new ConsoleWriter());
        public SudokuUITest()
        {
            bool validInput;
            check.CheckSudokuInput("5, 3, 0, 0, 7, 0, 0, 0, 0, 6, 0, 0, 1, 9, 5, 0, 0, 0, 0, 9, 8, 0, 0, 0, 0, 6, 0, 8, 0, " +
                "0, 0, 6, 0, 0, 0, 3, 4, 0, 0, 8, 0, 3, 0, 0, 1, 7, 0, 0, 0, 2, 0, 0, 0, 6, 0, 6, 0, 0, 0, 0, 2, 8, 0, 0, " +
                "0, 0, 4, 1, 9, 0, 0, 5, 0, 0, 0, 0, 8, 0, 0, 7, 9", out spaces, out validInput);

        }
        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void TestEmptySapcesShowSpaces()
        {
            ISpace[,] spaces = new ISpace[9, 9];
            SudokuUI ui = new SudokuUI(new ConsoleWriter());
            ui.ShowSpaces(null, 0);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void TestLessZeroShowSpaces()
        {
            SudokuUI ui = new SudokuUI(new ConsoleWriter());
            ui.ShowSpaces(spaces, -1);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void TestOverAcceptedValueShowSpaces()
        {
            SudokuUI ui = new SudokuUI(new ConsoleWriter());
            ui.ShowSpaces(spaces, 900000000);
        }
    }
}
