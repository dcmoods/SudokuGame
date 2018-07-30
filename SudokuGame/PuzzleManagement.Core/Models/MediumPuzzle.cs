/*  * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * *
*
*                    SUDOKU GAME AND SOLVER
*                                                                       
* * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * *
* * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * *
*   
*              Name: MediumPuzzle.cs
*     Creation Date: 6/20/2018
*            Author: M. Moody
*  
*       Description: This file defines a medium difficulty puzzle object. 
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
    public class MediumPuzzle : Puzzle
    {
        public MediumPuzzle() : base()
        {
            Difficulty = Enums.Difficulty.Medium;
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
