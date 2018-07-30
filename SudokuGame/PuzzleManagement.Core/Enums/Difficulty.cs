/*  * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * *
*
*                    SUDOKU GAME AND SOLVER
*                                                                       
* * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * *
* * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * *
*   
*              Name: Difficulty.cs
*     Creation Date: 6/20/2018
*            Author: M. Moody
*  
*       Description: This file defines an enum for difficulty types. 
* 
*	Code Review:	
*  
* * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * */

namespace PuzzleManagement.Core.Enums
{
    /// <summary>
    /// This Enum is used to determine the difficulty of puzzle objects.
    /// The numbers represent the amount of empty cells a puzzle will have.
    /// </summary>
    public enum Difficulty
    {
        Empty = 81,
        Easy = 45,
        Medium = 48,
        Hard = 52
    }
}
