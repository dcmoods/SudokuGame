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

namespace PuzzleManagement.Core.Models
{
    public class MediumPuzzle : Puzzle
    {
        public MediumPuzzle() : base()
        {
            Difficulty = Enums.Difficulty.Medium;
            Generator = Generator.Create(this.Difficulty);
        }

        public override void CreatePuzzle()
        {
            PuzzleArray = Generator.Generate();
        }
    }
}
