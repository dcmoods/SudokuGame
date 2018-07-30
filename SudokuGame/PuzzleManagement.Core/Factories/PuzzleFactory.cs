/*  * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * *
*
*                    SUDOKU GAME AND SOLVER
*                                                                       
* * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * *
* * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * *
*   
*              Name: PuzzleFactory.cs
*     Creation Date: 6/20/2018
*            Author: M. Moody
*  
*       Description: This file defines a puzzle factory 
*       and is responsible for returning a new puzzle. 
* 
*	Code Review:	
*  
* * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * */

using PuzzleManagement.Core.Enums;
using PuzzleManagement.Core.Models;

namespace PuzzleManagement.Core.Factories
{
    public class PuzzleFactory
    {
        /// <summary>
        /// This method is a factory method to puzzle types.
        /// </summary>
        /// <param name="difficulty">Difficulty of puzzle to return</param>
        /// <returns>Concrete puzzle object of selected difficulty</returns>
        public static Puzzle GetPuzzle(Difficulty difficulty)
        {
            switch (difficulty)
            {
                case Difficulty.Easy:
                    return new EasyPuzzle();
                case Difficulty.Medium:
                    return new MediumPuzzle();
                case Difficulty.Hard:
                    return new HardPuzzle();
                default:
                    return new EmptyPuzzle();
            }
        }
    }
}
