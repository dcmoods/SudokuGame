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

namespace PuzzleManagement.Core.Models
{
    public class EmptyPuzzle : Puzzle
    {
        public EmptyPuzzle() : base()
        {
            Difficulty = Enums.Difficulty.Empty;
            Generator = Generator.Create(this.Difficulty);
        }

        public override void CreatePuzzle()
        {            
            PuzzleArray = Generator.Generate();
        }

    }
}
