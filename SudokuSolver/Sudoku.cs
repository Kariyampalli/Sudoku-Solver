//-----------------------------------------------------------------------------------------------------
// <copyright file="Sudoku.cs" company="Fh Wr.Neustadt">
//     Copyright by Christy Kariyampalli. All rights reserved
// </copyright>
// <summary>The main class to start the Sudoku game.</summary>
// <author>Christy Kariyampalli</author>
//-----------------------------------------------------------------------------------------------------
namespace SudokuSolver
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    /// The sudoku class is needed to start the Sudoku game.
    /// </summary>
    public class Sudoku
    {
        /// <summary>
        /// Y-position for the space.
        /// </summary>
        private Direction direction = Direction.Forward;

        /// <summary>
        /// Solved boolean to indicate if Sudoku has been solved.
        /// </summary>
        private bool solved;

        /// <summary>
        /// Unsolvable boolean to indicate if Sudoku can't be solved.
        /// </summary>
        private bool unsolvable;

        /// <summary>
        /// All the spaces listed in an array of ISpace.
        /// </summary>
        private ISpace[,] spaces;

        /// <summary>
        /// Check object for validating inputs, values and so on.
        /// </summary>
        private Check check;

        /// <summary>
        /// SudokuUI object to put the Sudoku on the console.
        /// </summary>
        private SudokuUI sudokuUI;

        /// <summary>
        /// Game speed value to indicate how fast the Sudoku should be updated at a value change.
        /// </summary>
        private int gameSpeed;

        /// <summary>
        /// List of all the available clusters within the game.
        /// </summary>
        private List<Cluster> clusters;

        private ClusterCreator clustersCreator;
        private PositionMover mover;
        private ConsoleWriter consoleWriter;

        /// <summary>
        /// Initializes a new instance of the <see cref="Sudoku"/> class.
        /// </summary>
        /// <param name="basisSpaces">
        /// The spaces of the Sudoku.
        /// </param>
        /// <param name="receivedclusters">
        /// The clusters of the Sudoku.
        /// </param>
        /// <param name="speed">
        /// The speed the Sudoku has to be shown between each update.
        /// </param>
        public Sudoku(ConsoleWriter writer, PositionMover positionMover, ClusterCreator creator)
        {
            this.clustersCreator = creator;
            this.mover = positionMover;
            this.consoleWriter = writer;
            this.unsolvable = false;
            this.solved = false;
            this.check = new Check(writer);
            this.sudokuUI = new SudokuUI(writer);
        }

        /// <summary>
        /// The Run-method is used to run the StartGame-method to start the game.
        /// </summary>
        public void Run()
        {
            try
            {
                bool again = true;
                while (again)
                {
                    solved = false;
                    unsolvable = false;
                    bool validInput = false;
                    while (!validInput)
                    {
                        Console.Clear();
                        consoleWriter.WriteLine("Please put in the Sudoku", ConsoleColor.White);
                        string input = Console.ReadLine();

                        check.CheckSudokuInput(input, out spaces, out validInput);
                        if (validInput)
                        {
                            Console.Clear();
                            consoleWriter.WriteLine("Please chose the solving speed between 0 (fastest) and 5 (slowest)", ConsoleColor.White);
                            string speedInput = Console.ReadLine();
                            check.CheckSpeedInput(speedInput, out gameSpeed, out validInput);
                        }
                        if (!validInput)
                        {
                            Console.Clear();
                            consoleWriter.Write("-----Example----\n\n\n(9x9) Sudoku input:\n\n5, 3, 0, 0, 7, 0, 0, 0, 0, 6," +
                                 " 0, 0, 1, 9, 5, 0, 0, 0, 0, 9, 8, 0, 0, 0, 0, 6, 0, 8, 0, 0, 0, 6, 0, 0, 0, 3," +
                                 " 4, 0, 0, 8, 0, 3, 0, 0, 1, 7, 0, 0, 0, 2, 0, 0, 0, 6 , 0, 6, 0, 0, 0, 0, 2, 8," +
                                 " 0, 0, 0, 0, 4, 1, 9, 0, 0, 5, 0, 0, 0, 0, 8, 0, 0, 7, 9\n\n\n(Press Enter to skip)", ConsoleColor.White);
                            Console.ReadLine();
                            Console.Clear();
                            continue;
                        }
                        this.clusters = clustersCreator.CreateClusters(this.spaces, out validInput);
                        this.gameSpeed = this.gameSpeed * 50;
                    }

                    this.StartGame();

                    bool askAgain = true;
                    while (askAgain)
                    {
                        consoleWriter.WriteLine("Do you want me to solve another one? (n/y)", ConsoleColor.White);
                        string answer = Console.ReadLine();

                        again = check.CheckRestartInput(answer, out askAgain);
                    }
                }
            }
            catch (InvalidOperationException ioe)
            {
                consoleWriter.WriteLine(ioe.Message, ConsoleColor.DarkRed);
            }
            catch (ArgumentNullException anex)
            {
                consoleWriter.WriteLine(anex.Message, ConsoleColor.DarkRed);
            }
            catch (Exception ex)
            {
                consoleWriter.WriteLine($"An unexpected error has accured: {ex.Message}", ConsoleColor.DarkRed);
            }

        }

        /// <summary>
        /// The StartGame-method starts the Sudoku game and runs until the
        /// Sudoku game ends because its the "main" method which tries to 
        /// find the next step/move to make in the game.
        /// </summary>
        private void StartGame()
        {
            int xPosition = 0;
            int yPosition = 0;
            while (!this.solved && !this.unsolvable)
            {
                switch (this.spaces[yPosition, xPosition].KindType)
                {
                    case Kind.Reserved:
                        switch (this.direction)
                        {
                            case Direction.Forward:
                                mover.MoveForward(ref yPosition, ref xPosition, ref solved, ref direction);
                                break;
                            case Direction.Backward:
                                mover.MoveBackwards(ref yPosition, ref xPosition, ref unsolvable, ref direction);
                                break;
                        }

                        break;
                    case Kind.Usable:
                        if (this.check.FindPerfectValue(ref this.spaces, ref this.clusters, ref this.spaces[yPosition, xPosition]))
                        {
                            mover.MoveForward(ref yPosition, ref xPosition, ref solved, ref direction);
                        }
                        else
                        {
                            mover.MoveBackwards(ref yPosition, ref xPosition, ref solved, ref direction);
                        }

                        if (this.gameSpeed != 0)
                        {
                            Console.Clear();
                            this.sudokuUI.ShowSpaces(this.spaces, this.gameSpeed);
                        }

                        break;
                }
            }

            if (this.gameSpeed == 0)
            {
                Console.Clear();
                this.sudokuUI.ShowSpaces(this.spaces, this.gameSpeed);
            }

            if (this.unsolvable)
            {
                consoleWriter.WriteLine("\nSudoku can't be solved!", ConsoleColor.DarkYellow);
            }
            else if (this.solved)
            {
                consoleWriter.WriteLine("\nSudoku solved!", ConsoleColor.DarkGreen);
            }
            else
            {
                consoleWriter.WriteLine("\nSudoku can't be solved wheter be solved?!", ConsoleColor.DarkRed);
            }
        }
    }
}
