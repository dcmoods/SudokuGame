/*  * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * *
*
*                    SUDOKU GAME AND SOLVER
*                                                                       
* * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * *
* * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * *
*   
*              Name: EasyPuzzle.cs
*     Creation Date: 6/20/2018
*            Author: M. Moody
*  
*       Description: This file defines an easy puzzle object. 
* 
*	Code Review:	
*  
* * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * */

namespace PuzzleManagement.Core.Models
{
    public class EasyPuzzle : Puzzle
    {
        public EasyPuzzle() : base()
        {
            Difficulty = Enums.Difficulty.Easy;
            Generator = Generator.Create(this.Difficulty);
        }

        public override void CreatePuzzle()
        {
            PuzzleArray = Generator.Generate();
        }
    }
}
