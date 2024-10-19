using Microsoft.VisualStudio.TestTools.UnitTesting;
using SudokuSolver;
using System;

namespace TestConsoleWriter
{
    [TestClass]
    public class ConsoleOutputTest
    {
        private ConsoleWriter writer;
        public ConsoleOutputTest()
        {
            this.writer = new ConsoleWriter();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TestOutPutIsEmptyWrite()
        {
            writer.Write("", ConsoleColor.White);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TestOutPutIsNullWrite()
        {
            writer.Write(null, ConsoleColor.White);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TestOutPutIsEmptyWriteLine()
        {
            writer.Write("", ConsoleColor.White);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TestOutPutIsNullWriteLine()
        {
            writer.Write(null, ConsoleColor.White);
        }
    }
}
