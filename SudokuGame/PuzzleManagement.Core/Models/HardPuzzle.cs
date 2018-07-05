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

namespace PuzzleManagement.Core.Models
{
    public class HardPuzzle : Puzzle
    {
        public HardPuzzle() : base()
        {
            Difficulty = Enums.Difficulty.Hard;
            Generator = Generator.Create(this.Difficulty);
        }

        public override void CreatePuzzle()
        {
            PuzzleArray = Generator.Generate();
        }
    }
}
