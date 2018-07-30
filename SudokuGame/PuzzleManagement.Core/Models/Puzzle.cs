/*  * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * *
*
*                    SUDOKU GAME AND SOLVER
*                                                                       
* * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * *
* * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * *
*   
*              Name: Puzzle.cs
*     Creation Date: 6/20/2018
*            Author: M. Moody
*  
*       Description: This file defines a base puzzle object. 
* 
*	Code Review:	
*  
* * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * */

using PuzzleManagement.Core.Enums;
using PuzzleManagement.Core.Interfaces;
using System;
using System.Diagnostics.Contracts;

namespace PuzzleManagement.Core.Models
{
    public abstract class Puzzle : IStateObject
    {
        public Puzzle()
        {
            Solver = Solver.Create();
            StartTime = DateTime.Now;
        }

        public int Id { get; set; }
        protected Solver Solver { get; set; }
        protected Generator Generator { get; set; }
        public Difficulty Difficulty { get; set; }
        public int[,] PuzzleArray { get; set; }
        public int[,] SolvedPuzzleArray { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public ObjectState State { get; set; }

        /// <summary>
        /// This method is meant for inheriting objects to initialize puzzles.
        /// </summary>
        public abstract void CreatePuzzle();


        /// <summary>
        /// This method solves the puzzle and stores the result in the solved puzzle object.
        /// </summary>
        /// <returns>if solving was a success.</returns>
        public bool Solve()
        {
            Contract.Requires(PuzzleArray != null);

            SolvedPuzzleArray = (int[,])PuzzleArray.Clone();
            var result = Solver.Solve(SolvedPuzzleArray);
            SolvedPuzzleArray = Solver.SolvedPuzzle;
            return result;
        }

        /// <summary>
        /// This method checks if the Puzzle is solved correctly
        /// </summary>
        /// <returns>if the puzzle is solved correctly.</returns>
        public bool Check()
        {
            if (SolvedPuzzleArray == null)
            {
                Solve();
            }
            return PuzzlesAreEqual();
        }

        /// <summary>
        /// This method checks if the solved puzzle and initial puzzle are equal.
        /// </summary>
        /// <returns>if the PuzzleArray and SolvedPuzzleArray are equal.</returns>
        private bool PuzzlesAreEqual()
        {
            for (int row = 0; row < 9; row++)
            {
                for (int col = 0; col < 9; col++)
                {
                    if (SolvedPuzzleArray[row,col] != PuzzleArray[row,col])
                        return false;
                }
            }
            return true;
        }
    }
}
