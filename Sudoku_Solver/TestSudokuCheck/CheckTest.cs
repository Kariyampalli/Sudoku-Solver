using Microsoft.VisualStudio.TestTools.UnitTesting;
using SudokuSolver;
using System;
using System.Collections.Generic;
using System.IO;

namespace TestSudokuCheck
{
    [TestClass]
    public class CheckTest
    {
        private readonly ConsoleWriter writer;
        private readonly Check checker;
        public CheckTest()
        {
            this.writer = new ConsoleWriter();
            this.checker = new Check(writer);
        }

        [TestMethod]
        public void TestNullSudokuInput()
        {
            ISpace[,] spaces;
            bool validInput;
            var checkerValid = checker.CheckSudokuInput(null, out spaces, out validInput);

            Assert.IsTrue(checkerValid && !validInput);
        }

        [TestMethod]
        public void TestInvalidCharactersSudokuInput()
        {
            ISpace[,] spaces;
            bool validInput;
            var checkerValid = checker.CheckSudokuInput("5, 3, 0, 0, 7, 0, 0, 0, 0, 6, 0, 0, 1, 9, 5, 0, 0, 0, 0, 9," +
                " 8, 0, 0, 0, 0, 6, 0, 8, 0, 0, 0, 6, 0, 0, 0, 3, 4, 8, 0, 0, /, 0, 6, 0, ?, 0, 0, 0, 6, , 0, 0, 3, 4, 8, 0, 0, 0, 0, 6," +
                " 0, 8, 0, 0, 0, 6, 0, 0, 0, 3, 4, 8, 0, 0, 0, 0, 6, 0, 8, 0, 0, 0, 6, 0, 0, 0, 3, 4, 8, 0, 0, 0, 4, 6, 0, 8, 0, 0, 0, 6, 0, 0, 0, 3, 4", out spaces, out validInput);

            Assert.IsTrue(checkerValid && !validInput);
        }

        [TestMethod]
        public void TestTooShortSudokuInput()
        {
            ISpace[,] spaces;
            bool validInput;
            var checkerValid = checker.CheckSudokuInput("5, 3, 0, 0, 7, 0, 0, 0, 0, 6, 0, 0, 1, 9, 5, 0, 0, 0, 0, 9," +
                " 8, 0, 0, 0, 0, 6, 0, 8, 0, 0, 0, 6, 0, 0, 0, 3, 4,", out spaces, out validInput);

            Assert.IsTrue(checkerValid && !validInput);
        }

        [TestMethod]
        public void TestTooLargeSudokuInput()
        {
            ISpace[,] spaces;
            bool validInput;
            var checkerValid = checker.CheckSudokuInput("5, 3, 0, 0, 7, 0, 0, 0, 0, 6, 0, 0, 1, 9, 5, 0, 0, 0, " +
                "0, 9, 8, 0, 0, 0, 0, 6, 0, 8, 0, 0, 0, 6, 0, 0, 0, 3, 4, 0, 0, 8, 0, 3, 0, 0, 1, 7, 0, 0, 0, 2, " +
                "0, 0, 0, 6, 0, 6, 0, 0, 0, 0, 2, 8, 0, 0, 0, 0, 4, 1, 9, 0, 0, 5, 0, 0, 0, 0, 8, 0, 0, 7, 9 , 0, 0, 0," +
                " 0, 6, 0, 8, 0, 0, 0, 6, 0, 0, 0, 3, 4, 8, 0, 0, 0, 0, 6, 0, 8, 0, 0, 0, 6, 0, 0, 0, 3, 4, 0, 0, 0, 0, 6, 0, 8, 0," +
                " 0, 0, 6, 0, 0, 0, 3, 4, 8, 0, 0, 0, 0, 6, 0, 8, 0, 0, 0, 6, 0, 0, 0, 3, 4, 0, 0, 0, 0, 6, 0, 8, 0, 0, 0, 6, 0, 0, 0, 3, 4, 8, 0, 0," +
                " 0, 0, 6, 0, 8, 0, 0, 0, 6, 0, 0, 0, 3, 4", out spaces, out validInput);

            Assert.IsTrue(checkerValid && !validInput);
        }

        [TestMethod]
        public void TestEmptySudokuInput()
        {
            ISpace[,] spaces;
            bool validInput;
            var checkerValid = checker.CheckSudokuInput("", out spaces, out validInput);

            Assert.IsTrue(checkerValid && !validInput);
        }

        [TestMethod]
        public void TestRandomSudokuInpupt()
        {
            ISpace[,] spaces;
            bool validInput;
            var checkerValid = checker.CheckSudokuInput("235fh328", out spaces, out validInput);

            Assert.IsTrue(checkerValid && !validInput);
        }
        [TestMethod]
        public void TestRandomSpeedInputTest()
        {
            int speed;
            bool validInput;
            var checkerValid = checker.CheckSpeedInput("asf1", out speed, out validInput);
            Assert.IsTrue(checkerValid && !validInput);
        }

        [TestMethod]
        public void TestOverflowSpeedInputTest()
        {
            int speed;
            bool validInput;
            var checkerValid = checker.CheckSpeedInput("125213577193561793561935719351739", out speed, out validInput);
            Assert.IsTrue(checkerValid && !validInput);
        }

        [TestMethod]
        public void TestRestartInputTest()
        {

            bool askAgain;
            var checkerValid = checker.CheckRestartInput("n", out askAgain);
            Assert.IsTrue(!checkerValid && !askAgain);
        }

        [TestMethod]
        public void TestRandomRestartInputTest()
        {

            bool askAgain;
            var checkerValid = checker.CheckRestartInput("123", out askAgain);
            Assert.IsTrue(!checkerValid && askAgain);
        }
    }
}
//5, 3, 0, 0, 7, 0, 0, 0, 0, 6, 0, 0, 1, 9, 5, 0, 0, 0, 0, 9, 8, 0, 0, 0, 0, 6, 0, 8, 0, 0, 0, 6, 0, 0, 0, 3, 4, 0, 0, 8, 0, 3, 0, 0, 1, 7, 0, 0, 0, 2, 0, 0, 0, 6, 0, 6, 0, 0, 0, 0, 2, 8, 0, 0, 0, 0, 4, 1, 9, 0, 0, 5, 0, 0, 0, 0, 8, 0, 0, 7, 9
//5, 3, 0, 0, 7, 0, 0, 0, 0, 6, 0, 0, 1, 9, 5, 0, 0, 0, 0, 9, 8, 0, 0, 0, 0, 6, 0, 8, 0, 0, 0, 6, 0, 0, 0, 3, 4, 0, 0, 8, 0, 3, 0, 0, 1, 7, 0, 0, 0, 2, 0, 0, 0, 6, 0, 6, 0, 0, 0, 1, 2, 8, 1, 1, 1, 1, 4, 1, 9, 1, 1, 5, 1, 1, 1,1, 8, 1, 1, 7, 9
