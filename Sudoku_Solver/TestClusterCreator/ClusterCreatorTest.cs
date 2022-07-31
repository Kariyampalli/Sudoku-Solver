using Microsoft.VisualStudio.TestTools.UnitTesting;
using SudokuSolver;
using System;

namespace TestClusterCreator
{
    [TestClass]
    public class ClusterCreatorTest
    {
        [TestMethod]
        public void TestCreateClusters()
        {
            ClusterCreator creator = new ClusterCreator(new ConsoleWriter());
            bool validInput;
            // ISpace [] spaces = new ISpace[2, 2];
            creator.CreateClusters(new ISpace[2, 2], out validInput);
            Assert.IsTrue(!validInput);
        }

        [TestMethod]
        public void TestNullCreateCluster()
        {
            ClusterCreator creator = new ClusterCreator(new ConsoleWriter());
            bool validInput;
            // ISpace [] spaces = new ISpace[2, 2];
            creator.CreateClusters(null, out validInput);
            Assert.IsTrue(!validInput);
        }
    }
}
