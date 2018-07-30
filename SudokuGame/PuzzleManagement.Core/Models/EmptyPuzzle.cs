/*  * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * *
*
*                    SUDOKU GAME AND SOLVER
*                                                                       
* * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * *
* * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * *
*   
*              Name: EmptyPuzzle.cs
*     Creation Date: 6/20/2018
*            Author: M. Moody
*  
*       Description: This file defines an empty puzzle object. 
* 
*	Code Review:	
*  
* * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * */

using System.Diagnostics.Contracts;

namespace PuzzleManagement.Core.Models
{
    /// <summary>
    /// Concrete implementation of puzzle object.
    /// </summary>
    public class EmptyPuzzle : Puzzle
    {
        public EmptyPuzzle() : base()
        {
            Difficulty = Enums.Difficulty.Empty;
            Generator = Generator.Create(this.Difficulty);
        }

        /// <summary>
        /// This method overrides the CreatePuzzle and initializes the PuzzleArray.
        /// </summary>
        public override void CreatePuzzle()
        {
            Contract.Requires(Generator != null);
            PuzzleArray = Generator.Generate();
        }

    }
}
