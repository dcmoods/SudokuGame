/*  * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * *
*
*                    SUDOKU GAME AND SOLVER
*                                                                       
* * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * *
* * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * *
*   
*              Name: HardPuzzle.cs
*     Creation Date: 6/20/2018
*            Author: M. Moody
*  
*       Description: This file defines a hard difficulty puzzle object. 
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
    public class HardPuzzle : Puzzle
    {
        public HardPuzzle() : base()
        {
            Difficulty = Enums.Difficulty.Hard;
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
