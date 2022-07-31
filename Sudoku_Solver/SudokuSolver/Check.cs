//-----------------------------------------------------------------------------------------------------
// <copyright file="Check.cs" company="Fh Wr.Neustadt">
//     Copyright by Christy Kariyampalli. All rights reserved
// </copyright>
// <summary>A class to validate input, gameplay mechanics and so on.</summary>
// <author>Christy Kariyampalli</author>
//-----------------------------------------------------------------------------------------------------
namespace SudokuSolver
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    /// The check class verifies the inputs of the user, validates values of the EmptySpace 
    /// objects by checking through the default Sudoku game rules.
    /// It helps as well at generating the clusters for the Sudoku. 
    /// </summary>
    public class Check
    {
        //For writing something on the console
        private ConsoleWriter consoleWriter;

        /// <summary>
        /// Initializes a new instance of the <see cref="Check"/> class.
        /// </summary>
        public Check(ConsoleWriter writer)
        {
            this.consoleWriter = writer;
        }

        /// <summary>
        /// The CheckSpeedInput-method checks the speed input.
        /// </summary>
        /// <param name="input">
        /// Speed input from the user.
        /// </param>
        /// <param name="speed">
        /// Gives back a speed value with "out" to the main method of program.cs.
        /// </param>
        /// <param name="validInput">
        /// Gives back if input was valid or not.
        /// </param>
        /// <returns>
        /// Return a bool value indicating if validation was successful.
        /// </returns>
        public bool CheckSpeedInput(string input, out int speed, out bool validInput)
        {
            speed = 0;
            validInput = false;
            try
            {
                speed = Convert.ToInt32(input);
                if (speed >= 0 && speed <= 5)
                {
                    validInput = true;
                    return true;
                }
                else
                {
                    throw new FormatException();
                }
            }
            catch (FormatException)
            {
                consoleWriter.Write("Speed didn't match the following criterias: value between 0 - 5", ConsoleColor.DarkRed);
                Thread.Sleep(3000);
                //Console.Clear();
                return true;
            }
            catch (OverflowException)
            {
                consoleWriter.Write("Speed value is too big!", ConsoleColor.DarkRed);
                Thread.Sleep(3000);
                return true;
            }
            catch (Exception ex)
            {
                consoleWriter.Write("Speed didn't match the following criterias: value between 0 - 5" + ex.Message, ConsoleColor.DarkRed);
                Thread.Sleep(3000);
                //Console.Clear();
                return true;
            }
        }

        /// <summary>
        /// CheckSudokuInput-method to validate Sudoku input.
        /// </summary>
        /// <param name="spaces">
        /// The created spaces that should be "returned" with "out" (array).
        /// </param>
        /// <param name="input">
        /// Sudoku input from the user.
        /// </param>
        /// <param name="validInput">
        /// Gives back if input was valid or not.
        /// </param>
        /// <returns>
        /// Return a bool value indicating if validation was successfuls.
        /// </returns>
        public bool CheckSudokuInput(string input, out ISpace[,] spaces, out bool validInput)
        {
            validInput = false;
            ISpace[,] tempISpaces = new ISpace[9, 9];

            spaces = tempISpaces;
            try
            {
                if (string.IsNullOrEmpty(input) || string.IsNullOrWhiteSpace(input))
                {
                    throw new FormatException("Sudoku input was empty or null during the cheking!");
                }
                string[] values = input.Replace(" ", string.Empty).Split(',');
                if (values.Length != 81)
                {
                    throw new FormatException("Amount of numbers don't meet the 9x9 criteria!");
                }

                int yCounter = 0;
                int xCounter = 0;

                for (int i = 0; i < 81; i++)
                {
                    int inputValue = Convert.ToInt32(values[i]);
                    if (inputValue < 0 || inputValue > 9)
                    {
                        throw new FormatException("A value was found to be lower than 0 or higher than 9!");
                    }

                    switch (inputValue)
                    {
                        case 0:
                            spaces[yCounter, xCounter] = new EmptySpace(inputValue, yCounter, xCounter);
                            break;
                        default:
                            spaces[yCounter, xCounter] = new ReservedSpace(inputValue, yCounter, xCounter);
                            break;
                    }

                    xCounter++;
                    if ((i + 1) % 9 == 0)
                    {
                        yCounter++;
                        xCounter = 0;
                    }
                }
            }
            catch (FormatException ex)
            {
                consoleWriter.Write($"Error at loading the input. Make sure the values for the 9x9 Sudoku are numbers and seperated by a comma!\nExcetion:{ex.Message}", ConsoleColor.DarkRed);
                Thread.Sleep(3000);
                return true;
            }
            catch (Exception ex)
            {
                consoleWriter.Write($"Error at loading the input. Make sure the Sudoku input isn't too big and in the right format!\nExcetion:{ex.Message}", ConsoleColor.DarkRed);
                Thread.Sleep(3000);
            }

            validInput = true;
            return true;
        }

        /// <summary>
        /// Finds the perfect/a valid value for the current space the method is called for.
        /// </summary>
        /// <param name="spaces">
        /// References the array containing all spaces in the Sudoku-class.
        /// </param>
        /// <param name="clusters">
        /// References the list containing all clusters in the Sudoku-class.
        /// </param>
        /// <param name="space">
        /// The current space the method got called for.
        /// </param>
        /// <returns>
        /// Returns a bool value indicating if a valid value could be
        /// found for the space the method has been called up for.
        /// </returns>
        public bool FindPerfectValue(ref ISpace[,] spaces, ref List<Cluster> clusters, ref ISpace space)
        {
            if (space.Value == 9)
            {
                space.Value = 0;
                return false;
            }

            space.Value++;

            while (!this.NextAboveUnder(ref spaces, ref space) || !this.CheckCluster(ref clusters, ref space))
            {
                if (space.Value == 9)
                {
                    space.Value = 0;
                    return false;
                }

                space.Value++;
            }

            return true;
        }

        /// <summary>
        /// CheckCluster-method checks if the value of a space doesn't already exist withing the space's cluster 
        /// (space has to differ from the space the validation is being done for).
        /// </summary>
        /// <param name="clusters">
        /// References the list containing all clusters in the Sudoku-class.
        /// </param>
        /// <param name="space">
        /// References the space the validation is being done for.
        /// </param>
        /// <returns>
        /// Returns a boolean indicating if the "cluster-checking" was successful.
        /// </returns>
        private bool CheckCluster(ref List<Cluster> clusters, ref ISpace space)
        {
            foreach (var selectedISpace in clusters[space.ClusterId - 1].Spaces)
            {
                if (selectedISpace.Value == space.Value && selectedISpace.XPosition != space.XPosition && selectedISpace.YPosition != space.YPosition)
                {
                    return false;
                }
            }

            return true;
        }


        /// <summary>
        /// The NextAboveUnder-method checks if the value for the space the method has been called 
        /// up for differs from all the other value on the space's x-axis and y-axis.
        /// </summary>
        /// <param name="spaces">
        /// References the array containing all spaces in the Sudoku-class.
        /// </param>
        /// <param name="space">
        /// References the space the validation is being done for.
        /// </param>
        /// <returns>
        /// Returns a boolean indicating if the value is valid.
        /// </returns>
        private bool NextAboveUnder(ref ISpace[,] spaces, ref ISpace space)
        {
            for (int i = 1; i <= 8 - space.XPosition; i++)
            {
                if (spaces[space.YPosition, space.XPosition + i].Value == space.Value)
                {
                    return false;
                }
            }

            for (int i = 1; i <= space.XPosition; i++)
            {
                if (spaces[space.YPosition, space.XPosition - i].Value == space.Value)
                {
                    return false;
                }
            }

            for (int i = 1; i <= 8 - space.YPosition; i++)
            {
                if (spaces[space.YPosition + i, space.XPosition].Value == space.Value)
                {
                    return false;
                }
            }

            for (int i = 1; i <= space.YPosition; i++)
            {
                if (spaces[space.YPosition - i, space.XPosition].Value == space.Value)
                {
                    return false;
                }
            }

            return true;
        }

        //Checks if the restart input is correct
        public bool CheckRestartInput(string input, out bool askAgain)
        {
            askAgain = false;
            if (input.Trim() == "y")
            {
                return true;
            }
            if (input.Trim() == "n")
            {
                return false;
            }
            consoleWriter.WriteLine("Restart input was wrong!", ConsoleColor.DarkRed);
            askAgain = true;
            return false;
        }
    }
}
