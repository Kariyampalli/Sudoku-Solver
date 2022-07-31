using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SudokuSolver
{
    public class ClusterCreator
    {
        ConsoleWriter consoleWriter;

        //This class creates the clusters needed for the Sudoku
        public ClusterCreator(ConsoleWriter writer)
        {
            consoleWriter = writer;
        }
        /// <summary>
        /// CreateCluster-method creates the clusters for the Sudoku.
        /// </summary>
        /// <param name="spaces">
        /// References the array containing all spaces in the Sudoku-class.
        /// </param>
        /// <returns>
        /// Returns a List of the cluster objects created for the game.
        /// </returns>
        public List<Cluster> CreateClusters(ISpace[,] spaces, out bool validInput)
        {
            validInput = true;
            if (spaces == null || spaces.Length != 81)
            {
                consoleWriter.WriteLine($"There wasn't enough spaces for the creation of the clusters for some reason (Spaces might have been smaler than 81 or even null)!", ConsoleColor.DarkRed);
                validInput = false;
                return null;
            }
            List<Cluster> tempClusters = new List<Cluster>();
            int tempY = 0;
            int y = tempY;
            int x = 0;
            for (int i = 1; i <= 9; i++)
            {
                ISpace[,] tempISpaces = new ISpace[3, 3];
                for (int a = 0; a < 3; a++)
                {
                    tempISpaces[a, 0] = spaces[y, x];
                    spaces[y, x].ClusterId = i;
                    x++;
                    tempISpaces[a, 1] = spaces[y, x];
                    spaces[y, x].ClusterId = i;
                    x++;
                    tempISpaces[a, 2] = spaces[y, x];
                    spaces[y, x].ClusterId = i;
                    x = x - 2;
                    y++;
                }

                if (i % 3 == 0)
                {
                    tempY = y;
                    x = 0;
                }
                else
                {
                    y = tempY;
                    x = x + 3;
                }

                tempClusters.Add(new Cluster(i, tempISpaces));
            }

            return tempClusters;
        }
    }
}
